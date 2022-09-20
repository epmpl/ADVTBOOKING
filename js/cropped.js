// JScript File
/*function getcropped()
{
    var temp1 = new Array();
    var temp2 = new Array();
    //var choice = confirm('Do you want to Crop the Image');
    //if(choice){
        obj = document.getElementById(currentid);
        if(obj==null){alert('No Element Found !');}
        else{
            src=obj.innerHTML;
            if(src!=""){
                temp1 = src.split("src=\"");
                temp2 = temp1[1].split("\"");
                var imgsrc = temp2[0];
                imgsrc=imgsrc.replace("file:///","");
                imgsrc=imgsrc.replace("%20"," ");
                document.getElementById('imagepath').value=imgsrc;
                mywin = window.open('crop.aspx?image='+imgsrc);
            }
            else alert('No picture available to Crop ?');
        }
     //}
    
     //('saveme.aspx','','left=300px,top=250px,height=25px,width=250px,scroll=no,status=off');     
}*/





////    var moz = ((document.all)? false : true);
////    var ie = ((document.all)? true : false);
////    
////    
////    function ImageBox(imgId) {      
////        var origX, origY;
////      
////      // I put this div over the image to remove drag behaviour 
////      // on image in mozilla.
////     // if(moz) {
////        var overLayer = document.createElement("div");
////        document.body.appendChild(overLayer);
////        var point = getPosition(document.getElementById(imgId));
////        var dim = getDimension(document.getElementById(imgId));      
////        overLayer.style.position = "absolute";
////        overLayer.style.left = point.left;
////        overLayer.style.top = point.top;
////        overLayer.style.width = dim.width;
////        overLayer.style.height = dim.height;
////        overLayer.style.border = "1px solid";
////     // }
////      
////      var dragDiv = document.createElement("div");
////      document.body.appendChild(dragDiv);                        
////      dragDiv.style.visibility = "hidden";
////      dragDiv.style.position = "absolute";
////      dragDiv.style.border = "1px dashed black";
////      dragDiv.style.width = "0px";
////      dragDiv.style.height = "0px";
////      dragDiv.style.zIndex = 3;
////      dragDiv.style.left = "20px";
////      dragDiv.style.top = "20px";      
////     
////      function mouseDown(evt) {
////        if(!evt) {
////          evt = event;
////        }
////        dragDiv.style.visibility = "visible";
////        dragDiv.style.left = evt.clientX;
////        dragDiv.style.top = evt.clientY;
////        dragDiv.style.width = "1px";
////        dragDiv.style.height = "1px";
////        origX = evt.clientX;
////        origY = evt.clientY;
////        addEventListener(document, "mousemove", mouseMove);
////        addEventListener(document, "mouseup", mouseUp); 
////        evt.cancelBubble = true;
////        return false;     
////      }
////      
////      if(ie) {
////        // Removes default drag behaviour on image
////        addEventListener(document.getElementById(imgId), "drag",function() {return false;});
////        // Adds my "drag" behaviour to the image
////        addEventListener(document.getElementById(imgId), "mousedown",mouseDown);
////      }
////      if(moz) {
////        addEventListener(overLayer, "mousedown", mouseDown);      
////      }

