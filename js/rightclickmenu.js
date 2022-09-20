
var objselected = null;

function context_menu(obj,ev){
if(document.all)
{
    //alert("hi");
    if(obj.style.backgroundImage=="url(icons/logo.jpg)")
    {document.getElementById('getimg').style.display="block"; }
    else{document.getElementById('getimg').style.display="none";}
	objselected = obj;
	var objname=(objselected.id).split('~');
	//alert(objname[0]);
	//alert(objname[1]);
	if(objname[1]=="img")
	{
	
	}
	//alert(obj.id);
	//alert(event.clientX);
    //var hght=objselected.style.height;
    //var wdth=objselected.style.width;
    //alert(hght);
    //aler(wdth);
    //var leftc=objselected.style.left;
    //var topc=objselected.style.top;
    //leftc=leftc.replace("px","");
    //topc=topc.replace("px","");
	
    var leftc=parseInt(event.clientX);
    var topc=parseInt(event.clientY);
	if(topc>250 && leftc<500 )
	{
	    document.getElementById('imgToolMenu').style.left = event.clientX;
	    document.getElementById('imgToolMenu').style.top = event.clientY-130;
	    
	}
	else if(topc<250 && leftc>500 )
	{
	     document.getElementById('imgToolMenu').style.left = event.clientX-100;
	     document.getElementById('imgToolMenu').style.top = event.clientY;
	    
	}
	else if(topc>250 && leftc>500 )
	{
	    document.getElementById('imgToolMenu').style.left = event.clientX-100;
	    document.getElementById('imgToolMenu').style.top = event.clientY-130;
	    
	}
	else
	{
	    document.getElementById('imgToolMenu').style.left = event.clientX;
	    //alert(ev.clientX);
	    document.getElementById('imgToolMenu').style.top = event.clientY;
	}
	document.getElementById('imgToolMenu').style.visibility = 'visible';
	document.getElementById('imgToolMenu').style.backgroundColor='ButtonFace';
}
else
{
  if(obj.style.backgroundImage=="url(icons/logo.jpg)")
   {
    document.getElementById('getimg').style.display="block"; }
    else{document.getElementById('getimg').style.display="none";}
	objselected = obj;
	var objname=(objselected.id).split('~');
	//alert(objname[0]);
	//alert(objname[1]);
	if(objname[1]=="img")
	{
	document.getElementById('rightcut').style.display="none";
	document.getElementById('rightcopy').style.display="none";
	document.getElementById('rightpaste').style.display="none";
	document.getElementById('getimg').style.display="none";
	//document.getElementById('getimg').style.display="none";
	//alert("hi");
	}
	else
	{
	document.getElementById('rightcut').style.display="block";
	document.getElementById('rightcopy').style.display="block";
	document.getElementById('rightpaste').style.display="block";
	//document.getElementById('getimg').style.display="block";
	
	}
	if(objname[1]=="picture")
	{
	   //alert(document.getElementById(objselected.id+"pic").value);
	   if(document.getElementById(objselected.id+"pic")!=null)
	   {
	        //alert("hello")
	        document.getElementById(objselected.id+"pic").onmousedown=ignoreClick1;
	        document.getElementById(objselected.id+"pic").onmouseup=ignoreClick1;
	        document.getElementById(objselected.id+"pic").onmouseout=ignoreClick1;
	    
	   }
	}
		//alert(objselected.id);
        //	var hght=objselected.style.height;
        //	var wdth=objselected.style.width;
        //	hght=hght.replace("px","");
        //	wdth=wdth.replace("px","");
        //	//alert(hght);
        //	//alert(wdth);
        //	var leftc=objselected.style.left;
        //	var topc=objselected.style.top;
        //	leftc=leftc.replace("px","");
        //	topc=topc.replace("px","");
        //	leftc=parseInt(leftc)+parseInt(wdth);
        //    topc=parseInt(topc)+parseInt(hght);	
    var leftc=parseInt(ev.clientX);
    var topc=parseInt(ev.clientY);
	//alert(leftc);
	
	//alert(topc);
	
	if(topc>250 && leftc<500 )
	{
	document.getElementById('imgToolMenu').style.offsetLeft = ev.clientX;
	
	document.getElementById('imgToolMenu').style.offsetTop =  parseInt(ev.clientY-130);
	document.getElementById('imgToolMenu').style.left = document.getElementById('imgToolMenu').style.offsetLeft+"px" ;
	document.getElementById('imgToolMenu').style.top =document.getElementById('imgToolMenu').style.offsetTop+"px"; 
	
	}
	else if(topc<250 && leftc>500 )
	{
	    document.getElementById('imgToolMenu').style.offsetLeft = parseInt(ev.clientX-100);
	    document.getElementById('imgToolMenu').style.offsetTop = ev.clientY;
	    document.getElementById('imgToolMenu').style.left = document.getElementById('imgToolMenu').style.offsetLeft+"px" ;
	    document.getElementById('imgToolMenu').style.top =document.getElementById('imgToolMenu').style.offsetTop+"px"; 
	    
	}
	else if(topc>250 && leftc>500 )
	{
	    document.getElementById('imgToolMenu').style.offsetLeft = parseInt(ev.clientX-100);
	    document.getElementById('imgToolMenu').style.offsetTop = parseInt(ev.clientY-130);
	    document.getElementById('imgToolMenu').style.left = document.getElementById('imgToolMenu').style.offsetLeft+"px" ;
	    document.getElementById('imgToolMenu').style.top =document.getElementById('imgToolMenu').style.offsetTop+"px"; 
	}
	
	else
	{
	document.getElementById('imgToolMenu').style.offsetLeft = ev.clientX;
	
	document.getElementById('imgToolMenu').style.offsetTop = ev.clientY;
	document.getElementById('imgToolMenu').style.left = document.getElementById('imgToolMenu').style.offsetLeft+"px" ;
	document.getElementById('imgToolMenu').style.top =document.getElementById('imgToolMenu').style.offsetTop+"px"; 
	}
	
	document.getElementById('imgToolMenu').style.visibility = 'visible';
	document.getElementById('imgToolMenu').style.backgroundColor='ButtonFace';
	//alert(objselected.id);
	//alert("hi");
       
}
}
function ignoreClick1()
{
return false;
}
      

