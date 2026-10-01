<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ocr_Ai_Dashboard.aspx.cs"
    Inherits="OCR_Dashboard_Ocr_Ai_Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>OCR AI DASHBOARD</title>
    <%-- ═══ STEP 1: jQuery MUST load first ═══ --%>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <%-- ═══ STEP 2: Validation engine ═══ --%>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <%-- ═══ STEP 3: Modal/popup scripts ═══ --%>
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <%-- ═══ STEP 4: Remaining shared scripts ═══ --%>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script type="text/javascript">


        function openInTop(fnName, arg, width, height, left, top) {

            // AI Dashboard is opened two different ways (see #btnCloseDashboard's own fix,
            // below, for the same split): the OCR menu's "AI DASHBOARD" item uses
            // openGenericModal() (E_royal_Impex_Main.aspx), which never touches
            // parent.adcodewindow - that global only ever gets set by the older dhtmlmodal-based
            // open_Ocr_Ai_Dashboard() (the Import/Export search pages' toolbar icon). Step 1/3
            // below (saving then hiding dashboardRef = parent.adcodewindow) only ever closed the
            // dashboard for that toolbar-icon path; opened from the menu instead, parent.
            // adcodewindow was either undefined or some unrelated, previously-opened dhtmlmodal
            // popup, so the dashboard's own generic-modal overlay was left sitting open behind
            // the newly opened tool popup. window.frameElement.id tells the two apart the same
            // way as the close-icon fix: openGenericModal's iframe has
            // id="pmGenericModalFrame"; dhtmlwindow.js's iframe only ever gets a `name`.
            var isGenericModal = window.frameElement && window.frameElement.id === 'pmGenericModalFrame';

            // ✅ STEP 1: Save dashboard reference BEFORE tool opens
            //           (tool open will overwrite parent.adcodewindow)
            var dashboardRef = null;
            if (!isGenericModal) {
                try {
                    if (parent && parent.adcodewindow) {
                        dashboardRef = parent.adcodewindow;
                    }
                } catch (e) { }
            }

            // ✅ STEP 2: Open the tool popup
            try {
                if (window.top[fnName]) {
                    window.top[fnName](arg);
                } else {
                    window[fnName](arg);
                }
            } catch (e) {
                window[fnName](arg);
            }

            // ✅ STEP 3: Now close the dashboard - via closeGenericModal() when opened from the
            // OCR menu, or via the saved dhtmlmodal reference for the toolbar-icon path
            try {
                if (isGenericModal) {
                    if (parent && typeof parent.closeGenericModal === 'function') parent.closeGenericModal();
                } else if (dashboardRef) {
                    dashboardRef.hide();
                }
            } catch (e) { }

            setTimeout(function () {
                var popup =
            document.querySelector(".dhtmlwindow") ||
            window.top.document.querySelector(".dhtmlwindow");

                if (!popup) return;

                if (width && height) {
                    popup.style.width = width + "px";
                    popup.style.height = height + "px";
                    popup.style.left = left + "px";
                    popup.style.top = top + "px";
                    popup.style.position = "fixed";
                }

                popup.style.overflow = "hidden";

                var iframe = popup.querySelector("iframe");
                if (iframe) {
                    var titleBar =
                popup.querySelector(".wins_title") ||
                popup.querySelector(".dhtmlwindow_title");
                    var titleHeight = titleBar ? titleBar.offsetHeight : 28;
                    var popupHeight = height || popup.offsetHeight;

                    iframe.style.width = "100%";
                    iframe.style.height = (popupHeight - titleHeight) + "px";
                    iframe.style.border = "none";
                    iframe.style.display = "block";
                    iframe.setAttribute("scrolling", "auto");
                }
            }, 200);
        }

        // ✅ Unlock scroll when popup closes
        function unlockParentScroll() {
            document.body.classList.remove("popup-open");
            if (window.top && window.top.document && window.top.document.body) {
                window.top.document.body.classList.remove("popup-open");
            }
        }

        // ✅ Auto-unlock when child popup windows are closed via dhtmlmodal
        if (typeof dhtmlmodal !== "undefined") {
            var _origHide = dhtmlmodal.hide;
            dhtmlmodal.hide = function () {
                unlockParentScroll();
                return _origHide.apply(this, arguments);
            };
        }
    </script>
    <script type="text/javascript">
        function ShowUserGuide() {
            var pdfPath = '../OCR_Dashboard/Docs/OCR_Dashboard.pdf'; // <-- UPDATE THIS PATH
            window.open(pdfPath, '_blank');
        }

    </script>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        
        body
        {
            font-family: 'Segoe UI' , Tahoma, Geneva, Verdana, sans-serif;
            background: #f0f2f8;
            color: #333;
        }
        
        .dashboard-header
        {
            background: linear-gradient(135deg,#1a237e 0%,#283593 50%,#3949ab 100%);
            padding: 18px 30px;
            display: flex;
            align-items: center;
            box-shadow: 0 4px 15px rgba(26,35,126,0.4);
        }
        
        .dashboard-header h1
        {
            color: #fff;
            font-size: 22px;
            font-weight: 700;
            letter-spacing: 2px;
        }
        
        /* Push right-side controls to the end */
        .header-actions
        {
            margin-left: auto;
            display: flex;
            align-items: center;
            gap: 14px;
        }
        
        .header-badge
        {
            background: rgba(255,255,255,0.15);
            color: #fff;
            padding: 6px 16px;
            border-radius: 20px;
            font-size: 12px;
            border: 1px solid rgba(255,255,255,0.25);
            letter-spacing: 1px;
        }
        
        .dashboard-container
        {
            padding: 30px;
            max-width: 1100px;
            margin: 0 auto;
        }
        
        .section-card
        {
            background: #ffffff;
            border-radius: 16px;
            box-shadow: 0 4px 20px rgba(0,0,0,0.08);
            margin-bottom: 28px;
            overflow: hidden;
            border: 1px solid #e8eaf6;
        }
        
        .section-header
        {
            padding: 16px 24px;
            display: flex;
            align-items: center;
            gap: 12px;
        }
        .section-header.import-header
        {
            background: linear-gradient(135deg,#1976d2,#42a5f5);
        }
        
        .section-header.export-header
        {
            background: linear-gradient(135deg,#2e7d32,#66bb6a);
        }
        
        .section-header-icon
        {
            width: 36px;
            height: 36px;
            background: rgba(255,255,255,0.2);
            border-radius: 8px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 18px;
        }
        .section-header h2
        {
            color: #ffffff;
            font-size: 16px;
            font-weight: 600;
            letter-spacing: 1.5px;
            text-transform: uppercase;
        }
        .section-header span.sub
        {
            color: rgba(255,255,255,0.85);
            font-size: 13px;
            margin-left: auto;
            display: flex;
            align-items: center;
            margin-right: 12px;
        }
        
        .icons-grid
        {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            padding: 28px 24px;
            background: #fafbff;
        }
        
        .icon-card
        {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            width: 130px;
            padding: 20px 10px 16px;
            background: linear-gradient(180deg,#ffffff,#fafbff);
            border-radius: 14px;
            border: 1.5px solid #e3e8f5;
            cursor: pointer;
            transition: all 0.25s ease;
            text-decoration: none;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
            position: relative;
        }
        .icon-card:hover
        {
            transform: translateY(-6px);
            box-shadow: 0 12px 30px rgba(0,0,0,.12);
            border-color: #7986cb;
        }
        .icon-card.import-card:hover
        {
            border-color: #1e88e5;
            box-shadow: 0 10px 28px rgba(30,136,229,0.2);
        }
        .icon-card.export-card:hover
        {
            border-color: #43a047;
            box-shadow: 0 10px 28px rgba(67,160,71,0.2);
        }
        
        /* ===========================================
   TOOL ICON BACKGROUNDS
   =========================================== */
        
        .icon-wrapper
        {
            width: 60px;
            height: 60px;
            border-radius: 18px;
            display: flex;
            align-items: center;
            justify-content: center;
            margin-bottom: 12px;
            position: relative;
            overflow: hidden;
            transition: all .3s ease;
        }
        
        /* Glass shine effect */
        .icon-wrapper:before
        {
            content: '';
            position: absolute;
            inset: 0;
            background: rgba(255,255,255,.18);
        }
        
        .icon-wrapper img
        {
            width: 30px;
            height: 30px;
            position: relative;
            z-index: 2;
        }
        
        .icon-card:hover .icon-wrapper
        {
            transform: translateY(-4px) scale(1.08);
        }
        
        /* ===========================================
   PDF READER AI
   =========================================== */
        
        .icon-wrapper.pdf-ai
        {
            background: linear-gradient(135deg,#ff6ec4,#7873f5);
            box-shadow: 0 8px 20px rgba(120,115,245,.30);
        }
        
        /* ===========================================
   EXCEL OCR
   =========================================== */
        
        .icon-wrapper.excel
        {
            background: linear-gradient(135deg,#43e97b,#38f9d7);
            box-shadow: 0 8px 20px rgba(67,233,123,.30);
        }
        
        /* ===========================================
   PDF NEW
   =========================================== */
        
        .icon-wrapper.pdf-new
        {
            background: linear-gradient(135deg,#ff758c,#ff7eb3);
            box-shadow: 0 8px 20px rgba(255,117,140,.30);
        }
        
        /* ===========================================
   CHECKLIST
   =========================================== */
        
        .icon-wrapper.check
        {
            background: linear-gradient(135deg,#4facfe,#00f2fe);
            box-shadow: 0 8px 20px rgba(79,172,254,.30);
        }
        
        /* ===========================================
   XML / JSON
   =========================================== */
        
        .icon-wrapper.xml
        {
            background: linear-gradient(135deg,#36d1dc,#5b86e5);
            box-shadow: 0 8px 20px rgba(91,134,229,.30);
        }
        
        /* ===========================================
   REPORT
   =========================================== */
        
        .icon-wrapper.report
        {
            background: linear-gradient(135deg,#f6d365,#fda085);
            box-shadow: 0 8px 20px rgba(253,160,133,.30);
        }
        
        /* ===========================================
   TEMPLATE CREATION
   =========================================== */
        
        .icon-wrapper.template
        {
            background: linear-gradient(135deg,#667eea,#764ba2);
            box-shadow: 0 8px 20px rgba(118,75,162,.30);
        }
        
        .icon-label
        {
            font-size: 11.5px;
            font-weight: 600;
            color: #455a64;
            text-align: center;
            letter-spacing: 0.5px;
            text-transform: uppercase;
        }
        
        .badge-new
        {
            position: absolute;
            top: 8px;
            right: 8px;
            background: linear-gradient(135deg, #f44336, #e91e63);
            color: #fff;
            font-size: 9px;
            font-weight: 700;
            padding: 2px 6px;
            border-radius: 8px;
            letter-spacing: 0.5px;
        }
        
        .dashboard-footer
        {
            text-align: center;
            padding: 16px;
            color: #9e9e9e;
            font-size: 12px;
            letter-spacing: 0.5px;
        }
        .icon-card.locked
        {
            opacity: 0.85;
        }
        .icon-card.locked .icon-wrapper
        {
            filter: grayscale(40%);
        }
        .badge-lock
        {
            position: absolute;
            top: 8px;
            right: 8px;
            background: linear-gradient(135deg, #37474f, #546e7a);
            color: #fff;
            font-size: 9px;
            font-weight: 700;
            padding: 2px 6px;
            border-radius: 8px;
            letter-spacing: 0.5px;
        }
        /* ===== TAB DESIGN ===== */
        
        .tabs-container
        {
            display: flex;
            gap: 10px;
            margin-bottom: 25px;
            padding: 10px;
            background: #e8eefc;
            border-radius: 12px;
        }
        
        .tab-button
        {
            padding: 14px 28px;
            background: #ffffff;
            border: 2px solid #3f51b5;
            color: #1a237e;
            font-size: 16px;
            font-weight: 600;
            border-radius: 10px;
            cursor: pointer;
            transition: all 0.3s ease;
        }
        
        .tab-button:hover
        {
            background: #3f51b5;
            color: #ffffff;
        }
        
        .tab-button.active
        {
            background: #1a237e;
            color: #ffffff;
        }
        
        /* ===== TAB CONTENT ===== */
        
        .tab-content
        {
            display: none;
        }
        
        .tab-content.active
        {
            display: block;
        }
        
        /* ===== DASHBOARD CONTENT ===== */
        
        .dashboard-box
        {
            background: #ffffff;
            padding: 30px;
            border-radius: 16px;
            box-shadow: 0 4px 18px rgba(0,0,0,0.08);
            margin-bottom: 25px;
        }
        
        .dashboard-box h3
        {
            margin-bottom: 15px;
            color: #1a237e;
        }
        
        .notification-item
        {
            padding: 15px;
            border-bottom: 1px solid #e0e0e0;
            font-size: 14px;
        }
        
        /* ===== TOGGLE SWITCH ===== */
        
        .toggle-wrapper
        {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-left: auto;
            color: #fff;
            font-size: 13px;
            font-weight: 600;
        }
        
        .switch
        {
            position: relative;
            display: inline-block;
            width: 50px;
            height: 24px;
        }
        
        .switch input
        {
            opacity: 0;
            width: 0;
            height: 0;
        }
        
        .slider
        {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #d1d5db;
            transition: .4s;
        }
        
        .slider:before
        {
            position: absolute;
            content: "";
            height: 18px;
            width: 18px;
            left: 4px;
            bottom: 3px;
            background-color: white;
            transition: .4s;
        }
        
        input:checked + .slider
        {
            background-color: #1565c0;
        }
        
        input:checked + .slider:before
        {
            transform: translateX(24px);
        }
        
        .slider.round
        {
            border-radius: 34px;
        }
        
        .slider.round:before
        {
            border-radius: 50%;
        }
        
        .page-header-right
        {
            display: flex;
            align-items: center;
        }
        
        .btn-close-modern
        {
            width: 42px;
            height: 42px;
            border: none;
            border-radius: 50%;
            background: rgba(255,255,255,0.15);
            color: #fff;
            font-size: 20px;
            font-weight: 600;
            cursor: pointer;
            backdrop-filter: blur(8px);
            border: 1px solid rgba(255,255,255,0.25);
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        
        .btn-close-modern:hover
        {
            background: #ef3249;
            transform: rotate(90deg) scale(1.08);
            box-shadow: 0 8px 20px rgba(255,82,82,0.35);
        }
        
        .btn-close-modern:active
        {
            transform: scale(0.95);
        }
        
        .btn-close-modern:focus
        {
            outline: none;
        }
        /* ===== PREVENT PARENT SCROLL WHEN POPUP IS OPEN ===== */
        html, body
        {
            overflow: hidden; /* Dashboard itself is in an iframe — never needs to scroll */
            height: 100%;
        }
        
        body.popup-open
        {
            overflow: hidden !important;
            position: fixed;
            width: 100%;
        }
        
.whats-new-banner {
    background: linear-gradient(90deg,#f92121,#cd1236);
    color: #fff;
    padding: 12px 18px;
    border-radius: 10px;
    margin-bottom: 20px;
    font-size: 14px;
    font-weight: 600;
    position: relative;

    animation: fadeGlow 1.5s ease-in-out infinite;
}

@keyframes fadeGlow {
    0% {
        box-shadow: 0 0 5px rgba(249,33,33,.3);
        transform: scale(1);
    }

    50% {
        box-shadow:
            0 0 12px rgba(249,33,33,.7),
            0 0 24px rgba(249,33,33,.5),
            0 0 36px rgba(249,33,33,.3);
        transform: scale(1.01);
    }

    100% {
        box-shadow: 0 0 5px rgba(249,33,33,.3);
        transform: scale(1);
    }
}
/* ===== ANALYTICS TEASER ===== */
.analytics-teaser{
    position:relative;
    background:linear-gradient(135deg,#1a237e 0%,#283593 45%,#3949ab 100%);
    border-radius:20px;
    padding:45px 30px 42px;
    text-align:center;
    overflow:hidden;
    box-shadow:0 14px 40px rgba(26,35,126,0.35);
}
.analytics-teaser-glow{
    position:absolute;
    width:280px;
    height:280px;
    background:radial-gradient(circle, rgba(255,255,255,0.18), transparent 70%);
    top:-110px;
    right:-70px;
    border-radius:50%;
    animation:analyticsGlow 6s infinite ease-in-out;
}
@keyframes analyticsGlow{
    0%,100%{transform:translateY(0);}
    50%{transform:translateY(25px);}
}
.analytics-new-pill{
    position:absolute;
    top:18px;
    left:18px;
    background:linear-gradient(135deg,#f44336,#e91e63);
    color:#fff;
    font-size:11px;
    font-weight:700;
    padding:5px 12px;
    border-radius:14px;
    letter-spacing:1px;
    animation:pulseNewBadge 1.8s infinite;
}
@keyframes pulseNewBadge{
    0%,100%{transform:scale(1); box-shadow:0 0 0 0 rgba(244,67,54,0.5);}
    50%{transform:scale(1.07); box-shadow:0 0 0 6px rgba(244,67,54,0.12);}
}
.analytics-icon-float{
    display:flex;
    justify-content:center;
    align-items:center;
    margin-bottom:15px;
    animation:iconFloatBounce 3s ease-in-out infinite;
}

.analytics-icon-img{
    width:80px;      /* Increase/decrease as needed */
    height:80px;
    object-fit:contain;
    filter:drop-shadow(0 8px 20px rgba(0,0,0,.25));
}

@keyframes iconFloatBounce{
    0%,100%{
        transform:translateY(0);
    }
    50%{
        transform:translateY(-12px);
    }
}
.analytics-teaser-title{
    color:#fff;
    font-size:26px;
    font-weight:800;
    letter-spacing:1px;
    margin-bottom:12px;
    position:relative;
}
.analytics-teaser-desc{
    color:rgba(255,255,255,0.85);
    max-width:540px;
    margin:0 auto 26px;
    font-size:14px;
    line-height:1.7;
    position:relative;
}
.analytics-feature-row{
    display:flex;
    justify-content:center;
    gap:14px;
    flex-wrap:wrap;
    margin-bottom:32px;
    position:relative;
}
.analytics-feature-pill{
    background:rgba(255,255,255,0.12);
    border:1px solid rgba(255,255,255,0.25);
    color:#fff;
    font-size:12.5px;
    font-weight:600;
    padding:8px 16px;
    border-radius:20px;
    display:flex;
    align-items:center;
    gap:6px;
}
.btn-view-analytics{
    position:relative;
    background:linear-gradient(135deg,#ff6ec4,#7873f5);
    color:#fff;
    border:none;
    font-size:15px;
    font-weight:700;
    padding:14px 38px;
    border-radius:30px;
    cursor:pointer;
    letter-spacing:.5px;
    overflow:hidden;

    animation:
        buttonFloat 3s ease-in-out infinite,
        buttonGlow 1.8s ease-in-out infinite;
}

/* Floating */
@keyframes buttonFloat{
    0%,100%{
        transform:translateY(0);
    }
    50%{
        transform:translateY(-8px);
    }
}

/* Blinking Glow */
@keyframes buttonGlow{
    0%,100%{
        box-shadow:0 0 12px rgba(255,110,196,.45),
                   0 0 22px rgba(120,115,245,.35);
    }
    50%{
        box-shadow:0 0 24px rgba(255,110,196,.9),
                   0 0 45px rgba(120,115,245,.75);
    }
}

/* Moving Shine */
.btn-view-analytics::before{
    content:'';
    position:absolute;
    top:0;
    left:-120%;
    width:60%;
    height:100%;
    background:linear-gradient(
        90deg,
        transparent,
        rgba(255,255,255,.55),
        transparent
    );
    transform:skewX(-25deg);
    animation:shine 2.8s infinite;
}

@keyframes shine{
    100%{
        left:150%;
    }
}

.btn-view-analytics:hover{
    animation-play-state:paused;
    transform:translateY(-4px) scale(1.04);
}
    </style>
    <script type="text/javascript">

        function showTab(tabId, btn) {

            var buttons = document.getElementsByClassName("tab-button");
            for (var i = 0; i < buttons.length; i++) {
                buttons[i].classList.remove("active");
            }

            var tabs = document.getElementsByClassName("tab-content");
            for (var j = 0; j < tabs.length; j++) {
                tabs[j].classList.remove("active");
            }

            document.getElementById(tabId).classList.add("active");
            btn.classList.add("active");
        }

        /* ===== OCR TOGGLE MODE ===== */

        var OCR_MODE = "IMPORT";

        function changeOCRMode() {

            var toggle = document.getElementById("ocrToggle");
            var checklistCard = document.getElementById("checklistCard");
            var xmlCard = document.getElementById("xmlCard");
            var toolTitle = document.getElementById("toolTitle");

            localStorage.setItem("ocrToggleState", toggle.checked ? "1" : "0");

            if (!toggle.checked) {

                // IMPORT MODE
                OCR_MODE = "IMPORT";

                checklistCard.style.display = "flex";
                xmlCard.style.display = "none";

                document.getElementById("lblMode").style.fontWeight = "bold";
                document.getElementById("lblMode2").style.fontWeight = "normal";

                toolTitle.innerHTML = "Import Feature Tools";

                var header = document.getElementById("toolHeader");
                header.classList.remove("export-header");
                header.classList.add("import-header");
            }
            else {

                // EXPORT MODE
                OCR_MODE = "EXPORT";

                checklistCard.style.display = "none";
                xmlCard.style.display = "flex";

                document.getElementById("lblMode").style.fontWeight = "normal";
                document.getElementById("lblMode2").style.fontWeight = "bold";

                toolTitle.innerHTML = "Export Feature Tools";

                var header = document.getElementById("toolHeader");
                header.classList.remove("import-header");
                header.classList.add("export-header");
            }

            updateProBadges();
        }
        function updateProBadges() {

            // ---------- PDF ----------
            updateCard(
        document.getElementById("Ai_Pdf"),
        (OCR_MODE === "IMPORT") ? SHOW_IMPORT : SHOW_EXPORT
    );

            // ---------- REPORT ----------
            updateCard(
        document.getElementById("reportPage"),
        (OCR_MODE === "IMPORT") ? SHOW_IMPORT : SHOW_EXPORT
    );

            // ---------- TEMPLATE ----------
            updateCard(
        document.getElementById("templateCard"),
        (OCR_MODE === "IMPORT") ? SHOW_IMPORT : SHOW_EXPORT
    );

            // ---------- EXCEL ----------
            updateCard(
        document.getElementById("ExcelUpload"),
        (OCR_MODE === "IMPORT") ? SHOW_IMPORT_EXCEL : SHOW_EXPORT_EXCEL
    );

            // ---------- CHECKLIST ----------
            updateCard(
        document.getElementById("checklistCard"),
        SHOW_IMPORT_CHECKLIST
    );

            // ---------- XML ----------
            updateCard(
        document.getElementById("xmlCard"),
        SHOW_XMLJSON
    );
        }


        // Common function
        function updateCard(card, isSubscribed) {

            if (!card) return;

            var lock = card.querySelector(".badge-lock");
            var ai = card.querySelector(".badge-new");

            if (isSubscribed) {

                card.classList.remove("locked");

                if (lock)
                    lock.style.display = "none";

                if (ai)
                    ai.style.display = "block";
            }
            else {

                card.classList.add("locked");

                if (lock)
                    lock.style.display = "block";

                if (ai)
                    ai.style.display = "none";
            }
        }

        window.onload = function () {

            var toggle = document.getElementById("ocrToggle");

            var type = (typeof PDF_TYPE !== "undefined" && PDF_TYPE) ? PDF_TYPE.toUpperCase() : "";

            if (type === "EXP") {
                toggle.checked = true;   // Explicit Export request
            }
            else if (type === "IMP") {
                toggle.checked = false;  // Explicit Import request
            }
            else {
                // No explicit mode in the URL (e.g. Job_type=NEW from the
                // Analytics Dashboard close button) — restore last selected mode
                var saved = localStorage.getItem("ocrToggleState");
                toggle.checked = (saved === "1");
            }

            changeOCRMode();
            updateProBadges();
        };



        function openOCRTool(type) {

            // ================= IMPORT MODE =================
            if (OCR_MODE === "IMPORT") {

                // PDF / REPORT / TEMPLATE
                if ((type === "pdf" || type === "report" || type === "template") && !SHOW_IMPORT) {
                    showSubscribeModal("pdf");
                    return;
                }

                // IMPORT EXCEL
                if (type === "excel" && !SHOW_IMPORT_EXCEL) {
                    showSubscribeModal("excel");
                    return;
                }

                // IMPORT CHECKLIST
                if (type === "checklist" && !SHOW_IMPORT_CHECKLIST) {
                    showSubscribeModal("checklist");
                    return;
                }

                // Open Pages
                if (type === "pdf")
                    openInTop('open_Imp_UPload_PDF_AI', 'New');
                //open_Exp_UPload_PDF_New_AI('New');

                else if (type === "excel")
                    openInTop('open_Imp_Excel_Reader', 'New');

                else if (type === "checklist")
                    openInTop('open_Checklist_Reader', 'New');

                else if (type === "pdfnew")
                    openInTop('open_Imp_UPload_PDF', 'New', 1000, 600, 188, -550);

                else if (type === "report")
                    openInTop('open_PDF_Import_Report', 'New');

                else if (type === "template")
                    window.open("https://docparser.dockervision.in/", "_blank");
            }

            // ================= EXPORT MODE =================
            else {

                // PDF / REPORT / TEMPLATE
                if ((type === "pdf" || type === "report" || type === "template") && !SHOW_EXPORT) {
                    showSubscribeModal("pdf");
                    return;
                }

                // EXPORT EXCEL
                if (type === "excel" && !SHOW_EXPORT_EXCEL) {
                    showSubscribeModal("excel");
                    return;
                }

                // XML / JSON
                if (type === "xml" && !SHOW_XMLJSON) {
                    showSubscribeModal("xml");
                    return;
                }

                // Open Pages
                if (type === "pdf")
                    openInTop('open_Exp_UPload_PDF_New_AI', 'New');

                else if (type === "excel")
                    openInTop('open_Exp_Excel_Reader', 'New');

                else if (type === "xml")
                    openInTop('open_Exp_XML_JSON_Reader', 'New');

                else if (type === "pdfnew")
                    openInTop('open_Exp_UPload_PDF_New', 'New', 1000, 600, 188, -550);

                else if (type === "report")
                    openInTop('open_PDF_Export_Report', 'New');

                else if (type === "template")
                    window.open("https://docparser.dockervision.in/", "_blank");
            }
        }
        //        function showSubscribeModal() {
        //            document.getElementById("subscribeOverlay").style.display = "flex";
        //        }

        function showSubscribeModal(feature) {

            var title = "Premium Feature";
            var subTitle = "";
            var message = "";

            var feature1 = "";
            var feature2 = "";
            var feature3 = "";

            switch (feature) {

                case "pdf":
                case "report":
                case "template":

                    subTitle = "PDF AI Reader";
                    message = "To Enable <strong>PDF AI Reader</strong> subscription. Please contact the administrator.";

                    feature1 = "AI-powered field extraction";
                    feature2 = "Import & Export support";
                    feature3 = "Real-time processing & validation";


                    document.getElementById("feature3Icon").innerHTML = "&#9889;"; // ⚡
                    break;

                case "excel":

                    subTitle = "Excel OCR";
                    message = "To Enable <strong>Excel OCR</strong> subscription. Please contact the administrator.";

                    feature1 = "Based on Template Creation";
                    feature2 = "Import & Export support";
                    feature3 = "Please find details in View Feature Details";

                    document.getElementById("feature3Icon").innerHTML = "&#128218;"; // 📘
                    break;

                case "checklist":

                    subTitle = "Checklist Upload";
                    message = "To Enable <strong>Checklist Upload</strong> subscription. Please contact the administrator.";

                    feature1 = "Based on Template Creation";
                    feature2 = "Import & Export support";
                    feature3 = "Please find details in View Feature Details";

                    document.getElementById("feature3Icon").innerHTML = "&#128218;"; // 📘
                    break;

                case "xml":

                    subTitle = "XML / JSON Export";
                    message = "To Enable <strong>XML / JSON Export</strong> subscription. Please contact the administrator.";

                    feature1 = "Based on Template Creation";
                    feature2 = "Import & Export support";
                    feature3 = "Please find details in View Feature Details";

                    document.getElementById("feature3Icon").innerHTML = "&#128218;"; // 📘
                    break;
            }
            document.getElementById("feature1").innerHTML = feature1;
            document.getElementById("feature2").innerHTML = feature2;
            document.getElementById("feature3").innerHTML = feature3;

            document.getElementById("popupTitle").innerHTML = title;
            document.getElementById("popupSubTitle").innerHTML = subTitle;
            document.getElementById("popupMessage").innerHTML = message;

            document.getElementById("subscribeOverlay").style.display = "flex";
        }
        function closeSubscribeModal() {
            document.getElementById("subscribeOverlay").style.display = "none";
        }

        // This page is opened two different ways: the OCR menu's "AI DASHBOARD" item uses
        // openGenericModal() (E_royal_Impex_Main.aspx), whose wrapper card already draws its
        // own close "x" (.pm-robot-img-close -> closeGenericModal()); the Import/Export search
        // pages' "OCR AI Dashboard" toolbar icon instead uses the older dhtmlmodal via
        // open_Ocr_Ai_Dashboard() (js/iframepopupwin.js), which has no such outer chrome, so
        // this page's own #btnCloseDashboard button (parent.adcodewindow.hide()) is the only
        // close control there. Opened via openGenericModal, both showed at once - a redundant
        // (and non-functional, since adcodewindow is never set on that path) second close icon.
        // window.frameElement.id reliably tells them apart: openGenericModal's iframe has
        // id="pmGenericModalFrame" (E_royal_Impex_Main.aspx); dhtmlwindow.js's iframe only ever
        // gets a `name`, never an `id`.
        document.addEventListener('DOMContentLoaded', function () {
            if (window.frameElement && window.frameElement.id === 'pmGenericModalFrame') {
                var btn = document.getElementById('btnCloseDashboard');
                if (btn) btn.style.display = 'none';
            }
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Header -->
    <div class="dashboard-header">
        <h1>
            ⚙ AI DASHBOARD</h1>
        <div class="header-actions">
            <span class="header-badge">AI POWERED</span>
            <%--<button type="button" class="btn-close-modern" onclick="parent.adcodewindow.hide(); return false;"
                title="Close Dashboard">
                ✕
            </button>--%>
            <!-- AFTER — add unlockParentScroll() -->
            <button type="button" id="btnCloseDashboard" class="btn-close-modern" onclick="unlockParentScroll(); parent.adcodewindow.hide(); return false;"
                title="Close Dashboard">
                ✕</button>
        </div>
    </div>
    <div class="dashboard-container">
        <div class="tabs-container">
            <button type="button" id="btnOverview" class="tab-button active" onclick="showTab('tabOverview', this)">
                Overview Dashboard
            </button>
            <button type="button" id="btnAnalytics" class="tab-button" onclick="showTab('tabAnalytics', this)">
                Analytics Dashboard
            </button>
            <button type="button" id="btnLogsTab" runat="server" class="tab-button" onclick="showTab('tabLogs', this)">
                Logs
            </button>
        </div>
        <!-- Logs (CompanyId 1/10 or user "rts" only - see Page_Load) -->
        <div id="tabLogs" runat="server" class="tab-content">
             <!--<div class="whats-new-banner">
                🚀 New Feature Released : <strong>Logs</strong> is now available
                with downloadable AI Import &amp; Export log files.
            </div> -->
            <div class="analytics-teaser">
                <span class="analytics-new-pill">✨ NEW</span>
                <div class="analytics-icon-float">
                    <img src="../images/icons/OCR/statistics.png" alt="Logs" class="analytics-icon-img" />
                </div>
                <h3 class="analytics-teaser-title">
                    AI Import / Export Logs</h3>
                <p class="analytics-teaser-desc">
                    Download every Preview / API / Job log file <br> (Import &amp; Export, all days currently
                    retained) as a single ZIP archive, <br> straight from the server.
                </p>
                <asp:Button ID="btnDownloadLogsZip" runat="server" CssClass="btn-view-analytics"
                    Text="Download Logs (ZIP)" OnClick="btnDownloadLogsZip_Click" />
            </div>
        </div>
        <!-- Analytics Dashboard-->
        <div id="tabAnalytics" class="tab-content">
            <div class="analytics-teaser">
                <div class="analytics-teaser-glow">
                </div>
                <span class="analytics-new-pill">✨ NEW</span>
                <div class="analytics-icon-float">
                    <img src="../images/icons/OCR/statistics.png" alt="Statistics" class="analytics-icon-img" />
                </div>
                <h3 class="analytics-teaser-title">
                    Analytics Dashboard</h3>
                <p class="analytics-teaser-desc">
                    Get AI-powered reports, charts and insights on your OCR usage — Total Documents,
                    Pages Processed, Job statistics and Token Consumption, all in one place.
                </p>
                <div class="analytics-feature-row">
                    <div class="analytics-feature-pill">
                        <span>📈</span> Visual Reports</div>
                    <div class="analytics-feature-pill">
                        <span>🧾</span> Job Insights</div>
                    <div class="analytics-feature-pill">
                        <span>⚡</span> Token Usage</div>
                </div>
                <button type="button" class="btn-view-analytics" onclick="openInTop('open_Ocr_Dashboard','NEW');">
                    🔍 View Analytics Dashboard
                </button>
            </div>
        </div>
        <!-- Overview Dashboard-->
        <div id="tabOverview" class="tab-content active">
            <div class="whats-new-banner">
                🚀 New Feature Released : <strong>Analytics Dashboard</strong> is now available
                with AI Reports, Charts & Insights.
            </div>
            <div class="section-card">
                <div id="toolHeader" class="section-header import-header">
                    <div class="section-header-icon">
                        &#9881;
                    </div>
                    <h2 id="toolTitle">
                        Import Feature Tools
                    </h2>
                    <div class="toggle-wrapper">
                        <!-- TOGGLE -->
                        <span class="sub"><b>Mode :</b></span> <span id="lblMode"><b>Import</b></span>
                        <label class="switch">
                            <input type="checkbox" id="ocrToggle" onchange="changeOCRMode();" />
                            <span class="slider round"></span>
                        </label>
                        <span id="lblMode2"><b>Export</b></span>
                    </div>
                </div>
                <!-- TOOLS -->
                <div class="icons-grid">
                    <!-- PDF TOOL -->
                    <div id="Ai_Pdf" class="icon-card import-card <%=PDF_SUBSCRIBED_CLASS%>" onclick="openOCRTool('pdf');"
                        title="PDF READER AI">
                        <div class="icon-wrapper pdf-ai">
                            <img src="../images/icons/OCR/pdf_reader.png" />
                        </div>
                        <span class="icon-label">PDF READER</span> <span class="badge-lock" style="display: none;">
                            🔒 PRO</span> <span class="badge-new">AI</span>
                    </div>
                    <!-- EXCEL TOOL -->
                    <div id="ExcelUpload" class="icon-card import-card" onclick="openOCRTool('excel');"
                        title="Excel OCR">
                        <div class="icon-wrapper excel">
                            <img src="../images/icons/OCR/excel_ocr.png" />
                        </div>
                        <span class="icon-label">Excel OCR</span> <span class="badge-lock" style="display: none;">
                            🔒 PRO</span> <span class="badge-new">EXCEL</span>
                    </div>
                    <!-- PDF New -->
                    <div id="pdfNew" class="icon-card import-card" onclick="openOCRTool('pdfnew');" title="PDF New">
                        <div class="icon-wrapper pdf-new">
                            <img src="../images/icons/OCR/pdf_new.png" />
                        </div>
                        <span class="icon-label">PDF New</span>
                    </div>
                    <!-- CHECKLIST TOOL -->
                    <div id="checklistCard" class="icon-card import-card" onclick="openOCRTool('checklist');"
                        title="Checklist Upload">
                        <div class="icon-wrapper check">
                            <img src="../images/icons/OCR/checklist.png" />
                        </div>
                        <span class="icon-label">CHECKLIST UPLOAD </span><span class="badge-lock" style="display: none;">
                            🔒 PRO</span>
                    </div>
                    <!-- XML TOOL -->
                    <div id="xmlCard" class="icon-card import-card" onclick="openOCRTool('xml');" title="Xml / Json">
                        <div class="icon-wrapper xml">
                            <img src="../images/icons/OCR/xml.png" />
                        </div>
                        <span class="icon-label">XML / JSON </span><span class="badge-lock" style="display: none;">
                            🔒 PRO</span>
                    </div>
                    <!-- REPORT -->
                    <div id="reportPage" class="icon-card import-card <%=PDF_SUBSCRIBED_CLASS%>" onclick="openOCRTool('report');"
                        title="Report">
                        <div class="icon-wrapper report">
                            <img src="../images/icons/OCR/report.png" />
                        </div>
                        <span class="icon-label">REPORT</span> <span class="badge-lock" style="display: none;">
                            🔒 PRO</span> <span class="badge-new">AI</span>
                    </div>
                    <!-- TEMPLATE -->
                    <div id="templateCard" class="icon-card import-card <%=PDF_SUBSCRIBED_CLASS%>" onclick="openOCRTool('template');"
                        title="Template Creation">
                        <div class="icon-wrapper template">
                            <img src="../images/icons/OCR/template.png" />
                        </div>
                        <span class="icon-label">Template Creation</span> <span class="badge-lock" style="display: none;">
                            🔒 PRO</span> <span class="badge-new">AI</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Subsribe box -->
    <div id="subscribeOverlay" style="display: none; position: fixed; top: 0; left: 0;
        width: 100%; height: 100%; background: rgba(0,0,0,0.55); z-index: 9999; align-items: center;
        justify-content: center;">
        <div style="background: #fff; border-radius: 16px; width: 420px; overflow: hidden;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);">
            <!-- Modal header -->
            <div style="background: linear-gradient(135deg,#1a237e,#3949ab); padding: 24px 28px 20px;
                position: relative;">
                <button type="button" onclick="closeSubscribeModal();" title="Close" style="position: absolute;
                    top: 12px; right: 15px; width: 36px; height: 36px; border: none; border-radius: 50%;
                    background: rgba(255,255,255,0.18); color: #fff; font-size: 20px; font-weight: bold;
                    cursor: pointer; transition: all .3s ease; z-index: 2;">
                    ✕
                </button>
                <div style="display: flex; align-items: center; gap: 12px;">
                    <div style="width: 44px; height: 44px; border-radius: 50%; background: rgba(255,255,255,0.15);
                        display: flex; align-items: center; justify-content: center; font-size: 22px;">
                        &#128274;
                    </div>
                    <div>
                        <p id="popupTitle" style="color: #fff; font-size: 17px; font-weight: 600; margin: 0;">
                            Premium Feature
                        </p>
                        <p id="popupSubTitle" style="color: rgba(255,255,255,0.75); font-size: 13px; margin: 0;">
                            PDF Reader AI
                        </p>
                    </div>
                </div>
                <span style="position: absolute; top: 16px; right: 60px; background: rgba(255,255,255,0.15);
                    border: 1px solid rgba(255,255,255,0.30); color: #fff; font-size: 11px; padding: 5px 12px;
                    border-radius: 20px; z-index: 1;">AI POWERED </span>
            </div>
            <!-- Modal body -->
            <div style="padding: 24px 28px;">
                <p id="popupMessage" style="font-size: 14px; color: #546e7a; line-height: 1.7; margin: 0 0 20px;">
                </p>
                <!-- Feature bullets -->
                <div style="display: flex; flex-direction: column; gap: 10px; margin-bottom: 24px;">
                    <div style="display: flex; align-items: center; gap: 10px; padding: 10px 14px; background: #f5f7ff;
                        border-radius: 10px;">
                        <span style="font-size: 18px;">&#10024;</span> <span id="feature1" style="font-size: 13px;
                            color: #37474f;">AI-powered field extraction </span>
                    </div>
                    <div style="display: flex; align-items: center; gap: 10px; padding: 10px 14px; background: #f5f7ff;
                        border-radius: 10px;">
                        <span style="font-size: 18px;">&#128196;</span> <span id="feature2" style="font-size: 13px;
                            color: #37474f;">Import & Export support </span>
                    </div>
                    <div style="display: flex; align-items: center; gap: 10px; padding: 10px 14px; background: #f5f7ff;
                        border-radius: 10px;">
                        <span id="feature3Icon" style="font-size: 18px;">&#9889; </span><span id="feature3"
                            style="font-size: 13px; color: #37474f;">Real-time processing & validation </span>
                    </div>
                </div>
                <!-- Buttons -->
                <div style="display: flex; gap: 10px;">
                    <button onclick="window.open('https://www.eroyal-enquiry.eroyalimpex.org/', '_blank');"
                        style="flex: 1; padding: 11px; background: #1a237e; color: #fff; border: none;
                        border-radius: 10px; font-size: 14px; font-weight: 600; cursor: pointer;">
                        &#9733; Contact Admin
                    </button>
                    <button type="button" onclick="closeSubscribeModal();" style="padding: 11px 18px;
                        background: #fff; color: #78909c; border: 1.5px solid #cfd8dc; border-radius: 10px;
                        font-size: 14px; cursor: pointer;">
                        Home Pages
                    </button>
                    <%--<button type="button" onclick="ShowUserGuide();" style="padding: 11px 18px;
                        background: #fff; color: #78909c; border: 1.5px solid #cfd8dc; border-radius: 10px;
                        font-size: 14px; cursor: pointer;">
                        View Feature Details
                    </button>--%>
                </div>
                <p style="text-align: center; font-size: 12px; color: #b0bec5; margin: 14px 0 0;">
                    <b>Contact your administrator to enable subscription access.</b>
                </p>
            </div>
        </div>
    </div>
    <!-- Footer -->
    <div class="dashboard-footer">
        &copy; e-Royal Impex &nbsp;|&nbsp; AI Dashboard
    </div>
    </form>
    <script type="text/javascript">
        document.addEventListener("contextmenu", function (e) {
            if (e.target.tagName === "IMG") {
                e.preventDefault();
                return false;
            }
        });

        document.addEventListener("dragstart", function (e) {
            if (e.target.tagName === "IMG") {
                e.preventDefault();
            }
        });
        document.onkeydown = function (e) {
            e = e || window.event;

            // F12
            /*if (e.keyCode == 123) {
            return false;
            }

            // Ctrl+Shift+I, Ctrl+Shift+J, Ctrl+Shift+C
            if (e.ctrlKey && e.shiftKey &&
            (e.keyCode == 73 || e.keyCode == 74 || e.keyCode == 67)) {
            return false;
            }*/

            // Ctrl+U
            if (e.ctrlKey && e.keyCode == 85) {
                return false;
            }
        };
    </script>
</body>
</html>
