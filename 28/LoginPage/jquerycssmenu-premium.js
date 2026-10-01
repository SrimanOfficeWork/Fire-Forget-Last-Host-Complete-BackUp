/*********************
 * jQuery Multi Level CSS Menu - Premium click-to-open variant
 * Loaded ONLY by LoginPage_Premium/E_royal_Impex_Main.aspx in place of
 * the shared ../js/jquerycssmenu.js, so this never touches the other
 * login-page variants that still use the plain hover version.
 *
 * The shared script is pure hover (jQuery .hover(): fadeIn on mouseenter,
 * fadeOut on mouseleave) at every level. That's what used to close a
 * dropdown - or a dropdown inside a dropdown - the instant the mouse left
 * its small trigger row, before ever reaching the flyout itself.
 *
 * EVERY level here now behaves identically, top-level or nested:
 *   - Click a header: opens its dropdown and marks it "pm-menu-active"
 *     (styled already in premium-theme.css). It stays open no matter where
 *     the mouse goes - there is no hover-driven open or close at any depth.
 *   - Click a sibling header at the same level: closes this one (and
 *     whatever it had open beneath it), opens that one instead. Ancestors
 *     further up are left alone, so opening a nested item never collapses
 *     the panel it lives in.
 *   - Click the same header again, click a leaf link anywhere inside it,
 *     click anywhere else on the page, or press Escape: closes it.
 *********************/

//Specify full URL to down and right arrow images (25 is padding-right to add to top level LIs with drop downs):
var arrowimages = { down: ['downarrowclass', '../images/menu_arrow-down.png', 25], right: ['rightarrowclass', '../images/menu_arrow-right.png'] }

