<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_SW_Bulk.aspx.cs" Inherits="Imp_SupDocs_Bulk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import SW Bulk Entry</title>
    <link href="../css/MainStyle.css"               rel="stylesheet" type="text/css" />
    <link href="../main.css"                        rel="stylesheet" type="text/css" />
    <link href="../gridmain.css"                    rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css"        type="text/css" />
    <link href="../tabs/tabs.css"                   rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js"        type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet"    type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/js_bootstrap/jquery.min.js"    type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet"    type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>

    <style type="text/css">
        body { font-family: Arial, Helvetica, sans-serif; font-size: 12px;
               background: #f0f2f5; margin: 0; padding: 0; }

        #page_title_bar { background: #003366; color: #fff; font-size: 13px;
            font-weight: bold; padding: 6px 12px; height: 26px; line-height: 26px; }

        #main_container { width: 1200px; margin: 0; padding: 10px 14px 16px 14px;
            background: #fff; border: 1px solid #c8d4e0; }

        .jobno_row { padding: 4px 0 8px 0; border-bottom: 2px solid #003366; margin-bottom: 10px; }

        /* Top filter */
        .top_filter { display: table; width: 100%; background: #f7fafd;
            border: 1px solid #cdd8e3; border-radius: 3px; padding: 8px 12px;
            margin-bottom: 10px; box-sizing: border-box; }
        .fcell { display: table-cell; vertical-align: top; padding-right: 20px; white-space: nowrap; }
        .fcell:last-child { padding-right: 0; }
        .flabel { display: block; color: #003366; font-size: 11px; font-weight: bold;
            margin-bottom: 4px; text-transform: uppercase; letter-spacing: 0.3px; }

        .ddl_ritc { font-size: 12px; height: 25px; border: 2px solid #f0a500;
            background: #fffbf0; font-weight: bold; color: #003366; width: 165px; border-radius: 3px; }

        /* Mode + Dept dropdowns (DEPT mode) */
        .ddl_mode { font-size: 12px; height: 25px; border: 2px solid #2e6b00;
            background: #f2fff2; font-weight: bold; color: #003366; width: 120px; border-radius: 3px; }
        .ddl_dept { font-size: 12px; height: 25px; border: 2px solid #5a7fa0;
            background: #f0f8ff; font-weight: bold; color: #003366; width: 165px; border-radius: 3px; }

        /* RITC multi-select (DEPT mode) */
        .ritc_wrap { border: 1px solid #f0a500; background: #fffbf0;
            width: 200px; max-height: 130px; overflow-y: auto; padding: 5px; border-radius: 2px; }
        .txt_ritc  { font-size: 12px; height: 23px; border: 2px solid #f0a500;
            background: #fffbf0; width: 200px; padding: 1px 6px; border-radius: 2px;
            cursor: pointer; font-weight: bold; color: #003366; }

        /* Inv/Item */
        .invitem_wrap { border: 1px solid #7bafd4; background: #f0f8ff;
            width: 240px; max-height: 130px; overflow-y: auto; padding: 5px; border-radius: 2px; }
        .txt_invitem  { font-size: 12px; height: 23px; border: 1px solid #7bafd4;
            background: #f0f8ff; width: 240px; padding: 1px 6px; border-radius: 2px; cursor: pointer; }
        .sel_link { font-size: 10px; color: #003366; text-decoration: underline; cursor: pointer; margin-left: 6px; }
        .hint_txt { font-size: 10px; color: #888; display: block; margin-top: 2px; }

        .no_dept_msg { color: #cc0000; font-size: 12px; padding: 6px 0; }

        /* Dept section */
        .dept_section { border: 1px solid #7bafd4; border-radius: 4px; margin-bottom: 10px; overflow: hidden; }
        .dept_header  { background: #003366; color: #fff; padding: 5px 12px;
            font-size: 12px; font-weight: bold; letter-spacing: 0.5px; }

        /* Grid */
        .tbl_info { border-collapse: collapse; width: 100%; }
        .tbl_info thead tr  { background: #e8f0fe; }
        .tbl_info thead td  { color: #003366; font-size: 11px; font-weight: bold;
            padding: 5px 8px; border-bottom: 2px solid #7bafd4;
            border-right: 1px solid #c8d4e0; white-space: nowrap; }
        .tbl_info tbody tr.r0 { background: #ffffff; }
        .tbl_info tbody tr.r1 { background: #f5f9ff; }
        .tbl_info tbody td  { padding: 5px 7px; border-bottom: 1px solid #dde8f0;
            border-right: 1px solid #e8eef5; font-size: 12px; vertical-align: middle; }

        /* Controls inside grid */
        .ddl_code { font-size: 11px; height: 22px; border: 1px solid #7bafd4;
            background: #f0f8ff; width: 210px; border-radius: 2px; }
        .ddl_uqc  { font-size: 11px; height: 22px; border: 1px solid #7bafd4;
            background: #f0fff4; width: 145px; border-radius: 2px; }
        .txt_info { font-size: 11px; height: 20px; border: 1px solid #7bafd4;
            background: #fffff0; width: 200px; padding: 1px 4px; border-radius: 2px; }
        .txt_msr  { font-size: 11px; height: 20px; border: 1px solid #7bafd4;
            background: #fffff0; width: 80px; padding: 1px 4px; border-radius: 2px; }
        .lbl_fixed { color: #003366; font-weight: bold; }
        .dash { color: #bbb; }

        /* Buttons */
        .btn_row  { padding: 8px 0 2px 0; }
        .btn_save { background: #003366; color: #fff; font-size: 12px; font-weight: bold;
            border: 1px solid #001933; width: 100px; height: 28px; cursor: pointer; border-radius: 3px; margin-right: 6px; }
        .btn_update { background: #2e6b00; color: #fff; font-size: 12px; font-weight: bold;
            border: 1px solid #1a3f00; width: 110px; height: 28px; cursor: pointer; border-radius: 3px; margin-right: 6px; }
        .btn_delete { background: #990000; color: #fff; font-size: 12px; font-weight: bold;
            border: 1px solid #660000; width: 90px; height: 28px; cursor: pointer; border-radius: 3px; }
        .loading { text-align: center; }

        /* Refresh button */
        .btn_refresh { background: #5a7fa0; color: #fff; font-size: 12px; font-weight: bold;
            border: 1px solid #3a5f80; width: 90px; height: 28px; cursor: pointer;
            border-radius: 3px; }
        .btn_refresh:hover { background: #3a5f80; }

        /* ââ New button ââ */
        .btn_new { background: #5a5a5a; color: #fff; font-size: 12px; font-weight: bold;
            border: 1px solid #333; width: 80px; height: 28px; cursor: pointer;
            border-radius: 3px; margin-right: 6px; }

        /* ââ Saved records grid ââ */
        .tbl_saved { border-collapse: collapse; width: 100%;
            border: 1px solid #7bafd4; font-size: 11px; }
        .tbl_saved th { background: #e8f0fe; color: #003366; font-weight: bold;
            padding: 5px 7px; border: 1px solid #c8d4e0; text-align: left; }
        .tbl_saved td { padding: 4px 7px; border-bottom: 1px solid #dde8f0;
            border-right: 1px solid #e8eef5; vertical-align: middle; }
        .tbl_saved tr:hover td { background: #fff8e1 !important; cursor: pointer; }

        /* ââ Edit link in grid ââ */
    </style>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"
    EnablePartialRendering="false" LoadScriptsBeforeUI="false" EnablePageMethods="true">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

    <div class="loading" id="load" style="display:none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>

    <div id="page_title_bar">Import Single Window &nbsp;&ndash;&nbsp; SW Info Bulk Entry</div>

    <div id="main_container">

        <!-- JOB NO -->
        <div class="jobno_row">
            <span style="color:#003366;font-size:14px;font-weight:bold;">Job No &nbsp;:&nbsp;</span>
            <span style="color:#cc0000;font-size:14px;font-weight:bold;">
                <asp:Literal ID="lbljobno" runat="server"></asp:Literal>
            </span>
            <asp:HiddenField ID="hfJobNo"       runat="server" />
            <asp:HiddenField ID="hfBranchType"  runat="server" />
            <asp:HiddenField ID="hfEditSwId"    runat="server" Value="0" />
        </div>

                <!-- TOP FILTER: RITC | INV/ITEM | REFRESH &#8212; wraps instead of overflowing -->
                    <div style="display:flex;flex-wrap:wrap;align-items:flex-end;
                                width:100%;background:#f7fafd;border:1px solid #cdd8e3;
                                border-radius:3px;margin-bottom:10px;box-sizing:border-box;padding:7px 10px;">

                        <!-- MODE: RITC / DEPT -->
                        <div style="padding:0 14px 6px 0;white-space:nowrap;">
                            <span class="flabel">Based On</span>
                            <asp:DropDownList ID="ddl_Mode" runat="server"
                                CssClass="ddl_mode" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_Mode_SelectedIndexChanged">
                                <asp:ListItem Text="RITC" Value="RITC" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="DEPT" Value="DEPT"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- RITC (RITC mode) -->
                        <div id="td_RITC" runat="server" style="padding:0 14px 6px 0;white-space:nowrap;">
                            <span class="flabel">RITC No</span>
                            <asp:DropDownList ID="ddl_RITC" runat="server"
                                CssClass="ddl_ritc" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_RITC_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <!-- DEPT (DEPT mode) -->
                        <div id="td_Dept" runat="server" visible="false" style="padding:0 14px 6px 0;white-space:nowrap;">
                            <span class="flabel">Department</span>
                            <asp:DropDownList ID="ddl_Dept" runat="server"
                                CssClass="ddl_dept" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_Dept_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <!-- RITC MULTI-SELECT (DEPT mode) -->
                        <div id="td_RitcMulti" runat="server" visible="false" style="padding:0 14px 6px 0;white-space:nowrap;">
                            <span class="flabel">
                                RITC (multi) &nbsp;
                                <span class="sel_link" onclick="selectAllRitc(true)">All</span>
                                <span class="sel_link" onclick="selectAllRitc(false)">None</span>
                            </span>
                            <div style="position:relative;display:inline-block;">
                                <asp:TextBox ID="txt_Ritc" runat="server"
                                    CssClass="txt_ritc" ReadOnly="true"
                                    onclick="toggleRitcList()">
                                </asp:TextBox>
                                <div id="divRitc" class="ritc_wrap"
                                    style="display:none;position:absolute;top:25px;left:0;z-index:999;">
                                    <asp:CheckBoxList ID="chk_RITC" runat="server"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="chk_RITC_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>

                        <!-- INV / ITEM -->
                        <div style="padding:0 14px 6px 0;white-space:nowrap;">
                            <span class="flabel">
                                Inv / Item &nbsp;
                                <span class="sel_link" onclick="selectAllInvItem(true)">All</span>
                                <span class="sel_link" onclick="selectAllInvItem(false)">None</span>
                            </span>
                            <div style="position:relative;display:inline-block;">
                                <asp:TextBox ID="txt_InvItem" runat="server"
                                    CssClass="txt_invitem" ReadOnly="true"
                                    onclick="toggleInvItemList()">
                                </asp:TextBox>
                                <div id="divInvItem" class="invitem_wrap"
                                    style="display:none;position:absolute;top:25px;left:0;z-index:999;">
                                    <asp:CheckBoxList ID="chk_InvItem" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>

                        <!-- PART NO -->
                        <div style="padding:0 14px 6px 0;white-space:nowrap;">
                            <span class="flabel">Part No</span>
                            <asp:DropDownList ID="ddl_PartNo" runat="server"
                                CssClass="ddl_ritc" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_PartNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <!-- REFRESH -->
                        <div style="padding:0 0 6px 0;white-space:nowrap;">
                            <span class="flabel">&nbsp;</span>
                            <asp:Button ID="btnRefresh" runat="server"
                                Text="&#x21BB; Refresh"
                                CssClass="btn_refresh"
                                OnClick="btnRefresh_Click"
                                TabIndex="5"
                                ToolTip="Reload page data" />
                        </div>

                    </div>

                <!-- spacer -->
                <td style="width:100%;"></td>

            </tr>
        </table>

        <asp:Label ID="lblNoDept" runat="server" CssClass="no_dept_msg" Visible="false"></asp:Label>

        <!-- ALL DEPTS PANEL -->
        <asp:Panel ID="pnl_AllDepts" runat="server" Visible="false">

            <asp:Repeater ID="rpt_Depts" runat="server">
                <ItemTemplate>

                    <div class="dept_section">
                        <div class="dept_header">
                            &nbsp;&#9658;&nbsp;
                            <asp:Label ID="lbl_DeptName" runat="server"></asp:Label>
                            &nbsp;&mdash;&nbsp;Info Entries
                        </div>

                        <table class="tbl_info" cellspacing="0" cellpadding="0">
                            <thead>
                                <tr>
                                    <td style="width:28px;">#</td>
                                    <td style="width:195px;">Info Type</td>
                                    <td style="width:230px;">Info Qualifier</td>
                                    <td style="width:220px;">Info Code</td>
                                    <td style="width:210px;">Info Text</td>
                                    <td style="width:90px;">MSR</td>
                                    <td style="width:155px;">UQC</td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpt_DeptRows" runat="server">
                                    <ItemTemplate>
                                        <tr class='<%# Container.ItemIndex % 2 == 0 ? "r0" : "r1" %>'>

                                            <td><%# Container.ItemIndex + 1 %></td>

                                            <!-- Info Type -->
                                            <td>
                                                <span class="lbl_fixed"><%# Eval("InfoTypeDesc") %></span>
                                                <asp:HiddenField ID="hf_InfoType" runat="server"
                                                    Value='<%# Eval("InfoTypeCode") %>' />
                                            </td>

                                            <!-- Info Qualifier -->
                                            <td>
                                                <span class="lbl_fixed"><%# Eval("InfoQualDesc") %></span>
                                                <asp:HiddenField ID="hf_InfoQual" runat="server"
                                                    Value='<%# Eval("InfoQualCode") %>' />
                                                <%-- Per-row SW_INFO_TYPE_ID for update (set by Load_Saved_Grid) --%>
                                                <asp:HiddenField ID="hf_SwId" runat="server" Value="0" />
                                            </td>

                                            <!-- Info Code dropdown -->
                                            <td>
                                                <asp:DropDownList ID="ddl_Code" runat="server"
                                                    CssClass="ddl_code"
                                                    Visible='<%# (bool)Eval("NeedsInfoCode") || (bool)Eval("IsYesNo") %>'>
                                                </asp:DropDownList>
                                                <span class="dash"
                                                    <%# (!((bool)Eval("NeedsInfoCode")) && !((bool)Eval("IsYesNo"))) ? "" : "style='display:none'" %>
                                                >&#8212;</span>
                                            </td>

                                            <!-- Info Text -->
                                            <td>
                                                <asp:TextBox ID="txt_Text" runat="server"
                                                    CssClass="txt_info" MaxLength="2000"
                                                    Visible='<%# (bool)Eval("NeedsInfoText") %>'>
                                                </asp:TextBox>
                                                <span class="dash"
                                                    <%# (bool)Eval("NeedsInfoText") ? "style='display:none'" : "" %>
                                                >&#8212;</span>
                                            </td>

                                            <!-- MSR -->
                                            <td>
                                                <asp:TextBox ID="txt_MSR" runat="server"
                                                    CssClass="txt_msr" MaxLength="50"
                                                    Visible='<%# (bool)Eval("NeedsMSR") %>'>
                                                </asp:TextBox>
                                                <span class="dash"
                                                    <%# (bool)Eval("NeedsMSR") ? "style='display:none'" : "" %>
                                                >&#8212;</span>
                                            </td>

                                            <!-- UQC â static 2 items: KGS, NOS -->
                                            <td>
                                                <asp:DropDownList ID="ddl_UQC" runat="server"
                                                    CssClass="ddl_uqc"
                                                    Visible='<%# (bool)Eval("NeedsUQC") %>'>
                                                    <asp:ListItem Text="-- UQC --" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="KGS" Value="KGS"></asp:ListItem>
                                                    <asp:ListItem Text="NOS" Value="NOS"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="dash"
                                                    <%# (bool)Eval("NeedsUQC") ? "style='display:none'" : "" %>
                                                >&#8212;</span>
                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </asp:Panel>

        <!-- BUTTONS -->
        <div class="btn_row">
            <asp:Button ID="btnsave"    runat="server" Text="&#x2714; Bulk Save"
                CssClass="btn_save"   OnClick="btnsave_Click"   TabIndex="10" />
            <%--<asp:Button ID="btnNew"     runat="server" Text="&#x2795; New"
                CssClass="btn_new"    OnClick="btnNew_Click"    TabIndex="11" Visible="false" />--%>
            <asp:Button ID="btn_Update" runat="server" Text="&#x270E; Bulk Update"
                CssClass="btn_update" OnClick="btn_Update_Click" TabIndex="12" Visible="false" />
            <asp:Button ID="btndelete"  runat="server" Text="&#x2716; Delete"
                CssClass="btn_delete" OnClick="btndelete_Click"  TabIndex="13" Visible="false" />
        </div>

        <!-- SAVED RECORDS GRID -->
        <asp:Panel ID="pnl_SavedGrid" runat="server" Visible="false">
            <div style="margin-top:12px;">
                <div class="dept_header" style="border-radius:4px 4px 0 0;">
                    &nbsp;&#9776;&nbsp; Saved SW Info Records
                </div>
                <asp:GridView ID="gvSaved" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="tbl_saved"
                    DataKeyNames="SW_INFO_TYPE_ID"
                    GridLines="Horizontal"
                    HeaderStyle-BackColor="#e8f0fe"
                    AlternatingRowStyle-BackColor="#f5f9ff">
                    <Columns>
                        <asp:BoundField DataField="INVOICE_SLNO"   HeaderText="Inv"         ItemStyle-Width="35px"  />
                        <asp:BoundField DataField="ITEM_SLNO"      HeaderText="Item"        ItemStyle-Width="35px"  />
                        <asp:BoundField DataField="DEPARTMENT"     HeaderText="Dept"        ItemStyle-Width="60px"  />
                        <asp:BoundField DataField="INFO_TYPE"      HeaderText="Info Type"   ItemStyle-Width="90px"  />
                        <asp:BoundField DataField="INFO_QUALIFIER" HeaderText="Qualifier"   ItemStyle-Width="90px"  />
                        <asp:BoundField DataField="INFO_CODE"      HeaderText="Code"        ItemStyle-Width="90px"  />
                        <asp:BoundField DataField="INFO_TEXT"      HeaderText="Text"        ItemStyle-Width="130px" />
                        <asp:BoundField DataField="INFO_MSR"       HeaderText="MSR"         ItemStyle-Width="55px"  />
                        <asp:BoundField DataField="INFO_UQC"       HeaderText="UQC"         ItemStyle-Width="60px"  />
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="padding:8px;color:#888;text-align:center;">No saved records found.</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </asp:Panel>

    </div>

    <!-- Modal -->
    <asp:ModalPopupExtender ID="MP_JOB" runat="server"
        TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12"
        align="left" BorderColor="Transparent">
        <div style="width:400px;height:20px;font-weight:bold;color:Blue;margin-left:90px;">
            <asp:Label ID="lbl_heading" runat="server"></asp:Label>
        </div>
    </asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>
</form>

<script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
<script type="text/javascript" src="../modalfiles/modal.js"></script>
<script type="text/javascript" src="../js/Validation.js"></script>

<script type="text/javascript">
    function toggleInvItemList() {
        var div = document.getElementById("divInvItem");
        if (!div) return;
        div.style.display = (div.style.display === "none") ? "block" : "none";
    }

    document.addEventListener("click", function (ev) {
        var div = document.getElementById("divInvItem");
        var txt = document.getElementById('<%= txt_InvItem.ClientID %>');
        if (!div || !txt) return;
        if (!div.contains(ev.target) && ev.target !== txt)
            div.style.display = "none";
    });

    function updateInvItemText() {
        var wrap = document.getElementById('<%= chk_InvItem.ClientID %>');
        if (!wrap) return;
        var inputs = wrap.getElementsByTagName("input");
        var sel = [];
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type === "checkbox" && inputs[i].checked) {
                var lbl = inputs[i].parentNode.innerText || inputs[i].parentNode.textContent;
                sel.push(lbl.trim());
            }
        }
        var txt = document.getElementById('<%= txt_InvItem.ClientID %>');
        if (txt) txt.value = sel.join(", ");
    }

    function selectAllInvItem(check) {
        var wrap = document.getElementById('<%= chk_InvItem.ClientID %>');
        if (!wrap) return;
        var inputs = wrap.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type === "checkbox") inputs[i].checked = check;
        }
        updateInvItemText();
    }

    function attachInvItemHandlers() {
        var wrap = document.getElementById('<%= chk_InvItem.ClientID %>');
        if (!wrap) return;
        var inputs = wrap.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type === "checkbox")
                inputs[i].onclick = function () { updateInvItemText(); };
        }
    }

    /* ââ RITC multi-select (DEPT mode) ââ */
    function toggleRitcList() {
        var div = document.getElementById("divRitc");
        if (!div) return;
        div.style.display = (div.style.display === "none") ? "block" : "none";
    }

    document.addEventListener("click", function (ev) {
        var div = document.getElementById("divRitc");
        var txt = document.getElementById('<%= txt_Ritc.ClientID %>');
        if (!div || !txt) return;
        if (!div.contains(ev.target) && ev.target !== txt)
            div.style.display = "none";
    });

    function updateRitcText() {
        var wrap = document.getElementById('<%= chk_RITC.ClientID %>');
        if (!wrap) return;
        var inputs = wrap.getElementsByTagName("input");
        var sel = [];
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type === "checkbox" && inputs[i].checked) {
                var lbl = inputs[i].parentNode.innerText || inputs[i].parentNode.textContent;
                sel.push(lbl.trim());
            }
        }
        var txt = document.getElementById('<%= txt_Ritc.ClientID %>');
        if (txt) txt.value = sel.join(", ");
    }

    function selectAllRitc(check) {
        var wrap = document.getElementById('<%= chk_RITC.ClientID %>');
        if (!wrap) return;
        var inputs = wrap.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type === "checkbox") inputs[i].checked = check;
        }
        updateRitcText();
        // chk_RITC is AutoPostBack â but JS-checking boxes doesn't raise the
        // server event. Trigger a postback so the server rebuilds the combined
        // inv/item list + dept section for ALL ticked RITCs.
        if (typeof __doPostBack === "function")
            __doPostBack('<%= chk_RITC.UniqueID %>', '');
    }

    window.onload = attachInvItemHandlers;

    if (typeof Sys !== "undefined") {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            attachInvItemHandlers();
        });
    }
</script>

</body>
</html>
