function duceapp_gvslider(elem){var items=elem.getElementsByTagName('div'),max=items.length-1,animating=false,currentElem,nextElem;var time=Date.now||function(){return+new Date};return{start:function(){if(animating){return}animating=true;var els=elem.getElementsByTagName('div');currentElem=els[0];nextElem=els[1];if(!nextElem.fn){nextElem.fn=new morph(nextElem,{duration:500,onComplete:function(){elem.appendChild(currentElem);currentElem.style.zIndex=1;animating=false}},'opacity')}nextElem.fn.set({opacity:0});nextElem.style.zIndex=3;elem.insertBefore(nextElem,elem.firstChild);currentElem.style.zIndex=2;nextElem.fn.stop();nextElem.fn.start(1)},itemsNum:items&&items.length};function getStyle(j,t){if(j.currentStyle){var a=j.currentStyle[t]}else{var a=document.defaultView.getComputedStyle(j,null)[t]}if(/(margin|padding|width|height)/i.test(t)||/^(top|right|bottom|left)$/i.test(t)){a=parseInt(a),a=isNaN(a)?0:a}if(/^(opacity)$/i.test(t)){a=parseFloat(a),a=isNaN(a)?0:a}return a}function morph(obj,option,prop){var o={options:{fps:300,duration:300},prop:null,element:null,hash:{'opacity':0},$chain:[],chain:function(){for(var b=0,c=arguments.length;b<c;b++){this.$chain.push(arguments[b])}return this},callChain:function(){return this.$chain.length>0?this.$chain.shift().apply(this,arguments):!1},prepare:function(a,b){if(a=='opacity'){this.element.opacity=b;this.element.style[a]=b;this.element.style.filter='alpha(opacity='+(b*100)+')';this.element.style.display=b<=0?'none':'';this.element.style.visibility=b<=0?'hidden':'visible'}else{this.element.style[a]=b+'px'}this.hash[a]=b},step:function(){var a=time();if(a<this.time+this.options.duration)this.set(this.compute(this.from,this.to,this.transition((a-this.time)/this.options.duration)));else{this.set(this.compute(this.from,this.to,1));this.complete()}},set:function(d){if(this.prop=='scroll'){this.element.scrollLeft=d['x'];this.element.scrollTop=d['y'];return}for(var i in d)this.prepare(i,d[i])},compute:function(a,b,c){var d={},e;for(e in a){d[e]=(b[e]-a[e])*c+a[e]}return d},start:function(a,j){var b={},c={},d;if(typeof a!='object'){if(typeof this.prop!='string'||(this.prop!='opacity'&&typeof j=='undefined')){return this.stop()}var e={};if(this.prop=='opacity'&&typeof j=='undefined'){j=a;a=getStyle(this.element,'opacity')}if(this.prop=='scroll'){e['x']=[this.element.scrollLeft,a];e['y']=[this.element.scrollTop,j]}else{e[this.prop]=[a,j]}a=e}for(d in a){if(this.prop!='scroll'){this.prepare(d,a[d][0])}b[d]=a[d][0];c[d]=a[d][1]}this.time=0;this.from=b;this.to=c;this.transition=function(i){return.5-Math.cos(Math.PI*i)/2};this.startTimer();return this},stop:function(){this.stopTimer();return this},complete:function(){if(this.stopTimer())this.callChain();if(typeof this.options['onComplete']=='function'){this.options['onComplete'].call(this)}return this},stopTimer:function(){if(!this.timer)return false;this.time=time()-this.time;this.timer=clearInterval(this.timer);return true},startTimer:function(){if(this.timer)return false;var f=this;this.time=time()-this.time;this.timer=setInterval(function(){f.step()},Math.round(1E3/this.options.fps));return true}};o.element=typeof obj=='object'?obj:$(obj);o.prop=prop||null;if(option){for(var i in option)o.options[i]=option[i]}return this.prototype=o}}