var jquerycssmenu = {

    fadesettings: { overduration: 200, outduration: 120 }, //duration of fade in/ out animation, in milliseconds

    buildmenu: function (menuid, arrowsvar) {
        jQuery(document).ready(function ($) {
            var $mainmenu = $("#" + menuid + ">ul")
            var $headers = $mainmenu.find("ul").parent()

            // Puts a header's owned flyout <ul> back in its natural spot (as a plain
            // trailing child of its own <li>, exactly how the HTML authors it) if
            // openThis()'s isVertical branch below had reparented it elsewhere to
            // escape an ancestor's overflow clipping. Safe to call even if it's
            // already there (a no-op re-append).
            function pmRestoreFlyoutHome($li) {
                var $ul = $li.data('pmFlyout')
                if ($ul && $ul.length) $li.append($ul)
            }

            // Closes one header's own dropdown (and anything open further
            // inside it), without touching anything above it in the tree.
            function closeBranch($li) {
                var isVertical = $("body").hasClass("pm-vertical-menu")
                var isTop = $li.parents("ul").length == 1
                var $ul = $li.data('pmFlyout') || $li.children("ul:eq(0)")
                // Horizontal mode, level 2+ (Import, TP, Cert, ...): these are the
                // inline accordion branches opened by openThis() below - slide shut
                // instead of fading, matching their slideDown open animation.
                if (!isVertical && !isTop) $ul.stop(true, true).slideUp(jquerycssmenu.fadesettings.outduration)
                else $ul.stop(true, true).fadeOut(jquerycssmenu.fadesettings.outduration)

                // Cascading cleanup for any DESCENDANT header whose own flyout was
                // reparented out of $li's subtree (vertical mode - see openThis()
                // below), so it no longer lives inside $li in the DOM and plain
                // $li.find("ul")/$li.find("li") below can't reach it anymore. The
                // trigger <li> itself never moves though (only the <ul> it owns
                // does), and _ancestorLis was captured once at setup time from the
                // menu's ORIGINAL/true nesting, before any reparenting ever
                // happened - so this still correctly finds every logical
                // descendant regardless of where its flyout currently sits.
                //
                // This cascade/restore now always runs, regardless of the CURRENT
                // isVertical reading - not just "if (isVertical)". pmApplyMenuLayout()
                // (E_royal_Impex_Main.aspx) flips the body's pm-vertical-menu class
                // BEFORE it tries to close whatever's open, so a submenu left open in
                // Vertical mode and then closed via the Sidebar Layout toggle (mode
                // already Horizontal by the time closeBranch/closeAll runs here) used
                // to skip this block entirely - its flyout <ul> stayed reparented as a
                // stray direct child of the menu's top-level <ul> forever, no longer
                // nested inside its own <li>, which broke that submenu's depth-based
                // CSS (and absolute-position offsetParent) the next time it opened.
                // pmRestoreFlyoutHome() is a harmless no-op re-append when the flyout
                // is already home, so running it unconditionally is safe either way.
                $headers.each(function () {
                    if (this._ancestorLis && this._ancestorLis.indexOf($li[0]) !== -1) {
                        var $descLi = $(this)
                        var $descUl = $descLi.data('pmFlyout')
                        if ($descUl) $descUl.stop(true, true).hide()
                        pmRestoreFlyoutHome($descLi)
                        $descLi.removeClass("pm-menu-active")
                    }
                })
                // $li's own flyout, too - put it back home now that it's closed,
                // so its DOM depth (some CSS keys off how many <ul>s deep an
                // element sits) and default position are correct again the next
                // time it opens, in this mode or after switching layouts.
                pmRestoreFlyoutHome($li)
                if (!isVertical) $li.find("ul").not($ul).hide()
                $li.removeClass("pm-menu-active")
                $li.find("li").removeClass("pm-menu-active")
            }

            function closeAll() {
                $headers.each(function () { closeBranch($(this)) })
            }

            // Exposed so E_royal_Impex_Main.aspx's pmApplyMenuLayout() (the Sidebar
            // Layout toggle) can close/restore every open submenu through the same
            // closeBranch() logic instead of its own plain "hide whatever's visible"
            // pass, which left reparented vertical-mode flyouts stranded in the wrong
            // place in the DOM (see closeBranch's comment above).
            window.pmCloseAllMenus = closeAll

            $headers.each(function (i) {
                var $curobj = $(this)
                var $subul = $(this).find('ul:eq(0)')
                this._dimensions = { w: this.offsetWidth, h: this.offsetHeight, subulw: $subul.outerWidth(), subulh: $subul.outerHeight() }
                this.istopheader = $curobj.parents("ul").length == 1 ? true : false
                // Snapshot of every ANCESTOR header <li> (Master, Import, ...) - the
                // menu's true/original nesting, captured once here before openThis()
                // below ever reparents anything - so closeBranch() above can still
                // correctly cascade-close a descendant even after its flyout has been
                // moved elsewhere in the DOM to escape an ancestor's clipping.
                this._ancestorLis = $curobj.parents("li").toArray()
                $curobj.data('pmFlyout', $subul)
                $subul.css({ top: this.istopheader ? this._dimensions.h + "px" : 0 })
                $curobj.children("a:eq(0)").css(this.istopheader ? { paddingRight: arrowsvar.down[2] } : {}).append(
                    '<img src="' + (this.istopheader ? arrowsvar.down[1] : arrowsvar.right[1])
                    + '" class="' + (this.istopheader ? arrowsvar.down[0] : arrowsvar.right[0])
                    + '" style="border:0;" />'
                )

                var el = this

                function openThis() {
                    var $targetul = $curobj.data('pmFlyout') || $curobj.children("ul:eq(0)")
                    var isVertical = $("body").hasClass("pm-vertical-menu")

                    if (isVertical) {
                        // Sidebar mode, EVERY level (top-level menus and anything nested
                        // inside them - Import/Export's own list, TP, Cert, SDF FORMAT's
                        // own children, ...): the menu itself stays put as the sidebar
                        // column; every flyout opens OUTSIDE it, to the right of its own
                        // trigger row, never below/inline (that would push into the
                        // sidebar's own list of other menus instead of floating over the
                        // main content). Coordinates come fresh from the trigger's actual
                        // on-screen position (getBoundingClientRect) every time it opens,
                        // clamped to the viewport, and position:fixed (not absolute) so
                        // the whole box - and its scrollbar, for the couple of menus long
                        // enough to need one (.pm-sidebar #Rpt_Import > ul in
                        // premium-theme.css) - always starts on-screen, never mostly
                        // below the visible viewport just because its trigger row sits
                        // low in a long sidebar list.

                        // A "ul ul" ancestor's own overflow-y:auto + max-height (see that
                        // same premium-theme.css rule) also clips any position:fixed
                        // descendant nested inside it - position:fixed only changes what
                        // left/top are measured against, it does NOT escape an ancestor's
                        // overflow clipping. This flyout is positioned to open just to the
                        // right of its own trigger row, which sits INSIDE its ancestor
                        // flyout's own box - i.e. right at that box's clipped edge - so a
                        // 3rd-level+ (sub-submenu) flyout was getting cut off by its own
                        // parent flyout's clip box instead of showing.
                        //
                        // Earlier attempts suspended the ancestor's own overflow/max-height
                        // instead (temporarily switching it to overflow:visible) - that
                        // avoided the clip, but a scrolled ancestor stops being a scroll
                        // container the instant its overflow changes, so any scroll
                        // position was lost (snapping back to unscrolled) and the ancestor's
                        // own rounded/bordered/shadowed card design broke while doing it
                        // (this is exactly how "Customized DSR" under Import's "Other" group
                        // was found and reported broken - both the scroll jump and, once
                        // that was patched with a compensating transform, the ancestor still
                        // visibly lost its card shape and scrollability for the duration).
                        //
                        // Reparenting instead: move $targetul to be a direct child of the
                        // menu's own top-level <ul> - one/two levels of "ul ul" nesting away
                        // from any clipping ancestor, so it's never inside one - while
                        // leaving every ancestor's own overflow/max-height/card design
                        // completely untouched. closeBranch()/pmRestoreFlyoutHome() above
                        // put it back in its natural spot (inside its own <li>) once closed.
                        if ($targetul.parent()[0] !== $mainmenu[0]) $mainmenu.append($targetul)

                        var rect = el.getBoundingClientRect()
                        // rect.width (not el._dimensions.w) - the trigger's own width was
                        // measured once at page load while the menu was still in its
                        // default horizontal-bar layout (narrow, auto-width). In sidebar
                        // mode every row stretches to the full column width instead, so
                        // that cached value is stale and puts the flyout partway across
                        // the sidebar instead of just past its right edge. rect is always
                        // freshly measured, right above, so it reflects whichever layout
                        // is actually active right now.
                        var fixedLeft = rect.left + rect.width

                        // Same staleness problem as rect above, for THIS flyout's own size -
                        // el._dimensions.subulw/subulh were captured once at page-load time,
                        // in whichever layout mode happened to be the default at that moment
                        // (see the horizontal branch's identical freshW fix further below).
                        // If that default was Horizontal and the user then switches to
                        // Vertical via the Sidebar Layout toggle (no page reload), every
                        // flyout's cached size is still its narrow horizontal-bar dimensions
                        // instead of sidebar mode's wider min-width:246px card, throwing off
                        // the edge-clamping below - most visibly for a 3rd-level+ flyout,
                        // whose stale-too-narrow cached width made it look clipped/misplaced
                        // right where it opens, next to its own trigger. Re-measure fresh,
                        // same show-hidden-then-hide trick the horizontal branch already uses.
                        var freshSubulW = el._dimensions.subulw, freshSubulH = el._dimensions.subulh
                        if (!$targetul.is(':visible')) {
                            $targetul.css({ display: 'block', visibility: 'hidden' })
                            freshSubulW = $targetul.outerWidth()
                            freshSubulH = $targetul.outerHeight()
                            $targetul.css({ display: 'none', visibility: 'visible' })
                        }

                        var maxFixedLeft = $(window).width() - freshSubulW - 4
                        // Squeeze against the right edge rather than flipping to the left
                        // of the trigger - for a top-level item that sits right at the
                        // sidebar's own left edge, flipping left would push the flyout to
                        // a negative (off-screen) position instead of a merely-tight one.
                        if (fixedLeft > maxFixedLeft) fixedLeft = maxFixedLeft
                        if (fixedLeft < 4) fixedLeft = 4
                        var fixedTop = rect.top
                        var maxFixedTop = $(window).height() - freshSubulH - 4
                        if (fixedTop > maxFixedTop) fixedTop = maxFixedTop
                        // Floor is the header's own bottom edge (+ a small gap), not a flat
                        // 4px - a tall flyout (Report > Import, 20+ items) clamped upward to
                        // fit the screen could otherwise land at the very top of the page,
                        // rendering over/under the header bar instead of below it.
                        var topbarEl = document.querySelector(".pm-topbar")
                        var minFixedTop = (topbarEl ? topbarEl.getBoundingClientRect().bottom : 0) + 8
                        if (fixedTop < minFixedTop) fixedTop = minFixedTop
                        $targetul.css({ position: 'fixed', left: fixedLeft + "px", top: fixedTop + "px" }).stop(true, true).fadeIn(jquerycssmenu.fadesettings.overduration)
                    } else if (el.istopheader) {
                        // Horizontal mode, top-level trigger ("Report"/"Master"/...
                        // opening its panel below the horizontal bar).
                        var offsets = { left: $curobj.offset().left, top: $curobj.offset().top }
                        // Fresh width measurement instead of the cached el._dimensions.subulw -
                        // that number was captured once at page-load time, in whichever layout
                        // mode happened to be the default (often Vertical). A panel using the
                        // horizontal-only 2-column treatment (Admin/Sales Billing/Common/Import -
                        // #Li74/#Li73/#Billing/#Adm_Import/#User_Admin_Id, width:480px in
                        // premium-theme.css) is only that wide while body lacks
                        // pm-vertical-menu; measured under the default Vertical mode it was
                        // still the narrow single-column sidebar width instead. That stale,
                        // too-narrow number under-detects overflow near the right edge of the
                        // bar - Admin sits close enough to it that its true 480px panel ran off
                        // the browser edge while the stale width still said "fits, don't flip".
                        // The submenu is normally display:none while closed, so it has to be
                        // shown (off-screen-invisible via visibility:hidden, not display:none)
                        // just long enough to read its real current-mode width, same trick the
                        // page's very first buildmenu() measurement pass relies on.
                        var freshW = $targetul.outerWidth()
                        if (!$targetul.is(':visible')) {
                            $targetul.css({ display: 'block', visibility: 'hidden' })
                            freshW = $targetul.outerWidth()
                            $targetul.css({ display: 'none', visibility: 'visible' })
                        }
                        // The trigger LI's own width, too - el._dimensions.w has the exact same
                        // staleness problem (measured full sidebar-row width at buildmenu time),
                        // which threw off the flipped panel's right-edge alignment. No trick
                        // needed here - the trigger is already live/visible in the topbar right
                        // now, so its offsetWidth is always current truth.
                        var menuleft = (offsets.left + freshW > $(window).width()) ? (-freshW + el.offsetWidth) : 0
                        // top explicitly reset every open (not just left/position) - the
                        // isVertical branch above sets an inline position:fixed + top:<Ypx>
                        // (a raw viewport coordinate) on this same element whenever it was
                        // last opened in sidebar mode. Switching layout doesn't clear that
                        // inline style, so without resetting it here too, reopening this
                        // exact dropdown right after a vertical->horizontal switch left the
                        // stale fixed-mode top (often far down the page, since sidebar items
                        // like "Sidebar Layout" sit low in a tall column) stuck on the panel -
                        // it flew open at the bottom of the page instead of under the trigger.
                        //
                        // width: freshW (not left as CSS's own min-width:246px shrink-to-fit)
                        // locks the panel's width to what it measured just above, BEFORE any
                        // of its own nested accordion branches (Customized DSR, MIS Report,
                        // Declaration, ...) are open - those are still display:none at this
                        // exact moment, so they contributed nothing to that measurement. Without
                        // this, the panel had no explicit width at all, so once a nested branch
                        // was clicked open and its own (previously-hidden, now-visible) rows
                        // joined the shrink-to-fit width calculation, the WHOLE panel resized to
                        // fit them - visibly shifting every row's alignment at that instant, not
                        // just growing downward the way an accordion opening normally should.
                        // Longer nested labels now simply wrap onto a 2nd line instead.
                        $targetul.css({ position: 'absolute', left: menuleft + "px", top: el.offsetHeight + "px", width: freshW + "px" }).stop(true, true).fadeIn(jquerycssmenu.fadesettings.overduration)
                    } else {
                        // Horizontal mode, level 2+ (Import, TP, Cert, ...): accordion -
                        // expands inline directly below its own row (pushing later rows
                        // down), instead of flying out sideways as a separate card. No
                        // position/left to compute at all - it just grows in normal flow.
                        $targetul.css({ position: 'static', left: '' }).stop(true, true).slideDown(jquerycssmenu.fadesettings.overduration)
                    }
                    $curobj.addClass("pm-menu-active")
                }

                // Same click behaviour at every depth - see the file header comment.
                // preventDefault/stopPropagation matter here even for a plain hover
                // in the old script's world these were <a href="#"> with no click
                // handler at all, so clicking one (not just hovering it) let the
                // browser follow that "#" link and jump/scroll the page - which is
                // what was closing the very submenu that had just been opened.
                $curobj.children("a:eq(0)").bind("click", function (e) {
                    var wasOpen = (($curobj.data('pmFlyout')) || $curobj.children("ul:eq(0)")).is(":visible")
                    // "li" filter matters once openThis() below starts reparenting flyouts
                    // (vertical mode) - a currently-open sibling's <ul> can end up sitting
                    // as a plain DOM sibling of $curobj too (both moved to the same shared
                    // top-level <ul>), and closeBranch() expects an actual <li> trigger,
                    // not the flyout <ul> itself, to find/close/restore it correctly.
                    $curobj.siblings("li").each(function () { closeBranch($(this)) })
                    if (wasOpen) closeBranch($curobj); else openThis()
                    // The username/avatar dropdown (E_royal_Impex_Main.aspx) closes itself
                    // on any click that bubbles up to `document`, but e.stopPropagation()
                    // just below stops this click from ever reaching it - so clicking a
                    // top menu header while that dropdown was left open used to leave it
                    // open. closePmUserMenu is a plain top-level function on the page, so
                    // it's already a property of window - call it directly instead of
                    // relying on bubbling.
                    if (window.closePmUserMenu) window.closePmUserMenu()
                    e.preventDefault()
                    e.stopPropagation()
                })
            }) //end $headers.each()

            // A real leaf link (no submenu of its own) closes the whole open menu on
            // click, at any nesting depth - otherwise the panel is left open floating
            // over whatever just loaded in the content frame.
            $mainmenu.find("li").not($headers).find("a").bind("click", function () {
                closeAll()
                if (window.closePmUserMenu) window.closePmUserMenu()
            })

            // Click anywhere outside the menu closes whatever's open.
            $(document).bind("click", function (e) {
                if (!$(e.target).closest("#" + menuid).length) closeAll()
            })

            // Escape closes whatever's open, standard menu convention.
            // (keyCode, not e.key - this page runs jQuery 1.4.4 / can hit old IE.)
            $(document).bind("keydown", function (e) {
                if (e.keyCode === 27) closeAll()
            })

            $mainmenu.find("ul").css({ display: 'none', visibility: 'visible' })

            // Gates the horizontal accordion's position:static rule (premium-theme.css) -
            // added only now, after every header above has already measured its own
            // _dimensions. Level 3+ submenus need position:static so they expand inline
            // instead of flying out sideways, but while the $headers.each() loop above
            // was running, this page is (by default) still in horizontal mode with no
            // open/close state yet - if that CSS were active from the first paint, a
            // level 3+ submenu would already be in normal document flow with only
            // visibility:hidden (not display:none, per the display:none-breaks-
            // measurement note above), so it'd still reserve its full layout height,
            // inflating every ANCESTOR header's own _dimensions.subulh in turn (this is
            // exactly why e.g. Accounts' sidebar flyout measured ~600px tall for a
            // 7-item list - its descendants' collapsed accordion branches were all still
            // taking up space during measurement). Everything stays position:absolute
            // (out of flow, like it always was) until this class exists.
            $("#" + menuid).addClass("pm-menu-ready")
        }) //end document.ready
    }
}

//build menu with ID="myjquerymenu" on page:
jquerycssmenu.buildmenu("myjquerymenu", arrowimages)
