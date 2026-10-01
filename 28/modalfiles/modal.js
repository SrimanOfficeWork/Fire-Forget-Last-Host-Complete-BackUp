
if (typeof dhtmlwindow=="undefined")
alert('ERROR: Modal Window script requires all files from "DHTML Window widget" in order to work!')

var dhtmlmodal={
veilstack: 0,
open:function(t, contenttype, contentsource, title, attr, recalonload){
	var d=dhtmlwindow //reference dhtmlwindow object
	this.interVeil=document.getElementById("interVeil") //Reference "veil" div
	// Only count this as a NEW modal going up if a window with this id isn't already open.
	// dhtmlwindow.open() (below) REUSES the existing div for the same id rather than creating
	// a second one, so calling dhtmlmodal.open() twice in a row for the same popup (e.g. an
	// impatient double-click on a link that opens it - it doesn't always render instantly, see
	// OCR_Dashboard_Report/Template_Creation.aspx.cs's 300ms delay) was incrementing veilstack
	// twice for what is visibly still just ONE popup. A single close() (closeveil() below) only
	// ever decrements it once, so veilstack never made it back down to 0 - interVeil (the
	// darkened/blurred backdrop) stayed on screen (display:block, its blur(3px) filter still
	// applied) even after the popup itself had visibly closed.
	var existing=document.getElementById(t)
	var alreadyOpen=existing && existing.style.display=="block"
	if (!alreadyOpen)
		this.veilstack++ //var to keep track of how many modal windows are open right now
	this.loadveil()
	if (recalonload=="recal" && d.scroll_top==0)
		d.addEvent(window, function(){dhtmlmodal.adjustveil()}, "load")
	var t=d.open(t, contenttype, contentsource, title, attr, recalonload)
	t.controls.firstChild.style.display="none" //Disable "minimize" button
	t.controls.onclick=function(){dhtmlmodal.close(this._parent, true)} //OVERWRITE default control action with new one
	t.show=function(){dhtmlmodal.show(this)} //OVERWRITE default t.show() method with new one
	t.hide=function(){dhtmlmodal.close(this)} //OVERWRITE default t.hide() method with new one
return t
},


loadveil:function(){
	var d=dhtmlwindow
	d.getviewpoint()
	this.docheightcomplete=(d.standardbody.offsetHeight>d.standardbody.scrollHeight)? d.standardbody.offsetHeight : d.standardbody.scrollHeight
	this.interVeil.style.width=d.docwidth+"px" //set up veil over page
	this.interVeil.style.height=this.docheightcomplete+"px" //set up veil over page
	this.interVeil.style.left=0 //Position veil over page
	this.interVeil.style.top=0 //Position veil over page
	this.interVeil.style.visibility="visible" //Show veil over page
	this.interVeil.style.display="block" //Show veil over page
},

adjustveil:function(){ //function to adjust veil when window is resized
	if (this.interVeil && this.interVeil.style.display=="block") //If veil is currently visible on the screen
		this.loadveil() //readjust veil
},

closeveil:function(){ //function to close veil
	this.veilstack--
	// veilstack is a plain counter, incremented in open()/show() and decremented only
	// here - anywhere those two sides get out of step (see open()'s own comment above
	// about the impatient-double-click case it already guards against; a shared window
	// id like "Export General Excel Upload" being reused by several different tools/
	// pages across this app makes other drift scenarios plausible too, e.g. one tool's
	// popup being closed by some path that skips this function entirely) leaves
	// veilstack stuck above 0 forever after - interVeil (the darkened/blurred backdrop)
	// then never gets its display:none, staying visibly on screen behind whatever the
	// user does next even though every popup has actually closed. Falling back to "is
	// any dhtmlwindow actually still on screen" - not just what the counter claims - is
	// the same fix already applied to open()'s counterpart bug: rather than trust
	// veilstack alone, verify against the real DOM state and self-correct if it's ever
	// wrong.
	if (this.veilstack<=0 || !this.anyWindowStillOpen())
		this.interVeil.style.display="none"
	if (this.veilstack<0) this.veilstack=0
},

anyWindowStillOpen:function(){
	var wins=document.getElementsByClassName("dhtmlwindow")
	for (var i=0; i<wins.length; i++){
		if (wins[i].style.display=="block") return true
	}
	return false
},


close:function(t, forceclose){ //DHTML modal close function
	t.contentDoc=(t.contentarea.datatype=="iframe")? window.frames["_iframe-"+t.id].document : t.contentarea //return reference to modal window DIV (or document object in the case of iframe
	if (typeof forceclose!="undefined")
		t.onclose=function(){return true}
	if (dhtmlwindow.close(t)) //if close() returns true
		this.closeveil()
},


show:function(t){
	dhtmlmodal.veilstack++
	dhtmlmodal.loadveil()
	dhtmlwindow.show(t)
}
} //END object declaration


document.write('<div id="interVeil"></div>')
dhtmlwindow.addEvent(window, function(){if (typeof dhtmlmodal!="undefined") dhtmlmodal.adjustveil()}, "resize")