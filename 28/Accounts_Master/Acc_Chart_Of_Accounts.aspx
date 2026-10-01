<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Acc_Chart_Of_Accounts.aspx.cs" Inherits="Acc_Chart_Of_Accounts"
    ResponseEncoding="utf-8" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <%--<link href="../css/all.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style>
        *
        {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
        }
        
        
        #titlebar
        {
            background: linear-gradient(to bottom, #6ea0cc, #3a72a8);
            color: #fff;
            font-weight: bold;
            font-size: 14px;
            padding: 5px 10px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        
        #filterrow
        {
            border-bottom: 1px solid #a8c0d8;
            padding: 5px 10px;
            display: flex;
            align-items: center;
            gap: 14px;
        }
        #filterrow label
        {
            font-size: 13px;
        }
        #filterrow select, #filterrow input
        {
            border: 1px solid #888;
            padding: 2px 4px;
            font-size: 13px;
            font-family: Tahoma, Arial, sans-serif;
            height: 22px;
            background: #fff;
        }
        
        #main
        {
            display: flex;
            height: calc(100vh - 110px);
        }
        
        #treepane
        {
            width: 520px;
            min-width: 180px;
            border: 2px solid #cdd7dc;
            overflow-y: auto;
            overflow-x: auto;
            padding: 4px 0;
            position: relative;
            border-radius: 8px;
        }
        
        #detailspane
        {
            flex: 1;
            background: #f5f9ff;
            overflow-y: auto;
        }
        #detailspane .det-header
        {
            background: linear-gradient(to bottom, #5b8fc0, #3a6ea0);
            color: #fff;
            font-weight: bold;
            padding: 4px 14px;
            font-size: 13px;
        }
        #detailspane .det-body
        {
            padding: 16px 20px;
        }
        #detailspane .det-title
        {
            font-weight: bold;
            font-size: 13px;
            margin-bottom: 12px;
        }
        .det-row
        {
            display: flex;
            align-items: flex-start;
            margin-bottom: 8px;
            font-size: 13px;
        }
        .det-lbl
        {
            width: 90px;
            color: #222;
        }
        .det-sep
        {
            width: 16px;
            text-align: center;
        }
        .det-val
        {
            color: #000;
        }
        
        .tree-root
        {
            list-style: none;
            padding: 0;
            margin: 0;
        }
        .tree-root li
        {
            list-style: none;
        }
        .tree-node
        {
            display: flex;
            align-items: center;
            gap: 4px;
            padding: 2px 6px;
            cursor: pointer;
            white-space: nowrap;
            font-size: 13px;
        }
        .tree-node:hover
        {
            background: #c8ddf0;
        }
        .tree-node.selected
        {
            background: #4a7fc0;
            color: #fff;
        }
        .tree-node .toggle
        {
            width: 14px;
            text-align: center;
            font-size: 10px;
            cursor: pointer;
        }
        .tree-node .icon
        {
            width: 18px;
        }
        .tree-children
        {
            display: none;
            padding-left: 20px;
        }
        .tree-children.open
        {
            display: block;
        }
        
        #bottombar
        {
            background: #dce8f4;
            border-top: 1px solid #a8c0d8;
            padding: 5px 8px;
            display: flex;
            align-items: center;
            gap: 6px;
            flex-wrap: wrap;
        }
        .bot-btn
        {
            padding: 3px 12px;
            font-size: 12px;
            font-family: Tahoma, Arial, sans-serif;
            background: #e4eaf4;
            border: 1px solid #7a9cbf;
            border-radius: 2px;
            cursor: pointer;
        }
        .bot-btn:hover
        {
            background: #cddcee;
        }
        #bottombar .show-lbl
        {
            font-size: 13px;
            margin-left: 8px;
        }
        #bottombar select
        {
            height: 22px;
            font-size: 12px;
            border: 1px solid #888;
            background: #fff;
            padding: 1px 4px;
        }
        #bottombar input.search-box
        {
            height: 22px;
            font-size: 12px;
            border: 1px solid #888;
            background: #fff;
            padding: 1px 6px;
            width: 180px;
        }
        .refresh-btn
        {
            font-size: 14px;
            cursor: pointer;
            background: none;
            border: none;
        }
        .export-btn
        {
            margin-left: auto;
            padding: 3px 14px;
            font-size: 12px;
            background: #e4eaf4;
            border: 1px solid #7a9cbf;
            border-radius: 2px;
            cursor: pointer;
        }
        
        #popupOverlay
        {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0,0,0,0.35);
            z-index: 900;
        }
        #popupOverlay.open
        {
            display: block;
        }
        
        #popupWindow
        {
            position: fixed;
            top: 30%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 600px;
            background: #fff;
            border: 1px solid #7a9cbf;
            box-shadow: 4px 6px 18px rgba(0,0,0,.35);
            z-index: 1000;
            font-family: Tahoma, Arial, sans-serif;
            font-size: 13px;
        }
        
        #popupTitleBar
        {
            background: linear-gradient(to bottom, #6ea0cc, #3a72a8);
            color: #fff;
            font-weight: bold;
            font-size: 13px;
            padding: 5px 10px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        #popupTitleBar .ptitle
        {
        }
        #popupTitleBar .pstatus
        {
            font-size: 12px;
            font-weight: normal;
            display: flex;
            align-items: center;
            gap: 8px;
        }
        .pdot
        {
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background: #ffe44d;
            border: 1px solid #bba;
            display: inline-block;
        }
        .pactive
        {
            color: #ffe44d;
            font-weight: bold;
        }
        
        #popupToolbar
        {
            background: #c8ddf0;
            border-bottom: 1px solid #a0b8d0;
            padding: 3px 8px;
            display: flex;
            gap: 4px;
        }
        .ptool-btn
        {
            background: content-box;
            border: 2px solid #2320203b;
            border-radius: 8px;
            cursor: pointer;
            padding: 2px 4px;
            font-size: 12px;
        }
        .ptool-btn:hover
        {
            border-color: #6a9fd8;
            background: #dceeff;
        }
        
        #popupTabs
        {
            display: flex;
            gap: 2px;
            padding: 6px 8px 0;
            background: #eaf1f9;
        }
        .ptab-btn
        {
            padding: 4px 18px;
            font-family: Tahoma, Arial, sans-serif;
            font-size: 13px;
            background: #c0d4e8;
            border: 1px solid #a0b8d0;
            border-bottom: none;
            cursor: pointer;
            position: relative;
            z-index: 0;
        }
        .ptab-btn.active
        {
            background: #fff;
            border-bottom: 1px solid #fff;
            font-weight: bold;
            z-index: 1;
            margin-bottom: -1px;
        }
        .ptab-icon
        {
            font-size: 14px;
            padding: 4px 8px;
            background: #c0d4e8;
            border: 1px solid #a0b8d0;
            cursor: pointer;
        }
        
        #popupBody
        {
            background: #fff;
            border-top: 1px solid #a0b8d0;
            padding: 14px 18px;
        }
        .pform-row
        {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }
        .pform-lbl
        {
            width: 110px;
            text-align: right;
            padding-right: 10px;
            color: #222;
            white-space: nowrap;
        }
        .pform-lbl.req
        {
            color: #cc0000;
            font-weight: bold;
        }
        .pform-val
        {
            flex: 1;
            display: flex;
            align-items: center;
            gap: 6px;
        }
        .pinput
        {
            border: 1px solid #888;
            padding: 2px 5px;
            font-size: 13px;
            font-family: Tahoma, Arial, sans-serif;
            height: 22px;
            background: #fff;
        }
        .pinput:disabled
        {
            background: #f0f0f0;
            opacity: 0.7;
        }
        select.pinput
        {
            background: #fff;
        }
        
        .section-box
        {
            border: 1px solid #707377;
            border-radius: 3px;
            padding: 8px 12px;
            margin-bottom: 10px;
            background: #e3e8f0;
        }
        .section-title
        {
            font-size: 12px;
            font-weight: bold;
            color: #555;
            margin-bottom: 6px;
        }
        .section-row
        {
            display: flex;
            align-items: center;
            gap: 10px;
        }
        
        .radio-lbl
        {
            display: flex;
            align-items: center;
            gap: 4px;
            cursor: pointer;
            font-size: 13px;
        }
        
        #popupFooter
        {
            background: #eaf1f9;
            border-top: 1px solid #a8c0d8;
            padding: 7px 14px;
            display: flex;
            justify-content: flex-end;
            gap: 8px;
        }
        .pfooter-btn
        {
            padding: 4px 20px;
            font-size: 13px;
            font-family: Tahoma, Arial, sans-serif;
            background: #e4eaf4;
            border: 1px solid #7a9cbf;
            border-radius: 2px;
            cursor: pointer;
        }
        .pfooter-btn:hover
        {
            background: #cddcee;
        }
        .pfooter-btn.primary
        {
            background: #dceeff;
        }
        
        .val-msg
        {
            color: #cc0000;
            font-size: 12px;
        }
        .ok-msg
        {
            color: #007700;
            font-size: 12px;
        }
        .err-panel
        {
            padding: 4px 8px;
        }
        /* FORCE ICON COLORS */.group-node i
        {
            color: #2b579a !important; /* Blue */
        }
        .sub1-node i
        {
            color: #2e7d32 !important; /* Green */
        }
        .sub2-node i
        {
            color: #ef6c00 !important; /* Orange */
        }
        .leaf-node i
        {
            color: #c62828 !important; /* Red */
        }
        .tree-node
        {
            display: flex;
            align-items: center;
            gap: 6px;
        }
        .tree-node .icon i
        {
            width: 18px;
            text-align: center;
            font-size: 14px;
        }
        #popupOverlay
        {
            display: none;
        }
    </style>
    <!-- Hidden fields for popup data -->
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:HiddenField ID="hdnPopupType" runat="server" />
    <asp:HiddenField ID="hdnSelectedId" runat="server" />
    <asp:HiddenField ID="hdnParentId" runat="server" />
    <asp:HiddenField ID="hdnAction" runat="server" Value="New" />
    <asp:HiddenField ID="hdnSelectedCode" runat="server" />
    <asp:HiddenField ID="hdnCurrency" runat="server" Value="Multiple" />
    <asp:HiddenField ID="hdnExpandedNodes" runat="server" />
    <div id="innerbox_MidMain_Trans_new" style="color: black;">
        <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px; color: white">
            Chart Of Accounts
        </div>
        <div id="filterrow">
            <label>
                Fiscal Period</label>
            <asp:DropDownList ID="ddlFiscalPeriod" runat="server" Style="width: 200px">
            </asp:DropDownList>
            <label style="margin-left: 20px">
                Location</label>
            <asp:DropDownList ID="ddlLocation" runat="server" Style="width: 130px">
            </asp:DropDownList>
        </div>
        <div id="main" style="height: 380px;">
            <!-- Left: tree -->
            <div id="treepane">
                <ul class="tree-root" id="accountTree" runat="server">
                </ul>
            </div>
            <!-- Right: details -->
            <div id="innerbox_MidMain_Trans_new" style="height: 380px; width: 500px; margin: initial;">
                <div class="det-header" style="color: white; font-size: 15px; font-weight: bold;
                    padding: 4px;">
                    Details</div>
                <div class="det-body" id="detBody">
                    <asp:Panel ID="pnlDetails" runat="server" Visible="false" Style="padding: 10px;">
                        <div class="det-title" style="color: red; font-size: large;">
                            <asp:Literal ID="litDetTitle" runat="server" /></div>
                        <div class="det-row" style="margin-top: 5px;">
                            <span class="det-lbl">Code</span> <span class="det-sep">:</span> <span class="det-val">
                                <asp:Literal ID="litDetCode" runat="server" /></span>
                        </div>
                        <div class="det-row">
                            <span class="det-lbl">Type</span> <span class="det-sep">:</span> <span class="det-val">
                                <asp:Literal ID="litDetType" runat="server" /></span>
                        </div>
                        <div class="det-row">
                            <span class="det-lbl">Currency</span> <span class="det-sep">:</span> <span class="det-val">
                                <asp:Literal ID="litDetCurrency" runat="server" /></span>
                        </div>
                        <div class="det-row">
                            <span class="det-lbl">Under</span> <span class="det-sep">:</span> <span class="det-val">
                                <asp:Literal ID="litDetUnder" runat="server" /></span>
                        </div>
                        <div class="det-row">
                            <span class="det-lbl">Active</span> <span class="det-sep">:</span> <span class="det-val">
                                <asp:Literal ID="litDetActive" runat="server" /></span>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <!-- /main -->
        <div id="bottombar">
            <asp:Button ID="btnNewGroup" runat="server" CssClass="bot-btn" Text="New Group" OnClick="btnNewGroup_Click"
                CausesValidation="false" />
            <asp:Button ID="btnNewGL" runat="server" CssClass="bot-btn" Text="New G/L" OnClick="btnNewGL_Click"
                CausesValidation="false" />
            <asp:Button ID="btnEdit" runat="server" CssClass="bot-btn" Text="Edit" OnClick="btnEdit_Click"
                CausesValidation="false" />
            <asp:Button ID="btnMove" runat="server" CssClass="bot-btn" Text="Move" OnClick="btnMove_Click"
                CausesValidation="false" />
            <span class="show-lbl">Show</span>
            <button type="button" class="refresh-btn" title="Refresh" onclick="location.reload()">
                &#8635;</button>
            <label style="margin-left: 10px; font-size: 13px">
                Search</label>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="pinput search-box" Style="width: 180px" />
            <asp:Button ID="btnSearch" runat="server" CssClass="bot-btn" Text="Go" OnClick="btnSearch_Click"
                CausesValidation="false" />
            <asp:Button ID="btnExport" runat="server" CssClass="export-btn" Text="Export" OnClick="btnExport_Click"
                CausesValidation="false" />
        </div>
        <div id="popupOverlay">
            <div id="popupWindow">
                <!-- Popup title bar -->
                <div id="innerbox_MidMain_Trans_new" style="height: 30px; width: 600px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        <asp:Literal ID="litPopupTitle" runat="server" />
                    </div>
                </div>
                <div id="popupToolbar">
                    <button type="button" class="ptool-btn" onclick="window.print()" title="Print">
                        &#128438; Print</button>
                    <button type="button" class="ptool-btn" onclick="location.reload()" title="Refresh">
                        &#8635; Refresh</button>
                    <button type="button" class="ptool-btn" onclick="closePopup()" title="Close">
                        &#10006; Close</button>
                </div>
                <div id="innerbox_MidMain1_Trans_new" style="width: 600px;">
                    <ol id="toc" style="height: 25px; /*! margin-left: px; */background: gainsboro;">
                        <li><a href="#page-1" onclick="switchPopupTab('glaccount',this)" style="height: 20px">
                            <asp:Literal ID="litTabTitle" runat="server" /></a> </li>
                    </ol>
                    <div id="popupBody">
                        <!-- Tab panel: GL Account -->
                        <div id="ptab-glaccount" class="ptab-panel">
                            <!-- Parent Group (read-only display) -->
                            <div class="pform-row">
                                <span class="pform-lbl">Parent Group</span> <span class="pform-val">
                                    <asp:TextBox ID="txtParentGroup" runat="server" CssClass="pinput" Style="width: 350px"
                                        ReadOnly="true" Text="ASSET / Current Assets / Loans &amp; Advances (Asset) / Err" />
                                </span>
                            </div>
                            <!-- Code + Order -->
                            <asp:Panel ID="pnlCodeRow" runat="server" CssClass="pform-row">
                                <span class="pform-lbl req">Code</span> <span class="pform-val">
                                    <asp:TextBox ID="txtCode" runat="server" CssClass="pinput" Style="width: 150px" />
                                    <span style="margin-left: 20px">Order</span>
                                    <asp:TextBox ID="txtOrder" runat="server" CssClass="pinput" Style="width: 60px" Text="0" />
                                </span>
                            </asp:Panel>
                            <!-- Name -->
                            <asp:Panel ID="pnlNameRow" runat="server" CssClass="pform-row">
                                <span class="pform-lbl req">Name</span> <span class="pform-val">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="pinput" Style="width: 350px" />
                                </span>
                            </asp:Panel>
                            <!-- Alias -->
                            <asp:Panel ID="pnlAliasRow" runat="server" CssClass="pform-row">
                                <span class="pform-lbl">Alias</span> <span class="pform-val">
                                    <asp:TextBox ID="txtAlias" runat="server" CssClass="pinput" Style="width: 200px" />
                                </span>
                            </asp:Panel>
                            <!-- Control A/C -->
                            <asp:Panel ID="pnlControlRow" runat="server" CssClass="pform-row">
                                <span class="pform-lbl">Control A/C</span> <span class="pform-val">
                                    <asp:CheckBox ID="chkControlAC" runat="server" />
                                </span>
                            </asp:Panel>
                            <!-- Visibility section -->
                            <asp:Panel ID="pnlTransRow" runat="server" CssClass="section-box">
                                <div class="section-title">
                                    Visibility</div>
                                <span class="pform-lbl">Transacted At</span>
                                <asp:DropDownList ID="ddlTransactedAt" runat="server" CssClass="pinput">
                                    <asp:ListItem>All Branches</asp:ListItem>
                                    <asp:ListItem>This Branch Only</asp:ListItem>
                                </asp:DropDownList>
                            </asp:Panel>
                            <!-- Currency section -->
                            <asp:Panel ID="pnlCurrencyRow" runat="server" CssClass="section-box">
                                <div class="section-title">
                                    Currency</div>
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <!-- Radio -->
                                    <asp:RadioButtonList ID="rblCurrencyType" runat="server" RepeatDirection="Horizontal"
                                        CssClass="inline-radio">
                                        <asp:ListItem Text="Fixed" Value="FIXED" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Multiple" Value="MULTI"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <!-- Dropdown -->
                                    <asp:DropDownList ID="ddlFixedCurrency" runat="server" CssClass="pinput" Width="100px">
                                        <asp:ListItem>INR</asp:ListItem>
                                        <asp:ListItem>USD</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </asp:Panel>
                            <!-- Validation summary -->
                            <asp:ValidationSummary ID="vsPopup" runat="server" ValidationGroup="vgPopup" CssClass="val-msg err-panel"
                                ShowMessageBox="false" ShowSummary="true" DisplayMode="BulletList" />
                            <!-- Message label -->
                        </div>
                        <!-- /ptab-glaccount -->
                    </div>
                    <!-- /popupBody -->
                    <!-- Popup footer -->
                    <div id="popupFooter">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="52" OnClick="btnSave_Click"
                                CommandName="s" />
                        </div>
                        <div id="editbu" style="width: 95px;">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                TabIndex="19" OnClientClick="return validate();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" Text="Delete" CausesValidation="false"
                                OnClick="btnDelete_Click" OnClientClick="return confirm('Do you want to delete this record?');" />
                            <asp:Button ID="btn" runat="server" TabIndex="63" CausesValidation="false" UseSubmitBehavior="false"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- /popupWindow -->
        </div>
    </div>
    <!-- /popupOverlay -->
    <script>
        function toggleNode(el) {
            // el = .tree-node div; el.parentElement = <li>
            var li = el.parentElement;

            // Find ONLY the direct child <ul> of this <li>
            var children = Array.from(li.children).find(function (c) {
                return c.tagName === 'UL' && c.classList.contains('tree-children');
            });

            if (!children) return; // leaf node &#8212; no children ul

            var toggle = el.querySelector('.toggle');
            var nodeId = el.getAttribute('data-id');

            var hdn = document.getElementById('<%= hdnExpandedNodes.ClientID %>');
            var expanded = hdn.value
        ? hdn.value.split(',').filter(function (x) { return x !== ''; })
        : [];

            if (children.classList.contains('open')) {
                // Collapse
                children.classList.remove('open');
                if (toggle) toggle.innerHTML = "<i class='fa fa-caret-right'></i>";
                expanded = expanded.filter(function (x) { return x !== nodeId; });
            } else {
                // Expand
                children.classList.add('open');
                if (toggle) toggle.innerHTML = "<i class='fa fa-caret-down'></i>";
                if (expanded.indexOf(nodeId) === -1) expanded.push(nodeId);
            }

            hdn.value = expanded.join(',');
        }

        function selectLeaf(el, id, name, type) {
            document.querySelectorAll('.tree-node').forEach(function (n) {
                n.classList.remove('selected');
            });
            el.classList.add('selected');

            document.getElementById('<%= hdnSelectedId.ClientID %>').value = id;
            document.getElementById('<%= hdnSelectedCode.ClientID %>').value = id;
            document.getElementById('<%= hdnParentId.ClientID %>').value = id;

            saveExpandedNodes();

            // Only LEDGER nodes post back (to show the details panel)
            if (type === 'LEDGER') {
                __doPostBack('LoadDetails', id.toString());
            }
            // GROUP/SUBGROUP: selection stored in hidden fields only.
            // Edit/New buttons read hdnSelectedId on their own postback.
        }

        function saveExpandedNodes() {
            var expanded = [];
            document.querySelectorAll('.tree-children.open').forEach(function (ul) {
                // ul.parentElement = <li>; first .tree-node child = the owner node div
                var li = ul.parentElement;
                var nodeDiv = Array.from(li.children).find(function (c) {
                    return c.classList.contains('tree-node');
                });
                if (nodeDiv) {
                    var id = nodeDiv.getAttribute('data-id');
                    if (id && expanded.indexOf(id) === -1) expanded.push(id);
                }
            });
            document.getElementById('<%= hdnExpandedNodes.ClientID %>').value = expanded.join(',');
        }


        function openPopup() {
            document.getElementById('popupOverlay').classList.add('open');
        }
        function closePopup() {
            document.getElementById('popupOverlay').classList.remove('open');
        }
        function switchPopupTab(name, btn) {
            document.querySelectorAll('.ptab-btn').forEach(function (b) { b.classList.remove('active'); });
            document.querySelectorAll('.ptab-panel').forEach(function (p) { p.style.display = 'none'; });
            btn.classList.add('active');
            var panel = document.getElementById('ptab-' + name);
            if (panel) panel.style.display = 'block';
        }
        function toggleFixedCurrency(enable) {
            var ddl = document.getElementById('<%= ddlFixedCurrency.ClientID %>');
            if (ddl) ddl.disabled = !enable;
        }

        document.addEventListener('DOMContentLoaded', function () {

            if ('<%= ShowPopupOnLoad %>' === 'true') {
                openPopup();
            }

            var serverButtons = document.querySelectorAll(
        'input[type="submit"], input[type="button"][id]'
    );
            serverButtons.forEach(function (btn) {
                btn.addEventListener('click', function () {
                    saveExpandedNodes();
                });
            });
        });

        function restoreExpandedNodes() {
            var hdn = document.getElementById('<%= hdnExpandedNodes.ClientID %>');
            alert(hdn);
            if (!hdn || !hdn.value) return;

            var expanded = hdn.value.split(',');

            expanded.forEach(function (id) {
                var node = document.querySelector(".tree-node[data-id='" + id + "']");
                if (!node) return;

                var children = node.parentElement.querySelector('.tree-children');
                var toggle = node.querySelector('.toggle');

                if (children) {
                    children.classList.add('open');
                    if (toggle) toggle.innerHTML = "<i class='fa fa-caret-down'></i>";
                }
            });
        }
        //        if ('<%= ShowPopupOnLoad %>' === 'true') {
        //            openPopup();
        //        }
    </script>
</asp:Content>