function delete_selected(ev)
{
 //alert("delete_selected");
if(document.all)
{
	if(objselected.id!="outer")
	{
	    //alert("delete_selected");
		var r = document.body.createControlRange();
		r.add(objselected);
		r.select();
		objselected = null;
		//alert(document.getElementById('textdialog').style.display)
        document.getElementById('textdialog').style.display='none';
        document.getElementById('linedialog').style.display='none';
        document.getElementById('picdialog').style.display='none';
        //document.getElementById('fonttoolbar_fontsizef').disabled=true;
        //document.getElementById('fonttoolbar_fontsizef').visibility="false";
        document.getElementById('fonttoolbar_alignment').disabled=true;
        document.getElementById('fonttoolbar_fnttools').disabled=true;
		document.getElementById('imgToolMenu').style.visibility = 'hidden';
		//document.getElementById('deletea').disabled="true";
	}
	document.getElementById('imgToolMenu').style.visibility = 'hidden';
	document.selection.clear();
}
else
    {
        document.getElementById('imgToolMenu').style.visibility = 'hidden';
        deleted1(ev);
    }
}

function cut_selected()
 {
  if(document.all)
  {
	if(objselected.id!="outer")
	{
		var r = document.body.createControlRange();
		r.add(objselected);
		r.select();
	    CutToClipboard();
		objselected = null;
        //document.getElementById('getimg').style.display="none";
		document.getElementById('imgToolMenu').style.visibility = 'hidden';
	}
	document.getElementById('imgToolMenu').style.visibility = 'hidden';
	//document.selection.clear();
}
else
{
        document.getElementById('imgToolMenu').style.visibility = 'hidden';
        alert("Mozilla does not support this feature");
}
}


function copy_selected()
{
if(document.all)
{
	if(objselected.id!="outer")
	{
       var r = document.body.createControlRange();
       r.add(objselected);
	   r.select();
	   CopyToClipboard();
	   objselected = null;
       //document.getElementById('getimg').style.display="none";
	   document.getElementById('imgToolMenu').style.visibility = 'hidden';
	}
	document.getElementById('imgToolMenu').style.visibility = 'hidden';
	//document.selection.clear();
}

else
  {
  if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
          document.getElementById('imgToolMenu').style.visibility = 'hidden';
          alert("Mozilla does not support this feature");
       }
}   }


function paste_selected()
{
  if(document.all)
  {
    objselected = editordiv;
    //objselected = document.getElementById('myhdnval').value
	if(objselected)
	 {
		var r = document.body.createControlRange();
		r.add(objselected);
		r.select();
	    PasteFromClipboard();
		objselected = null;
        //document.getElementById('getimg').style.display="none";
		document.getElementById('imgToolMenu').style.visibility = 'hidden';
	  }
	  //document.selection.clear();
  }

else
    {
    if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
          document.getElementById('imgToolMenu').style.visibility = 'hidden';
          alert("Mozilla does not support this feature");
   
       }
    }
}