////      
////      function mouseMove(evt) {
////        if(!evt) {
////          evt = event;
////        }       
////        try{        
////            var newWidth = evt.clientX - origX;
////            var newHeight = evt.clientY - origY;
////            
////            // You can add lots and lots of checks and arithmetics here to
////            // to add possibility to go to "negative" widths, height, tops and lefts
////            // and also see to it so you don't drag outside the image
////            // I simply didn't have the energy, but i have;-->ajay
////            if(newWidth >document.getElementById('imagebox').width){
////                newWidth=document.getElementById('imagebox').width;
////            }
////            if(newHeight >document.getElementById('imagebox').height){
////                newHeight=document.getElementById('imagebox').height;
////            }
////            dragDiv.style.width = newWidth;
////            dragDiv.style.height = newHeight;
////            document.getElementById('top').value=dragDiv.style.top;
////            document.getElementById('left').value=dragDiv.style.left;
////            document.getElementById('heights').value=dragDiv.style.height;  
////            document.getElementById('widths').value=dragDiv.style.width;
////        }
////        catch(er){}
////            
////      }
////      
////      function mouseUp(evt) {        
////        removeEventListener(document, "mousemove", mouseMove);  
////        removeEventListener(document, "mouseup", mouseUp);
////      }     
////     
////      this.getX = function() {
////        return (parseInt(dragDiv.style.left) - parseInt(point.left)) +
////"px";
////      }
////      
////      this.getY = function() {
////        return (parseInt(dragDiv.style.top) - parseInt(point.top)) +
////"px";
////      }
////      
////      this.getWidth = function() {
////        return dragDiv.style.width;
////      }
////      
////      this.getHeight = function() {
////        return dragDiv.style.height;
////      }      
////    }
////    
////    function getPosition(elt) {
////      var point = new Object();      
////      // You might have to do some more advanced tricks here like
////      // looping through the offset parent until you get to the top
////      // and add the positions as you go up
////      point.left = elt.offsetLeft;
////      point.top = elt.offsetTop;
////      return point;
////    }
////    
////    function getDimension(elt) {
////      var dim = new Object();
////      dim.width = elt.offsetWidth;
////      dim.height = elt.offsetHeight;
//////        dim.width = "300";
//////        dim.height = 300;
////      return dim;
////    }
////    
////    function addEventListener(o, type, handler) {
////      if(ie) {
////        o.attachEvent("on" + type, handler);
////      }
////      else if(moz) {
////        o.addEventListener(type, handler, false);
////      }
////    }

////    function removeEventListener(o, type, handler) {
////      if(ie) {
////       o.detachEvent("on" + type, handler);
////      }
////      else if(moz) {
////        o.removeEventListener(type, handler, false);
////      }
////    }
////    function YourFunc()
////	{}

////function showResult() {
////    try{
////    
////        var str = "Left: " + box.getX() + "\n" +
////        "Top: " + box.getY() + "\n" +
////        "Width: " + box.getWidth() + "\n" + 
////        "Height: " + box.getHeight();
////	    var xpos=box.getX();
////	    var p = document.getElementById('sepath').value;
////	    xpos=xpos.replace("px","");
////	    var ypos=box.getY();
////	    ypos=ypos.replace("px","");
////	    var height=box.getHeight();
////	    height=height.replace("px","");
////	    var width=box.getWidth();
////	    width=width.replace("px","");
////	    var imgs = opener.document.getElementById('imagepath').value;
////	    var sp = document.getElementById('sepath').value;
////	    //document.getElementById('sepath').value = imgs;
////	    crop.drawImage(xpos,ypos,width,height,imgs,sp,call_value);//(box.getX());//,box.getY(),box.getWidth(),box.getHeight());
////  	    // var Shell = CreateObject("WScript.Shell")
////        // temp = Shell.ExpandEnvironmentStrings("%TEMP%");
////        //var paths= document.getElementById('gettemp').value + "//test.jpg";
////        //alert(paths);
////        //document.getElementById('preview').setAttribute('src',paths);
////        var sp1 = document.getElementById('sepath1').value;
////    }
////    catch(er){}

////    //document.getElementById('preview').setAttribute('src',sp1);
////    }
////    function call_value(res)
////    {

////        var ds=res.value;
////        var newval=ds.toLowerCase();
////        if(newval!=null)
////        {
////            var ds1 = newval.split("lexpress/");
////            var ab = document.getElementById('sepath2').value;
////            var ds2 = ab + ds1[1];
////            document.getElementById('preview').setAttribute('src',ds2);
////        }
////    else
////        {
////            alert("Please Make Selection on Image");
////        }
////    }
////  
////    function init() {
////      box = new ImageBox("imagebox");
////      
////    }
////    var box = null;
////    //var getimage = opener.document.getElementById('imagepath').value;
////  
////   function applyimg()
////   {
////   
////   var xx= document.getElementById('preview').src;
////   opener.document.getElementById('imagepath').value=xx;
////   opener.document.getElementById('applylink').disabled=false;
////   opener.document.getElementById('applylink').style.visibility='visible';
////   window.close();
////   }

    

    
    
  

