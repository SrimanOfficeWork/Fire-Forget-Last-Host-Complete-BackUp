<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Change_Password.aspx.cs" Inherits="eRoyalMasters_Adcode_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        :root {
            --pmb-bg-panel: #ffffff;
            --pmb-bg-panel-alt: #f2f4fa;
            --pmb-border: rgba(20, 28, 55, 0.10);
            --pmb-border-soft: rgba(20, 28, 55, 0.06);
            --pmb-text-primary: #1a2137;
            --pmb-text-muted: #5b6584;
            --pmb-text-faint: #8892ac;
            --pmb-accent: #2563eb;
            --pmb-accent-2: #0ea5b7;
            --pmb-danger: #dc2626;
            --pmb-radius: 10px;
            --pmb-font: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
        }
        * { box-sizing: border-box; }
        html, body {
            margin: 0;
            padding: 0;
            background: var(--pmb-bg-panel);
            font-family: var(--pmb-font);
            color: var(--pmb-text-primary);
            overflow: hidden;
        }
        .pmb-card {
            display: flex;
            flex-direction: column;
            height: 100%;
            padding: 20px 22px 18px 22px;
        }
        .pmb-header {
            display: flex;
            align-items: center;
            gap: 8px;
            margin-bottom: 16px;
        }
        .pmb-header-text {
            font-size: 14px;
            font-weight: 700;
            color: var(--pmb-text-primary);
        }
        .pmb-body { flex: 1; min-height: 0; }
        .pmb-field { margin-bottom: 30px; }
        .pmb-field-last { margin-bottom: 8px; }

        /* Material "Outlined TextField" look: border runs all the way around, and the
           label sits notched into the top border line (bg-colored backdrop behind the
           label text punches a gap through the border) instead of floating above it. */
        .pmb-outlined {
            position: relative;
            margin-top: 20px;
        }
        .pmb-outlined label {
            position: absolute;
            top: -8px;
            left: 10px;
            padding: 0 6px;
            background: var(--pmb-bg-panel);
            font-size: 10.5px;
            font-weight: 700;
            letter-spacing: .3px;
            text-transform: uppercase;
            color: var(--pmb-text-faint);
            pointer-events: none;
            z-index: 1;
        }
        .pmb-outlined:focus-within label { color: var(--pmb-accent); }
        .pmb-input {
            width: 100%;
            height: 38px;
            padding: 0 38px 0 12px;
            font-family: var(--pmb-font);
            font-size: 12.5px;
            font-weight: 600;
            color: var(--pmb-text-primary);
            background: var(--pmb-bg-panel);
            border: 1.5px solid var(--pmb-border);
            border-radius: var(--pmb-radius);
            transition: border-color .15s ease, box-shadow .15s ease;
        }
        .pmb-input:focus {
            outline: none;
            border-color: rgba(37, 99, 235, .45);
            box-shadow: 0 0 0 3px rgba(37, 99, 235, .12);
        }
        .pmb-pwd-toggle {
            position: absolute;
            right: 8px;
            top: 50%;
            transform: translateY(-50%);
            width: 26px;
            height: 26px;
            border: 0;
            background: none;
            display: flex;
            align-items: center;
            justify-content: center;
            color: var(--pmb-text-faint);
            cursor: pointer;
            border-radius: 6px;
        }
        .pmb-pwd-toggle:hover { color: var(--pmb-text-primary); background: var(--pmb-bg-panel-alt); }
        .pmb-error {
            display: block;
            min-height: 14px;
            font-size: 11px;
            font-weight: 700;
            color: var(--pmb-danger) !important;
            margin-top: 2px;
        }
        .pmb-actions {
            display: flex;
            gap: 8px;
            padding-top: 10px;
            border-top: 1px solid var(--pmb-border-soft);
        }
        .pmb-btn {
            flex: 1;
            height: 38px;
            font-family: var(--pmb-font);
            font-size: 12.5px;
            font-weight: 700;
            border-radius: var(--pmb-radius);
            cursor: pointer;
            border: 1px solid transparent;
            transition: transform .15s ease, box-shadow .15s ease, background .15s ease;
        }
        .pmb-btn-primary {
            background: linear-gradient(135deg, var(--pmb-accent) 0%, #3b82f6 100%);
            color: #fff;
            box-shadow: 0 6px 16px rgba(37, 99, 235, .3);
        }
        .pmb-btn-primary:hover { transform: translateY(-1px); box-shadow: 0 8px 20px rgba(37, 99, 235, .4); }
        .pmb-btn-ghost {
            background: var(--pmb-bg-panel-alt);
            border-color: var(--pmb-border);
            color: var(--pmb-text-primary);
        }
        .pmb-btn-ghost:hover { background: var(--pmb-border-soft); }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div class="pmb-card">
                <div class="pmb-header">
                    <span class="pmb-header-text">Change Password</span>
                </div>
                <div class="pmb-body">
                    <div class="pmb-field pmb-outlined" id="pmpNewPwdWrap">
                        <asp:TextBox ID="txtnew_pwd" runat="server" CssClass="pmb-input" TabIndex="1"
                            MaxLength="50" TextMode="Password"></asp:TextBox>
                        <label for="txtnew_pwd">New Password</label>
                        <button type="button" class="pmb-pwd-toggle" onclick="pmpTogglePwd('txtnew_pwd', this)" title="Show/Hide">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="15" height="15" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M1 12s4-7 11-7 11 7 11 7-4 7-11 7-11-7-11-7z"></path><circle cx="12" cy="12" r="3"></circle></svg>
                        </button>
                    </div>
                    <div class="pmb-field pmb-outlined pmb-field-last" id="pmpConfirmPwdWrap">
                        <asp:TextBox ID="txtconfirmnew_pwd" runat="server" CssClass="pmb-input" TabIndex="2"
                            MaxLength="50" TextMode="Password"></asp:TextBox>
                        <label for="txtconfirmnew_pwd">Confirm New Password</label>
                        <button type="button" class="pmb-pwd-toggle" onclick="pmpTogglePwd('txtconfirmnew_pwd', this)" title="Show/Hide">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="15" height="15" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M1 12s4-7 11-7 11 7 11 7-4 7-11 7-11-7-11-7z"></path><circle cx="12" cy="12" r="3"></circle></svg>
                        </button>
                    </div>
                    <asp:Label ID="lbl_msg" runat="server" CssClass="pmb-error" ClientIDMode="Static"></asp:Label>
                </div>
                <div class="pmb-actions">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="pmb-btn pmb-btn-primary"
                        OnClick="btnUpdate_Click" OnClientClick="return Validation_pwd();" TabIndex="3" />
                    <input type="submit" value="Cancel" class="pmb-btn pmb-btn-ghost" onclick="parent.closeChangePassword();return false;"
                        tabindex="4" id="btnCancel" />
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdn_User_Status" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hdn_User_Type" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="HiddenField1" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hdn_User_Creation_Id" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hdn_Company_ID" ClientIDMode="Static" />
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

        function pmpTogglePwd(id, btn) {
            var input = document.getElementById(id);
            if (!input) return;
            input.type = (input.type === 'password') ? 'text' : 'password';
        }

        // New Password / Confirm New Password must both be filled and must match.
        // (The old version checked field.length instead of field.value.length, which
        // is always undefined on a text input, so the empty checks never actually ran.)
        function Validation_pwd() {
            var errEl = document.getElementById('lbl_msg');
            var newpwd = document.getElementById('<%= txtnew_pwd.ClientID %>');
            var confirmnewpwd = document.getElementById('<%= txtconfirmnew_pwd.ClientID %>');

            if (errEl) errEl.textContent = '';

            if (!newpwd.value.length) {
                if (errEl) errEl.textContent = 'New Password cannot be empty';
                newpwd.focus();
                return false;
            }
            if (!confirmnewpwd.value.length) {
                if (errEl) errEl.textContent = 'Confirm New Password cannot be empty';
                confirmnewpwd.focus();
                return false;
            }
            if (newpwd.value !== confirmnewpwd.value) {
                if (errEl) errEl.textContent = 'The Confirm New Password must match the New Password entry.';
                confirmnewpwd.focus();
                return false;
            }
            return true;
        }

    </script>
</body>
</html>
