$(document).ready(function(){

	$('.accordion').accordion({
		autoHeight  : false,
		collapsible : true,
		active      : false // start compressed
	});

	$('#slider1')
	.anythingSlider({
		width          : 400,
		height         : 300,
		startStopped   : true,
		toggleControls : true,
		theme          : 'metallic',
		navigationFormatter : function(i, panel){
			return '<img src="demos/images/th-slide-' + ['civil-1', 'env-1', 'civil-2', 'env-2'][i-1] + '.jpg">';
		}
	})
	.find('.panel:not(.cloned) img') // ignore the cloned panels
		.attr('rel','group')           // add all slider images to a colorbox group
		.colorbox({
			width: '90%',
			height: '90%',
			href: function(){ return $(this).attr('src'); },
			// use $(this).attr('title') for specific image captions
			title: 'Press escape to close',
			rel: 'group'
		});

	$('#slider2')
	.anythingSlider({
		width               : 600,
		height              : 350,
		startStopped        : true,
		resizeContents      : false,
		navigationFormatter : function(i, panel){
			return ['Recipe', 'Quote', 'Image', 'Quote #2', 'Image #2', 'Test'][i - 1];
		}
	})
	.anythingSliderFx({
		// base FX definitions
		// '.selector' : [ 'effect(s)', 'distance/size', 'time', 'easing' ] - 'time' and 'easing' are optional parameters
		'.quoteSlide'         : [ 'top', '500px', '1000', 'easeOutElastic' ],
		'.expand'             : [ 'expand', '10%', '400', 'easeOutBounce' ],
		'.textSlide h3'       : [ 'top left', '200px', '500', 'easeOutCirc' ],
		'.textSlide img,.fade': [ 'fade' ],
		'.textSlide li'       : [ 'listLR' ] /*,

		// for more precise control, use the "in" and "out" definitions
		// in = the animation that occurs when you slide "in" to a panel
		    inFx  : {
		     '.textSlide h3'  : { opacity: 1, top  : 0, duration: 400, easing : 'easeOutBounce' },
		     '.textSlide li'  : { opacity: 1, left : 0, duration: 400 },
		     '.textSlide img' : { opacity: 1, duration: 400 },
		     '.quoteSlide'    : { top : 0, duration: 400, easing : 'easeOutElastic' },
		     '.expand'        : { width: '100%', top: '0%', left: '0%', duration: 400, easing : 'easeOutBounce' }
		    },
		// out = the animation that occurs when you slide "out" of a panel
		// (it also occurs before the "in" animation)
		     outFx : {
		     '.textSlide h3'      : { opacity: 0, top  : '-100px', duration: 350 },
		     '.textSlide li:odd'  : { opacity: 0, left : '-200px', duration: 350 },
		     '.textSlide li:even' : { opacity: 0, left : '200px',  duration: 350 },
		     '.textSlide img'     : { opacity: 0, duration: 350 },
		     '.quoteSlide:first'  : { top : '-500px', duration: 350 },
		     '.quoteSlide:last'   : { top : '500px', duration: 350 },
		     '.expand'            : { width: '10%', top: '50%', left: '50%', duration: 350 },
		    } */
	});

	$('#slider3')
	.anythingSlider({
		width               : 500,
		height              : 400,
		startStopped        : true,
		navigationFormatter : function(i, panel){
			return ['Top', 'Right', 'Bottom', 'Left'][i - 1];
		}
	})
	.anythingSliderFx({
		'.caption-top'    : [ 'caption-Top', '50px' ],
		'.caption-right'  : [ 'caption-Right', '130px', '1000', 'easeOutBounce' ],
		'.caption-bottom' : [ 'caption-Bottom', '50px' ],
		'.caption-left'   : [ 'caption-Left', '130px', '1000', 'easeOutBounce' ]
	})
	/* use this code to have the caption slide in and out from the bottom with each panel
	.anythingSliderFx({
		inFx: {
			'.caption-top'    : { top: 0, opacity: 0.8, duration: 400 },
			'.caption-right'  : { right: 0, opacity: 0.8, duration: 400 },
			'.caption-bottom' : { bottom: 0, opacity: 0.8, duration: 400 },
			'.caption-left'   : { left: 0, opacity: 0.8, duration: 400 }
		},
		outFx: {
			'.caption-top'    : { top: -50, opacity: 0, duration: 350 },
			'.caption-right'  : { right: -150, opacity: 0, duration: 350 },
			'.caption-bottom' : { bottom: -50, opacity: 0, duration: 350 },
			'.caption-left'   : { left: -150, opacity: 0, duration: 350 }
		}
	}) */
	// add a close button (x) to the caption
	.find('div[class*=caption]')
		.css({ position: 'absolute' })
		.prepend('<span class="close">x</span>')
		.find('.close').click(function(){
			var cap = $(this).parent(),
				ani = { bottom : -50 }; // bottom
			if (cap.is('.caption-top')) { ani = { top: -50 }; }
			if (cap.is('.caption-left')) { ani = { left: -150 }; }
			if (cap.is('.caption-right')) { ani = { right: -150 }; }
			cap.animate(ani, 400, function(){ cap.hide(); } );
		});

	
});


