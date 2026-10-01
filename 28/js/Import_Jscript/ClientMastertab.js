/* =================================================================
ClientMastertab.js
Path : ~/js/Import_Jscript/ClientMastertab.js
Works WITH activatables.js
================================================================= */

/* -----------------------------------------------------------------
OVERRIDE tab_page1 — fixes IGM_General.js conflict
----------------------------------------------------------------- */
function tab_page1(val) {
    var p2 = document.getElementById('page-2');
    var p3 = document.getElementById('page-3');
    if (p2) p2.style.display = 'none';
    if (p3) p3.style.display = 'none';
    var p1 = document.getElementById('page-1');
    if (p1) p1.style.display = 'block';
}

/* -----------------------------------------------------------------
OVERRIDE tab_page2 — fixes IGM_General.js conflict
----------------------------------------------------------------- */
function tab_page2(val) {
    var p1 = document.getElementById('page-1');
    var p3 = document.getElementById('page-3');
    if (p1) p1.style.display = 'none';
    if (p3) p3.style.display = 'none';
    var p2 = document.getElementById('page-2');
    if (p2) p2.style.display = 'block';
}

/* -----------------------------------------------------------------
Account Info tab — called from onclick
----------------------------------------------------------------- */
function cm_tab_AccInfo() {
    var p1 = document.getElementById('page-1');
    var p2 = document.getElementById('page-2');
    var p3 = document.getElementById('page-3');
    if (p1) p1.style.display = 'none';
    if (p2) p2.style.display = 'none';
    if (p3) p3.style.display = 'block';

 
    var savedInner = document.getElementById('hdn_ActiveInnerTab').value || 'inner-General';
    var savedBank = document.getElementById('hdn_ActiveBankTab').value || 'bank-Payable';
    var savedDeep = document.getElementById('hdn_ActiveDeepTab').value || 'deep-Customer';

    cm_showInnerTab(savedInner);
    cm_showDeepTab(savedDeep);
    cm_showBankTab(savedBank);
}

/* -----------------------------------------------------------------
LEVEL-2 inner tab: General | TDS Details | Bank Details
FIX: uses style.display directly — no class dependency
----------------------------------------------------------------- */
function cm_showInnerTab(tabId) {
    var innerPanels = ['inner-General', 'inner-TDS', 'inner-Bank'];
    for (var i = 0; i < innerPanels.length; i++) {
        var el = document.getElementById(innerPanels[i]);
        if (el) el.style.display = 'none';
    }
    var active = document.getElementById(tabId);
    if (active) active.style.display = 'block';

    var links = document.querySelectorAll('#toc_inner li a');
    for (var j = 0; j < links.length; j++) {
        links[j].className = links[j].className.replace(/\s*\bactive\b/g, '').trim();
    }
    var linkId = tabId.replace(/-/, '_');
    var link = document.getElementById(linkId);
    if (link) link.className = (link.className + ' active').trim();

    // ✅ If Bank Details tab selected, also restore bank sub-tab
    if (tabId === 'inner-Bank') {
        var savedBank = document.getElementById('hdn_ActiveBankTab').value || 'bank-Payable';
        cm_showBankTab(savedBank);
    }
}
/* -----------------------------------------------------------------
LEVEL-3 deep tab: Customer | Vendor
FIX: uses style.display directly — no class dependency
This is why Customer was showing in Vendor tab!
CSS class toggle wasn't working but display toggle does.
----------------------------------------------------------------- */
function cm_showDeepTab(tabId) {
    var deepPanels = ['deep-Customer', 'deep-Vendor'];
    for (var i = 0; i < deepPanels.length; i++) {
        var el = document.getElementById(deepPanels[i]);
        if (el) el.style.display = 'none';
    }
    var active = document.getElementById(tabId);
    if (active) active.style.display = 'block';

    var links = document.querySelectorAll('#toc_deep li a');
    for (var j = 0; j < links.length; j++) {
        links[j].className = links[j].className.replace(/\s*\bactive\b/g, '').trim();
    }
    var linkId = tabId.replace(/-/, '_');
    var link = document.getElementById(linkId);
    if (link) link.className = (link.className + ' active').trim();
}


/* -----------------------------------------------------------------
Copy email Customer → Vendor
----------------------------------------------------------------- */
function CopyEmailToVendor() {
    var src = document.getElementById('txtCust_NotifEmail');
    var dst = document.getElementById('txtVend_NotifEmail');
    if (src && dst) { dst.value = src.value; }
}

/* -----------------------------------------------------------------
INIT on page load and after every UpdatePanel postback
----------------------------------------------------------------- */


/* Run on DOM ready */
if (typeof jQuery !== 'undefined') {
    jQuery(document).ready(function () { cm_InitTabs(); });
} else {
    window.addEventListener('load', cm_InitTabs);
}

/* Re-run after UpdatePanel postback */
if (typeof Sys !== 'undefined') {
    Sys.Application.add_load(function () { cm_InitTabs(); });
}


function cm_InitTabs() {
    cm_showDeepTab('deep-Customer');
    cm_showInnerTab('inner-General');
    cm_showBankTab('bank-Payable');
}