/**************************/
function get_image()
{
  if(document.all)
  {
	if(objselected)
	{
		var r = document.body.createControlRange();
		r.add(objselected);
		r.select();
	    showupload();
	    document.getElementById('getimg').style.display="none";
		objselected = null;
		document.getElementById('imgToolMenu').style.visibility = 'hidden';
	}
 }
 else
   {
     showupload(); 
     document.getElementById('imgToolMenu').style.visibility = 'hidden';
   }

}


var ie5=document.all&&document.getElementById
var ns6=document.getElementById&&!document.all
var display_url=0

function highlight(e){
var firingobj=ie5? event.srcElement : e.target
if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems"){
if (ns6&&firingobj.parentNode.className=="menuitems") firingobj=firingobj.parentNode //up one node
firingobj.style.backgroundColor="highlight"
firingobj.style.color="white"
if (display_url==1)
window.status=event.srcElement.url
}
}

function lowlight(e){
var firingobj=ie5? event.srcElement : e.target
if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems"){
if (ns6&&firingobj.parentNode.className=="menuitems") firingobj=firingobj.parentNode //up one node
firingobj.style.backgroundColor=""
firingobj.style.color="black"
window.status=''
}
}
//function hidemenuie5(e){
//document.getElementById('imgToolMenu').style.visibility="hidden"
//}

document.onclick=document.getElementById('imgToolMenu').style.visibility="hidden"

/************************/


