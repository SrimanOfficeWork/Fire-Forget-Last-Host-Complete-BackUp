<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoicelock_new.aspx.cs" Inherits="Users_Joblock_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Invoice Release</title>

    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />

    <style type="text/css">
        .ui-autocomplete-loading {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        .hideGridColumn { display: none; }

        /* ---------- page base ---------- */
        html, body.uir-body {
            margin: 0;
            padding: 0;
            background: transparent;   /* parent frame supplies the page bg   */
            font-family: 'Segoe UI', Tahoma, Arial, sans-serif;
            font-size: 13px;
            color: #2d3436;
        }

        /* ---------- shell: matches the old container exactly ----------
           Old page: #innerbox_MidMain_Trans_new width:969px + #ere
           height:950px. Same footprint here, so it sits flush inside the
           parent frame (no side gaps) and the parent copyright footer
           stays BELOW the page instead of overlapping.                   */
        /* ---------- shell: matches the old container width ----------
           Natural height now (no forced 948px stretch) - the grid box has
           its own fixed height like the old screen, so the page ends a
           little shorter and the parent copyright footer flows below.    */
        .uir-shell {
            width: 965px;
            margin: 0;
            padding-bottom: 6px;
            box-sizing: border-box;
        }

        /* ---------- page header ---------- */
     
        
        
        .uir-header {
        background: linear-gradient(135deg, var(--uir-grad1) 0%, var(--uir-grad2) 100%);
        color: var(--uir-text-on-primary);
        padding: 8px 16px;
        font-size: 14px;
        font-weight: 600;
        letter-spacing: .3px;
        border-radius: 8px 8px 0 0;
        box-shadow: 0 2px 6px rgba(0,0,0,.12);
        display: flex;
        align-items: center;
        gap: 8px;
    }
       
       
      .uir-header .uir-ico {
            width: 26px; height: 26px;
            background: rgba(255,255,255,.25);
            border-radius: 6px;
            display: inline-flex; align-items: center; justify-content: center;
            font-size: 14px;
        }

        /* ---------- filter card ---------- */
        .uir-card {
            background: #fff;
            margin: 0 0 16px 0;
            border-radius: 0 0 10px 10px;
            box-shadow: 0 1px 4px rgba(20,40,80,.10);
            border: 1px solid #e4e8ef;
            border-top: none;
            padding: 10px 16px 8px 16px;    /* compact */
        }
        .uir-row {
            display: flex;
            flex-wrap: wrap;
            gap: 8px 18px;                  /* tight - all 4 fields fit ONE row */
            align-items: flex-end;
        }
        .uir-field { display: flex; flex-direction: column; }
        .uir-field label {
            font-size: 10.5px;
            font-weight: 600;
            color: #5a6472;
            text-transform: uppercase;
            letter-spacing: .4px;
            margin: 0 0 3px 2px;
        }

        /* uniform control width for every textbox / dropdown */
        .uir-input, .uir-select {
            width: 200px !important;
            height: 29px !important;        /* compact */
            padding: 3px 9px !important;
            border: 1px solid #c9d2de !important;
            border-radius: 5px !important;
            background: #fbfcfe !important;
            font-size: 12.5px !important;
            font-family: inherit !important;
            color: #2d3436 !important;
            box-sizing: border-box !important;
            transition: border-color .15s, box-shadow .15s;
        }
        
        
       
         .uir-input:focus, .uir-select:focus {
        outline: none !important;
        border-color: var(--uir-focus-border) !important;
        box-shadow: 0 0 0 3px var(--uir-focus-glow) !important;
        background: #fff !important;
    }
        
        

        /* invoice box + magnifier as one unit */
        .uir-invwrap { position: relative; display: inline-block; }
        
        
        
        .uir-invwrap .uir-input { padding-right: 30px !important; }
        
         
    
       .uir-invwrap .magnfy-new {
        position: absolute;
        right: 5px;
        top: 50%;
        transform: translateY(-50%);
        width: 20px;
        height: 20px;
        border-radius: 4px;
        display: inline-flex;
        align-items: center;
        justify-content: center;
        text-decoration: none;
        font-size: 12px;
        color: #e08e0b;
        background: #fdf3e2;
        border: 1px solid #f0d9ad;
        cursor: pointer;
    }
    
      .uir-invwrap .magnfy-new:hover {
        background: #e08e0b;
        color: #fff;
    }
    
    

        /* ---------- buttons ---------- */
        .uir-actions {
            display: flex;
            gap: 10px;
            align-items: center;
            margin-top: 9px;
            padding-top: 8px;
            border-top: 1px dashed #e4e8ef;
            flex-wrap: wrap;
        }
        .uir-btn {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            gap: 5px;
            height: 29px;               /* compact */
            padding: 0 16px;
            border-radius: 5px;
            border: 1px solid transparent;
            font-size: 12.5px;
            font-weight: 600;
            font-family: inherit;
            cursor: pointer;
            text-decoration: none !important;
            transition: filter .15s, transform .05s;
        }
        .uir-btn:active { transform: translateY(1px); }
         .uir-btn-primary {
        background: linear-gradient(var(--uir-grad1), var(--uir-grad2));
        color: var(--uir-text-on-primary) !important;
        box-shadow: 0 2px 4px var(--uir-focus-glow);
    }
    
         .uir-btn-primary:hover { filter: brightness(1.06); }
       
        .uir-btn-ghost { background: #fff; color: #5a6472 !important; border-color: #c9d2de; }
        .uir-btn-ghost:hover { background: #f2f4f8; }
        .uir-btn-success { background: linear-gradient(#3fae5c, #2f9349); color: #fff !important; box-shadow: 0 2px 4px rgba(47,147,73,.30); }
        .uir-btn-success:hover { filter: brightness(1.06); }
        .uir-btn-dark { background: #5a6472; color: #fff !important; }
        .uir-btn-dark:hover { filter: brightness(1.1); }
        .uir-spacer { flex: 1; }

        .uir-gridcard {
            background: #fff;
            margin: 0 0 16px 0;
            border-radius: 10px;        /* rounded on ALL sides = own box   */
            box-shadow: 0 1px 4px rgba(20,40,80,.10);
            border: 1px solid #e4e8ef;
            overflow: hidden;
        }
        .uir-gridtitle {
            padding: 9px 16px;
            font-weight: 600;
            font-size: 13px;
            color: #5a6472;
            background: #f8fafc;
            border-bottom: 1px solid #e4e8ef;
        }
        .uir-gridscroll { overflow: auto; height: 430px; }
        .uir-gridscroll table.grid-view { width: 100%; border-collapse: collapse !important; border: none !important; }
        
         .uir-gridscroll .grid-view tr.header th,
    .uir-gridscroll .grid-view th {
        position: sticky; top: 0; z-index: 2;
        background: linear-gradient(var(--uir-grad1), var(--uir-grad2)) !important;
        color: var(--uir-grid-head-text) !important;
        font-weight: 700;
        font-size: 12px !important;
        text-transform: uppercase;
        letter-spacing: .3px;
        padding: 8px 10px !important;
        border-bottom: 2px solid var(--uir-grid-head-border) !important;
        border-right: 1px solid rgba(255,255,255,.35) !important;
        text-align: center;
    }
        
      
        
        /* NO RECORD FOUND row (EmptyDataText) */
        .uir-gridscroll .grid-view .uir-empty,
        .uir-gridscroll .grid-view tr td[colspan] {
            text-align: center !important;
            font-weight: 700;
            color: #5a6472;
            padding: 10px !important;
        }
        .uir-gridscroll .grid-view td {
            padding: 8px 10px !important;
            border-bottom: 1px solid #eef1f6 !important;
            font-size: 12.5px;
        }
        .uir-gridscroll .grid-view tr.normal    { background: #fff; }
        .uir-gridscroll .grid-view tr.alternate { background: #fafbfd; }
     
        
          .uir-gridscroll .grid-view tr:hover td {
        background: var(--uir-light-bg) !important;
    }
        
      
        .uir-gridscroll .grid-view input[type=checkbox] {
        width: 15px; height: 15px;
        accent-color: var(--uir-grad2);
        cursor: pointer;
        }
      
      

        @media (max-width: 990px) {
            .uir-shell { width: 100%; }
            .uir-input, .uir-select { width: 100% !important; min-width: 180px; }
            .uir-field { flex: 1 1 45%; }
        }
        
        
         :root {
        --uir-grad1: #f5a623;
        --uir-grad2: #e08e0b;
        --uir-text-on-primary: #ffffff;
        --uir-light-bg: #fdf3e2;
        --uir-light-border: #f0d9ad;
        --uir-focus-glow: rgba(224,142,11,.15);
        --uir-focus-border: #e08e0b;
        --uir-grid-head-text: #4a2f00;
        --uir-grid-head-border: #c87f08;
    }

    /* ---- Blue ---- */
    body.theme-blue {
        --uir-grad1: #4a90e2;
        --uir-grad2: #2b6cb0;
        --uir-text-on-primary: #ffffff;
        --uir-light-bg: #e8f1fc;
        --uir-light-border: #bcd6f5;
        --uir-focus-glow: rgba(43,108,176,.15);
        --uir-focus-border: #2b6cb0;
        --uir-grid-head-text: #1a3a5c;
        --uir-grid-head-border: #1e4e82;
    }

    /* ---- DBlue (Dark Blue / Navy) ---- */
    body.theme-dblue {
        --uir-grad1: #2c3e60;
        --uir-grad2: #16213a;
        --uir-text-on-primary: #ffffff;
        --uir-light-bg: #e3e7ee;
        --uir-light-border: #b7c0d1;
        --uir-focus-glow: rgba(22,33,58,.18);
        --uir-focus-border: #16213a;
        --uir-grid-head-text: #ffffff;
        --uir-grid-head-border: #0e1626;
    }

    /* ---- Green ---- */
    body.theme-green {
        --uir-grad1: #43a047;
        --uir-grad2: #2e7d32;
        --uir-text-on-primary: #ffffff;
        --uir-light-bg: #e8f6e9;
        --uir-light-border: #b6e0ba;
        --uir-focus-glow: rgba(46,125,50,.15);
        --uir-focus-border: #2e7d32;
        --uir-grid-head-text: #1b4d1e;
        --uir-grid-head-border: #1e5e22;
    }

    /* ---- Blue Fancy (two-tone teal-blue) ---- */
    body.theme-bluefancy {
        --uir-grad1: #5b86e5;
        --uir-grad2: #36d1dc;
        --uir-text-on-primary: #ffffff;
        --uir-light-bg: #eef2ff;
        --uir-light-border: #c8d3fb;
        --uir-focus-glow: rgba(54,140,220,.18);
        --uir-focus-border: #4a7fd4;
        --uir-grid-head-text: #12306b;
        --uir-grid-head-border: #345fc4;
    }

    /* ---- Violet Fancy ---- */
    body.theme-violetfancy {
        --uir-grad1: #8e2de2;
        --uir-grad2: #4a00e0;
        --uir-text-on-primary: #ffffff;
        --uir-light-bg: #f3e8fd;
        --uir-light-border: #dcc2f7;
        --uir-focus-glow: rgba(74,0,224,.16);
        --uir-focus-border: #6a1fc4;
        --uir-grid-head-text: #ffffff;
        --uir-grid-head-border: #3d0099;
    }
        
        
        
        
        
        
    </style>

    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <script src="../js/Export_Jscript/Export_Joblock.js" type="text/javascript"></script>
    <script type="text/javascript">
        //<!--  (functionality unchanged)
        function Check_Click(objRef) {
            var row = objRef.parentNode.parentNode;
            var GridView = row.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var headerCheckBox = inputList[0];
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                        }
                        else {
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
        function win_close1() {
            window.parent.document.getElementById('interVeil').style.display = 'none';
            window.parent.adcodewindow.hide();
        }
    </script>
</head>
<body class="uir-body" runat="server" id="BodyTag">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"
            EnablePartialRendering="false" LoadScriptsBeforeUI="false">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
            <ContentTemplate>
                <div class="loading" align="center" id="load" style="display: none;">
                    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
                </div>

                <div class="uir-shell">

                <div class="uir-header">
                    <span class="uir-ico">&#128274;</span> Duplicate Invoice Release
                </div>

                <div class="uir-card">
                    <div class="uir-row">
                        <div class="uir-field">
                            <label>Job Type</label>
                            <asp:DropDownList ID="ddlJobType" runat="server" CssClass="uir-select" ClientIDMode="Static">
                                <asp:ListItem>Import</asp:ListItem>
                                <asp:ListItem>Export</asp:ListItem>
                                <asp:ListItem>Both</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="uir-field">
                            <label>Select Branch</label>
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="uir-select">
                            </asp:DropDownList>
                        </div>

                        <div class="uir-field">
                            <label>User Name</label>
                            <asp:DropDownList ID="ddlUserName" runat="server" CssClass="uir-select" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                        <div class="uir-field">
                            <label>
                                Invoice No</label>
                            <span class="uir-invwrap">
                                <asp:TextBox ID="txtInvoiceNumber" runat="server" onkeyup="autotab(this);" CssClass="validate[required] uir-input"
                                    Width="180px" MaxLength="50" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                                <a href="#" class="magnfy-new" title="Search Invoice No" onclick="OpenPopupInvoiceNo(); return false"
                                    tabindex="6">&#128269;</a> </span>
                        </div>
                    </div>

                    <div class="uir-actions">
                        <a href="#" class="uir-btn uir-btn-primary" id="btnSearch" runat="server"
                           onserverclick="btnSearch_Click" tabindex="10">&#128269; Search</a>

                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="uir-btn uir-btn-ghost"
                           tabindex="11">&#10005; Cancel</a>

                        <span class="uir-spacer"></span>

                        <div id="joblockoption" runat="server" style="display:flex;gap:12px;">
                            <%--<asp:Button ID="btnLock" runat="server" CausesValidation="false" OnClick="btnLock_Click"
                                UseSubmitBehavior="false" CssClass="uir-btn uir-btn-dark" Text="Lock" />

                            <asp:Button ID="btnUnlock" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="uir-btn uir-btn-ghost" Text="UnLock" OnClick="btnUnlock_Click" />--%>

                            <asp:Button ID="btnInvJobRelease" runat="server" CausesValidation="false" OnClick="btn_Invoice_JobRelease_Click"
                                UseSubmitBehavior="false" CssClass="uir-btn uir-btn-success" Text="Release" />
                        </div>
                    </div>
                </div>

                <div class="uir-gridcard">
                    <div class="uir-gridtitle">Jobs using this Invoice No</div>
                    <div class="uir-gridscroll" id="Main_Grid_Container" runat="server">
                        <asp:GridView ID="gv_details" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                            BorderColor="#C8C8C8" BorderStyle="None" BorderWidth="0px" CellPadding="1" CellSpacing="0"
                            CssClass="grid-view" DataKeyNames="JOBID" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                            EmptyDataRowStyle-CssClass="uir-empty"
                            Width="100%" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                            <AlternatingRowStyle CssClass="column_style_right" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                </div>  

                <asp:HiddenField runat="server" ID="hdn_Server" />
                 <asp:HiddenField runat="server" ID="HD_imp_exp" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>

    <script src="../js/Export_Jscript/Export_Joblock.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
    </script>
    <script type="text/javascript">
        function SelectheaderCheckboxes(headerchk, gv) {
            var gvcheck = document.getElementById(gv);
            var i;
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        function Selectchildcheckboxes(header, gv) {
            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {
                    count++;
                }
            }
            if (count == rowcount - 1) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }
        }
    </script>
    <script type="text/javascript">
        function SelectheaderCheckboxes_file(headerchk, gv, button) {
            var gvcheck = document.getElementById(gv);
            var i;
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
                document.getElementById(button).click();
            }
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        function Selectchildcheckboxes_file(header, gv, button) {
            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {
                    document.getElementById(button).click();
                    count++;
                }
            }
            if (count == rowcount - 1) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }
        }
    </script>

    <script type="text/javascript">

        // ---- reads the logged-in user's theme (same Session["Theme"] your
        //      existing theme menu already sets - nothing else to change) ----
        var PAGE_THEME = '<%= (Session["Theme"] != null && Session["Theme"].ToString() != "") ? Session["Theme"].ToString() : "Orange" %>';

        // ---- THE ONLY POPUP FUNCTION IN THE WHOLE APP - call this from
        //      anywhere (JS or via C# wrapper below) ----
        function Show_Popup_JS(title, htmlMsg) {
            var theme = PAGE_THEME ? PAGE_THEME.toLowerCase() : 'orange';
            var gradTop = '#f5a623', gradBot = '#e08e0b';   // Orange (default)

            if (theme === 'blue') { gradTop = '#4a90e2'; gradBot = '#2b6cb0'; }
            else if (theme === 'dblue') { gradTop = '#2c3e60'; gradBot = '#16213a'; }
            else if (theme === 'green') { gradTop = '#43a047'; gradBot = '#2e7d32'; }
            else if (theme === 'bluefancy') { gradTop = '#5b86e5'; gradBot = '#36d1dc'; }
            else if (theme === 'violetfancy') { gradTop = '#8e2de2'; gradBot = '#4a00e0'; }

            var old = document.getElementById('cstm_pop_ovl');
            if (old) old.parentNode.removeChild(old);

            var ovl = document.createElement('div');
            ovl.id = 'cstm_pop_ovl';
            ovl.style.cssText =
            'position:fixed;top:0;left:0;width:100%;height:100%;' +
            'background:rgba(0,0,0,.50);z-index:999998;' +
            'display:flex;align-items:center;justify-content:center;';

            var box = document.createElement('div');
            box.style.cssText =
            'width:460px;max-width:94vw;background:#fff;border-radius:8px;' +
            'box-shadow:0 8px 32px rgba(0,0,0,.40);' +
            'font-family:Segoe UI,Tahoma,Arial,sans-serif;font-size:13px;color:#2d3436;' +
            'display:flex;flex-direction:column;max-height:85vh;overflow:hidden;';

            box.innerHTML =
            '<div style="background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;' +
                'font-weight:700;font-size:14px;padding:10px 16px;flex-shrink:0;">' + title + '</div>' +
            '<div style="padding:16px 18px;line-height:1.55;overflow:auto;flex:1;">' + htmlMsg + '</div>' +
            '<div style="padding:10px 14px;text-align:center;border-top:1px solid #eee;flex-shrink:0;">' +
                '<button type="button" id="cstm_pop_ok" style="min-width:88px;height:30px;' +
                'background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;border:0;' +
                'border-radius:5px;font-weight:600;cursor:pointer;">OK</button></div>';

            ovl.appendChild(box);
            document.body.appendChild(ovl);

            document.getElementById('cstm_pop_ok').onclick = function () {
                var el = document.getElementById('cstm_pop_ovl');
                if (el) el.parentNode.removeChild(el);
            };
        }

</script>


<script type="text/javascript">
    function OpenPopupInvoiceNo() {
        NewWindow1('../ListPopup/Invoice_No_ListPopup.aspx?jt=Import', 'List', '810', '470', 'yes');
    }

//    $(function () {
//        $("#txtInvoiceNumber").autocomplete({
//            source: function (request, response) {
//                $.ajax({
//                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Invoice_No_List_NEW",
//                    data: "{ 'mail': '" + request.term + "' ,'JobType':'Import'}",
//                    dataType: "json",
//                    type: "POST",
//                    contentType: "application/json; charset=utf-8",
//                    dataFilter: function (data) { return data; },
//                    async: true,
//                    success: function (data) {
//                        response(data.d);
//                        if (data.d == '') {
//                            jQuery('#txtInvoiceNumber').validationEngine('showPrompt', 'Incorrect Invoice No', 'error', 'topRight', true);
//                        }
//                        else {
//                            jQuery('#txtInvoiceNumber').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                        }
//                    },
//                    error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    }
//                });
//            },
//            minLength: 1
//        });
//        return false;
//        scroll: true;
//    });




    $(function () {
        $("#txtInvoiceNumber").autocomplete({
            source: function (request, response) {
                // ✅ reads the CURRENT dropdown value every time, not a fixed string
                var jt = document.getElementById('ddlJobType')
                        ? document.getElementById('ddlJobType').value
                        : '';

                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Invoice_No_List_NEW",
                    data: "{ 'mail': '" + request.term + "' ,'JobType':'" + jt + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txtInvoiceNumber').validationEngine('showPrompt', 'Incorrect Invoice No', 'error', 'topRight', true);
                        }
                        else {
                            jQuery('#txtInvoiceNumber').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

</script>
</body>
</html>