/*LEXPRESS_OLD CODE**********************************************************/



 var moz = ((document.all)? false : true);
    var ie = ((document.all)? true : false);
   // var stmt="";
    
    function ImageBox(imgId) {  
       // alert("hello");    
        var origX, origY;
        
      
      // I put this div over the image to remove drag behaviour 
      // on image in mozilla.
     if(moz) {
     //alert("in mozilla");
     var point = getPosition(document.getElementById(imgId));
     var dim = getDimension(document.getElementById(imgId));
   
        //alert(point.left);
        //alert(dim.width);
     stmt='<Div id="overLayer" style=" position:absolute; top:'+point.top+'px; left:'+point.left+'px; width:'+dim.width+'px; height:'+dim.height+'px; border:1px dashed black;"></Div>';
    // alert(stmt);
      document.body.innerHTML+=stmt;
     //ank='<DIV id="'+currentid+'" onmouseup=javascript:up(); class=drag oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeydown=javascript:deleted(); onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;" onfocusout=javascript:lostfocus(); ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:getid(this); align=center name=" textBox"><STRONG  onkeypress="javascript:blockkeu1(event)">add&nbsp;to title here</STRONG></DIV>'
//        var overLayer = document.createElement("div");
//        document.body.appendChild(overLayer);
//        var point = getPosition(document.getElementById(imgId));
//        var dim = getDimension(document.getElementById(imgId));      
//        overLayer.style.position = "absolute";
//        overLayer.style.left = point.left;
//        overLayer.style.top = point.top;
//        overLayer.style.width = dim.width;
//        overLayer.style.height = dim.height;
//        overLayer.style.border = "1px solid";
      }
      else
      {
      var point = getPosition(document.getElementById(imgId));
      var dim = getDimension(document.getElementById(imgId));
      var dragDiv = document.createElement("div");
      document.body.appendChild(dragDiv);                        
      dragDiv.style.visibility = "hidden";
      dragDiv.style.position = "absolute";
      dragDiv.style.border = "1px dashed black";
      dragDiv.style.width = "0px";
      dragDiv.style.height = "0px";
      dragDiv.style.zIndex = 3;
      dragDiv.style.left = "20px";
      dragDiv.style.top = "20px";      
     }
      function mouseDown(evt) {
   //  alert("hello");
        if(!evt) {
          evt = event;
        }
        if(document.all)
        {
        dragDiv.style.visibility = "visible";
        dragDiv.style.left = evt.clientX;
        dragDiv.style.top = evt.clientY;
        dragDiv.style.width = "1px";
        dragDiv.style.height = "1px";
        origX = evt.clientX;
        origY = evt.clientY;
        addEventListener(document, "mousemove", mouseMove);
        addEventListener(document, "mouseup", mouseUp); 
        evt.cancelBubble = true;
        return false;     
        }
        else
        {
        //alert("hello1");
        //alert(evt.clientX);
        //alert(evt.clientY);
        document.getElementById('overLayer').style.visibility="visible";
        document.getElementById('overLayer').style.left=evt.clientX+"px";
        //alert(document.getElementById('overLayer').style.left);
        document.getElementById('overLayer').style.top=evt.clientY+"px";
        document.getElementById('overLayer').style.width = "1px";
        document.getElementById('overLayer').style.height = "1px";
        origX = parseInt(evt.clientX);
        origY = parseInt(evt.clientY);
        addEventListener(document, "mousemove", mouseMove);
        addEventListener(document, "mouseup", mouseUp); 
        evt.cancelBubble = true;
       // alert("bye");
        return false;  
        }
      }
      
      if(ie) {
        // Removes default drag behaviour on image
        addEventListener(document.getElementById(imgId), "drag",function() {return false;});
        // Adds my "drag" behaviour to the image
        addEventListener(document.getElementById(imgId), "mousedown",mouseDown);
      }
      if(moz) {
      //alert(document.getElementById('overLayer').style.position);
  //   addEventListener(document.getElementById(imgId), "drag",function() {return false;});
        addEventListener(document.getElementById('overLayer'), "mousedown", mouseDown);      
      }

      
      function mouseMove(evt) {
      //alert("mmo");
        if(!evt) {
          evt = event;
        }       
        try{ 
        if(ie)
        {       
            var newWidth = evt.clientX - origX;
            var newHeight = evt.clientY - origY;
            
            // You can add lots and lots of checks and arithmetics here to
            // to add possibility to go to "negative" widths, height, tops and lefts
            // and also see to it so you don't drag outside the image
            // I simply didn't have the energy, but i have;-->ajay
            if(newWidth >document.getElementById('imagebox').width){
                newWidth=document.getElementById('imagebox').width;
            }
            if(newHeight >document.getElementById('imagebox').height){
                newHeight=document.getElementById('imagebox').height;
            }
            dragDiv.style.width = newWidth;
            dragDiv.style.height = newHeight;
            document.getElementById('top').value=dragDiv.style.top;
            document.getElementById('left').value=dragDiv.style.left;
            document.getElementById('heights').value=dragDiv.style.height;  
            document.getElementById('widths').value=dragDiv.style.width;
        }
        else
        {
             var newWidth = parseInt(evt.clientX - origX);
            var newHeight = parseInt(evt.clientY - origY);
            
            // You can add lots and lots of checks and arithmetics here to
            // to add possibility to go to "negative" widths, height, tops and lefts
            // and also see to it so you don't drag outside the image
            // I simply didn't have the energy, but i have;-->ajay
            if(newWidth >document.getElementById('imagebox').width){
                newWidth=document.getElementById('imagebox').width;
            }
            if(newHeight >document.getElementById('imagebox').height){
                newHeight=document.getElementById('imagebox').height;
            }
            document.getElementById('overLayer').style.width = newWidth+"px";
            document.getElementById('overLayer').style.height = newHeight+"px";
            document.getElementById('top').value=document.getElementById('overLayer').style.top;
            document.getElementById('left').value=document.getElementById('overLayer').style.left;
            document.getElementById('heights').value=document.getElementById('overLayer').style.height;  
            document.getElementById('widths').value=document.getElementById('overLayer').style.width;
        
        }
        }
        catch(er){}
            
      }
      
      function mouseUp(evt) { 
          
        removeEventListener(document, "mousemove", mouseMove);  
        removeEventListener(document, "mouseup", mouseUp);
      }     
     
      this.getX = function() {
      if(ie)
      {
        return (parseInt(dragDiv.style.left) - parseInt(point.left)) +"px";
      }
      else
      {
      return (parseInt(document.getElementById('overLayer').style.left) - parseInt(point.left)) +"px";
      }
      }
      
      this.getY = function() {
      if(ie)
      {
        return (parseInt(dragDiv.style.top) - parseInt(point.top)) +"px";
      }
      else
      {
         return (parseInt(document.getElementById('overLayer').style.top) - parseInt(point.top)) +"px";
      }
      }
      this.getWidth = function()
       {
      if(ie)
      {
        return dragDiv.style.width;
      }
      else
      {
      return document.getElementById('overLayer').style.width;
        
      }
      }
      
      this.getHeight = function() {
      if(ie)
      {
        return dragDiv.style.height;
      }
      else
      {
        return document.getElementById('overLayer').style.height;
      }
      }      
    }
   /********************/ 
    function getPosition(elt) {
      var point = new Object();      
      // You might have to do some more advanced tricks here like
      // looping through the offset parent until you get to the top
      // and add the positions as you go up
      point.left = elt.offsetLeft;
      point.top = elt.offsetTop;
      return point;
    }
 /*************************/   
    function getDimension(elt)
     {
        var dim = new Object();
        dim.width = elt.offsetWidth;
        dim.height = elt.offsetHeight;
        //dim.width = "300";
        //dim.height = 300;
        return dim;
   }
 /****************************/   
    function addEventListener(o, type, handler) {
      if(ie) {
        o.attachEvent("on" + type, handler);
      }
      else if(moz) {
        o.addEventListener(type, handler, false);
      }
    }
