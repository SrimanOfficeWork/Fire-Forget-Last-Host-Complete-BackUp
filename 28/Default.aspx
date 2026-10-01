<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LoginPage_Premium_E_royal_Impex_Login_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRoyal Impex - Login | Import &amp; Export | CHA | Customs Clearence | e-Royal Tech Systems Pvt Ltd.</title>
    <link rel="shortcut icon" type="image/png" href="../images/eroyal_title_logo.png" />
    <link rel="icon" type="image/png" href="../images/eroyal_title_logo.png" />
    <script src="../js/Validation.js" type="text/javascript"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%-- Without this, mobile browsers assume a ~980px desktop layout and zoom the
         whole page out to fit the screen - none of the @media breakpoints in
         premium-login-theme.css would ever actually trigger on a real phone. --%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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
    <script src="../MessageBox_js/jquery.alerts.js?v=2" type="text/javascript"></script>
    <%-- Premium re-skin: loaded after main.css so it overrides the old sprite-based
         #log-* look. Markup/IDs/logic below are the untouched originals from
         ../Default.aspx - only the visual layer changes. --%>
    <link href="premium-theme.css" rel="stylesheet" type="text/css" />
    <link href="premium-login-theme.css?v=7" rel="stylesheet" type="text/css" />
</head>
<body topmargin="0" id="bg1" class="premium-body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div id="pm-login-shell">
                <div id="pm-login-visual">
                    <div id="pm-login-visual-orbs" aria-hidden="true">
                        <span></span><span></span><span></span>
                    </div>
                    <div id="pm-login-visual-grain" aria-hidden="true"></div>
                    <div id="pm-login-visual-overlay">
                        <div id="pm-login-visual-header">
                            <div id="pm-login-visual-brand">
                                <span id="pm-login-visual-brandmark">eR</span>
                                <span id="pm-login-visual-brandname">eRoyal Suite</span>
                            </div>
                            <div id="pm-login-visual-tagline">One platform for every trade &amp; logistics operation</div>
                        </div>
                        <div id="pm-login-products" role="list">
                            <a class="pm-product-card" style="--pm-i: 0" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal_Freight.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card" style="--pm-i: 1" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal_Billing.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card" style="--pm-i: 2" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal_Accounts.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card pm-product-card--tall" style="--pm-i: 3" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal%20Smart%20IRN.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card pm-product-card--tall" style="--pm-i: 4" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eroyal%20ExtractAI.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card" style="--pm-i: 5" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal_CSN.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card" style="--pm-i: 6" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal_SCM.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                            <a class="pm-product-card" style="--pm-i: 7" role="listitem" href="https://wa.me/918939217565?text=Hi%20eRoyal%20Team%2C%20I%27m%20interested%20in%20knowing%20more%20about%20your%20solutions.%20Please%20contact%20me%20with%20more%20details%20and%20arrange%20a%20demo" target="_blank" rel="noopener noreferrer">
                                <span class="pm-product-img" style="background-image: url('../images/Product%20Images/eRoyal_ICON.png')"></span>
                                <span class="pm-product-shine"></span>
                            </a>
                        </div>
                    </div>
                </div>
                <div id="pm-login-formside">
            <div id="log-pageout">
                <div id="log-bg-l">
                </div>
                <div id="log-bg-m">
                    <div id="log-top1">
                        <div id="log-mainlogo">
                        </div>
                        <div id="logpage-capt">
                        </div>
                    </div>
                    <div id="log-top2">
                        <div id="log-top2-left">
                            <div id="log-txtandlabelcontainer">
                                <div id="log-label">
                                    Company License
                                </div>
                                <div id="log-txt-container">
                                    <div id="log-txtcon-l">
                                    </div>
                                    <div id="log-txtcon-m">
                                        <asp:TextBox ID="txtCompany_License" runat="server" CssClass="txt-s" MaxLength="10"
                                            TabIndex="1" AutoPostBack="true" OnTextChanged="txtCompany_License_TextChanged"
                                            onkeypress="return pin1(event);" oninput="sanitizeCompanyLicense(this);"></asp:TextBox>
                                    </div>
                                    <div id="log-txtcon-r">
                                    </div>
                                </div>
                            </div>
                            <div id="log-txtandlabelcontainer">
                                <div id="log-label">
                                    Login ID</div>
                                <div id="log-txt-container">
                                    <div id="log-txtcon-l">
                                    </div>
                                    <div id="log-txtcon-m">
                                        <asp:TextBox ID="txtUserId" runat="server" CssClass="txt-s" MaxLength="30" TabIndex="2" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div id="log-txtcon-r">
                                    </div>
                                </div>
                            </div>
                           <div id="log-txtandlabelcontainer">
                                <div id="log-label">
                                    Password</div>
                                <div id="log-txt-container">
                                    <div id="log-txtcon-l">
                                    </div>
                                    <div id="log-txtcon-m" style="position: relative">
                                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="30" TextMode="Password" TabIndex="3"
                                            CssClass="txt-s" Enabled="false"></asp:TextBox>
                                        <span id="togglePassword" style="position: absolute; right: 10px; top: 50%; transform: translateY(-50%);
                                            cursor: pointer; user-select: none; color: #888; line-height: 0; display: none;">
                                            <!-- Eye Open Icon -->
                                            <svg id="eyeOpen" xmlns="http://www.w3.org/2000/svg" width="20" height="20" style="margin-right: -10px;
                                                margin-top: 6px" viewbox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"
                                                stroke-linecap="round" stroke-linejoin="round">
                                                <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/>
                                                <circle cx="12" cy="12" r="3"/>
                                            </svg>
                                            <!-- Eye Closed Icon -->
                                            <svg id="eyeClosed" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewbox="0 0 24 24"
                                                fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                                                style="display: none; margin-right: -10px; margin-top: 6px;">
                                                <path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8 a18.45 18.45 0 0 1 5.06-5.94"/>
                                                <path d="M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8 a18.5 18.5 0 0 1-2.16 3.19"/>
                                                <line x1="1" y1="1" x2="23" y2="23"/>
                                            </svg>
                                        </span>
                                    </div>
                                    <div id="log-txtcon-r">
                                    </div>
                                </div>
                            </div>
                                    <div id="log-txtandlabelcontainer">
                                        <div id="log-label">
                                            <span class="pm-login-label-split">Group Name</span><span class="pm-login-label-split">Branch Name</span></div>
                                        <div id="log-txt-container">
                                            <div id="log-txtcon-l">
                                            </div>
                                            <div id="log-txtcon-m">
                                                <asp:DropDownList ID="ddlGroupname" runat="server" CssClass="listtxt-s" AutoPostBack="true"
                                                    TabIndex="4" ClientIDMode="Static" Width="100px" OnSelectedIndexChanged="ddlGroupname_SelectedIndexChanged"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="listtxt-s" TabIndex="5"
                                                    ClientIDMode="Static" Width="125px" Enabled="false">
                                                </asp:DropDownList>
                                            </div>
                                            <div id="log-txtcon-r">
                                            </div>
                                        </div>
                                    </div>
                                    <div id="log-txtandlabelcontainer">
                                        <div id="log-label">
                                            Working Period</div>
                                        <div id="log-txt-container">
                                            <div id="log-txtcon-l">
                                            </div>
                                            <div id="log-txtcon-m">
                                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="listtxt-s" TabIndex="5" Enabled="false">
                                                </asp:DropDownList>
                                            </div>
                                            <div id="log-txtcon-r">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="log-top2-rght">
                                    <div id="log-errmsg">
                                        <asp:Label ID="expiremsg" runat="server"></asp:Label>
                                        <a id="anchorID" style="text-align: center" runat="server"></a>
                                    </div>
                                    <br />
                                    <div id="log-butt-container">
                                        <div id="log-butt-left">
                                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" class="loginButt"
                                                OnClientClick="return validate_Login();" TabIndex="6" Text="Login" />
                                        </div>
                                        <div id="log-butt-rght">
                                            <asp:Button ID="btnreset" runat="server" class="logincancelButt" TabIndex="7" OnClientClick="Clear();" Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="log-bg-r">
                        </div>
                    </div>
            <div id="log-footer">
                <%--
                <span style="color: Black; font-size: larger;">Best viewed in Mozila FireFox & Internet
                    Explorer 7.0 and above.</span>
                <br />
                &#65533;
                <!--<a href="http://royaltechsystems.co.in" style="color:Blue; font-weight:bold;"  target="_blank">Royal Tech Systems</a>-->
                <a style="color: Blue; font-weight: bold;" target="_blank">eRoyal Support Contact -
                    +91 98402 41678,+91 93854 13685</a>
                <br />
                <a style="color: Blue; font-weight: bold;" target="_blank">Account & Payment Enquiries
                    - +91762 85457</a>
                <br />
                Website : <a href="http://www.royaltechsystems.co.in" style="color: Blue; font-weight: bold;"
                    target="_blank">Royal Tech Systems</a> , INDIA | All Rights Reserved
                --%>
                <div id="pm-login-support">
                    eRoyal Support Contact&nbsp;&ndash;&nbsp;+91 98402 41678,&nbsp;+91 93854 13685
                    <%-- <br />
                    Account &amp; Payment Enquiries&nbsp;&ndash;&nbsp;<a href="tel:+9176285457">+91 762 85457</a> --%>
                </div>
                <div id="pm-login-policy-links">
                    <a href="javascript:void(0);" onclick="NewWindow('../Privacy_Policy/Privacy_Policy.htm','Privacy','810','470','yes'); return false;">Privacy Policy</a>
                    <span aria-hidden="true">|</span>
                    <a href="javascript:void(0);" onclick="NewWindow('../Disclaimer/Disclaimer.htm','Disclaimer','810','470','yes'); return false;">Disclaimer</a>
                </div>
                <div id="pm-login-copyright">&copy; <a href="https://www.royaltechsystems.co.in/" target="_blank" rel="noopener noreferrer">eRoyal Tech Systems Pvt Ltd</a>.</div>
            </div>
                </div>
            </div>
            <asp:Button ID="btnCompany" runat="server" OnClick="btnCompany_Click" class="loginButt"
                Style="display: none;" />
            <asp:Button ID="btn_AlreadyLogin" runat="server" OnClick="btn_AlreadyLogin_Click"
                class="loginButt" Style="display: none;" />
            <asp:HiddenField ID="hdn_result" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Branch" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Comp_License" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Renewal" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <asp:UpdatePanel ID="updateParent" runat="Server">
            <ContentTemplate>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 450px; height: 129px;">
                    <div id="innerbox_MidMain_Transact_popup_new" style="width: 449px; height: 129px;">
                        <div id="tag_srcinner1_new">
                            <div id="editbu">
                                <a href="#" class="edit"></a>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="text-align: center">
                                Login Alert</div>
                        </div>
                        <div id="tag_transaction_inner_new" style="margin-left: 20px; margin-top: 10px; width: 500px;">
                            <div id="tag_label_transaction_popup_IGM2_empty_gen">
                            </div>
                            <%--------------------------------------------------%>
                            <div id="tag_Exchange_lft_in1_new1" style="text-align: center; width: 420px;">
                                <asp:Label ID="lblRenewal" runat="server" ForeColor="Red"></asp:Label>
                                <br></br>
                                <asp:Label ID="lblContact" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <%--------------------------------------------------%>
                            <div id="tag_label_transaction_popup_IGM2_empty_gen">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_gen">
                            </div>
                            <div id="tag_Exchange_lft_in1_new1">
                            </div>
                            <div id="tag_Exchange_lft_in1_new1">
                                <div id="tag_label_transaction_Src_new" style="width: 30px;">
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 60px;">
                                </div>
                                <div id="tag_label_transaction_date" style="width: 205px; text-align: center;">
                                    <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
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

        // Backstops pin1 (keypress) for paste/drag-drop/autofill, which don't
        // fire keypress events - strips anything but letters/digits and caps
        // at 10 chars so the value the server ever sees is already clean.
        function sanitizeCompanyLicense(el) {
            var cleaned = el.value.replace(/[^a-zA-Z0-9]/g, '').substring(0, 10);
            if (cleaned !== el.value) el.value = cleaned;
        }

        function Clear() {
            document.getElementById('txtCompany_License').value = '';
            document.getElementById('txtUserId').value = '';
            document.getElementById('txtPassword').value = '';

            //$("#ddlBranch").empty();
            //document.getElementById('txtCompany_License').focus();

        }
        function validate_Login() {

            var txtCompany_License = document.getElementById('txtCompany_License').value;
            if (txtCompany_License.length <= 0) {
                jAlert('Company License cannot be blank', 'LOGIN', function (r) { document.getElementById("txtCompany_License").focus(); });

                return false;
            }
            var txtUserId = document.getElementById('txtUserId').value;
            if (txtUserId.length <= 0) {
                jAlert('Username cannot be blank', 'LOGIN', function (r) { document.getElementById("txtUserId").focus(); });

                return false;
            }
            var txtPassword = document.getElementById('txtPassword').value;
            if (txtPassword.length <= 0) {
                jAlert('Password cannot be blank', 'LOGIN', function (r) { document.getElementById("txtPassword").focus(); });

                return false;
            }
            var ddlBranch = document.getElementById('ddlBranch').value;
            if (ddlBranch.length <= 0) {
                jAlert('Branch cannot be blank', 'LOGIN', function (r) { document.getElementById("ddlBranch").focus(); });

                return false;
            }
            var ddlWorkingPeriod = document.getElementById('ddlWorkingPeriod').value;
            if (ddlWorkingPeriod.length <= 0) {
                jAlert('WorkingPeriod cannot be blank', 'LOGIN', function (r) { document.getElementById("ddlWorkingPeriod").focus(); });

                return false;
            }
        }

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }



        function Call_Branch_Name(src, dest) {
            var ctrl = document.getElementById(src).value;

            var ctrl1 = document.getElementById('expiremsg').innerHTML;

            if (ctrl != '') {


                ShowImage(src);
                PageMethods.BindDatatoDropdown(ctrl, CallSuccess, CallFailed, dest);

            }
            else {

            }
        }

        // set the destination textbox value with the ContactName
        function CallSuccess(data, destCtrl) {
            HideImage('txtCompany_License');

            var dest = document.getElementById(destCtrl);
            dest.value = data;
            $("#ddlBranch").empty();
            document.getElementById('ddlBranch').value = '-1';

            __doPostBack('<%= btnCompany.ClientID  %>', '');

            //            $.each(data, function (key, value) {
            //
            //                $("#ddlBranch").append($("<option></option>").val(value.CountryId).html(value.CountryName));
            //                document.getElementById('hdn_Comp_License').value = value.Comp_License;
            //                document.getElementById('hdn_result').value = value.result;
            //            });

            //            if(document.getElementById('hdn_result').value == '0')
            //            {
            //                  $("#ddlBranch").empty();

            //                if (document.getElementById('ddlBranch').value == '-1') {
            //                    var d = 'CompanyId Does not Exists';
            //                    $('#expiremsg').text($(this).d);
            //                }
            //            }
            //            if (document.getElementById('hdn_Comp_License').value == '') {
            //
            //            }
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {

        }
        var win = null;
        function NewWindow(mypage, myname, w, h, scroll) {
            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
            win = window.open(mypage, myname, settings);
            win.focus();

            return false;
        }
        function open_window() {
            //alert('l');
            NewWindow('E_royal_Impex_Main.aspx', 'index', '1000', '1000', 'yes');
            //OPen_ERoyalImpexMain_Popup();
        }
    </script>
    <script type="text/javascript">
        window.onload = function () {
            // Added by Pandiyan on 14-10-2025 for Copper to Eroyal auto-login
            var query = window.location.search.substring(1);
            var vars = query.split("&");

            var params = {};
            for (var i = 0; i < vars.length; i++) {
                var pair = vars[i].split("=");
                var key = decodeURIComponent(pair[0] || "").trim();
                var value = decodeURIComponent(pair.slice(1).join("=") || "").trim();
                params[key] = value;
            }

            var companyId = params["company"];
            var username = params["username"];
            var password = params["password"];
            var groupname = params["ddlGroupname"];
            var branch = params["ddlBranch"];
            var workingPeriod = params["ddlWorkingPeriod"];

            // Assign values to textboxes
            var txtCompany = document.getElementById('<%= txtCompany_License.ClientID %>');
            if (txtCompany && companyId) txtCompany.value = companyId;

            var txtUser = document.getElementById('<%= txtUserId.ClientID %>');
            if (txtUser && username) txtUser.value = username;

            var txtPass = document.getElementById('<%= txtPassword.ClientID %>');
            if (txtPass && password) txtPass.value = password;

            // Assign values to dropdowns safely
            var ddlGroup = document.getElementById('<%= ddlGroupname.ClientID %>');
            if (ddlGroup && groupname) {
                for (var i = 0; i < ddlGroup.options.length; i++) {
                    if (ddlGroup.options[i].text === groupname || ddlGroup.options[i].value === groupname) {
                        ddlGroup.selectedIndex = i;
                        break;
                    }
                }
            }

            var ddlBranch = document.getElementById('<%= ddlBranch.ClientID %>');
            if (ddlBranch && branch) {
                for (var i = 0; i < ddlBranch.options.length; i++) {
                    if (ddlBranch.options[i].text === branch || ddlBranch.options[i].value === branch) {
                        ddlBranch.selectedIndex = i;
                        break;
                    }
                }
            }

            var ddlPeriod = document.getElementById('<%= ddlWorkingPeriod.ClientID %>');
            if (ddlPeriod && workingPeriod) {
                for (var i = 0; i < ddlPeriod.options.length; i++) {
                    if (ddlPeriod.options[i].text === workingPeriod || ddlPeriod.options[i].value === workingPeriod) {
                        ddlPeriod.selectedIndex = i;
                        break;
                    }
                }
            }
        };
    </script>
    <script type="text/javascript">
        function triggerPasswordVisiblity() {
            var password = document.getElementById('<%=txtPassword.ClientID%>');
            var eyeOpen = document.getElementById('eyeOpen');
            var eyeClose = document.getElementById('eyeClosed');

            if (!password) return;

            if (password.type === 'password') {
                password.type = 'text';
                eyeOpen.style.display = 'none';
                eyeClose.style.display = 'block';
            } else {
                password.type = 'password';
                eyeOpen.style.display = 'block';
                eyeClose.style.display = 'none';
            }
        }

        function handlePasswordInput() {
            var toggleIcon = document.getElementById('togglePassword');
            if (this.value.length > 0) {
                toggleIcon.style.display = 'block';
            } else {
                toggleIcon.style.display = 'none';
                this.type = 'password';
                document.getElementById('eyeOpen').style.display = 'block';
                document.getElementById('eyeClosed').style.display = 'none';
            }
        }

        // pageLoad() fires after every UpdatePanel refresh — critical for ASP.NET AJAX
        function pageLoad() {
            var toggleButton = document.getElementById('togglePassword');
            if (toggleButton) {
                toggleButton.removeEventListener('click', triggerPasswordVisiblity);
                toggleButton.addEventListener('click', triggerPasswordVisiblity);
            }

            var txtPasswordInput = document.getElementById('<%=txtPassword.ClientID%>');
            if (txtPasswordInput) {
                txtPasswordInput.removeEventListener('input', handlePasswordInput);
                txtPasswordInput.addEventListener('input', handlePasswordInput);
            }
        }
</script>
</body>
</html>
