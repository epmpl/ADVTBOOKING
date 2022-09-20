// JScript File

 var dragobject={
        z: 0, x: 0, y: 0, offsetx : null, offsety : null, targetobj : null , dragapproved : 0,
        initialize:function()
        {
             document.onmousedown=this.drag
             document.onmouseup=function()
             { 
                this.dragapproved=0
             }
        },
                    drag:function(e)
                    {    
                        var evtobj=window.event? window.event  : e
                        this.targetobj=window.event? event.srcElement : e.target
                      // this.targetobj=window.event.srcElement
                        if (this.targetobj.className=="drag"){
                            this.dragapproved=1
                            if (isNaN(parseInt(this.targetobj.style.left)))
                            {
                                this.targetobj.style.left=0
                            }
                            if (isNaN(parseInt(this.targetobj.style.top)))
                            {
                                this.targetobj.style.top=0
                            }
                            
                            
                            this.offsetx=parseInt(this.targetobj.style.left)
                            this.offsety=parseInt(this.targetobj.style.top)
                            this.x=evtobj.clientX
                            this.y=evtobj.clientY
                            if (evtobj.preventDefault)
                            evtobj.preventDefault()
                          
                           //if(this.targetobj.this.offsetx > parseInt(document.getElementById('Panel1').style.width))
                              // document.getElementById('Panel1').scrollLeft=this.offsetx+evtobj.clientX-this.x;
                            document.onmousemove=dragobject.moveit
                           // window.scrollBy(this.x,this.y)
                       
                         //document.ondblclick=dragobject.moveit
                           }                          
                         
                        },       
                        moveit:function(e){
                            var evtobj=window.event? window.event : e
                            
                            if (this.dragapproved==1){
                               
                                this.targetobj.style.left=this.offsetx+evtobj.clientX-this.x+"px"
                                this.targetobj.style.top=this.offsety+evtobj.clientY-this.y+"px"
                                //document.getElementById('Panel1').scrollLeft=this.offsetx+evtobj.clientX-this.x;
                                     return false
                                }
                            }
                          
                          
                    }
                    dragobject.initialize();
                    
                    
                    
  function mclkpos()
  {
   var evtobj=window.event? window.event : e
  // this.x=evtobj.clientX
 //  alert(evtobj.clientX);
  // this.y=evtobj.clientY
  // alert(evtobj.clientY);
  
  }
                    
       