function ddpanel(setting){
	setting.dir="up" //initial state of panel (up="contracted")
	if (setting.stateconfig.persiststate && ddpanel.getCookie(setting.ids[0])=="down"){
		setting.dir="down"
	}
	if (setting.dir=="up"){ //if "up", output CSS to hide panel contents
		document.write('<style type="text/css">\n')
		document.write('#'+setting.ids[1]+'{height:' + parseInt(setting.stateconfig.initial) + 'px; overflow:hidden}\n')
		document.write('</style>\n')
	}
	setting.stateconfig.initial=parseInt(setting.stateconfig.initial)
	this.setting=setting
	if (setting.pointerimage.enabled){ //preload images
		var img1=new Image(), img2=new Image()
		img1.src=setting.pointerimage.src[0]
		img2.src=setting.pointerimage.src[1]
	}
	var thispanel=this
	if (window.addEventListener) //if non IE browsers, initialize panel window.onload
		ddpanel.addEvent(window, function(e){thispanel.initpanel(setting)}, "load")
	else //else if IE, add 100 millisec after window.onload before initializing
		ddpanel.addEvent(window, function(e){setTimeout(function(){thispanel.initpanel(setting)}, 100)}, "load")
	ddpanel.addEvent(window, function(e){thispanel.uninit(setting)}, "unload")
}

ddpanel.events_array=[] //object array to contain events created by script

ddpanel.addEvent=function(target, functionref, tasktype){
	var evtmodel=target.addEventListener? "w3c" : "ie"
	var evtaction=evtmodel=="w3c"? "addEventListener" : "attachEvent"
	var i=this.events_array.push({ //store event info in ddpanel.events_array[] and return current event's index within array
		target: target,
		tasktype: (evtmodel=="ie"? "on" : "")+tasktype,
		listener: evtmodel=="ie"? function(){return functionref.call(target, window.event)} : functionref
	})-1
	target[evtaction](this.events_array[i].tasktype, this.events_array[i].listener, evtmodel=="w3c"? false : null)
}

ddpanel.removeEvent=function(target, functionref, tasktype){
	var evtmodel=target.removeEventListener? "w3c" : "ie"
	var evtaction=evtmodel=="w3c"? "removeEventListener" : "detachEvent"
	target[evtaction](tasktype, functionref, evtmodel=="w3c"? false : null)
}

ddpanel.getCookie=function(Name){ 
	var re=new RegExp(Name+"=[^;]+", "i"); //construct RE to search for target name/value pair
	if (document.cookie.match(re)) //if cookie found
		return document.cookie.match(re)[0].split("=")[1] //return its value
	return null
}

ddpanel.setCookie=function(name, value){
	document.cookie = name+"=" + value + ";path=/"
}

ddpanel.addpointer=function(target, className, imagesrc){
	var pointer=document.createElement("img")
	pointer.src=imagesrc
	pointer.className=className
	pointer.style.borderWidth=0
	target.appendChild(pointer)
	return pointer
}

