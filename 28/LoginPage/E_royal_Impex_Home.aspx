<%@ Page Title="" Language="C#" MasterPageFile="~/LoginPage/eRoyalMasters_01.master"
    AutoEventWireup="true" CodeFile="E_royal_Impex_Home.aspx.cs" Inherits="LoginPage_Premium_E_royal_Impex_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
      Dashboard design ported in from E_royal_Impex_Dashboard_New.aspx (KPI cards, chart
      carousel-style trend/mode-share row, Shipment Breakdown, Top Customers ranking,
      KPI drill-down, "View All Customers" popup) so this page - the real "Home" every
      cancel/close button across the app links back to - carries the same visual design,
      instead of that design only being reachable through Main.aspx's dashboard iframe.
      Uses this page's own MasterPageFile (eRoyalMasters_01.master) rather than
      Dashboard_New's standalone <html>/<head>/<body>/ScriptManager, since the master
      already provides all of that (including ScriptManager1 with EnablePageMethods="true").
    --%>
    <%-- KPI drill-down table (below) is rendered with DataTables.net - https://datatables.net/ -
         so clicking a KPI card shows its jobs in that grid: search box top-left, "Show N
         entries" length menu top-right, page-number pagination bottom-right, 10 rows/page
         by default. Only the CSS is loaded eagerly here; the JS is lazy-loaded by
         ensureDataTablesLib() the first time a card is clicked (see below) because this
         page's own jQuery gets reloaded/replaced by the master page AFTER this markup runs,
         and DataTables must attach itself to that final jQuery instance, not the earlier one. --%>
    <link rel="stylesheet" href="../css/dataTables.min.css" type="text/css" />
    <style>
        :root{
          --font-sans:-apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,Helvetica,Arial,sans-serif;
          --font-mono:"SF Mono",ui-monospace,"Cascadia Code","Roboto Mono","Consolas",monospace;
          --n:#0B1F3A;--n2:#152B4E;--n3:#1E3A5F;
          --bl:#1A6FBF;--bl2:#2484D8;--blt:#E8F3FC;
          --tl:#0E8A7C;--tlt:#E4F5F3;
          --am:#D97706;--amt:#FEF3C7;
          --rd:#C0392B;--rdt:#FDECEA;
          --gr:#1D7A45;--grt:#E8F5ED;
          --pu:#6D28D9;--put:#EDE9FE;
          --g0:#F8FAFC;--g1:#F1F5F9;--g2:#E2E8F0;--g3:#CBD5E1;
          --g4:#94A3B8;--g5:#64748B;--g6:#475569;--g7:#334155;--g8:#1E293B;
          --wh:#fff;
          --ease:cubic-bezier(.4,0,.2,1);
        }
        .ic{width:16px;height:16px;flex-shrink:0;stroke:currentColor;fill:none;stroke-width:2;stroke-linecap:round;stroke-linejoin:round;vertical-align:-3px}
        .ic-sm{width:13px;height:13px}

        /* page header */
        .pt{font-size:18px;font-weight:600;color:var(--g8);letter-spacing:-.3px;display:flex;align-items:center;gap:8px}
        .ps{font-size:12px;color:var(--g5);margin-top:2px}
        .ph{display:flex;align-items:flex-start;justify-content:space-between;margin-bottom:14px;gap:14px;flex-wrap:wrap}
        .pa{display:flex;gap:7px;flex-wrap:wrap}

        /* card system */
        .card{background:#fff;border:0.5px solid var(--g2);border-radius:10px;margin-bottom:12px;overflow:hidden}

        /* Hover lift on the top KPI row and the Shipments Trend / Shipment Share row. */
        .kpi6-row .card,.dash-3col-row .card,.import-extra-row .card{transition:transform .15s ease,box-shadow .15s ease,border-color .15s ease;cursor:default}
        .kpi6-row .card:hover,.dash-3col-row .card:hover,.import-extra-row .card:hover{transform:translateY(-3px);box-shadow:0 10px 24px -8px rgba(11,31,58,.22);border-color:var(--g3)}
        .ch{display:flex;align-items:center;justify-content:space-between;padding:10px 14px;border-bottom:0.5px solid var(--g2);gap:10px;flex-wrap:wrap}
        .ct{font-size:13px;font-weight:600;color:var(--g8);display:flex;align-items:center;gap:6px}
        .cb{padding:14px}
        .cf{padding:8px 14px;border-top:0.5px solid var(--g2);background:var(--g0);font-size:11.5px;color:var(--g5)}

        /* buttons */
        .btn{display:inline-flex;align-items:center;gap:5px;padding:6px 12px;border-radius:6px;font-size:12px;font-weight:500;cursor:pointer;border:none;font-family:var(--font-sans);transition:all .12s var(--ease);white-space:nowrap}
        .btn-pri{background:var(--bl);color:#fff}.btn-pri:hover{background:var(--bl2)}
        .btn-out{background:#fff;color:var(--g7);border:0.5px solid var(--g3)}.btn-out:hover{background:var(--g1);border-color:var(--g4)}
        .btn-sm{padding:4px 9px;font-size:11px}

        /* form controls */
        .fc{padding:6px 9px;border:0.5px solid var(--g3);border-radius:6px;font-size:12.5px;color:var(--g8);background:#fff;outline:none;font-family:var(--font-sans);width:100%}
        .fc:focus{border-color:var(--bl)}
        .ta{color:var(--bl);cursor:pointer;font-weight:500;font-size:12px;background:none;border:none;padding:0;font-family:var(--font-sans);display:inline-flex;align-items:center;gap:3px}

        /* badges */
        .b{display:inline-flex;align-items:center;gap:4px;padding:2px 7px;border-radius:20px;font-size:10.8px;font-weight:600;white-space:nowrap}
        .b-bl{background:var(--blt);color:#0C447C}.b-gr{background:var(--grt);color:#27500A}
        .b-am{background:var(--amt);color:#633806}.b-rd{background:var(--rdt);color:#791F1F}
        .b-pu{background:var(--put);color:#3C3489}.b-gy{background:var(--g1);color:var(--g6)}
        .b-tl{background:var(--tlt);color:#085041}
        .dot::before{content:'';width:5px;height:5px;border-radius:50%;background:currentColor;display:inline-block;flex-shrink:0}

        /* tabs */
        .tbb{padding:7px 14px;font-size:12.3px;font-weight:500;color:var(--g5);cursor:pointer;border-bottom:2px solid transparent;background:none;border-top:none;border-left:none;border-right:none;font-family:var(--font-sans);transition:all .12s var(--ease);white-space:nowrap;flex-shrink:0}
        .tbb:hover{color:var(--bl)}.tbb.on{color:var(--bl);border-bottom-color:var(--bl)}

        /* top row: 6 plain stat cards (Total Shipments / Draft / Sent / Received / OOC-LEO / Cancelled) */
        .kpi6-row{display:grid;grid-template-columns:repeat(6,1fr);gap:12px;margin-bottom:14px}
        @media (max-width:1500px){ .kpi6-row{grid-template-columns:repeat(3,1fr)} }
        @media (max-width:900px){ .kpi6-row{grid-template-columns:repeat(2,1fr)} }
        @media (max-width:560px){ .kpi6-row{grid-template-columns:1fr} }
        .kpi-icon-3d{width:48px;height:48px;border-radius:50%;display:flex;align-items:center;justify-content:center;flex-shrink:0;position:relative}
        .kpi-icon-3d::after{content:'';position:absolute;inset:0;border-radius:50%;background:linear-gradient(155deg,rgba(255,255,255,.65),rgba(255,255,255,0) 55%)}
        .kpi-icon-3d::before{content:'';position:absolute;inset:-4px;border-radius:50%;background:inherit;opacity:.18;filter:blur(6px);z-index:-1}
        .kpi-icon-3d .ic{position:relative;z-index:1;color:#fff!important;filter:drop-shadow(0 1px 1px rgba(0,0,0,.15))}

        /* Selected KPI card (drill-down open for this one) - the row's own hover
           lift/shadow already signals "clickable"; this on top of it signals
           "this is the one currently shown below". */
        .kpi-card-clickable.kpi-card-active{box-shadow:0 0 0 2px var(--bl) inset,0 10px 24px -8px rgba(11,31,58,.22)}

        /* KPI drill-down data grid - rendered as a DataTables.net table (see
           ../js/dataTables.min.js / ../css/dataTables.min.css, lazy-loaded by
           ensureDataTablesLib() below). These rules only add the app's own
           colors/cursor on top - borders, padding, search box, pagination etc.
           all come from DataTables' own stylesheet so the table matches the
           datatables.net look. */
        .kpi-dd-table{font-size:12.3px}
        .kpi-dd-table tbody tr{cursor:pointer}
        .kpi-dd-table tbody tr:hover{background:var(--blt)}
        .kpi-dd-table tbody tr:active{background:var(--g2)}
        .kpi-dd-table td.kpi-dd-name{font-weight:600;color:var(--g8);max-width:220px;overflow:hidden;text-overflow:ellipsis}
        /* Shared by every drill-down panel (.kpi-dd-panel - see kpiDrilldown/nakStatusDrilldown/
           igmRegularisedDrilldown/queryReplyDrilldown below) via one class instead of an
           ID-list, so a new drill-down panel gets this alignment for free just by carrying the
           class - forgetting to add a new panel's ID to a hand-maintained list here is exactly
           what broke IGM Regularised's pagination/length alignment before this. */
        .kpi-dd-panel .dataTables_wrapper{padding:10px 14px 14px}
        .kpi-dd-panel .kpi-dt-top{display:flex;align-items:center;justify-content:space-between;gap:12px;flex-wrap:wrap;margin-bottom:8px}
        .kpi-dd-panel .kpi-dt-bottom{display:flex;align-items:center;justify-content:space-between;gap:12px;flex-wrap:wrap;margin-top:8px}
        .kpi-dd-panel .dataTables_filter input{margin-left:6px;border:0.5px solid var(--g2);border-radius:6px;padding:4px 8px;font-size:12px}
        .kpi-dd-panel .dataTables_length select{margin:0 4px;border:0.5px solid var(--g2);border-radius:6px;padding:2px 6px;font-size:12px}
        .kpi-dd-panel .dataTables_filter,.kpi-dd-panel .dataTables_length,.kpi-dd-panel .dataTables_info,.kpi-dd-panel .dataTables_paginate{font-size:12px;color:var(--g5)}

        /* dashboard layout */
        .dash-body-grid{display:grid;grid-template-columns:1fr}
        .dash-main-col{min-width:0}

        /* Shipment Breakdown (3 parts) + Top Customers (2 parts), same row */
        .dash-2col-row{display:grid;grid-template-columns:3fr 2fr;gap:12px;margin-bottom:14px;align-items:stretch}
        .dash-2col-row>.card{display:flex;flex-direction:column;height:100%}
        .dash-2col-row>.card>.cb{flex:1}
        @media (max-width:900px){ .dash-2col-row{grid-template-columns:1fr} }

        /* Shipments Trend / Shipment Share by Mode */
        .dash-3col-row{display:grid;grid-template-columns:3fr 2fr;gap:12px;margin-bottom:14px;align-items:stretch}
        .dash-3col-row>.card{display:flex;flex-direction:column;height:100%}
        .dash-3col-row>.card>.cb{flex:1}
        @media (max-width:1100px){ .dash-3col-row{grid-template-columns:1fr} }

        /* Import-only extra row: 3 cards shown only when the header's "Import" filter
           (dashFilterType) is selected - hidden for "Import & Export" and "Export".
           Visibility toggled in initHeaderFilters()/applyImportOnlyCardsVisibility(). */
        .import-extra-row{display:grid;grid-template-columns:repeat(3,1fr);gap:12px;margin-bottom:14px}
        @media (max-width:900px){ .import-extra-row{grid-template-columns:1fr} }

        .trend-legend{display:flex;align-items:center;gap:12px;flex-wrap:wrap}
        .trend-legend-item{display:inline-flex;align-items:center;gap:5px;font-size:11px;font-weight:600;color:var(--g6)}
        .trend-legend-dot{width:8px;height:8px;border-radius:50%;flex-shrink:0}
        .trend-bar{transform-box:fill-box;transform-origin:bottom;animation:trendBarGrow .6s cubic-bezier(.34,1.56,.64,1) backwards}
        @keyframes trendBarGrow{from{transform:scaleY(0)}to{transform:scaleY(1)}}

        .mode-share-body{display:flex;flex-direction:row;justify-content:center;align-items:center;gap:18px;padding:16px 18px}
        .mode-share-labels,.mode-share-values{display:flex;flex-direction:column;justify-content:center;gap:14px}
        .mode-share-row{display:flex;align-items:center;gap:8px;font-size:12.5px;padding:4px 6px;border-radius:7px;transition:background .12s ease}
        .mode-share-row:hover{background:var(--g0)}
        .mode-share-values .mode-share-row{justify-content:flex-end}
        .mode-share-dot{width:9px;height:9px;border-radius:50%;flex-shrink:0}
        .mode-share-lbl{color:var(--g6);font-weight:600}
        .mode-share-val{font-weight:800;color:var(--g8);font-size:14px}

        /* toasts */
        .toast-stack{position:fixed;bottom:18px;right:18px;display:flex;flex-direction:column;gap:8px;z-index:999;width:300px}
        .toast{background:var(--g8);color:#fff;padding:10px 14px;border-radius:8px;font-size:12px;font-weight:500;box-shadow:0 8px 24px rgba(0,0,0,.22);border-left:3px solid var(--gr);display:flex;gap:9px;align-items:flex-start;transform:translateX(115%);opacity:0;transition:transform .3s var(--ease),opacity .3s}
        .toast.show{transform:translateX(0);opacity:1}
        .toast.error{border-left-color:var(--rd)}
        .toast.warn{border-left-color:var(--am)}
        .toast-msg{flex:1}
        .toast-close{cursor:pointer;opacity:.6;flex-shrink:0}
        .toast-close:hover{opacity:1}

        /* #maincontent (eRoyalMasters_01.master / premium-theme.css) already handles scrolling
           for every master-based page - flex:1;height:100vh;overflow-y:auto - so this page just
           centers itself inside it instead of repeating that trick on body/form. */
        .preview-shell{max-width:1600px;width:100%;margin:0 auto}

        /* â”€â”€ Import / Export Workspace: Top Customers by Shipments (real data) â”€â”€ */
        .iew-search{position:relative;width:220px}
        .iew-search input{width:100%;padding:6px 10px 6px 30px;border:0.5px solid var(--g3);border-radius:6px;font-size:12px;outline:none;font-family:var(--font-sans)}
        .iew-search input:focus{border-color:var(--bl)}
        .iew-search svg{position:absolute;left:9px;top:50%;transform:translateY(-50%);color:var(--g4)}
        .iew-empty{padding:36px 20px;text-align:center;color:var(--g5);font-size:12.5px;font-weight:600}

        .cust-rank-title{padding:12px 14px 0 14px;font-size:11px;font-weight:700;letter-spacing:.4px;text-transform:uppercase;color:var(--g5)}
        .cust-rank-list{padding:6px 8px}
        .cust-rank-row{display:flex;align-items:center;gap:12px;padding:9px 8px;border-radius:8px;transition:background .12s ease}
        .cust-rank-row:hover{background:var(--g0)}
        .cust-rank-num{width:22px;height:22px;border-radius:50%;background:var(--g1);color:var(--g6);font-size:11px;font-weight:800;display:flex;align-items:center;justify-content:center;flex-shrink:0}
        .cust-rank-row:nth-child(1) .cust-rank-num{background:linear-gradient(150deg,#F5D061,#D9A017);color:#fff}
        .cust-rank-row:nth-child(2) .cust-rank-num{background:linear-gradient(150deg,#CBD5E1,#8FA0B5);color:#fff}
        .cust-rank-row:nth-child(3) .cust-rank-num{background:linear-gradient(150deg,#E8B48C,#C6835A);color:#fff}
        .cust-rank-name{width:220px;flex-shrink:0;font-size:12px;font-weight:700;color:var(--g8);white-space:nowrap;overflow:hidden;text-overflow:ellipsis}
        .cust-rank-bar-wrap{flex:1;height:8px;background:var(--g1);border-radius:4px;overflow:hidden;min-width:60px}
        .cust-rank-bar{height:100%;background:linear-gradient(90deg,var(--bl),#3D9BE9);border-radius:4px}
        .cust-rank-count{width:64px;flex-shrink:0;text-align:right;font-size:12.5px;font-weight:800;color:var(--n)}
        .cust-rank-viewall{padding:6px 14px 14px;text-align:center;border-top:0.5px solid var(--g1);margin-top:2px}

        /* "View All Customers" popup - same centered/blurred-backdrop, pop-in,
           floating-close-button feel as the header robot icon's popup. */
        .cra-modal-overlay{display:none;position:fixed;inset:0;background:rgba(15,20,35,.55);backdrop-filter:blur(3px);-webkit-backdrop-filter:blur(3px);z-index:2000;align-items:center;justify-content:center;padding:24px}
        .cra-modal-overlay.open{display:flex}
        .cra-modal-card{position:relative;background:#fff;border:1px solid var(--g1);border-radius:14px;box-shadow:0 24px 60px rgba(11,31,58,.28);width:100%;max-width:560px;max-height:82vh;display:flex;flex-direction:column;overflow:visible;animation:craModalPop .18s ease}
        @keyframes craModalPop{from{transform:scale(.92);opacity:0}to{transform:scale(1);opacity:1}}
        .cra-modal-head{padding:16px 18px;border-bottom:0.5px solid var(--g1);flex-shrink:0;border-radius:14px 14px 0 0}
        .cra-modal-title{font-size:13px;font-weight:800;color:var(--n);letter-spacing:.2px}
        .cra-modal-close{position:absolute;top:-14px;right:-14px;background:#fff;border:1px solid var(--g1);width:30px;height:30px;border-radius:50%;color:var(--g6);font-size:18px;line-height:1;cursor:pointer;display:flex;align-items:center;justify-content:center;box-shadow:0 6px 16px rgba(11,31,58,.18);transition:color .15s ease,background .15s ease;z-index:1}
        .cra-modal-close:hover{background:#fff;color:var(--n)}
        .cra-modal-body{overflow-y:auto;padding:6px 8px;border-radius:0 0 14px 14px}

        .ship-grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(140px,1fr));gap:14px}
        .ship-tile{background:var(--g0);border-radius:10px;padding:16px 16px 15px 16px}
        .ship-tile-hd{display:flex;align-items:center;gap:9px;margin-bottom:14px}
        .ship-tile-ico{width:28px;height:28px;border-radius:50%;flex-shrink:0;display:flex;align-items:center;justify-content:center;color:#fff}
        .ship-tile-label{font-size:11.5px;font-weight:700;color:var(--g7);white-space:nowrap;overflow:hidden;text-overflow:ellipsis}
        .ship-tile-count{font-size:22px;font-weight:800;color:var(--n);line-height:1.1}
        .ship-tile-pct{font-size:11px;color:var(--g5);margin-top:5px}
        .ship-tile-bar-wrap{height:6px;background:var(--g2);border-radius:3px;overflow:hidden;margin-top:12px}
        .ship-tile-bar{height:100%;border-radius:3px}
    </style>

    <div class="toast-stack" id="toastStack"></div>

    <div id="dashDiagBanner" runat="server" visible="false" style="background:#fee2e2;color:#7f1d1d;padding:10px 16px;font-size:12px;font-weight:600;border-bottom:1px solid #fca5a5">
        <asp:Literal ID="litDiag" runat="server" />
    </div>

    <div class="preview-shell">
    <div class="ph" style="padding-bottom:10px;padding-top:16px">
      <div>
        <div class="pt"><svg class="ic" data-icon="dashboard" style="color:var(--bl)"></svg>Dashboard</div>
        <div class="ps">eRoyal Impex &middot; Premium &nbsp;&middot;&nbsp; <span id="dashDate" style="color:var(--g5)"></span></div>
      </div>
      <div class="pa">
        <select class="fc" id="dashFilterMode" style="width:auto">
          <option value="">All Modes</option>
          <option value="sea">Sea</option>
          <option value="air">Air</option>
          <option value="land">Land</option>
        </select>
        <select class="fc" id="dashFilterType" style="width:auto">
          <option value="" selected>Import &amp; Export</option>
          <option value="import">Import</option>
          <option value="export">Export</option>
        </select>
      </div>
    </div>

    <div class="dash-body-grid">
    <div class="dash-main-col">

    <!-- â”€â”€ TOP KPI ROW (6 plain stat cards, no flip) â”€â”€ -->
    <div class="kpi6-row">

      <div class="card kpi-card-clickable" id="kpiCard_total" onclick="toggleKpiDrilldown('total')" style="border-left:4px solid var(--bl);margin:0;background:linear-gradient(150deg,#fff 45%,var(--blt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">Total Shipments</div>
              <div id="kpiTotalVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#3D9BE9,var(--bl));box-shadow:0 6px 16px -4px rgba(26,111,191,.5)"><svg class="ic" data-icon="package" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_draft" onclick="toggleKpiDrilldown('draft')" style="border-left:4px solid var(--am);margin:0;background:linear-gradient(150deg,#fff 45%,var(--amt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div id="kpiDraftLabel" style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">Created Jobs</div>
              <div id="kpiDraftVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#F5B75C,var(--am));box-shadow:0 6px 16px -4px rgba(217,119,6,.5)"><svg class="ic" data-icon="clock" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_sent" onclick="toggleKpiDrilldown('sent')" style="border-left:4px solid var(--tl);margin:0;background:linear-gradient(150deg,#fff 45%,var(--tlt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div id="kpiSentLabel" style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">Sent Jobs</div>
              <div id="kpiSentVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#4FC3B0,var(--tl));box-shadow:0 6px 16px -4px rgba(14,138,124,.5)"><svg class="ic" data-icon="upload" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_received" onclick="toggleKpiDrilldown('received')" style="border-left:4px solid var(--gr);margin:0;background:linear-gradient(150deg,#fff 45%,var(--grt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div id="kpiReceivedLabel" style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">Received Jobs</div>
              <div id="kpiReceivedVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#3FBF7F,var(--gr));box-shadow:0 6px 16px -4px rgba(30,138,79,.5)"><svg class="ic" data-icon="check-circle" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_oocleo" onclick="toggleKpiDrilldown('oocleo')" style="border-left:4px solid var(--pu);margin:0;background:linear-gradient(150deg,#fff 45%,var(--put) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div id="kpiOocLeoLabel" style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">OOC/LEO Received</div>
              <div id="kpiOocLeoVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#B084F0,var(--pu));box-shadow:0 6px 16px -4px rgba(109,40,217,.5)"><svg class="ic" data-icon="truck" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_cancelled" onclick="toggleKpiDrilldown('cancelled')" style="border-left:4px solid var(--rd);margin:0;background:linear-gradient(150deg,#fff 45%,var(--rdt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">Cancelled Jobs</div>
              <div id="kpiCancelledVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#F0847A,var(--rd));box-shadow:0 6px 16px -4px rgba(192,57,43,.5)"><svg class="ic" data-icon="alert" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

    </div>

    <!-- â”€â”€ IMPORT-ONLY EXTRA CARDS: shown for "Import & Export" and "Import" (hidden only
         for "Export") - see applyImportOnlyCardsVisibility() below.
         Same plain-stat-card look as the kpi6-row cards above. â”€â”€ -->
    <div class="import-extra-row" id="importExtraCardsRow" style="display:none">

      <div class="card kpi-card-clickable" id="kpiCard_igmRegularised" onclick="toggleIgmRegularisedDrilldown()" style="border-left:4px solid var(--gr);margin:0;background:linear-gradient(150deg,#fff 45%,var(--grt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">IGM Regularised</div>
              <div id="kpiIgmRegularisedVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#3FBF7F,var(--gr));box-shadow:0 6px 16px -4px rgba(30,138,79,.5)"><svg class="ic" data-icon="check-circle" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_nakStatus" onclick="toggleNakStatusDrilldown()" style="border-left:4px solid var(--rd);margin:0;background:linear-gradient(150deg,#fff 45%,var(--rdt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">NAK Status</div>
              <div id="kpiNakStatusVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#F0847A,var(--rd));box-shadow:0 6px 16px -4px rgba(192,57,43,.5)"><svg class="ic" data-icon="alert" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

      <div class="card kpi-card-clickable" id="kpiCard_queryReply" onclick="toggleQueryReplyDrilldown()" style="border-left:4px solid var(--am);margin:0;background:linear-gradient(150deg,#fff 45%,var(--amt) 165%);cursor:pointer">
        <div class="cb" style="padding:14px 16px">
          <div style="display:flex;justify-content:space-between;align-items:flex-start">
            <div>
              <div style="font-size:10.5px;font-weight:700;letter-spacing:.4px;color:var(--g5);text-transform:uppercase">Query Reply</div>
              <div id="kpiQueryReplyVal" style="font-size:26px;font-weight:800;color:var(--n);line-height:1.1;margin-top:4px">0</div>
            </div>
            <div class="kpi-icon-3d" style="width:40px;height:40px;background:linear-gradient(150deg,#F5B75C,var(--am));box-shadow:0 6px 16px -4px rgba(217,119,6,.5)"><svg class="ic" data-icon="message-circle" style="width:18px;height:18px"></svg></div>
          </div>
        </div>
      </div>

    </div>

    <!-- â”€â”€ NAK STATUS DRILL-DOWN: clicking the "NAK Status" card above opens this row right
         underneath it with the real pending rows from dbo.IMPORT_NAK_ACK_PENDING_SEARCH
         (Job No + File Remarks only, per the card's own request) - see
         toggleNakStatusDrilldown()/loadNakStatusDrilldown() below. Small dataset (pending
         NAK mails), so unlike the KPI drill-down below this fetches everything in one
         PageMethod call and lets DataTables page it client-side. â”€â”€ -->
    <div class="card kpi-dd-panel" id="nakStatusDrilldown" style="display:none">
      <div class="ch">
        <div class="ct"><svg class="ic" data-icon="alert"></svg><span>NAK Status</span></div>
        <div style="display:flex;align-items:center;gap:14px">
          <span id="nakStatusDrilldownCount" style="font-size:11.5px;color:var(--g5);font-weight:600"></span>
          <button type="button" class="ta" onclick="closeNakStatusDrilldown()"><svg class="ic ic-sm" data-icon="close"></svg>Close</button>
        </div>
      </div>
      <div class="cb" style="padding:0">
        <div style="overflow-x:auto">
          <table id="nakStatusDrilldownTable" class="kpi-dd-table display" style="width:100%">
            <thead>
              <tr>
                <th>Job No</th>
                <th>File Remarks</th>
              </tr>
            </thead>
            <tbody></tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- â”€â”€ IGM REGULARISED DRILL-DOWN: clicking the "IGM Regularised" card above opens this row
         right underneath it with the real pending rows from dbo.IMPORT_REGULARISED_PENDING_SEARCH
         (Job No + Filing Status only, per the card's own request) - see
         toggleIgmRegularisedDrilldown()/loadIgmRegularisedDrilldown() below. Same small-dataset,
         fetch-everything-in-one-call pattern as the NAK Status drill-down above. â”€â”€ -->
    <div class="card kpi-dd-panel" id="igmRegularisedDrilldown" style="display:none">
      <div class="ch">
        <div class="ct"><svg class="ic" data-icon="check-circle"></svg><span>IGM Regularised</span></div>
        <div style="display:flex;align-items:center;gap:14px">
          <span id="igmRegularisedDrilldownCount" style="font-size:11.5px;color:var(--g5);font-weight:600"></span>
          <button type="button" class="ta" onclick="closeIgmRegularisedDrilldown()"><svg class="ic ic-sm" data-icon="close"></svg>Close</button>
        </div>
      </div>
      <div class="cb" style="padding:0">
        <div style="overflow-x:auto">
          <table id="igmRegularisedDrilldownTable" class="kpi-dd-table display" style="width:100%">
            <thead>
              <tr>
                <th>Job No</th>
                <th>Filing Status</th>
              </tr>
            </thead>
            <tbody></tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- â”€â”€ QUERY REPLY DRILL-DOWN: clicking the "Query Reply" card above opens this row right
         underneath it with the real pending rows from dbo.IMPORT_QUERY_PENDING_SEARCH. That SP
         only carries a BE_NO (Bill of Entry number) per pending query mail, not a Job No, so each
         row's BE_NO is matched against Import job data (Import_General_Grid_Search, the same
         source Transaction/General_Search.aspx uses, searched by BE No) to resolve the Job No it
         belongs to - see GetQueryReplyPendingJobs() in the code-behind. Shows Job No + BE No, per
         the card's own request. Same small-dataset, fetch-everything-in-one-call pattern as the
         NAK Status / IGM Regularised drill-downs above. â”€â”€ -->
    <div class="card kpi-dd-panel" id="queryReplyDrilldown" style="display:none">
      <div class="ch">
        <div class="ct"><svg class="ic" data-icon="message-circle"></svg><span>Query Reply</span></div>
        <div style="display:flex;align-items:center;gap:14px">
          <span id="queryReplyDrilldownCount" style="font-size:11.5px;color:var(--g5);font-weight:600"></span>
          <button type="button" class="ta" onclick="closeQueryReplyDrilldown()"><svg class="ic ic-sm" data-icon="close"></svg>Close</button>
        </div>
      </div>
      <div class="cb" style="padding:0">
        <div style="overflow-x:auto">
          <table id="queryReplyDrilldownTable" class="kpi-dd-table display" style="width:100%">
            <thead>
              <tr>
                <th>Job No</th>
                <th>BE No</th>
              </tr>
            </thead>
            <tbody></tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- â”€â”€ KPI DRILL-DOWN: clicking any of the cards above opens this row
         underneath them with the actual jobs behind that card's number (real Job No,
         not an aggregate), lazily paged from GetKpiDrilldownJobsPage() via DataTables'
         serverSide mode (see initKpiDrilldownDataTable()) - the same job-list source
         Transaction/General_Search.aspx and Export/General_Search.aspx already use.
         Clicking a row opens that job's real popup in the parent window
         (Import -> General_Details_Update(), Export -> Export_General_Update(), both
         from js/iframepopupwin.js - see openKpiDrilldownJob() below). â”€â”€ -->
    <div class="card kpi-dd-panel" id="kpiDrilldown" style="display:none">
      <div class="ch">
        <div class="ct"><svg class="ic" id="kpiDrilldownIcon" data-icon="package"></svg><span id="kpiDrilldownTitle">Total Shipments</span></div>
        <div style="display:flex;align-items:center;gap:14px">
          <span id="kpiDrilldownCount" style="font-size:11.5px;color:var(--g5);font-weight:600"></span>
          <button type="button" class="ta" onclick="closeKpiDrilldown()"><svg class="ic ic-sm" data-icon="close"></svg>Close</button>
        </div>
      </div>
      <div class="cb" style="padding:0">
        <div style="overflow-x:auto">
          <table id="kpiDrilldownTable" class="kpi-dd-table display" style="width:100%">
            <thead>
              <tr>
                <th>Job No</th>
                <th>Type</th>
                <th>Party Name</th>
                <th>Mode</th>
                <th>Job Date</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody id="kpiDrilldownBody"></tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- â”€â”€ SHIPMENTS TREND / SHIPMENT SHARE BY MODE: 2 columns (real data, falls back to demo trend if empty) â”€â”€ -->
    <div class="dash-3col-row">

      <div class="card" style="margin:0">
        <div class="ch">
          <div class="ct"><svg class="ic" data-icon="trending-up" style="color:var(--bl)"></svg>Shipments Trend (Last 12 Months)</div>
          <div class="trend-legend">
            <span class="trend-legend-item"><span class="trend-legend-dot" style="background:var(--bl)"></span>Sea Shipment</span>
            <span class="trend-legend-item"><span class="trend-legend-dot" style="background:var(--pu)"></span>Air Shipment</span>
            <span class="trend-legend-item"><span class="trend-legend-dot" style="background:var(--g4)"></span>Land Shipment</span>
          </div>
        </div>
        <div class="cb" style="padding:16px 12px 8px 12px">
          <svg id="trendChartSvg" style="width:100%;height:170px;display:block;overflow:visible"></svg>
        </div>
        <div class="cf" id="trendFooter">Latest month: <strong style="color:var(--n)">312 shipments</strong> &nbsp;&middot;&nbsp; <span style="color:var(--gr);font-weight:700">&uarr; 8.4%</span> vs prior month</div>
      </div>

      <div class="card" style="margin:0">
        <div class="ch"><div class="ct"><svg class="ic" data-icon="chart-pie" style="color:var(--pu)"></svg>Shipment Share by Mode</div></div>
        <div class="cb mode-share-body">
          <div class="mode-share-labels">
            <div class="mode-share-row"><span class="mode-share-dot" style="background:var(--bl)"></span><span class="mode-share-lbl">Sea</span></div>
            <div class="mode-share-row"><span class="mode-share-dot" style="background:var(--pu)"></span><span class="mode-share-lbl">Air</span></div>
            <div class="mode-share-row"><span class="mode-share-dot" style="background:var(--g4)"></span><span class="mode-share-lbl">Land</span></div>
          </div>
          <svg viewBox="0 0 160 160" style="width:158px;height:158px;display:block;flex-shrink:0;filter:drop-shadow(0 6px 14px rgba(109,40,217,.18))">
            <circle cx="80" cy="80" r="58" fill="none" style="stroke:var(--g1)" stroke-width="20"/>
            <circle id="modeShareSeaArc" cx="80" cy="80" r="58" fill="none" style="stroke:var(--bl);transition:stroke-dasharray 1s cubic-bezier(.4,0,.2,1),stroke-dashoffset 1s cubic-bezier(.4,0,.2,1)" stroke-width="20" stroke-linecap="round"
              stroke-dasharray="0 364.42" stroke-dashoffset="0" transform="rotate(-90 80 80)"/>
            <circle id="modeShareAirArc" cx="80" cy="80" r="58" fill="none" style="stroke:var(--pu);transition:stroke-dasharray 1s cubic-bezier(.4,0,.2,1) .15s,stroke-dashoffset 1s cubic-bezier(.4,0,.2,1) .15s" stroke-width="20" stroke-linecap="round"
              stroke-dasharray="0 364.42" stroke-dashoffset="-234.03" transform="rotate(-90 80 80)"/>
            <circle id="modeShareLandArc" cx="80" cy="80" r="58" fill="none" style="stroke:var(--g4);transition:stroke-dasharray 1s cubic-bezier(.4,0,.2,1) .3s,stroke-dashoffset 1s cubic-bezier(.4,0,.2,1) .3s" stroke-width="20" stroke-linecap="round"
              stroke-dasharray="0 364.42" stroke-dashoffset="-343.66" transform="rotate(-90 80 80)"/>
            <text id="modeShareCenterVal" x="80" y="75" text-anchor="middle" style="font-size:24px;font-weight:800;fill:var(--n)">312</text>
            <text x="80" y="92" text-anchor="middle" style="font-size:9.5px;font-weight:700;letter-spacing:.5px;fill:var(--g5);text-transform:uppercase">Shipments</text>
          </svg>
          <div class="mode-share-values">
            <div class="mode-share-row"><span class="mode-share-val" id="modeShareSeaPct">65%</span></div>
            <div class="mode-share-row"><span class="mode-share-val" id="modeShareAirPct">30%</span></div>
            <div class="mode-share-row"><span class="mode-share-val" id="modeShareLandPct">5%</span></div>
          </div>
        </div>
      </div>

    </div>

    <!-- â”€â”€ SHIPMENT BREAKDOWN + TOP CUSTOMERS: same row - Breakdown takes 3/5 width, Top Customers 2/5 â”€â”€ -->
    <div class="dash-2col-row">

    <!-- Shipment Breakdown (static demo split - real data only distinguishes Import/Export, not Air/Sea mode) -->
    <div class="card" style="margin:0">
      <div class="ch"><div class="ct"><svg class="ic" data-icon="chart-pie" style="color:var(--pu)"></svg>Shipment Breakdown</div></div>
      <div class="cb" style="padding:12px 14px">
        <div class="ship-grid">

          <div class="ship-tile">
            <div class="ship-tile-hd">
              <div class="ship-tile-ico" style="background:linear-gradient(150deg,#F5B75C,var(--am))"><svg class="ic" data-icon="plane" style="width:14px;height:14px;transform:rotate(180deg)"></svg></div>
              <div class="ship-tile-label">Air Import</div>
            </div>
            <div class="ship-tile-count" id="tileAirImportCount">37</div>
            <div class="ship-tile-pct" id="tileAirImportPct">12% of total</div>
            <div class="ship-tile-bar-wrap"><div class="ship-tile-bar" id="tileAirImportBar" style="width:12%;background:var(--am)"></div></div>
          </div>

          <div class="ship-tile">
            <div class="ship-tile-hd">
              <div class="ship-tile-ico" style="background:linear-gradient(150deg,#B084F0,var(--pu))"><svg class="ic" data-icon="plane" style="width:14px;height:14px"></svg></div>
              <div class="ship-tile-label">Air Export</div>
            </div>
            <div class="ship-tile-count" id="tileAirExportCount">58</div>
            <div class="ship-tile-pct" id="tileAirExportPct">19% of total</div>
            <div class="ship-tile-bar-wrap"><div class="ship-tile-bar" id="tileAirExportBar" style="width:19%;background:var(--pu)"></div></div>
          </div>

          <div class="ship-tile">
            <div class="ship-tile-hd">
              <div class="ship-tile-ico" style="background:linear-gradient(150deg,#4FC3B0,var(--tl))"><svg class="ic" data-icon="anchor" style="width:14px;height:14px"></svg></div>
              <div class="ship-tile-label">Sea Import</div>
            </div>
            <div class="ship-tile-count" id="tileSeaImportCount">74</div>
            <div class="ship-tile-pct" id="tileSeaImportPct">24% of total</div>
            <div class="ship-tile-bar-wrap"><div class="ship-tile-bar" id="tileSeaImportBar" style="width:24%;background:var(--tl)"></div></div>
          </div>

          <div class="ship-tile">
            <div class="ship-tile-hd">
              <div class="ship-tile-ico" style="background:linear-gradient(150deg,#3D9BE9,var(--bl))"><svg class="ic" data-icon="ship" style="width:14px;height:14px"></svg></div>
              <div class="ship-tile-label">Sea Export</div>
            </div>
            <div class="ship-tile-count" id="tileSeaExportCount">128</div>
            <div class="ship-tile-pct" id="tileSeaExportPct">41% of total</div>
            <div class="ship-tile-bar-wrap"><div class="ship-tile-bar" id="tileSeaExportBar" style="width:41%;background:var(--bl)"></div></div>
          </div>

          <div class="ship-tile">
            <div class="ship-tile-hd">
              <div class="ship-tile-ico" style="background:linear-gradient(150deg,#B7C1CE,var(--g4))"><svg class="ic" data-icon="package" style="width:14px;height:14px"></svg></div>
              <div class="ship-tile-label">Others (Land)</div>
            </div>
            <div class="ship-tile-count" id="tileOthersCount">15</div>
            <div class="ship-tile-pct" id="tileOthersPct">5% of total</div>
            <div class="ship-tile-bar-wrap"><div class="ship-tile-bar" id="tileOthersBar" style="width:5%;background:var(--g4)"></div></div>
          </div>

        </div>
      </div>
      <div class="cf" style="display:flex;align-items:center;justify-content:space-between;background:var(--grt);border-top:none">
        <span>Total Shipments: <strong id="breakdownTotalVal" style="color:var(--n);font-size:13px">312</strong></span>
        <span id="breakdownGrowthVal" style="color:var(--gr);font-weight:700">&uarr; 8.4% <span style="color:var(--g5);font-weight:400">vs last month</span></span>
      </div>
    </div>

    <!-- Top Customers by Shipments (real data from Load_Chart() below) - Import/Export is driven
         by the "Import & Export" filter in the page header (top right), not a tab here, so the
         two controls aren't duplicated. -->
    <div class="card" style="margin:0">
      <div class="ch">
        <div class="ct"><svg class="ic ic-sm" data-icon="trending-up" style="color:var(--bl)"></svg>Top Customers by Shipments</div>
        <div style="display:flex;align-items:center;gap:8px;flex-wrap:wrap">
          <select class="fc" id="iewRankMonth" style="width:auto"></select>
          <div class="iew-search">
            <svg class="ic ic-sm" data-icon="search"></svg>
            <input type="text" id="iewSearchInput" placeholder="Search importer / exporter..." autocomplete="off" />
          </div>
        </div>
      </div>
      <div class="cust-rank-title" id="iewRankTitle">Top 5 Customers by Shipments</div>
      <div id="iewImportPanel">
        <div id="iewImportRankList" class="cust-rank-list"></div>
        <div id="iewImportDataEmpty" class="iew-empty" style="display:none">No import data found.</div>
        <div id="iewImportSearchEmpty" class="iew-empty" style="display:none">No importer matches your search.</div>
        <div class="cust-rank-viewall"><button type="button" class="ta" id="iewImportViewAllBtn" style="display:none">View All Customers</button></div>
      </div>
      <div id="iewExportPanel" style="display:none">
        <div id="iewExportRankList" class="cust-rank-list"></div>
        <div id="iewExportDataEmpty" class="iew-empty" style="display:none">No export data found.</div>
        <div id="iewExportSearchEmpty" class="iew-empty" style="display:none">No exporter matches your search.</div>
        <div class="cust-rank-viewall"><button type="button" class="ta" id="iewExportViewAllBtn" style="display:none">View All Customers</button></div>
      </div>
      <!-- "Import & Export" header filter (blank value) - Importer + Exporter counts merged
           into one ranked list by name (see getFilteredSortedRows()'s combined branch in the
           .aspx script below). -->
      <div id="iewCombinedPanel" style="display:none">
        <div id="iewCombinedRankList" class="cust-rank-list"></div>
        <div id="iewCombinedDataEmpty" class="iew-empty" style="display:none">No shipment data found.</div>
        <div id="iewCombinedSearchEmpty" class="iew-empty" style="display:none">No customer matches your search.</div>
        <div class="cust-rank-viewall"><button type="button" class="ta" id="iewCombinedViewAllBtn" style="display:none">View All Customers</button></div>
      </div>
    </div>

    </div><!-- /dash-2col-row -->

    </div><!-- /dash-main-col -->
    </div><!-- /dash-body-grid -->
    </div><!-- /preview-shell -->

    <!-- "View All Customers" popup - shows the full ranked list instead of expanding
         the card in place (which used to push everything below it down the page). -->
    <div class="cra-modal-overlay" id="craModalOverlay">
      <div class="cra-modal-card">
        <div class="cra-modal-head">
          <div class="cra-modal-title" id="craModalTitle">All Customers by Shipments</div>
          <button type="button" class="cra-modal-close" id="craModalClose" aria-label="Close">&times;</button>
        </div>
        <div class="cra-modal-body" id="craModalBody"></div>
      </div>
    </div>

    <script type="text/javascript">
    /* ============================================================
       0. ICON SYSTEM (subset of the reference file's ICONS map -
          only the icons actually used on this screen)
       ============================================================ */
    var ICONS = {
      "ship":'<path d="M2 21c.6.5 1.2 1 2.5 1 2.5 0 2.5-2 5-2 1.3 0 1.9.5 2.5 1 .6.5 1.2 1 2.5 1 2.5 0 2.5-2 5-2 1.3 0 1.9.5 2.5 1"/><path d="M19.38 20A11.6 11.6 0 0 0 21 14l-9-4-9 4c0 2.9.94 5.34 2.31 7"/><path d="M19 13V7a2 2 0 0 0-2-2H7a2 2 0 0 0-2 2v6"/><path d="M12 10V3"/><path d="M9 4h6"/>',
      "search":'<circle cx="11" cy="11" r="7"/><path d="m21 21-4.3-4.3"/>',
      "bell":'<path d="M18 8a6 6 0 0 0-12 0c0 7-3 9-3 9h18s-3-2-3-9"/><path d="M13.7 21a2 2 0 0 1-3.4 0"/>',
      "package":'<path d="M16.5 9.4 7.5 4.21"/><path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"/><polyline points="3.27 6.96 12 12.01 20.73 6.96"/><line x1="12" y1="22.08" x2="12" y2="12"/>',
      "cash":'<rect x="2" y="6" width="20" height="12" rx="2"/><circle cx="12" cy="12" r="3"/><path d="M6 12h.01M18 12h.01"/>',
      "file-text":'<path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><path d="M14 2v6h6"/><line x1="16" y1="13" x2="8" y2="13"/><line x1="16" y1="17" x2="8" y2="17"/><line x1="10" y1="9" x2="8" y2="9"/>',
      "info":'<circle cx="12" cy="12" r="10"/><line x1="12" y1="16" x2="12" y2="12"/><line x1="12" y1="8" x2="12.01" y2="8"/>',
      "dashboard":'<rect x="3" y="3" width="7" height="9" rx="1"/><rect x="14" y="3" width="7" height="5" rx="1"/><rect x="14" y="12" width="7" height="9" rx="1"/><rect x="3" y="16" width="7" height="5" rx="1"/>',
      "building":'<rect x="4" y="2" width="16" height="20" rx="1"/><line x1="9" y1="7" x2="9" y2="7.01"/><line x1="15" y1="7" x2="15" y2="7.01"/><line x1="9" y1="11" x2="9" y2="11.01"/><line x1="15" y1="11" x2="15" y2="11.01"/><line x1="9" y1="15" x2="9" y2="15.01"/><line x1="15" y1="15" x2="15" y2="15.01"/><path d="M9 22v-3a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v3"/>',
      "clipboard":'<rect x="8" y="2" width="8" height="4" rx="1"/><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"/><line x1="9" y1="12" x2="15" y2="12"/><line x1="9" y1="16" x2="15" y2="16"/>',
      "calendar-check":'<rect x="3" y="4" width="18" height="18" rx="2"/><line x1="16" y1="2" x2="16" y2="6"/><line x1="8" y1="2" x2="8" y2="6"/><line x1="3" y1="10" x2="21" y2="10"/><path d="m9 16 2 2 4-4"/>',
      "license":'<rect x="2" y="4" width="20" height="16" rx="2"/><circle cx="8" cy="10" r="2"/><path d="M4 16c0-2 2-3 4-3s4 1 4 3"/><line x1="15" y1="8" x2="19" y2="8"/><line x1="15" y1="12" x2="19" y2="12"/>',
      "file-minus":'<path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><polyline points="14 2 14 8 20 8"/><line x1="9" y1="15" x2="15" y2="15"/>',
      "anchor":'<circle cx="12" cy="5" r="3"/><line x1="12" y1="8" x2="12" y2="21"/><path d="M5 12H2a10 10 0 0 0 20 0h-3"/>',
      "zap":'<polygon points="13 2 3 14 12 14 11 22 21 10 12 10 13 2"/>',
      "truck":'<rect x="1" y="3" width="15" height="13" rx="1"/><path d="M16 8h4l3 3v5h-7"/><circle cx="5.5" cy="18.5" r="2.5"/><circle cx="18.5" cy="18.5" r="2.5"/>',
      "receipt":'<path d="M4 2v20l2-1 2 1 2-1 2 1 2-1 2 1 2-1 2 1V2l-2 1-2-1-2 1-2-1-2 1-2-1-2 1Z"/><line x1="8" y1="7" x2="16" y2="7"/><line x1="8" y1="11" x2="16" y2="11"/><line x1="8" y1="15" x2="13" y2="15"/>',
      "bank":'<line x1="3" y1="21" x2="21" y2="21"/><line x1="3" y1="10" x2="21" y2="10"/><polyline points="5 6 12 3 19 6"/><line x1="4" y1="10" x2="4" y2="21"/><line x1="20" y1="10" x2="20" y2="21"/><line x1="8" y1="14" x2="8" y2="17"/><line x1="12" y1="14" x2="12" y2="17"/><line x1="16" y1="14" x2="16" y2="17"/>',
      "chart-bar":'<line x1="12" y1="20" x2="12" y2="10"/><line x1="18" y1="20" x2="18" y2="4"/><line x1="6" y1="20" x2="6" y2="16"/>',
      "plus":'<path d="M12 5v14M5 12h14"/>',
      "download":'<path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/><polyline points="7 10 12 15 17 10"/><line x1="12" y1="15" x2="12" y2="3"/>',
      "upload":'<path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/><polyline points="17 8 12 3 7 8"/><line x1="12" y1="3" x2="12" y2="15"/>',
      "rupee":'<path d="M6 3h12M6 8h12M6 13l8.5 0a4 4 0 0 0 0-8M6 13l7 8"/>',
      "plane":'<path d="M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-1 0-1.3.4l-.7.7c-.4.4-.2 1.1.3 1.3L9 11l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 2.7 6.8c.2.5.9.7 1.3.3l.7-.7c.4-.3.5-.8.4-1.3"/>',
      "chart-pie":'<path d="M21.21 15.89A10 10 0 1 1 8 2.83"/><path d="M22 12A10 10 0 0 0 12 2v10z"/>',
      "alert":'<path d="M10.29 3.86 1.82 18a2 2 0 0 0 1.71 3h16.94a2 2 0 0 0 1.71-3L13.71 3.86a2 2 0 0 0-3.42 0z"/><line x1="12" y1="9" x2="12" y2="13"/><line x1="12" y1="17" x2="12.01" y2="17"/>',
      "trending-up":'<polyline points="23 6 13.5 15.5 8.5 10.5 1 18"/><polyline points="17 6 23 6 23 12"/>',
      "arrow-left":'<line x1="19" y1="12" x2="5" y2="12"/><polyline points="12 19 5 12 12 5"/>',
      "arrow-right":'<line x1="5" y1="12" x2="19" y2="12"/><polyline points="12 5 19 12 12 19"/>',
      "check-circle":'<path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/>',
      "clock":'<circle cx="12" cy="12" r="10"/><polyline points="12 6 12 12 16 14"/>',
      "refresh-cw":'<polyline points="23 4 23 10 17 10"/><polyline points="1 20 1 14 7 14"/><path d="M3.51 9a9 9 0 0 1 14.85-3.36L23 10M1 14l4.64 4.36A9 9 0 0 0 20.49 15"/>',
      "close":'<line x1="18" y1="6" x2="6" y2="18"/><line x1="6" y1="6" x2="18" y2="18"/>',
      "user":'<path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"/><circle cx="12" cy="7" r="4"/>',
      "map-pin":'<path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 1 1 18 0z"/><circle cx="12" cy="10" r="3"/>',
      "warehouse":'<path d="M22 8.35V20a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V8.35a1 1 0 0 1 .56-.9l9-4.5a1 1 0 0 1 .88 0l9 4.5a1 1 0 0 1 .56.9Z"/><path d="M6 18v-7"/><path d="M18 18v-7"/><path d="M10 18v-4a2 2 0 0 1 4 0v4"/>',
      "filter":'<polygon points="22 3 2 3 10 12.46 10 19 14 21 14 12.46 22 3"/>',
      "message-circle":'<path d="M21 11.5a8.38 8.38 0 0 1-.9 3.8 8.5 8.5 0 0 1-7.6 4.7 8.38 8.38 0 0 1-3.8-.9L3 21l1.9-5.7a8.38 8.38 0 0 1-.9-3.8 8.5 8.5 0 0 1 4.7-7.6 8.38 8.38 0 0 1 3.8-.9h.5a8.48 8.48 0 0 1 8 8v.5z"/>'
    };
    function renderIcons(root){
      (root||document).querySelectorAll("svg[data-icon]").forEach(function(svg){
        var name = svg.getAttribute("data-icon");
        if(svg.dataset.rendered === name) return;
        var inner = ICONS[name];
        if(inner === undefined) return;
        svg.setAttribute("viewBox","0 0 24 24");
        svg.innerHTML = inner;
        svg.dataset.rendered = name;
      });
    }
    function $(sel,ctx){ return (ctx||document).querySelector(sel); }
    function $all(sel,ctx){ return Array.prototype.slice.call((ctx||document).querySelectorAll(sel)); }
    function el(tag,cls,html){ var e=document.createElement(tag); if(cls)e.className=cls; if(html!==undefined)e.innerHTML=html; return e; }
    function esc(s){ var d=document.createElement("div"); d.textContent = s==null?"":String(s); return d.innerHTML; }
    function toast(title,msg,type){
      type = type || "success";
      var stack = $("#toastStack");
      var t = el("div","toast "+(type==="error"?"error":type==="warn"?"warn":""));
      var icoName = type==="error" ? "alert" : type==="warn" ? "alert" : "check-circle";
      t.innerHTML = '<svg class="ic" data-icon="'+icoName+'"></svg><div class="toast-msg"><strong style="display:block">'+esc(title)+'</strong>'+(msg?'<span style="color:#A8B3C7">'+esc(msg)+'</span>':"")+'</div><svg class="ic toast-close" data-icon="close"></svg>';
      stack.appendChild(t);
      renderIcons(t);
      requestAnimationFrame(function(){ t.classList.add("show"); });
      function remove(){ t.classList.remove("show"); setTimeout(function(){ t.remove(); },300); }
      $(".toast-close",t).addEventListener("click",remove);
      setTimeout(remove,4200);
    }

    document.addEventListener("DOMContentLoaded", function(){
      renderIcons(document);

      var dd = document.getElementById("dashDate");
      if(dd){
        var now = new Date();
        dd.textContent = now.toLocaleDateString("en-IN",{weekday:"long",day:"numeric",month:"long",year:"numeric"});
      }

      initImportExportWorkspace();
      initHeaderFilters();
      renderShipmentsTrend();
      applyRealDashboardData();
      applyNakStatusCard();
      applyQueryReplyCard();
      applyIgmRegularisedCard();
    });

    /* ============================================================
       REAL DATA -> KPI CARDS / SHIPMENT BREAKDOWN / MODE SHARE DONUT
       window.dashKpi and window.dashModeBreakdown come from Load_Chart_ModeWise()
       in the code-behind (DASHBOARD_JOB_REPORT_MODEWISE_SELECT_NEW_02's TOTAL row
       and per-mode TOTAL_NO sums). If dashKpi never got emitted (0 rows - see the
       diagnostic banner), the cards just keep the 0 defaults already in the markup.
       ============================================================ */
    function applyRealDashboardData(){
      var kpi = window.dashKpi;
      if(!kpi) return;

      var total = kpi.totalShipments || 0;
      function pct(part){ return total > 0 ? Math.round((part / total) * 1000) / 10 : 0; }
      function setText(id, val){ var e = document.getElementById(id); if(e) e.textContent = val; }
      function setHtml(id, html){ var e = document.getElementById(id); if(e) e.innerHTML = html; }
      function growthHtml(g, suffix){
        if(g === null || g === undefined) return suffix;
        var arrow = g >= 0 ? "&uarr;" : "&darr;";
        var color = g >= 0 ? "var(--gr)" : "var(--rd)";
        return '<span style="color:' + color + ';font-weight:600">' + arrow + ' ' + Math.abs(g) + '%</span>' + suffix;
      }

      setText("kpiTotalVal", total);
      setHtml("kpiTotalSub", growthHtml(kpi.growthPct, " vs last month"));

      // Draft/Sent/Received labels read differently depending on which side of
      // the "Import & Export" header filter is selected: Import jobs move
      // through BE (Bill of Entry) stages, Export jobs through SB (Shipping
      // Bill) stages, so the generic labels are swapped for the Import/Export-
      // specific ones. On "Import & Export" (both), since there's no single
      // BE/SB context, both are named together ("BE/SB Sent Jobs" etc).
      var typeFilterEl = document.getElementById("dashFilterType");
      var curType = typeFilterEl ? typeFilterEl.value : "";
      var draftLabel = "Created Jobs", sentLabel = "BE/SB Sent Jobs", receivedLabel = "BE/SB Received Jobs";
      if(curType === "import"){
        draftLabel = "Created Jobs"; sentLabel = "BE Sent Jobs"; receivedLabel = "BE Received Jobs";
      } else if(curType === "export"){
        draftLabel = "Created Jobs"; sentLabel = "SB Sent Jobs"; receivedLabel = "SB Received Jobs";
      }
      setText("kpiDraftLabel", draftLabel);
      setText("kpiSentLabel", sentLabel);
      setText("kpiReceivedLabel", receivedLabel);

      // OOC (Out of Charge, Import) / LEO (Let Export Order, Export) - same
      // Import/Export label-switching pattern as Draft/Sent/Received above.
      var oocLeoLabel = "OOC/LEO Received";
      if(curType === "import") oocLeoLabel = "OOC Received";
      else if(curType === "export") oocLeoLabel = "LEO Received";
      setText("kpiOocLeoLabel", oocLeoLabel);

      // Real count now, from BE_STATUS_TRACKING_AUTOMATION.OOC_DATE (Import) / the export-side
      // LEO_DATE equivalent, summed server-side into dashKpi.oocLeoJobs by BuildModeWiseJson()
      // in the code-behind (see the OOC/LEO SQL script for DASHBOARD_JOB_REPORT_MODEWISE_SELECT_
      // USERWISE_IEC_BASED_SEARCH). pct() below still reads against `total` (all shipments),
      // same denominator as every other KPI sub-line on this row.
      setText("kpiOocLeoVal", kpi.oocLeoJobs || 0);

      setText("kpiDraftVal", kpi.draftJobs);
      setText("kpiDraftSub", pct(kpi.draftJobs) + "% of total");

      setText("kpiSentVal", kpi.sentJobs);
      setText("kpiSentSub", pct(kpi.sentJobs) + "% of total");

      setText("kpiReceivedVal", kpi.receivedJobs);
      setText("kpiReceivedSub", pct(kpi.receivedJobs) + "% of total");

      setText("kpiCancelledVal", kpi.cancelledJobs);
      setText("kpiCancelledSub", pct(kpi.cancelledJobs) + "% of total");

      setHtml("kpiGrowthVal", (kpi.growthPct === null || kpi.growthPct === undefined)
        ? "--" : ((kpi.growthPct >= 0 ? "&uarr; " : "&darr; ") + Math.abs(kpi.growthPct) + "%"));

      var mb = window.dashModeBreakdown || {};
      var airImport = mb.airImport || 0, airExport = mb.airExport || 0;
      var seaImport = mb.seaImport || 0, seaExport = mb.seaExport || 0;
      var landImport = mb.landImport || 0, landExport = mb.landExport || 0;
      var others = landImport + landExport;

      // Shipment Breakdown (tiles) and Mode Share (donut) both come from dashModeBreakdown,
      // a mode+type total that's independent of the KPI header's `total` (Created + Sent +
      // Received + OOC/LEO Received + Cancelled - OOC/LEO overlaps with Received rather than
      // being a distinct bucket on top of it, so the two totals are genuinely different
      // numbers). Use their own total as the percentage denominator so the tiles/donut always
      // sum to 100% and the footer/center figures match what's actually shown next to them,
      // instead of borrowing the bigger KPI `total` and drifting out of sync with it.
      var modeTotal = airImport + airExport + seaImport + seaExport + landImport + landExport;
      function pctMode(part){ return modeTotal > 0 ? Math.round((part / modeTotal) * 1000) / 10 : 0; }

      function applyTile(name, count){
        setText("tile" + name + "Count", count);
        setText("tile" + name + "Pct", pctMode(count) + "% of total");
        var bar = document.getElementById("tile" + name + "Bar");
        if(bar) bar.style.width = pctMode(count) + "%";
      }
      applyTile("AirImport", airImport);
      applyTile("AirExport", airExport);
      applyTile("SeaImport", seaImport);
      applyTile("SeaExport", seaExport);
      applyTile("Others", others);

      setText("breakdownTotalVal", modeTotal);
      setHtml("breakdownGrowthVal", growthHtml(kpi.growthPct, ' <span style="color:var(--g5);font-weight:400">vs last month</span>'));

      // Mode Share donut: Sea = seaImport+seaExport, Air = airImport+airExport, Land = others
      var seaTotal = seaImport + seaExport, airTotal = airImport + airExport, landTotal = others;
      var CIRC = 364.42;
      function setArc(id, len, offset){
        var c = document.getElementById(id);
        if(!c) return;
        c.setAttribute("stroke-dasharray", len.toFixed(2) + " " + CIRC);
        c.setAttribute("stroke-dashoffset", offset.toFixed(2));
        // stroke-linecap="round" draws a full dot (diameter = stroke-width) even for a
        // 0-length dash, so a 0% segment still shows a colored blob on the ring - hide the
        // circle outright instead of relying on the dasharray length to make it invisible.
        c.style.opacity = len > 0.01 ? "1" : "0";
      }
      var seaLen = modeTotal > 0 ? (seaTotal / modeTotal) * CIRC : 0;
      var airLen = modeTotal > 0 ? (airTotal / modeTotal) * CIRC : 0;
      var landLen = modeTotal > 0 ? (landTotal / modeTotal) * CIRC : 0;
      setArc("modeShareSeaArc", seaLen, 0);
      setArc("modeShareAirArc", airLen, -seaLen);
      setArc("modeShareLandArc", landLen, -(seaLen + airLen));

      setText("modeShareCenterVal", modeTotal);
      setText("modeShareSeaPct", pctMode(seaTotal) + "%");
      setText("modeShareAirPct", pctMode(airTotal) + "%");
      setText("modeShareLandPct", pctMode(landTotal) + "%");
    }

    // NAK Status card (importExtraCard row) - real count of Import jobs with a pending
    // .nak mail and no matching .ack yet, from dbo.IMPORT_NAK_ACK_PENDING_SEARCH (see
    // Dashboard.IMPORT_NAK_ACK_PENDING_COUNT() in the code-behind). window.dashNakStatusCount
    // is emitted on initial page load (Load_Chart_ModeWise()) and refreshed on every filter
    // change (GetModeWiseDashboardData() - see refetchFromServer() above).
    function applyNakStatusCard(){
      var e = document.getElementById("kpiNakStatusVal");
      if(e) e.textContent = (typeof window.dashNakStatusCount === "number") ? window.dashNakStatusCount : 0;
    }

    // Query Reply card (importExtraCard row) - real count from dbo.IMPORT_QUERY_PENDING_SEARCH
    // (see Dashboard.IMPORT_QUERY_PENDING_COUNT() in the code-behind).
    // window.dashQueryReplyCount is emitted on initial page load (Load_Chart_ModeWise()) and
    // refreshed on every filter change (GetModeWiseDashboardData() below). Clicking the card
    // opens its own drill-down row - see toggleQueryReplyDrilldown() below.
    function applyQueryReplyCard(){
      var e = document.getElementById("kpiQueryReplyVal");
      if(e) e.textContent = (typeof window.dashQueryReplyCount === "number") ? window.dashQueryReplyCount : 0;
    }

    // IGM Regularised card (importExtraCard row) - real count from dbo.IMPORT_REGULARISED_
    // PENDING_SEARCH (see Dashboard.IMPORT_REGULARISED_PENDING_COUNT() in the code-behind).
    // window.dashIgmRegularisedCount is emitted on initial page load (Load_Chart_ModeWise())
    // and refreshed on every filter change (GetModeWiseDashboardData() below). Clicking the card
    // opens its own drill-down row - see toggleIgmRegularisedDrilldown() below.
    function applyIgmRegularisedCard(){
      var e = document.getElementById("kpiIgmRegularisedVal");
      if(e) e.textContent = (typeof window.dashIgmRegularisedCount === "number") ? window.dashIgmRegularisedCount : 0;
    }

    // NAK Status drill-down - clicking the card opens the row below it with the real pending
    // rows (Job No + File Remarks only) behind the count, via GetNakStatusPendingJobs()
    // (see the code-behind). Unlike the KPI drill-down further below, this is a small dataset
    // (pending NAK mails, not the full job list), so it's fetched whole in one PageMethod call
    // and handed to DataTables for client-side paging/search - no server-side DataTables
    // protocol needed. Reuses ensureDataTablesLib()/dtJQ (defined below) so the DataTables
    // library is only ever loaded once regardless of which drill-down is opened first.
    var nakStatusDrilldownOpen = false;
    var nakStatusTable = null;

    function toggleNakStatusDrilldown(){
      if(nakStatusDrilldownOpen){ closeNakStatusDrilldown(); return; }
      // Only one drill-down panel open at a time - same single-panel behavior as the 6 KPI
      // cards switching between each other (see toggleKpiDrilldown() below, which closes this
      // one the same way) and the IGM Regularised / Query Reply drill-downs.
      closeKpiDrilldown();
      closeIgmRegularisedDrilldown();
      closeQueryReplyDrilldown();
      nakStatusDrilldownOpen = true;
      document.getElementById("nakStatusDrilldown").style.display = "block";
      var card = document.getElementById("kpiCard_nakStatus");
      if(card) card.classList.add("kpi-card-active");
      loadNakStatusDrilldown();
    }
    function closeNakStatusDrilldown(){
      nakStatusDrilldownOpen = false;
      document.getElementById("nakStatusDrilldown").style.display = "none";
      var card = document.getElementById("kpiCard_nakStatus");
      if(card) card.classList.remove("kpi-card-active");
    }
    // Called again whenever the header's Mode filter changes while the panel is open (see
    // refetchFromServer() above) so the pending-NAK list stays in sync with that filter,
    // same "reload while open" behavior as window.refreshKpiDrilldownIfOpen() below.
    window.refreshNakStatusDrilldownIfOpen = function(){ if(nakStatusDrilldownOpen) loadNakStatusDrilldown(); };

    function loadNakStatusDrilldown(){
      if(typeof PageMethods === "undefined" || !PageMethods.GetNakStatusPendingJobs) return;
      var modeFilterEl = document.getElementById("dashFilterMode");
      var curMode = modeFilterEl ? modeFilterEl.value : "";
      ensureDataTablesLib(function(){
        PageMethods.GetNakStatusPendingJobs(curMode, function(result){
          var rows;
          try { rows = JSON.parse(result) || []; } catch(e){ rows = []; }
          var countEl = document.getElementById("nakStatusDrilldownCount");
          if(countEl) countEl.textContent = rows.length + " job" + (rows.length === 1 ? "" : "s");

          // Checks the DOM directly (dtJQ.fn.DataTable.isDataTable), not just the nakStatusTable
          // variable - two overlapping loads (e.g. the user re-toggling the card before the first
          // PageMethod response lands) would otherwise both see nakStatusTable as still null and
          // both call .DataTable({...}) below, which DataTables allows but leaves a second,
          // misaligned set of length/pagination controls stacked under the first. This makes a
          // late-arriving duplicate response update the one real table instead.
          if(nakStatusTable || dtJQ.fn.DataTable.isDataTable("#nakStatusDrilldownTable")){
            nakStatusTable = dtJQ("#nakStatusDrilldownTable").DataTable();
            nakStatusTable.clear(); nakStatusTable.rows.add(rows).draw();
            return;
          }

          nakStatusTable = dtJQ("#nakStatusDrilldownTable").DataTable({
            data: rows,
            ordering: false,
            pageLength: 10,
            lengthMenu: [10, 25, 50, 100],
            dom: '<"kpi-dt-top"f l>rt<"kpi-dt-bottom"ip>',
            columns: [
              { data: "jobNo", className: "kpi-dd-name", render: function(d, t){ return t === "display" ? esc(d) : d; } },
              { data: "fileRemarks", render: function(d, t){ return t === "display" ? esc(d) : d; } }
            ],
            language: {
              search: "",
              searchPlaceholder: "Search...",
              lengthMenu: "Show _MENU_",
              emptyTable: "No pending NAK jobs found.",
              zeroRecords: "No pending NAK jobs found.",
              info: "Showing _START_ to _END_ of _TOTAL_ jobs",
              infoEmpty: "No jobs to show",
              infoFiltered: ""
            }
          });

          // Clicking a row opens that job's real popup in the parent window, same as the KPI
          // drill-down's row click (openKpiDrilldownJob() below) - see openImportDrilldownJob().
          dtJQ("#nakStatusDrilldownTable tbody").on("click", "tr", function(){
            var rowData = nakStatusTable.row(this).data();
            if(rowData) openImportDrilldownJob(rowData);
          });
        }, function(){
          var countEl = document.getElementById("nakStatusDrilldownCount");
          if(countEl) countEl.textContent = "";
        });
      });
    }

    // Opens a clicked drill-down row's real job popup - in the PARENT window, same reason and
    // same opener (General_Details_Update() from js/iframepopupwin.js) as openKpiDrilldownJob()
    // below. Shared by both the NAK Status and IGM Regularised drill-downs (both Import-only, so
    // there's no Export branch here). Neither GetNakStatusPendingJobs() nor
    // GetIgmRegularisedPendingJobs() carries jobId for most rows (see their comments in the
    // code-behind), so it's resolved here on demand via GetImportJobId(), once per click, rather
    // than for every row up front - keeps the list load fast and only pays for the lookup on
    // rows the user actually opens.
    var importDrilldownJobIdRequestToken = 0;
    function openImportDrilldownJob(r){
      if(!r || !r.jobNo) return;
      if(r.jobId){ launchImportJobPopup(r.jobId); return; }
      if(typeof PageMethods === "undefined" || !PageMethods.GetImportJobId){
        toast("Could not open job", "The popup opener isn't available from this window.", "error");
        return;
      }
      var myToken = ++importDrilldownJobIdRequestToken;
      PageMethods.GetImportJobId(r.jobNo, function(jobId){
        if(myToken !== importDrilldownJobIdRequestToken) return; // user clicked another row meanwhile
        if(!jobId){ toast("Could not open job", "Job \"" + r.jobNo + "\" was not found.", "error"); return; }
        r.jobId = jobId; // cache on the row's own data object so re-clicking it skips the lookup
        launchImportJobPopup(jobId);
      }, function(){
        if(myToken !== importDrilldownJobIdRequestToken) return;
        toast("Could not open job", "The popup opener isn't available from this window.", "error");
      });
    }
    function launchImportJobPopup(jobId){
      try {
        if(window.parent && window.parent.General_Details_Update){
          window.parent.General_Details_Update(jobId);
        } else {
          toast("Could not open job", "The popup opener isn't available from this window.", "error");
        }
      } catch(e){
        toast("Could not open job", "The popup opener isn't available from this window.", "error");
      }
    }

    // IGM Regularised drill-down - same fetch-everything-in-one-call / client-side DataTables
    // pattern as the NAK Status drill-down above (small dataset, not the full job list), via
    // GetIgmRegularisedPendingJobs() (see the code-behind). Row click reuses
    // openImportDrilldownJob() above (both drill-downs are Import-only).
    var igmRegularisedDrilldownOpen = false;
    var igmRegularisedTable = null;

    function toggleIgmRegularisedDrilldown(){
      if(igmRegularisedDrilldownOpen){ closeIgmRegularisedDrilldown(); return; }
      // Only one drill-down panel open at a time - same single-panel behavior as the 6 KPI
      // cards and the NAK Status / Query Reply drill-downs.
      closeKpiDrilldown();
      closeNakStatusDrilldown();
      closeQueryReplyDrilldown();
      igmRegularisedDrilldownOpen = true;
      document.getElementById("igmRegularisedDrilldown").style.display = "block";
      var card = document.getElementById("kpiCard_igmRegularised");
      if(card) card.classList.add("kpi-card-active");
      loadIgmRegularisedDrilldown();
    }
    function closeIgmRegularisedDrilldown(){
      igmRegularisedDrilldownOpen = false;
      document.getElementById("igmRegularisedDrilldown").style.display = "none";
      var card = document.getElementById("kpiCard_igmRegularised");
      if(card) card.classList.remove("kpi-card-active");
    }
    // Called again whenever the header's Mode filter changes while the panel is open - same
    // "reload while open" behavior as window.refreshNakStatusDrilldownIfOpen() above.
    window.refreshIgmRegularisedDrilldownIfOpen = function(){ if(igmRegularisedDrilldownOpen) loadIgmRegularisedDrilldown(); };

    function loadIgmRegularisedDrilldown(){
      if(typeof PageMethods === "undefined" || !PageMethods.GetIgmRegularisedPendingJobs) return;
      var modeFilterEl = document.getElementById("dashFilterMode");
      var curMode = modeFilterEl ? modeFilterEl.value : "";
      ensureDataTablesLib(function(){
        PageMethods.GetIgmRegularisedPendingJobs(curMode, function(result){
          var rows;
          try { rows = JSON.parse(result) || []; } catch(e){ rows = []; }
          var countEl = document.getElementById("igmRegularisedDrilldownCount");
          if(countEl) countEl.textContent = rows.length + " job" + (rows.length === 1 ? "" : "s");

          // See nakStatusTable's equivalent guard above for why this checks the DOM directly
          // instead of just the igmRegularisedTable variable.
          if(igmRegularisedTable || dtJQ.fn.DataTable.isDataTable("#igmRegularisedDrilldownTable")){
            igmRegularisedTable = dtJQ("#igmRegularisedDrilldownTable").DataTable();
            igmRegularisedTable.clear(); igmRegularisedTable.rows.add(rows).draw();
            return;
          }

          igmRegularisedTable = dtJQ("#igmRegularisedDrilldownTable").DataTable({
            data: rows,
            ordering: false,
            pageLength: 10,
            lengthMenu: [10, 25, 50, 100],
            dom: '<"kpi-dt-top"f l>rt<"kpi-dt-bottom"ip>',
            columns: [
              { data: "jobNo", className: "kpi-dd-name", render: function(d, t){ return t === "display" ? esc(d) : d; } },
              { data: "filingStatus", render: function(d, t){ return t === "display" ? esc(d) : d; } }
            ],
            language: {
              search: "",
              searchPlaceholder: "Search...",
              lengthMenu: "Show _MENU_",
              emptyTable: "No pending IGM Regularised jobs found.",
              zeroRecords: "No pending IGM Regularised jobs found.",
              info: "Showing _START_ to _END_ of _TOTAL_ jobs",
              infoEmpty: "No jobs to show",
              infoFiltered: ""
            }
          });

          // Clicking a row opens that job's real popup in the parent window - see
          // openImportDrilldownJob() above.
          dtJQ("#igmRegularisedDrilldownTable tbody").on("click", "tr", function(){
            var rowData = igmRegularisedTable.row(this).data();
            if(rowData) openImportDrilldownJob(rowData);
          });
        }, function(){
          var countEl = document.getElementById("igmRegularisedDrilldownCount");
          if(countEl) countEl.textContent = "";
        });
      });
    }

    // Query Reply drill-down - same fetch-everything-in-one-call / client-side DataTables
    // pattern as the NAK Status / IGM Regularised drill-downs above, via
    // GetQueryReplyPendingJobs() (see the code-behind). That PageMethod already resolves each
    // row's Job No from its BE_NO server-side, so this table (unlike NAK/IGM) always has jobId
    // up front - no per-click GetImportJobId() lookup needed, openImportDrilldownJob() above just
    // opens it directly.
    var queryReplyDrilldownOpen = false;
    var queryReplyTable = null;

    function toggleQueryReplyDrilldown(){
      if(queryReplyDrilldownOpen){ closeQueryReplyDrilldown(); return; }
      // Only one drill-down panel open at a time - same single-panel behavior as the 6 KPI
      // cards and the NAK Status / IGM Regularised drill-downs above.
      closeKpiDrilldown();
      closeNakStatusDrilldown();
      closeIgmRegularisedDrilldown();
      queryReplyDrilldownOpen = true;
      document.getElementById("queryReplyDrilldown").style.display = "block";
      var card = document.getElementById("kpiCard_queryReply");
      if(card) card.classList.add("kpi-card-active");
      loadQueryReplyDrilldown();
    }
    function closeQueryReplyDrilldown(){
      queryReplyDrilldownOpen = false;
      document.getElementById("queryReplyDrilldown").style.display = "none";
      var card = document.getElementById("kpiCard_queryReply");
      if(card) card.classList.remove("kpi-card-active");
    }
    // Called again whenever the header's Mode filter changes while the panel is open - same
    // "reload while open" behavior as window.refreshNakStatusDrilldownIfOpen() above.
    window.refreshQueryReplyDrilldownIfOpen = function(){ if(queryReplyDrilldownOpen) loadQueryReplyDrilldown(); };

    function loadQueryReplyDrilldown(){
      if(typeof PageMethods === "undefined" || !PageMethods.GetQueryReplyPendingJobs) return;
      var modeFilterEl = document.getElementById("dashFilterMode");
      var curMode = modeFilterEl ? modeFilterEl.value : "";
      ensureDataTablesLib(function(){
        PageMethods.GetQueryReplyPendingJobs(curMode, function(result){
          var rows;
          try { rows = JSON.parse(result) || []; } catch(e){ rows = []; }
          var countEl = document.getElementById("queryReplyDrilldownCount");
          if(countEl) countEl.textContent = rows.length + " job" + (rows.length === 1 ? "" : "s");

          // Checks the DOM directly (dtJQ.fn.DataTable.isDataTable), not just the queryReplyTable
          // variable. This load is the slowest of the three drill-downs (GetQueryReplyPendingJobs
          // resolves every row's Job No via a separate BE_NO search server-side - see the
          // code-behind), which makes it the easiest to re-trigger before the first PageMethod
          // response lands (e.g. clicking the card again while it's still loading). Two overlapping
          // loads would otherwise both see queryReplyTable as still null and both call
          // .DataTable({...}) below - DataTables allows that, but it leaves a second, misaligned
          // set of length/pagination controls stacked under the first, which is exactly the
          // "pagination not showing properly" symptom. This makes a late-arriving duplicate
          // response update the one real table instead of initializing a second one.
          if(queryReplyTable || dtJQ.fn.DataTable.isDataTable("#queryReplyDrilldownTable")){
            queryReplyTable = dtJQ("#queryReplyDrilldownTable").DataTable();
            queryReplyTable.clear(); queryReplyTable.rows.add(rows).draw();
            return;
          }

          queryReplyTable = dtJQ("#queryReplyDrilldownTable").DataTable({
            data: rows,
            ordering: false,
            pageLength: 10,
            lengthMenu: [10, 25, 50, 100],
            dom: '<"kpi-dt-top"f l>rt<"kpi-dt-bottom"ip>',
            columns: [
              { data: "jobNo", className: "kpi-dd-name", render: function(d, t){ return t === "display" ? esc(d) : d; } },
              { data: "beNo", render: function(d, t){ return t === "display" ? esc(d) : d; } }
            ],
            language: {
              search: "",
              searchPlaceholder: "Search...",
              lengthMenu: "Show _MENU_",
              emptyTable: "No pending Query Reply jobs found.",
              zeroRecords: "No pending Query Reply jobs found.",
              info: "Showing _START_ to _END_ of _TOTAL_ jobs",
              infoEmpty: "No jobs to show",
              infoFiltered: ""
            }
          });

          // Clicking a row opens that job's real popup in the parent window - see
          // openImportDrilldownJob() above.
          dtJQ("#queryReplyDrilldownTable tbody").on("click", "tr", function(){
            var rowData = queryReplyTable.row(this).data();
            if(rowData) openImportDrilldownJob(rowData);
          });
        }, function(){
          var countEl = document.getElementById("queryReplyDrilldownCount");
          if(countEl) countEl.textContent = "";
        });
      });
    }

    /* ============================================================
       KPI DRILL-DOWN (top cards -> expandable data-grid row underneath them)
       Each row is a REAL job (Job No, Party, Mode, Date, Status), not an
       aggregate - fetched via the GetKpiDrilldownJobsPage() PageMethod (server-side
       DataTables processing - see initKpiDrilldownDataTable() below), which reuses
       the exact same job-list source Transaction/General_Search.aspx and
       Export/General_Search.aspx already use (Import_General_Grid_Search /
       Export_General_Grid_Search - see the code-behind), filtered to whichever
       status the clicked card represents, LAZILY - only the page of rows actually
       on screen is ever fetched, not the full match set (see the code-behind's
       "KPI DRILL-DOWN GRID - server-side (lazy) pagination" comment for why that
       matters at 20,000-50,000 jobs). Clicking a row opens that job's real popup
       in the PARENT window - General_Details_Update() for Import,
       Export_General_Update() for Export, both from js/iframepopupwin.js. Those
       only exist on the top-level document (E_royal_Impex_Main.aspx, which
       loads windowfiles/dhtmlwindow.js + modalfiles/modal.js), not on this page,
       since it's loaded inside Main's #mainiframecontainer iframe - see
       openKpiDrilldownJob() below.
       ============================================================ */
    var kpiDrilldownMetric = null;
    var kpiDrilldownRequestToken = 0; // bumped whenever the metric/card changes, so a
                                       // slow/stale AJAX response for a card the user has
                                       // since moved away from gets dropped instead of
                                       // overwriting what's on screen now.
    var kpiDrilldownTable = null;     // the live DataTable instance, once initKpiDrilldownDataTable()
                                       // has run once. Reused (not destroyed/recreated) across
                                       // card switches and filter changes - its `ajax` function
                                       // reads kpiDrilldownMetric/dashFilterType/dashFilterMode
                                       // live on every draw, so a plain .ajax.reload() is enough.

    var KPI_DD_META = {
      total:     { title: "Total Shipments",    icon: "package" },
      draft:     { title: "Draft Jobs",         icon: "clock" },
      sent:      { title: "Sent Jobs",          icon: "upload" },
      received:  { title: "Received Jobs",      icon: "check-circle" },
      oocleo:    { title: "OOC/LEO Received",   icon: "truck", labelId: "kpiOocLeoLabel" },
      cancelled: { title: "Cancelled Jobs",     icon: "alert" }
    };

    function toggleKpiDrilldown(metric){
      if(kpiDrilldownMetric === metric){ closeKpiDrilldown(); return; }
      // Only one drill-down panel open at a time - see closeNakStatusDrilldown()/
      // closeIgmRegularisedDrilldown()/closeQueryReplyDrilldown() calls in their own toggle
      // functions above for the reverse direction.
      closeNakStatusDrilldown();
      closeIgmRegularisedDrilldown();
      closeQueryReplyDrilldown();
      kpiDrilldownMetric = metric;
      renderKpiDrilldown();
      document.getElementById("kpiDrilldown").style.display = "block";
      updateKpiCardActiveStates();
    }
    function closeKpiDrilldown(){
      kpiDrilldownMetric = null;
      kpiDrilldownRequestToken++;
      document.getElementById("kpiDrilldown").style.display = "none";
      updateKpiCardActiveStates();
    }
    function updateKpiCardActiveStates(){
      Object.keys(KPI_DD_META).forEach(function(m){
        var card = document.getElementById("kpiCard_" + m);
        if(card) card.classList.toggle("kpi-card-active", m === kpiDrilldownMetric);
      });
    }
    window.refreshKpiDrilldownIfOpen = function(){ if(kpiDrilldownMetric) renderKpiDrilldown(); };

    // Sets the panel's title/icon for the newly-selected card, then (re)loads the grid. Unlike
    // the old eager version, this function itself never fetches rows - initKpiDrilldownDataTable()
    // owns fetching now, via DataTables' own serverSide `ajax` function calling
    // PageMethods.GetKpiDrilldownJobsPage for exactly the rows currently on screen. That's what
    // makes a card click show its first ~10 rows near-instantly instead of waiting on a full
    // page-walk of the underlying job list first, the way it used to.
    function renderKpiDrilldown(){
      var metric = kpiDrilldownMetric;
      if(!metric) return;
      var meta = KPI_DD_META[metric];

      // Use the card's OWN current label text (Draft/Sent/Received become
      // Create/BE Sent/SB Sent etc. depending on the Import-Export filter - see
      // applyRealDashboardData() above) so the panel title always matches
      // exactly what the card it was opened from currently says.
      var labelId = meta.labelId || ("kpi" + metric.charAt(0).toUpperCase() + metric.slice(1) + "Label");
      var labelEl = document.getElementById(labelId);
      document.getElementById("kpiDrilldownTitle").textContent = labelEl ? labelEl.textContent : meta.title;
      var iconEl = document.getElementById("kpiDrilldownIcon");
      iconEl.removeAttribute("data-rendered");
      iconEl.setAttribute("data-icon", meta.icon);
      renderIcons(document.getElementById("kpiDrilldown"));

      kpiDrilldownRequestToken++; // invalidate any in-flight fetch for a card/metric just left
      initKpiDrilldownDataTable();
    }

    // DataTables 2.x needs jQuery >= 1.7 (it calls .on()/.off() internally). This app's
    // OWN jQuery - both the copy in <head> (MessageBox_js/jquery.js, v1.3.2) and the one
    // the master page loads after this content (js/jquery.min.js, v1.4.4) - predate that
    // by years, so DataTables can't attach to either one (confirmed live: it throws
    // "H(...).on is not a function" the instant it tries). Pointing window.jQuery at a
    // newer version would fix that but break the rest of the app, which depends on the
    // OLD jQuery/$ staying exactly as they are (jquery.alerts, jquery-ui, this page's own
    // code, etc.). So instead: load a modern jQuery (3.7.1) as a THROWAWAY global,
    // immediately jQuery.noConflict(true) it back out into a private variable (dtJQ) so
    // window.jQuery/$ go right back to being the app's originals, then briefly re-point
    // window.jQuery at dtJQ only while DataTables' own script tag executes and attaches
    // itself (its UMD wrapper reads the plain `jQuery` global at load time), restoring
    // the app's real jQuery/$ immediately after. From here on ALL DataTables calls use
    // dtJQ - the app's own $/jQuery are never touched.
    var dtJQ = null;
    var dataTablesLibPromise = null;
    function ensureDataTablesLib(cb){
      if(dtJQ && dtJQ.fn && dtJQ.fn.DataTable){ cb(); return; }
      if(!dataTablesLibPromise){
        dataTablesLibPromise = new Promise(function(resolve){
          var jq = document.createElement("script");
          jq.src = "../js/jquery-3.7.1.min.js";
          jq.onload = function(){
            dtJQ = window.jQuery.noConflict(true);
            var origJQuery = window.jQuery, origDollar = window.$;
            window.jQuery = dtJQ;
            var dt = document.createElement("script");
            dt.src = "../js/dataTables.min.js";
            dt.onload = function(){
              window.jQuery = origJQuery;
              window.$ = origDollar;
              resolve();
            };
            dt.onerror = function(){
              window.jQuery = origJQuery;
              window.$ = origDollar;
              resolve();
            };
            document.body.appendChild(dt);
          };
          jq.onerror = resolve;
          document.body.appendChild(jq);
        });
      }
      dataTablesLibPromise.then(cb);
    }

    // Initializes the KPI drill-down grid ONCE as a server-side-processing DataTable (every
    // later call just reloads it) - true lazy pagination: each draw (first load, every page
    // turn, every search keystroke after its debounce, every card/filter switch) calls
    // GetKpiDrilldownJobsPage on the server for EXACTLY the rows[start, start+length) it
    // needs, instead of the old approach of fetching every matching job up front. That's what
    // makes this scale to 20,000-50,000-job companies the same way it does at 600 - a card
    // click only ever pays for the page currently on screen, never the full match count.
    //  - 10 rows per page by default (pageLength:10); "Show N entries" length menu top-right
    //    still works (dom's <f l> group) - a bigger page size just means the server walks
    //    further to fill THAT page, same lazy-per-request behavior either way.
    //  - search box top-left; routed server-side into IMPORTER_NAME/EXPORTER_NAME (see the
    //    `ajax` function below) - a real SP-level filter, not a client-side re-filter of
    //    whatever's already loaded.
    //  - page-number pagination bottom-right, next to the info text (dom's <i p> group,
    //    laid out with .kpi-dt-bottom).
    //  - ordering:false - column headers aren't click-to-sort. The SP has no server-side sort,
    //    and a true re-sort would need the full match set in hand first, which is exactly what
    //    lazy loading is here to avoid - so there are no sort arrows promising something this
    //    can't actually do.
    //  - processing:true shows a small "Loading..." indicator during each fetch WITHOUT
    //    clearing the rows already on screen, unlike the old "wipe tbody, show one Loading...
    //    row" approach.
    function initKpiDrilldownDataTable(){
      ensureDataTablesLib(function(){
        if(kpiDrilldownTable){ kpiDrilldownTable.ajax.reload(); return; }

        kpiDrilldownTable = dtJQ("#kpiDrilldownTable").DataTable({
          serverSide: true,
          processing: true,
          ordering: false,
          pageLength: 10,
          lengthMenu: [10, 25, 50, 100],
          searchDelay: 400,
          dom: '<"kpi-dt-top"f l>rt<"kpi-dt-bottom"ip>',
          columns: [
            { data: "jobNo", className: "kpi-dd-name" },
            { data: "type", className: "kpi-dd-tag", render: function(d, t){
                if(t !== "display") return d;
                return '<span class="b ' + (d === "Import" ? "b-bl" : "b-pu") + '">' + esc(d) + '</span>';
              } },
            { data: "partyName", className: "kpi-dd-name", render: function(d, t){ return t === "display" ? esc(d) : d; } },
            { data: "mode", render: function(d, t){ return t === "display" ? esc(d) : d; } },
            { data: "jobDate", render: function(d, t){ return t === "display" ? esc(d) : d; } },
            { data: "status", className: "kpi-dd-tag", render: function(d, t){ return t === "display" ? esc(d) : d; } }
          ],
          // Bridges DataTables' serverSide contract to the ASP.NET PageMethod - not a URL,
          // so `ajax` is a function here rather than the usual string/object form. Reads
          // kpiDrilldownMetric and the dashFilterType/dashFilterMode dropdowns LIVE (not
          // captured at init time), which is what lets a card switch or filter change just
          // call kpiDrilldownTable.ajax.reload() instead of destroying/recreating the table.
          ajax: function(data, callback){
            if(!kpiDrilldownMetric || typeof PageMethods === "undefined" || !PageMethods.GetKpiDrilldownJobsPage){
              callback({ recordsTotal: 0, recordsFiltered: 0, data: [] });
              return;
            }
            var typeFilterEl = document.getElementById("dashFilterType");
            var curType = typeFilterEl ? typeFilterEl.value : "";
            var modeFilterEl = document.getElementById("dashFilterMode");
            var curMode = modeFilterEl ? modeFilterEl.value : "";
            var searchVal = (data.search && data.search.value) || "";
            var myToken = ++kpiDrilldownRequestToken;

            PageMethods.GetKpiDrilldownJobsPage(curType, curMode, kpiDrilldownMetric, searchVal, data.start, data.length, function(result){
              if(myToken !== kpiDrilldownRequestToken) return; // panel closed / switched to another card meanwhile
              var parsed;
              try { parsed = JSON.parse(result); } catch(e){ parsed = { recordsTotal: 0, recordsFiltered: 0, data: [] }; }
              document.getElementById("kpiDrilldownCount").textContent =
                parsed.recordsFiltered + (parsed.exhausted ? "" : "+") + " job" + (parsed.recordsFiltered === 1 && parsed.exhausted ? "" : "s");
              callback({ draw: data.draw, recordsTotal: parsed.recordsTotal, recordsFiltered: parsed.recordsFiltered, data: parsed.data || [] });
            }, function(){
              if(myToken !== kpiDrilldownRequestToken) return;
              callback({ draw: data.draw, recordsTotal: 0, recordsFiltered: 0, data: [] });
            });
          },
          language: {
            search: "",
            searchPlaceholder: "Search jobs...",
            lengthMenu: "Show _MENU_",
            processing: "Loading...",
            emptyTable: "No jobs found for this filter.",
            zeroRecords: "No jobs found for this filter.",
            info: "Showing _START_ to _END_ of _TOTAL_ jobs",
            infoEmpty: "No jobs to show",
            infoFiltered: ""
          }
        });

        dtJQ("#kpiDrilldownTable tbody").on("click", "tr", function(){
          var rowData = kpiDrilldownTable.row(this).data();
          if(rowData) openKpiDrilldownJob(rowData);
        });
      });
    }

    // Opens the clicked row's real job popup - in the PARENT window, since that's
    // where dhtmlmodal/General_Details_Update()/Export_General_Update() actually
    // live (this page is loaded inside Main's iframe and doesn't carry its own
    // copy of that popup library).
    function openKpiDrilldownJob(r){
      if(!r || !r.jobId) return;
      try {
        if(r.type === "Import" && window.parent && window.parent.General_Details_Update){
          window.parent.General_Details_Update(r.jobId);
        } else if(r.type === "Export" && window.parent && window.parent.Export_General_Update){
          window.parent.Export_General_Update(r.jobId);
        } else {
          toast("Could not open job", "The popup opener isn't available from this window.", "error");
        }
      } catch(e){
        toast("Could not open job", "The popup opener isn't available from this window.", "error");
      }
    }

    /* ============================================================
       SHIPMENTS TREND (Last 12 Months) - grouped bars (Sea / Air / Land
       Shipment), drawn as inline SVG (no chart library). Real data from
       window.dashTrend (built server-side in BuildModeWiseJson() -> the
       "SHIPMENTS TREND" block - see the code-behind), same per-month
       Sea/Air/Land totals that sum back to the KPI cards' monthly total.
       Falls back to the static demo numbers below only when dashTrend
       never got emitted (0 rows - see applyRealDashboardData()'s comment
       on the same fallback pattern for the KPI cards).
       ============================================================ */
    function renderShipmentsTrend(){
      var svg = document.getElementById("trendChartSvg");
      if(!svg) return;

      var real = window.dashTrend;
      var months, series;
      if(real && real.length){
        // dashTrend's "month" label comes straight from the SP's MonthYear column
        // ("September 2025") - fine as a select-option value elsewhere on this page,
        // but too wide for 12 columns of x-axis text at this chart's size (it was
        // overlapping into neighboring labels: "September 2025November 2025..").
        // Abbreviate to "Sep '25" here, same width class as the old static demo
        // labels ("Aug","Sep",..) this chart was originally sized for.
        months = real.map(function(r){
          var parts = (r.month || "").split(" ");
          return parts.length === 2 ? (parts[0].slice(0, 3) + " '" + parts[1].slice(-2)) : (r.month || "");
        });
        series = [
          { name: "sea",  color: "var(--bl)", values: real.map(function(r){ return r.sea  || 0; }) },
          { name: "air",  color: "var(--pu)", values: real.map(function(r){ return r.air  || 0; }) },
          { name: "land", color: "var(--g4)", values: real.map(function(r){ return r.land || 0; }) }
        ];
      } else {
        months = ["Aug","Sep","Oct","Nov","Dec","Jan","Feb","Mar","Apr","May","Jun","Jul"];
        series = [
          { name: "sea",  color: "var(--bl)", values: [136,146,128,156,166,174,172,183,192,195,179,203] },
          { name: "air",  color: "var(--pu)", values: [63,68,59,72,77,80,80,84,89,90,82,94] },
          { name: "land", color: "var(--g4)", values: [10,11,10,12,13,14,13,14,15,15,14,15] }
        ];
      }

      var W = 600, H = 170, padL = 6, padR = 6, padT = 16, padB = 24;
      var plotW = W - padL - padR, plotH = H - padT - padB;
      var allValues = [];
      series.forEach(function(s){ allValues = allValues.concat(s.values); });
      var maxV = (Math.max.apply(null, allValues) || 0) * 1.15;
      if(maxV <= 0) maxV = 1;
      var n = months.length;

      // Grouped bars: each month gets an equal-width slot, subdivided into one
      // bar per series.
      var groupW = plotW / n;
      var barGap = 1.5;
      var barW = (groupW - barGap * (series.length + 1)) / series.length;

      var barsHtml = "";
      months.forEach(function(m, i){
        var groupX = padL + groupW * i;
        series.forEach(function(s, si){
          var v = s.values[i];
          var barH = (v / maxV) * plotH;
          var x = groupX + barGap + si * (barW + barGap);
          var y = padT + plotH - barH;
          barsHtml += '<rect x="' + x + '" y="' + y + '" width="' + barW + '" height="' + barH +
            '" rx="1.5" class="trend-bar" style="fill:' + s.color + ';animation-delay:' + (i * 35 + si * 15) + 'ms"/>';
        });
      });

      var labelsHtml = months.map(function(m, i){
        var cx = padL + groupW * i + groupW / 2;
        return '<text x="' + cx + '" y="' + (H - 6) + '" text-anchor="middle" style="font-size:9px;fill:var(--g5)">' + m + '</text>';
      }).join("");

      svg.setAttribute("viewBox", "0 0 " + W + " " + H);
      svg.setAttribute("preserveAspectRatio", "none");
      svg.innerHTML = barsHtml + labelsHtml;

      updateTrendFooter(real);
    }

    // "Latest month: N shipments · ↑/↓ X% vs prior month" - only overwritten once real
    // dashTrend data is present; otherwise the static demo line already in the markup is
    // left alone (same reasoning as applyRealDashboardData()'s dashKpi guard above). The
    // growth % reuses window.dashKpi.growthPct rather than recomputing it here, since it's
    // the exact same latest-vs-prior-month comparison already done server-side in
    // BuildModeWiseJson() off the same monthTotals the Sea+Air+Land figures are summed from.
    function updateTrendFooter(real){
      var el = document.getElementById("trendFooter");
      if(!el || !real || !real.length) return;

      var last = real[real.length - 1];
      var total = (last.sea || 0) + (last.air || 0) + (last.land || 0);
      var g = window.dashKpi ? window.dashKpi.growthPct : null;
      var growthHtml = (g === null || g === undefined) ? "" :
        ' &nbsp;&middot;&nbsp; <span style="color:' + (g >= 0 ? "var(--gr)" : "var(--rd)") + ';font-weight:700">' +
        (g >= 0 ? "&uarr; " : "&darr; ") + Math.abs(g) + '%</span> vs prior month';

      el.innerHTML = "Latest month: <strong style=\"color:var(--n)\">" + total + " shipments</strong>" + growthHtml;
    }

    /* ============================================================
       HEADER FILTERS (Mode / Import-Export) - Import/Export switches the
       "Top Customers" card below between its Import and Export panel (via
       window.iewSetType(), set up in initImportExportWorkspace()). Both filters
       also re-run DASHBOARD_JOB_REPORT_MODEWISE_SELECT_NEW_02 on the server (via
       the GetModeWiseDashboardData PageMethod) with the exact @MODE/@TYPE chosen,
       so the KPI cards / Shipment Breakdown tiles / Mode Share donut (applyReal
       DashboardData()) and the Top Customers list (window.iewUpdateModeData(),
       set up in initImportExportWorkspace()) all reflect a real filtered query
       instead of just re-slicing the all-mode/both-type dataset already in the
       browser.
       ============================================================ */
    function initHeaderFilters(){
      var modeFilter = document.getElementById("dashFilterMode");
      var typeFilter = document.getElementById("dashFilterType");
      if(!modeFilter && !typeFilter) return;

      function currentSpMode(){
        var v = modeFilter ? modeFilter.value : "";
        return v ? v.toUpperCase() : "";
      }
      function currentSpType(){
        var v = typeFilter ? typeFilter.value : "";
        return v ? v.toUpperCase() : "BOTH";
      }

      function applyImportOnlyCardsVisibility(){
        var row = document.getElementById("importExtraCardsRow");
        if(!row) return;
        var v = typeFilter ? typeFilter.value : "";
        var hide = (v === "export");
        row.style.display = hide ? "none" : "";
        // The NAK Status / IGM Regularised / Query Reply cards that open these panels are hidden
        // too in that case - close them instead of leaving one open with no visible trigger card.
        if(hide && window.closeNakStatusDrilldown) window.closeNakStatusDrilldown();
        if(hide && window.closeIgmRegularisedDrilldown) window.closeIgmRegularisedDrilldown();
        if(hide && window.closeQueryReplyDrilldown) window.closeQueryReplyDrilldown();
      }
      applyImportOnlyCardsVisibility();

      function refetchFromServer(){
        if(typeof PageMethods === "undefined" || !PageMethods.GetModeWiseDashboardData) return;
        PageMethods.GetModeWiseDashboardData(currentSpMode(), currentSpType(), function(result){
          var data;
          try { data = JSON.parse(result); } catch(ex){ toast("Filter failed", "Could not read server response", "error"); return; }

          window.jobDataMode = data.jobDataMode || {};
          window.jobDataMode_SB = data.jobDataMode_SB || {};
          window.dashKpi = data.dashKpi || null;
          window.dashModeBreakdown = data.dashModeBreakdown || null;
          if(data.dashTrend && data.dashTrend.length) window.dashTrend = data.dashTrend;
          window.dashNakStatusCount = (typeof data.nakStatusCount === "number") ? data.nakStatusCount : 0;
          window.dashQueryReplyCount = (typeof data.queryReplyCount === "number") ? data.queryReplyCount : 0;
          window.dashIgmRegularisedCount = (typeof data.igmRegularisedCount === "number") ? data.igmRegularisedCount : 0;

          if(window.iewUpdateModeData) window.iewUpdateModeData(window.jobDataMode, window.jobDataMode_SB);
          applyRealDashboardData();
          applyNakStatusCard();
          applyQueryReplyCard();
          applyIgmRegularisedCard();
          renderShipmentsTrend();
          window.refreshKpiDrilldownIfOpen();
          window.refreshNakStatusDrilldownIfOpen();
          window.refreshIgmRegularisedDrilldownIfOpen();
          window.refreshQueryReplyDrilldownIfOpen();
        }, function(){
          toast("Filter failed", "Could not refresh dashboard data from the server", "error");
        });
      }

      if(typeFilter){
        typeFilter.addEventListener("change", function(){
          // blank ("Import & Export") now switches the card to its merged Import+Export
          // ranking panel - see iewSetType()'s "both" branch in initImportExportWorkspace().
          if(window.iewSetType) window.iewSetType(typeFilter.value);
          applyImportOnlyCardsVisibility();
          refetchFromServer();
        });
      }
      if(modeFilter){
        // initImportExportWorkspace() already re-renders the Top Customers list instantly off
        // the existing dataset on this same event; this listener additionally goes to the server.
        modeFilter.addEventListener("change", refetchFromServer);
      }
    }

    /* ============================================================
       IMPORT / EXPORT WORKSPACE (real data, from Load_Chart() below)
          Top 5 customers (by month) ranked by shipment count, per tab, with
          a "View All Customers" toggle that expands to the full ranked list.
       ============================================================ */
    function initImportExportWorkspace(){
      var jobData = window.jobData || {};
      var monthYears = window.monthYears || [];
      var importerNames = window.importerNames || [];
      var jobData_SB = window.jobData_SB || {};
      var monthYears_SB = window.monthYears_SB || [];
      var exporterNames = window.exporterNames || [];

      // Month + Mode (Sea/Air/Land) + name level counts, from DASHBOARD_JOB_REPORT_MODEWISE_SELECT_NEW_02
      // (see Load_Chart_ModeWise() in the code-behind). Used only when the header's Mode
      // filter (dashFilterMode) has something other than "All Modes" selected.
      var jobDataMode = window.jobDataMode || {};
      var jobDataMode_SB = window.jobDataMode_SB || {};
      var modeFilterEl = document.getElementById("dashFilterMode");

      var TOP_N = 5;

      // "by Shipments" means every job for that customer regardless of its current stage -
      // sum all 4 status buckets rather than reading a single field. Shared by context()'s
      // import/export branches and the combined branch of getFilteredSortedRows() below.
      var IMPORT_FIELDS = ["Be_created_Jobs", "Be_sent_Jobs", "Be_Received_Jobs", "Be_cancelledJobs"];
      var EXPORT_FIELDS = ["SBCreatedJobs", "SB_SentJobs", "SBReceivedJobs", "SBcancelledJobs"];

      // "ALL" in monthYears/monthYears_SB is a real, server-provided "all months combined"
      // option (DASHBOARD_JOB_REPORT_SELECT_USERWISE_IEC_BASED_SEARCH ships one row per real
      // customer with MonthYear="ALL" holding that customer's all-time total) - jobData/
      // jobData_SB can be looked up with month="ALL" directly. jobDataMode/jobDataMode_SB
      // (DASHBOARD_JOB_REPORT_MODEWISE_SELECT_USERWISE_IEC_BASED_SEARCH) has no such bucket,
      // only real months - so lookupCount() sums across REAL_MONTHS itself when a Mode filter
      // is active and "ALL" is still selected, instead of a single lookup that always misses.
      var REAL_MONTHS = monthYears.filter(function(m){ return m !== "ALL"; });
      var REAL_MONTHS_SB = monthYears_SB.filter(function(m){ return m !== "ALL"; });

      // Which panel is showing - driven by the "Import & Export"/Import/Export filter in the
      // page header (top right) via window.iewSetType(), not an in-card tab. "both" is the
      // header's blank ("Import & Export") value - merged Importer+Exporter ranking.
      var currentType = "both";

      var importPanel = document.getElementById("iewImportPanel");
      var exportPanel = document.getElementById("iewExportPanel");
      var combinedPanel = document.getElementById("iewCombinedPanel");
      var searchInput = document.getElementById("iewSearchInput");
      var monthSelect = document.getElementById("iewRankMonth");
      var rankTitle = document.getElementById("iewRankTitle");

      var modalOverlay = document.getElementById("craModalOverlay");
      var modalTitle = document.getElementById("craModalTitle");
      var modalBody = document.getElementById("craModalBody");
      var modalCloseBtn = document.getElementById("craModalClose");

      // Importer names and exporter names are two separate party lists (buyer vs supplier) -
      // a name appearing in both is the same party doing both import and export business, and
      // getFilteredSortedRows()'s combined branch sums their counts together under that one name.
      function combinedNames(){
        var seen = {}, out = [];
        importerNames.concat(exporterNames).forEach(function(n){
          if(!seen[n]){ seen[n] = true; out.push(n); }
        });
        return out;
      }
      // Same MonthYear label format from both SPs (DASHBOARD_JOB_REPORT_SELECT_USERWISE_IEC_
      // BASED_SEARCH and its _MODEWISE_ counterpart, run against the same GENERAL_DETAILS/
      // EXPORT_GENERAL_DETAILS job dates) - union, de-duplicated, so a month that only has
      // import or only export activity still shows up.
      function combinedMonths(){
        var seen = {}, out = [];
        monthYears.concat(monthYears_SB).forEach(function(m){
          if(!seen[m]){ seen[m] = true; out.push(m); }
        });
        return out;
      }

      function context(){
        if(currentType === "export"){
          return {
            names: exporterNames, months: monthYears_SB, jobData: jobData_SB, jobDataMode: jobDataMode_SB,
            fields: EXPORT_FIELDS, realMonths: REAL_MONTHS_SB,
            list: document.getElementById("iewExportRankList"),
            dataEmpty: document.getElementById("iewExportDataEmpty"),
            searchEmpty: document.getElementById("iewExportSearchEmpty"),
            viewAllBtn: document.getElementById("iewExportViewAllBtn")
          };
        }
        if(currentType === "import"){
          return {
            names: importerNames, months: monthYears, jobData: jobData, jobDataMode: jobDataMode,
            fields: IMPORT_FIELDS, realMonths: REAL_MONTHS,
            list: document.getElementById("iewImportRankList"),
            dataEmpty: document.getElementById("iewImportDataEmpty"),
            searchEmpty: document.getElementById("iewImportSearchEmpty"),
            viewAllBtn: document.getElementById("iewImportViewAllBtn")
          };
        }
        return {
          combined: true,
          names: combinedNames(), months: combinedMonths(),
          list: document.getElementById("iewCombinedRankList"),
          dataEmpty: document.getElementById("iewCombinedDataEmpty"),
          searchEmpty: document.getElementById("iewCombinedSearchEmpty"),
          viewAllBtn: document.getElementById("iewCombinedViewAllBtn")
        };
      }

      function populateMonthSelect(months){
        monthSelect.innerHTML = "";
        months.forEach(function(m){ monthSelect.options[monthSelect.options.length] = new Option(m,m); });
        if(months.length > 0) monthSelect.value = months[0];
      }

      function lookupCount(name, month, mode, srcJobData, srcJobDataMode, fields, realMonths){
        if(!mode){
          var data = srcJobData[month + "_" + name];
          var count = 0;
          if(data){ for(var i = 0; i < fields.length; i++){ count += data[fields[i]] || 0; } }
          return count;
        }
        // jobDataMode/jobDataMode_SB have no "ALL" (all-months) bucket - only real per-month
        // rows - so when "ALL" is still selected in the month dropdown, sum every real month
        // instead of one lookup that would always miss and read as 0.
        var monthsToSum = month === "ALL" ? realMonths : [month];
        var total = 0;
        monthsToSum.forEach(function(m){
          var data = srcJobDataMode[m + "_" + mode.toUpperCase() + "_" + name];
          if(data){ for(var i = 0; i < fields.length; i++){ total += data[fields[i]] || 0; } }
        });
        return total;
      }

      // Shared by the inline card (top N / search results) and the "View All
      // Customers" popup (full list), so both always agree on the same data.
      function getFilteredSortedRows(ctx, month, mode, q){
        var rows;
        if(ctx.combined){
          // Same name in both the importer and exporter lists = one party doing both
          // import and export - its Import count and Export count are added together
          // under that single ranked entry, per the merged-ranking request.
          rows = ctx.names.map(function(name){
            var count = lookupCount(name, month, mode, jobData, jobDataMode, IMPORT_FIELDS, REAL_MONTHS) +
                        lookupCount(name, month, mode, jobData_SB, jobDataMode_SB, EXPORT_FIELDS, REAL_MONTHS_SB);
            return { name: name, count: count };
          });
        } else {
          rows = ctx.names.map(function(name){
            var count = lookupCount(name, month, mode, ctx.jobData, ctx.jobDataMode, ctx.fields, ctx.realMonths);
            return { name: name, count: count };
          });
        }
        if(q) rows = rows.filter(function(r){ return r.name.toLowerCase().indexOf(q) !== -1; });
        rows.sort(function(a,b){ return b.count - a.count; });
        return rows;
      }

      function buildRowsHtml(rows){
        var maxCount = rows.length ? rows[0].count : 0;
        return rows.map(function(r, i){
          var pct = maxCount > 0 ? Math.max(4, Math.round((r.count / maxCount) * 100)) : 0;
          return '<div class="cust-rank-row">' +
            '<div class="cust-rank-num">' + (i + 1) + '</div>' +
            '<div class="cust-rank-name" title="' + esc(r.name) + '">' + esc(r.name) + '</div>' +
            '<div class="cust-rank-bar-wrap"><div class="cust-rank-bar" style="width:' + pct + '%"></div></div>' +
            '<div class="cust-rank-count">' + r.count + '</div>' +
          '</div>';
        }).join("");
      }

      function render(){
        var ctx = context();

        if(ctx.names.length === 0){
          ctx.dataEmpty.style.display = "block";
          ctx.searchEmpty.style.display = "none";
          ctx.list.innerHTML = "";
          ctx.viewAllBtn.style.display = "none";
          rankTitle.textContent = "";
          return;
        }
        ctx.dataEmpty.style.display = "none";

        var q = searchInput.value.trim().toLowerCase();
        var month = monthSelect.value;
        var mode = modeFilterEl ? modeFilterEl.value : "";

        var rows = getFilteredSortedRows(ctx, month, mode, q);

        var total = rows.length;
        if(total === 0){
          ctx.list.innerHTML = "";
          ctx.searchEmpty.style.display = "block";
          ctx.viewAllBtn.style.display = "none";
          rankTitle.textContent = "";
          return;
        }
        ctx.searchEmpty.style.display = "none";

        // Search results are shown in full inline (usually a short list already);
        // otherwise just the top N, with "View All Customers" opening the popup
        // for the complete ranking instead of expanding this card in place.
        var limited = q ? rows : rows.slice(0, TOP_N);
        ctx.list.innerHTML = buildRowsHtml(limited);

        var typeLabel = currentType === "export" ? "Export" : currentType === "import" ? "Import" : "Import & Export";
        var modeLabel = mode ? (" · " + mode.charAt(0).toUpperCase() + mode.slice(1) + " only") : "";
        if(q){
          rankTitle.textContent = "Search results (" + total + ")" + modeLabel;
          ctx.viewAllBtn.style.display = "none";
        } else {
          rankTitle.textContent = "Top " + TOP_N + " " + typeLabel + " Customers by Shipments" + modeLabel;
          ctx.viewAllBtn.textContent = "View All Customers";
          ctx.viewAllBtn.style.display = total > TOP_N ? "inline-flex" : "none";
        }
      }

      function openViewAllModal(){
        var ctx = context();
        var month = monthSelect.value;
        var mode = modeFilterEl ? modeFilterEl.value : "";
        var rows = getFilteredSortedRows(ctx, month, mode, "");
        var typeLabel = currentType === "export" ? "Export" : currentType === "import" ? "Import" : "Import & Export";
        var modeLabel = mode ? (" · " + mode.charAt(0).toUpperCase() + mode.slice(1) + " only") : "";
        var title = "All " + typeLabel + " Customers by Shipments (" + rows.length + ")" + modeLabel;
        var bodyHtml = buildRowsHtml(rows);

        // This page runs inside #mainiframecontainer in E_royal_Impex_Main.aspx -
        // a position:fixed overlay in here can only ever cover THIS iframe's own box,
        // never the parent page's header/topbar/footer. So hand the content over to
        // the parent's popup (same full-screen treatment as its bell/robot icon
        // popups) instead. Falls back to the local popup below when this file is
        // opened standalone with no such parent.
        if (window.parent && window.parent !== window && typeof window.parent.openViewAllCustomersModal === "function") {
          window.parent.openViewAllCustomersModal(title, bodyHtml);
          return;
        }

        modalTitle.textContent = title;
        modalBody.innerHTML = bodyHtml;
        modalOverlay.classList.add("open");
      }
      function closeViewAllModal(){
        modalOverlay.classList.remove("open");
      }
      modalCloseBtn.addEventListener("click", closeViewAllModal);
      modalOverlay.addEventListener("click", function(e){ if(e.target === modalOverlay) closeViewAllModal(); });
      document.addEventListener("keydown", function(e){
        if(e.key === "Escape" && modalOverlay.classList.contains("open")) closeViewAllModal();
      });

      document.getElementById("iewImportViewAllBtn").addEventListener("click", openViewAllModal);
      document.getElementById("iewExportViewAllBtn").addEventListener("click", openViewAllModal);
      document.getElementById("iewCombinedViewAllBtn").addEventListener("click", openViewAllModal);

      // type is the header's dashFilterType value directly - "import", "export", or ""
      // (Import & Export, which context() maps to the merged "both" panel).
      function setType(type){
        currentType = type === "export" ? "export" : type === "import" ? "import" : "both";
        importPanel.style.display = currentType === "import" ? "" : "none";
        exportPanel.style.display = currentType === "export" ? "" : "none";
        combinedPanel.style.display = currentType === "both" ? "" : "none";
        searchInput.value = "";
        var months = currentType === "export" ? monthYears_SB : currentType === "import" ? monthYears : combinedMonths();
        populateMonthSelect(months);
        render();
      }
      // Exposed so the "Import & Export" filter in the page header (top right) can
      // switch this card's panel - the two controls aren't duplicated in the card itself.
      window.iewSetType = setType;

      function updateModeData(newModeData, newModeData_SB){
        jobDataMode = newModeData || {};
        jobDataMode_SB = newModeData_SB || {};
        render();
      }
      // Exposed so initHeaderFilters()'s server refetch (GetModeWiseDashboardData PageMethod)
      // can push freshly filtered mode data into this card's closured state and re-render.
      window.iewUpdateModeData = updateModeData;

      monthSelect.addEventListener("change", render);
      searchInput.addEventListener("input", render);
      if(modeFilterEl) modeFilterEl.addEventListener("change", render);

      // Match whatever the header's Import/Export filter is already showing on load
      // (its markup default is "" - Import & Export - so this starts on the merged panel).
      var typeFilterElInit = document.getElementById("dashFilterType");
      setType(typeFilterElInit ? typeFilterElInit.value : "");
    }
    </script>
</asp:Content>