function getAbsoluteDivs()
{
if(document.all)
{
    var arr = new Array();
    var all_divs = new Array();
    var inner_html = document.getElementById('editordiv').innerHTML;
    all_divs = inner_html.split("<DIV ");
    
    //document.body.getElementsByTagName("DIV");
    //var j = 0;

    //for (i = 0; i < all_divs.length; i++)
      //  if (all_divs[i].style.position=='absolute')
        //{
          //  arr[j] = all_divs.item(i);
            //j++;
        //}

    return all_divs;
}
else
{
      
    var arr = new Array();
    var all_divs = new Array();
    var inner_html = document.getElementById('editordiv').childNodes[0].innerHTML;
    all_divs = inner_html.split("<div ");
    
    //document.body.getElementsByTagName("DIV");
    //var j = 0;

    //for (i = 0; i < all_divs.length; i++)
      //  if (all_divs[i].style.position=='absolute')
        //{
          //  arr[j] = all_divs.item(i);
            //j++;
        //}

    return all_divs;
}

}
function sendToBack()
{
if(document.all)
{
    if (!document.getElementById ||!document.getElementsByTagName)
        return;
    
    var obj = objselected;
    //alert(obj.id);
	 var length=document.getElementById('editordiv').children.length;
    for(i=0;i<length;i++)
    {
        if(document.getElementById('editordiv').childNodes[i].id!=obj.id)
        {
         if(document.getElementById('editordiv').childNodes[i].id!="outer")
            {
            document.getElementById('editordiv').childNodes[i].style.zIndex=2;
            }
        }
    }
    var divs = getAbsoluteDivs();
    var min_index = 999999;
    var cur_index;

    if (divs.length < 2)
        return;

    // Compute the minimal z-index of
    // other absolute-positioned divs
    for (i = 1; i <=divs.length; i++)
    {
        item = "<DIV " + divs[i];
        if (item == obj)
            continue;

        if (obj.style.zIndex == '')
        {
            min_index = 0;
            break;
        }

        cur_index = parseInt(obj.style.zIndex);
        if (min_index > cur_index)
        {
            min_index = cur_index;
        }

    }

    if (min_index > parseInt(obj.style.zIndex))
    {
        return;
    }

    obj.style.zIndex = 1;

    if (min_index > 1)
        return;

    var add = min_index == 0 ? 2 : 1;

    for (i = 0; i < divs.length; i++)
    {
        var item = divs[i];
        if (item == obj)
            continue;

        obj.style.zIndex += add;
    }
	 obj.style.zIndex =1;
    imgToolMenu.style.visibility = 'hidden';
}
else
{
//alert("send")
    if (!document.getElementById ||!document.getElementsByTagName)
        return;
    
    var obj = objselected;
    //alert(obj.id);
          //alert(obj.style.zIndex.value);
    var length=parseInt(document.getElementById('editordiv').childNodes[0].childNodes.length);
    //alert(length);
    for(i=0;i<length;i++)
    {
    //alert(document.getElementById('editordiv').childNodes[0].childNodes[i].id);
        if(document.getElementById('editordiv').childNodes[0].childNodes[i].id!=obj.id)
        {
        //alert("in loop2");
         
          //  alert("hello");
            //alert(document.getElementById('editordiv').childNodes[0].childNodes[i].style.zIndex)
            document.getElementById('editordiv').childNodes[0].childNodes[i].style.zIndex=2;
            
        }
    }
	 
    var divs = getAbsoluteDivs();
    var min_index = 999999;
    var cur_index;

    if (divs.length < 2)
        return;

    // Compute the minimal z-index of
    // other absolute-positioned divs
    for (i = 1; i <=divs.length; i++)
    {
        item = "<DIV " + divs[i];
        if (item == obj)
            continue;

        if (obj.style.zIndex == '')
        {
             document.getElementById('imgToolMenu').style.visibility = 'hidden';
            min_index = 0;
            break;
        }

        cur_index = parseInt(obj.style.zIndex);
        if (min_index > cur_index)
        {
            min_index = cur_index;
        }

    }

    if (min_index > parseInt(obj.style.zIndex))
    {
         document.getElementById('imgToolMenu').style.visibility = 'hidden';
        return;
       
    }

    obj.style.zIndex = 1;

    if (min_index > 1)
    {
         document.getElementById('imgToolMenu').style.visibility = 'hidden';
        return;
       
    }

    var add = min_index == 0 ? 2 : 1;

    for (i = 0; i < divs.length; i++)
    {
        var item = divs[i];
        if (item == obj)
            continue;

        obj.style.zIndex += add;
    }
	 obj.style.zIndex =1;
	  document.getElementById('imgToolMenu').style.visibility = 'hidden';
   
}
 document.getElementById('imgToolMenu').style.visibility = 'hidden';
}
function bringToFront()
{
if(document.all)
{   
    if (!document.getElementById ||!document.getElementsByTagName)
        return;

    var obj = objselected;
        //alert(obj.id);
        //alert(obj.style.zIndex.value);
 var length=document.getElementById('editordiv').children.length;
    for(i=0;i<length;i++)
    {
        if(document.getElementById('editordiv').childNodes[i].id!=obj.id)
        {
         if(document.getElementById('editordiv').childNodes[i].id!="outer")
            {
            document.getElementById('editordiv').childNodes[i].style.zIndex=1;
            }
        }
    }
    var divs = getAbsoluteDivs();
    var max_index = 0;
    var cur_index;

    // Compute the maximal z-index of
    // other absolute-positioned divs
    for (i = 2; i <= divs.length; i++)
    {
        //alert(item);
        item2 = "<DIV " + divs[i];
        //zindex=item2.match("z-Index:");
        
        
        if (item2 == obj)// ||item2.style.zIndex:300 == '')
            continue;

        cur_index = parseInt(obj.style.zIndex);
        if (max_index < cur_index)
        {
            max_index = cur_index;
        }
    }

    obj.style.zIndex =2;
    document.getElementById('imgToolMenu').style.visibility = 'hidden';
}
else
{
//alert("bring")
     if (!document.getElementById ||!document.getElementsByTagName)
        return;

    var obj = objselected;
        //alert(obj.id);
        //alert(obj.style.zIndex.value);
    var length=parseInt(document.getElementById('editordiv').childNodes[0].childNodes.length);
    //alert(length);
    for(i=0;i<length;i++)
    {
    //alert(document.getElementById('editordiv').childNodes[0].childNodes[i].id);
        if(document.getElementById('editordiv').childNodes[0].childNodes[i].id!=obj.id)
        {
        //alert("in loop2");
         
          //  alert("hello");
            //alert(document.getElementById('editordiv').childNodes[0].childNodes[i].style.zIndex)
            document.getElementById('editordiv').childNodes[0].childNodes[i].style.zIndex=1;
            
        }
    }
    var divs = getAbsoluteDivs();
    var max_index = 0;
    var cur_index;

    // Compute the maximal z-index of
    // other absolute-positioned divs
    for (i = 2; i <= divs.length; i++)
    {
        //alert(item);
        item2 = "<DIV " + divs[i];
        //zindex=item2.match("z-Index:");
        
        
        if (item2 == obj)// ||item2.style.zIndex:300 == '')
            continue;

        cur_index = parseInt(obj.style.zIndex);
        if (max_index < cur_index)
        {
            max_index = cur_index;
        }
    }

    obj.style.zIndex =2;
    document.getElementById('imgToolMenu').style.visibility = 'hidden';

}

}