ddpanel.prototype={

togglepanel:function(dir){ //public function that toggles the panel's state. Optional dir parameter ("up" or "down") to explicitly set state.
	var setting=this.setting
	setting.dir=dir || ((setting.dir=="up")? "down" : "up")
	var pcontent=setting.pcontent, dir=setting.dir
	pcontent._currentheight=(dir=="down")? pcontent._actualheight : setting.stateconfig.initial
	pcontent.style.height=pcontent._currentheight+"px"
	if (setting.pointerimage.enabled){
		setting.arrow.src=setting.pointerimage.src[(setting.dir=="down")? 1 : 0]
		setting.arrow.style.visibility="visible"
	}
	ddpanel.setCookie(setting.ids[0], setting.dir)
},

togglepanelplus:function(dir){ //public function that toggles the panel's state w/ animation. Optional dir parameter ("up" or "down") to explicitly set state.
	var setting=this.setting
	setting.dir=dir || ((setting.dir=="up")? "down" : "up")
	if (setting.pointerimage.enabled)
		setting.arrow.style.visibility="hidden"
	clearTimeout(setting.revealtimer)
	this.revealcontent()
},

revealcontent:function(){
	var setting=this.setting
	var pcontent=setting.pcontent, curH=pcontent._currentheight, maxH=pcontent._actualheight, minH=setting.stateconfig.initial, steps=setting.animate.steps, dir=setting.dir
	if (dir=="down" && curH<maxH || dir=="up" && curH>minH){
		var newH = curH + (Math.round((maxH-curH)/steps)+1) * (dir=="up"? -1 : 1)
		newH=(dir=="down")? Math.min(maxH, newH) : Math.max(minH, newH)
		pcontent.style.height=newH+"px"
		pcontent._currentheight=newH
	}
	else{
		if (setting.pointerimage.enabled){
			setting.arrow.src=setting.pointerimage.src[(setting.dir=="down")? 1 : 0]
			setting.arrow.style.visibility="visible"
		}
		return
	}
	var thispanel=this
	setting.revealtimer=setTimeout(function(){thispanel.revealcontent()}, 10)
},

initpanel:function(){
	var setting=this.setting
	var pcontainer=setting.pcontainer=document.getElementById(setting.ids[0])
	var pcontent=setting.pcontent=document.getElementById(setting.ids[1])
	var tdiv=setting.tdiv=document.getElementById(setting.ids[2])
	pcontent.style.overflow="scroll"
	pcontent._actualheight=pcontent.scrollHeight
	setTimeout(function(){pcontent._actualheight=pcontent.scrollHeight}, 100)
	pcontent.style.overflow="hidden"
	pcontent._currentheight=(setting.dir=="down")? pcontent._actualheight : setting.stateconfig.initial
	var thispanel=this
	ddpanel.addEvent(tdiv, function(e){ //assign click behavior when toggle DIV tab is clicked on
		if (setting.animate.enabled)
			thispanel.togglepanelplus()
		else
			thispanel.togglepanel()
		if (e.preventDefault) e.preventDefault()
		return false
	}, "click")
	if (setting.pointerimage.enabled){
		var pointer1=new Image(), pointer2=new Image()
		pointer1.src=setting.pointerimage.src[0]
		pointer2.src=setting.pointerimage.src[1]
		setting.arrow=ddpanel.addpointer(tdiv.getElementsByTagName("span")[0], "pointerimage", setting.pointerimage.src[setting.dir=="down"? 1:0])
	}
	if (setting.closepanelonclick.enabled){ //assign click behavior when panel content is clicked on (links within panel or elements with class "closepanel"
			ddpanel.addEvent(pcontent, function(e){
				var target=e.srcElement || e.target
				if (/(^|\s+)closepanel($|\s+)/.test(target.className) || target.tagName=="A" || (target.parentNode && target.parentNode.tagName=="A")){
					thispanel.togglepanel("up")
				}
			}, "click")
	}
},

uninit:function(){
	var setting=this.setting
	if (setting.stateconfig.persiststate){
		ddpanel.setCookie(setting.ids[0], setting.dir)
	}
	for (prop in setting){
		setting[prop]=null
	}
}



} //end of ddpanel object


//initialize instance of DD Drop Down Panel:

var defaultpanel=new ddpanel({
	ids: ["mypanel", "mypanelcontent", "mypaneltab"], // id of main panel DIV, content DIV, and tab DIV
	stateconfig: {initial: "5px", persiststate: true}, // initial: initial reveal amount in pixels (ie: 5px)
	animate: {enabled: true, steps: 5}, //steps: number of animation steps. Int between 1-20. Smaller=faster.
	pointerimage: {enabled: true, src: ["images/arrow-down.gif", "images/arrow-up.gif"]},
	closepanelonclick: {enabled: true} // close panel when links or elements with CSS class="closepanel" within container is clicked on?
})