/*************************/
    function removeEventListener(o, type, handler) {
      if(ie) {
       o.detachEvent("on" + type, handler);
      }
      else if(moz) {
        o.removeEventListener(type, handler, false);
      }
    }
    /*********************/
    function YourFunc()
	{}
/**********************/
function showResult()
 {
    try
    {
     if(ie)
       { 
        //box = new ImageBox("imagebox");
        var str = "Left: " + box.getX() + "\n" +
        "Top: " + box.getY() + "\n" +
        "Width: " + box.getWidth() + "\n" + 
        "Height: " + box.getHeight();
	    var xpos=box.getX();
	    var p = document.getElementById('sepath').value;
	    xpos=xpos.replace("px","");
	    var ypos=box.getY();
	    ypos=ypos.replace("px","");
	    var height=box.getHeight();
	    height=height.replace("px","");
	    var width=box.getWidth();
	    width=width.replace("px","");
	    var imgs = opener.document.getElementById('imagepath').value;
	    var sp = document.getElementById('sepath').value;
	    //document.getElementById('sepath').value = imgs;
	    crop.drawImage(xpos,ypos,width,height,imgs,sp,call_value);
	    //_Default.drawImage(xpos,ypos,width,height,imgs,sp,call_value);//(box.getX());//,box.getY(),box.getWidth(),box.getHeight());
  	    // var Shell = CreateObject("WScript.Shell")
        // temp = Shell.ExpandEnvironmentStrings("%TEMP%");
        //var paths= document.getElementById('gettemp').value + "//test.jpg";
        //alert(paths);
        //document.getElementById('preview').setAttribute('src',paths);
        var sp1 = document.getElementById('sepath1').value;
        }
        else
        {
          box = new ImageBox("imagebox");
          var str = "Left: " + box.getX() + "\n" +
          "Top: " + box.getY() + "\n" +
          "Width: " + box.getWidth() + "\n" + 
          "Height: " + box.getHeight();
          var xpos=box.getX();
	      var p = document.getElementById('sepath').value;
	      xpos=xpos.replace("px","");
	      var ypos=box.getY();
	      ypos=ypos.replace("px","");
	      var height=box.getHeight();
	      height=height.replace("px","");
	      var width=box.getWidth();
	      width=width.replace("px","");
	      var imgs = opener.document.getElementById('imagepath').value;
	      var sp = document.getElementById('sepath').value;
	      crop.drawImage(xpos,ypos,width,height,imgs,sp,call_value);
	      //crop.drawImage(xpos,ypos,width,height,imgs,sp,call_value);//(box.getX());//,box.getY(),box.getWidth(),box.getHeight());
	      //alert(ds4);
  	      // var Shell = CreateObject("WScript.Shell")
          // temp = Shell.ExpandEnvironmentStrings("%TEMP%");
          //var paths= document.getElementById('gettemp').value + "//test.jpg";
          //alert(paths);
         //document.getElementById('preview').setAttribute('src',paths);
         var sp1 = document.getElementById('sepath1').value;
         
        }
    }
    catch(er){}
   }
    
    
    /***********************/
    function call_value(res)
    {
    if(document.all)
    {
       var myurl=document.URLUnencoded.split("?")[0].split("/");
       var length=myurl.length;
       var myfinal="";
       for(i=0;i<length-1;i++)
         {
           myfinal+=myurl[i]+"/";
         }
     
    var newres=res.value.split("images1")[1];
    newres="images1"+newres;
      var ds=res.value;
    //alert(ds);
    // var newval=ds.toLowerCase();
    //  if(newval!=null)
    // {
          // var ds1 = newval.split("lexpress1/");
          //var ab = document.getElementById('sepath2').value;
          var ds2 =myfinal+newres
          document.getElementById('preview').setAttribute('src',ds2);
          //document.getElementById('preview').src=ds2.replace("/","\\");
       // }
     // else
       // {
          //alert("Please Make Selection on Image");
       // }
     //}  
   }
   else
   {
      var myurl=document.URL.split("?")[0].split("/");
       var length=myurl.length;
       var myfinal="";
    for(i=0;i<length-1;i++)
     {
       myfinal+=myurl[i]+"/";
     }
    var newres=res.value.split("images1")[1];
    newres="images1"+newres;
    var ds=res.value;
    //alert(ds);
    // var newval=ds.toLowerCase();
    //  if(newval!=null)
    // {
          // var ds1 = newval.split("lexpress1/");
          //var ab = document.getElementById('sepath2').value;
          var ds2 =myfinal+newres
          document.getElementById('preview').setAttribute('src',ds2);
       // }
     // else
       // {
          //alert("Please Make Selection on Image");
       // }
   
     }
   } 
   
  /*******************/
    function init() {
      box = new ImageBox("imagebox");
      
    }
    /**************************/
    var box = null;
    //var getimage = opener.document.getElementById('imagepath').value;
  
  
  /***************************/
   function applyimg()
   {
   
   var xx= document.getElementById('preview').src;
   opener.document.getElementById('imagepath').value=xx;
   opener.document.getElementById('applylink').disabled=false;
   opener.document.getElementById('applylink').style.visibility='visible';
   //alert('ajay');
   window.close();
   }

    
