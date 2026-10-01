<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Combined_Job.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Combined_Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        /* Scoped to this page only - won't touch master page header/sidebar styles */
        #unifiedJobRoot { font-family: 'Segoe UI', Arial, sans-serif; background-color: #f1f5f9; padding: 20px; color: #1e293b; box-sizing: border-box; }
        #unifiedJobRoot * { box-sizing: border-box; }

        #unifiedJobRoot .main-workspace { max-width: 1300px; margin: 0 auto; background: #ffffff; border: 1px solid #cbd5e1; border-radius: 10px; box-shadow: 0 4px 25px rgba(0,0,0,0.06); padding: 25px; height: calc(100vh - 140px); overflow-y: scroll; scrollbar-width: thin; scrollbar-color: #94a3b8 #f1f5f9; }
        #unifiedJobRoot .main-workspace::-webkit-scrollbar { width: 10px; }
        #unifiedJobRoot .main-workspace::-webkit-scrollbar-track { background: #f1f5f9; border-radius: 10px; }
        #unifiedJobRoot .main-workspace::-webkit-scrollbar-thumb { background-color: #94a3b8; border-radius: 10px; border: 2px solid #f1f5f9; }
        #unifiedJobRoot .main-workspace::-webkit-scrollbar-thumb:hover { background-color: #64748b; }

        
        #unifiedJobRoot .sticky-top-section { position: sticky; top: 0; margin: -25px -25px 0 -25px; padding: 25px 25px 0 25px; z-index: 50; background: #fff; box-shadow: 0 6px 8px -6px rgba(0,0,0,0.10); }

        #unifiedJobRoot .page-header { border-bottom: 2px solid #e2e8f0; padding-bottom: 15px; margin-bottom: 25px; display: flex; align-items: center; justify-content: space-between; flex-wrap: wrap; gap: 16px; }
        #unifiedJobRoot .page-header h1 { margin: 0; font-size: 26px; color: #0f172a; font-weight: 700; letter-spacing: -0.5px; flex-shrink: 0; }
        #unifiedJobRoot .header-controls { display: flex; align-items: center; gap: 24px; flex-wrap: wrap; }
        #unifiedJobRoot .header-field { display: flex; align-items: center; gap: 10px; position: relative; }
        #unifiedJobRoot .header-field label { font-weight: 600; font-size: 13px; color: #475569; white-space: nowrap; }
        #unifiedJobRoot .header-select { padding: 7px 10px; border: 1.5px solid #94a3b8; font-size: 13px; background: #fff; border-radius: 6px; color: #0f172a; min-width: 190px; }
        #unifiedJobRoot .exporter-select { min-width: 240px !important; width: 240px; }
        #unifiedJobRoot .mode-select { min-width: 80px !important; width: 80px; }

        #unifiedJobRoot .grid-panel { background: #ffffff; border: 1px solid #cbd5e1; border-radius: 8px; padding: 18px; box-shadow: 0 2px 4px rgba(0,0,0,0.01); margin-bottom: 25px; }
        #unifiedJobRoot .panel-title { font-weight: 700; font-size: 13px; color: #475569; margin-bottom: 14px; text-transform: uppercase; letter-spacing: 0.5px; border-bottom: 1px solid #f1f5f9; padding-bottom: 8px; }

        #unifiedJobRoot .checkbox-stack { display: flex; flex-wrap: wrap; align-items: center; column-gap: 32px; row-gap: 10px; }
        #unifiedJobRoot .checkbox-item { display: flex; align-items: center; font-size: 13.5px; font-weight: 600; color: #334155; cursor: pointer; white-space: nowrap; }
        #unifiedJobRoot .checkbox-item input { margin-right: 10px; width: 17px; height: 17px; cursor: pointer; }

        #unifiedJobRoot .section-box { background: #fff; border: 1px solid #cbd5e1; border-radius: 8px; overflow: hidden; box-shadow: 0 2px 4px rgba(0,0,0,0.01); margin-bottom: 20px; }
        #unifiedJobRoot .section-box-title { font-weight: 700; font-size: 13px; color: #2563eb; padding: 12px 16px; background: #eff6ff; border-bottom: 2px solid #dbeafe; text-transform: uppercase; letter-spacing: 0.5px; }

        #unifiedJobRoot .summary-grid { display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px 20px; padding: 14px 16px; }
        #unifiedJobRoot .summary-item label { display: block; font-size: 11px; font-weight: 700; color: #94a3b8; text-transform: uppercase; margin-bottom: 2px; }
        #unifiedJobRoot .summary-item span { font-size: 13.5px; color: #0f172a; font-weight: 600; }
        #unifiedJobRoot .multi-note { font-size: 12px; color: #b45309; background: #fffbeb; border-top: 1px solid #fde68a; padding: 8px 16px; }

        #unifiedJobRoot .tbl-scroll-area { max-height: 260px; overflow-y: scroll; scrollbar-width: thin; scrollbar-color: #94a3b8 #f1f5f9; }
        #unifiedJobRoot .tbl-scroll-area::-webkit-scrollbar { width: 9px; }
        #unifiedJobRoot .tbl-scroll-area::-webkit-scrollbar-track { background: #f1f5f9; }
        #unifiedJobRoot .tbl-scroll-area::-webkit-scrollbar-thumb { background-color: #94a3b8; border-radius: 8px; border: 2px solid #f1f5f9; }
        #unifiedJobRoot .tbl-scroll-area::-webkit-scrollbar-thumb:hover { background-color: #64748b; }
        #unifiedJobRoot .tbl-unified { width: 100%; border-collapse: collapse; table-layout: fixed; }
        #unifiedJobRoot .tbl-unified thead th {
            position: sticky; top: 0; z-index: 2;
            background: #f8fafc; padding: 11px 14px; font-size: 12.5px; font-weight: 700;
            color: #475569; text-align: left; text-transform: uppercase; letter-spacing: 0.4px;
            border-bottom: 2px solid #e2e8f0;
        }
        #unifiedJobRoot .tbl-unified td {
            padding: 10px 14px; font-size: 13px; color: #334155;
            border-bottom: 1px solid #f1f5f9; text-align: left;
            overflow: hidden; text-overflow: ellipsis; white-space: nowrap;
        }
        #unifiedJobRoot .tbl-unified tr:last-child td { border-bottom: none; }
        #unifiedJobRoot .tbl-unified tbody tr:hover td { background: #f8fafc; }
        #unifiedJobRoot .tbl-unified tr.empty-row td { color: #94a3b8 !important; background: transparent !important; font-style: italic; }
        #unifiedJobRoot .tbl-unified tr.excluded-row td { color: #cbd5e1 !important; text-decoration: line-through; }
        #unifiedJobRoot .sel-col { width: 42px !important; text-align: center !important; }
        #unifiedJobRoot .src-col { width: 90px !important; }

        #unifiedJobRoot .pagination-bar { display: flex; align-items: center; justify-content: space-between; padding: 9px 14px; border-top: 1px solid #e2e8f0; background: #f8fafc; }
        #unifiedJobRoot .pagination-info { font-size: 12.5px; color: #64748b; font-weight: 600; }

        #unifiedJobRoot .outside-footer-panel { max-width: 1300px; margin: 20px auto 0 auto; display: flex; justify-content: flex-end; align-items: center; gap: 12px; position: sticky; bottom: 0; background: #f1f5f9; padding: 12px 25px; z-index: 40; box-shadow: 0 -6px 10px -6px rgba(0,0,0,0.10); border-radius: 0 0 10px 10px; }
        #unifiedJobRoot .action-btn { background: #fff; color: #334155; border: 1px solid #cbd5e1; padding: 9px 22px; font-size: 13.5px; font-weight: 600; cursor: pointer; border-radius: 6px; transition: all 0.2s; }
        #unifiedJobRoot .btn-preview { background: #2563eb; color: #fff; border-color: #2563eb; }
        #unifiedJobRoot .btn-preview:hover { background: #1d4ed8; }
        #unifiedJobRoot .btn-generate { background: #16a34a; color: #fff; border-color: #16a34a; }
        #unifiedJobRoot .btn-generate:hover { background: #15803d; }
        #unifiedJobRoot .btn-clear { background: #fff; color: #dc2626; border-color: #fca5a5; }
        #unifiedJobRoot .btn-clear:hover { background: #fef2f2; }
        #unifiedJobRoot .newjob-input { padding: 7px 10px; border: 1px solid #cbd5e1; border-radius: 6px; font-size: 13px; width: 160px; }

        #unifiedJobRoot .jobno-box { padding: 7px 30px 7px 10px; border: 1.5px solid #94a3b8; border-radius: 6px; background: #fff url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" width="10" height="6"><path d="M0 0l5 6 5-6z" fill="%23475569"/></svg>') no-repeat right 10px center; font-size: 13px; color: #0f172a; min-width: 190px; cursor: pointer; }
        #unifiedJobRoot .jobno-dropdown { position: absolute; top: 38px; right: 0; z-index: 9999; background: #fff; border: 1px solid #cbd5e1; border-radius: 6px; box-shadow: 0 6px 16px rgba(0,0,0,0.12); max-height: 240px; overflow-y: auto; min-width: 190px; padding: 6px 0; }
        #unifiedJobRoot .ms-job-table { border-collapse: collapse; width: 100%; }
        #unifiedJobRoot .ms-job-table td { padding: 0; }
        #unifiedJobRoot .ms-job-table input[type="checkbox"] { vertical-align: middle; margin: 0 8px 0 12px; cursor: pointer; }
        #unifiedJobRoot .ms-job-table label { display: inline-flex; align-items: center; padding: 8px 12px 8px 0; font-size: 13px; color: #0f172a; cursor: pointer; white-space: nowrap; vertical-align: middle; }
        #unifiedJobRoot .ms-job-table tr:hover td { background: #eff6ff; }

        #unifiedJobRoot .selected-jobs-strip { font-size: 12px; color: #2563eb; padding: 0 16px 10px 16px; }

        .ujModalBox {
            background: #fff !important;
            width: 360px !important;
            max-width: 360px !important;
            height: auto !important;
            padding: 24px !important;
            border-radius: 8px !important;
            box-shadow: 0 8px 30px rgba(0,0,0,0.2) !important;
            box-sizing: border-box !important;
            font-family: 'Segoe UI', Arial, sans-serif !important;
        }
        .ujModalBox table { width: 100% !important; }
        .ujModalMsg { font-size: 14px !important; color: #0f172a !important; font-weight: 600 !important; line-height: 1.5 !important; }
    </style>

    <asp:UpdatePanel ID="TopUpdatePanel" runat="server">
        <ContentTemplate>

            <div id="unifiedJobRoot">
                <div class="main-workspace">

                    <div class="sticky-top-section">
                        <div class="page-header">
                            <h1>Combined Job</h1>
                            <div class="header-controls">
                                <div class="header-field">
                                    <label>Exporter</label>
                                    <asp:DropDownList ID="ddlExporter" runat="server" CssClass="header-select exporter-select"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlExporter_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="header-field">
                                    <label>Tr.Mode</label>
                                    <asp:DropDownList ID="ddlTrMode" runat="server" CssClass="header-select mode-select"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlTrMode_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="SEA" Value="Sea"></asp:ListItem>
                                        <asp:ListItem Text="AIR" Value="Air"></asp:ListItem>
                                        <asp:ListItem Text="LAND" Value="Land"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="header-field">
                                    <label>Job No</label>
                                    <div class="jobno-box" onclick="ToggleJobNoPanel();">
                                        <asp:Literal ID="litJobNoSummary" runat="server" Text="Select Job No"></asp:Literal>
                                    </div>
                                    <asp:Panel ID="pnlJobNoList" runat="server" CssClass="jobno-dropdown" Style="display:none;">
                                        <asp:CheckBoxList ID="chkJobNoList" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="chkJobNoList_SelectedIndexChanged"
                                            CssClass="ms-job-table">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                        <%-- SELECT PAGE --%>
                        <div class="grid-panel">
                            <div class="panel-title">Select Page</div>
                            <div class="checkbox-stack">
                                <asp:CheckBox ID="chkGeneral" runat="server" Text=" General" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                                <asp:CheckBox ID="chkAnnexure" runat="server" Text=" Annexure C" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                                <asp:CheckBox ID="chkInvoices" runat="server" Text=" Invoices" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                                <asp:CheckBox ID="chkItems" runat="server" Text=" Items" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                                <asp:CheckBox ID="chkAnnexureC1" runat="server" Text=" Annexure C1" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                                <asp:CheckBox ID="chkLicense" runat="server" Text=" License" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                                <asp:CheckBox ID="chkSupDoc" runat="server" Text=" Sup Doc" AutoPostBack="true" Checked="true" OnCheckedChanged="PageTrigger_CheckedChanged" CssClass="checkbox-item" />
                            </div>
                        </div>

                        <%-- GENERAL + ANNEXURE C SUMMARY --%>
                        <div class="section-box">
                            <div class="section-box-title">General &amp; Annexure C (from first selected job / summed)</div>
                            <div class="summary-grid">
                                <div class="summary-item"><label>Exporter</label><asp:Literal ID="litExporterName" runat="server" Text="-"></asp:Literal></div>
                                <div class="summary-item"><label>IEC No</label><asp:Literal ID="litIec" runat="server" Text="-"></asp:Literal></div>
                                <div class="summary-item"><label>Port Discharge</label><asp:Literal ID="litPortDischarge" runat="server" Text="-"></asp:Literal></div>
                                <div class="summary-item"><label>Transport Mode</label><asp:Literal ID="litMode" runat="server" Text="-"></asp:Literal></div>
                                <div class="summary-item"><label>Total Packages (sum)</label><asp:Literal ID="litTotalPkg" runat="server" Text="0"></asp:Literal></div>
                                <div class="summary-item"><label>Gross Weight (sum)</label><asp:Literal ID="litGrossWt" runat="server" Text="0"></asp:Literal></div>
                                <div class="summary-item"><label>Net Weight (sum)</label><asp:Literal ID="litNetWt" runat="server" Text="0"></asp:Literal></div>
                                <div class="summary-item"><label>No. of Containers (sum)</label><asp:Literal ID="litContainers" runat="server" Text="0"></asp:Literal></div>
                            </div>
                            <div class="multi-note">
                                <asp:Literal ID="litSummaryNote" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <%-- end sticky-top-section --%>

                    <%-- INVOICE DETAILS --%>
                    <div class="section-box">
                        <div class="section-box-title">Invoice Details</div>
                        <div class="tbl-scroll-area">
                            <table class="tbl-unified">
                                <thead>
                                    <tr>
                                        <th class="sel-col">SEL</th>
                                        <th style="width:55px">SL NO</th>
                                        <th class="src-col">SRC JOB</th>
                                        <th style="width:170px">INV NO</th>
                                        <th style="width:120px">INV DATE</th>
                                        <th style="width:100px">TERMS</th>
                                        <th style="width:130px">INV VALUE</th>
                                        <th style="width:auto">CURRENCY</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="litInvoiceRows" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                        <div class="pagination-bar">
                            <asp:Label ID="lblInvoicePageInfo" runat="server" CssClass="pagination-info" Text="Total: 0 rows"></asp:Label>
                        </div>
                    </div>

                    <%-- ITEM DETAILS --%>
                    <div class="section-box">
                        <div class="section-box-title">Item Details</div>
                        <div class="tbl-scroll-area">
                            <table class="tbl-unified">
                                <thead>
                                    <tr>
                                        <th class="sel-col">SEL</th>
                                        <th style="width:60px">ITEMSL</th>
                                        <th class="src-col">SRC JOB</th>
                                        <th style="width:auto">DESCRIPTION</th>
                                        <th style="width:90px">QUANTITY</th>
                                        <th style="width:100px">UNIT PRICE</th>
                                        <th style="width:110px">AMOUNT</th>
                                        <th style="width:100px">RITC</th>
                                        <th style="width:170px">SCHEME</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="litItemRows" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                        <div class="pagination-bar">
                            <asp:Label ID="lblItemPageInfo" runat="server" CssClass="pagination-info" Text="Total: 0 rows"></asp:Label>
                        </div>
                    </div>

                </div>

                <div class="outside-footer-panel">
                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="action-btn btn-generate" OnClick="btnGenerate_Click"
                        OnClientClick="return confirm('This will create a new consolidated Export Job from the selected jobs. Continue?');" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="action-btn btn-clear" OnClick="btnClear_Click" />
                </div>
            </div>

            <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
                BackgroundCssClass="modalBackground" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDU" runat="server" />
            <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="ujModalBox" align="left">
                <table width="100%">
                    <tr><td align="center"><asp:Label ID="lblUser_Msg" runat="server" Text="" CssClass="ujModalMsg"></asp:Label></td></tr>
                    <tr><td style="padding-top: 14px;" align="center">
                        <asp:Button ID="btnhide" runat="server" Text="Ok" CssClass="action-btn btn-preview" OnClick="btnhide_Click" />
                    </td></tr>
                </table>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function ToggleJobNoPanel() {
            var p = document.getElementById('<%= pnlJobNoList.ClientID %>');
            p.style.display = (p.style.display === 'none' || p.style.display === '') ? 'block' : 'none';
        }
        document.addEventListener('click', function (e) {
            var box = document.querySelector('#unifiedJobRoot .jobno-box');
            var panel = document.getElementById('<%= pnlJobNoList.ClientID %>');
            if (panel && box && !panel.contains(e.target) && !box.contains(e.target)) {
                panel.style.display = 'none';
            }
        });
    </script>

</asp:Content>
