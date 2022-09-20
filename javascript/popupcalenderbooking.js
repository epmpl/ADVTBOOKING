
//for double click

var browser=navigator.appName;

var dec=0;
var dcTime=250;    // doubleclick time
 var dcDelay=100;   // no clicks after doubleclick
 var dcAt=0;        // time of doubleclick
 var savEvent=null; // save Event for handling doClick().
 var savEvtTime=0;  // save time of click event.
 var savTO=null;    // handle of click setTimeOut
 var tempdate; 
//-----------------------------------------------------------------
var caldate1 = new Array();
var caldatemonth1 = new Array()
var caldateyear1 = new Array()
var caldatelength = 0;
var caldate = new Array();
var caldatemonth = new Array()
var caldateyear = new Array()
var name="";
var checkflag="0";

var gridItemCount=0;
var calselect = new Array()
var packagename = "";
var cali = 0;

	var	fixedX = -1;
	var	fixedY = -1;
	var globalid;
	
	/*
	function displaycoordIE(){
		fixedX = event.clientX - 200;
		fixedY = event.clientY;
	}
	
	
	document.onmousemove=displaycoordIE
	var	fixedX = document.onmousemove.clientX;			//Ajitabh :  x position (-1 if to appear below control)
	var	fixedY = document.onmousemove.clientY;			//Ajitabh :  y position (-1 if to appear below control)
	*/
	
	
	
	var startAt = 1			// 0 - sunday ; 1 - monday
	var showWeekDecimal = 1	// 0 - don't show; 1 - show
	var showToday = 1		// 0 - don't show; 1 - show
	var imgDir = "images/"			// directory for images ... e.g. var imgDir="/img/"

	var gotoString = "Go To Current Month"
	var todayString = "Today is"
	var weekString = "Wk"
	var scrollLeftMessage = "Click to scroll to previous month. Hold mouse button to scroll automatically."
	var scrollRightMessage = "Click to scroll to next month. Hold mouse button to scroll automatically."
	var selectMonthMessage = "Click to select a month."
	var selectYearMessage = "Click to select a year."
	var selectDateMessage = "Select [date] as date." // do not replace [date], it will be replaced by date.

	var	crossobj, crossMonthObj, crossYearObj, monthSelected, yearSelected, dateSelected, omonthSelected, oyearSelected, odateSelected, monthConstructed, yearConstructed, intervalID1, intervalID2, timeoutID1, timeoutID2, ctlToPlaceValue, ctlNow, dateFormat, nStartingYear

	var	bPageLoaded=false
	var	ie=document.all
	var	dom=document.getElementById

	var	ns4=document.layers
	var	today =	new	Date()
	var	dateNow	 = today.getDate()
	var	monthNow = today.getMonth()
	var	yearNow	 = today.getYear()
	var	imgsrc = new Array("drop1.gif","drop2.gif","left1.gif","left2.gif","right1.gif","right2.gif")
	var	img	= new Array()

	var bShow = false;
    function doClick(which) {
   // preempt if DC occurred after original click.
     if (savEvtTime - dcAt <= 0) {
        
        return false;
      }
     
     closeCalendar1();

    }
    
     function arrangeArrayItems()
    {
     caldate=null;
	caldate=new Array();
	caldatemonth=null;
	caldatemonth=new Array();
	caldateyear=null;
	caldateyear=new Array();
	
	if(document.getElementById('hiddensavemod').value!="0")
	{
	var len="bookdiv";
	document.getElementById("hiddenrowcount").value=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1
	    if(document.getElementById('hiddeninsertion').value!="")
        {
          
            gridItemCount=parseInt(document.getElementById(len).getElementsByTagName('table')[0].rows.length-1)/parseInt(document.getElementById('txtinsertion').value);
        cali=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
        
        }
               noofinsert=parseInt(gridItemCount) * parseInt(document.getElementById('txtinsertion').value);
    }
    else
    {
                noofinsert=parseInt(gridItemCount) * parseInt(document.getElementById('txtinsertion').value);
    }
	        var tot=parseInt(noofinsert) //* parseInt(document.getElementById('txtinsertion').value)
	       // alert(noofinsert);
		//	alert(document.getElementById('txtinsertion').value);
			//alert(document.getElementById('hiddendateformat').value);
			var i1=0;
			var j1=0;
			inc=parseInt(tot)/parseInt(document.getElementById('txtinsertion').value)
			var val="";
			var k1=0;
			while(i1<tot)
			{
			    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
			    {
			    
			        //if(document.getElementById("Text"+k1)==null)
			        while(document.getElementById("Text"+k1)==null && i1<tot)
			        {
			         k1=k1 + inc;
			         
			        }
			        if(i1<tot)
			        {
			        break;
			        }
			       
			        val=document.getElementById("Text"+k1).value;
			        if(val!="")
			        {
			            calselect=val.split("/");
			            caldate[j1]=calselect[1];
			            caldatemonth[j1]=calselect[0];
			            caldateyear[j1]=calselect[2];
			           // alert(calselect[0]);
			            //alert(calselect[1]);
			            //alert(calselect[2]);
			        }
			    }
			    i1=i1 + inc;
			    k1=k1 + inc;
			    j1=j1 + 1;
			}
		
    }
    
     function doDoubleClick(which) {
     
     if(name=="txtdummydate")
     {
   var d = new Date();
   dcAt = d.getTime();
   if (savTO != null) {
     clearTimeout( savTO );          // Clear pending Click  
     savTO = null;
   }
  // alert("doDoubleClick");
   arrangeArrayItems();
   
   caldate.remove(dateSelected);

 
      insertval=parseInt(insertval)-1;
   constructCalendar();
   
   //----------------------
   var i=0;
   var k=0;
   var j=0;
   while(i<document.getElementById("hiddenrowcount").value)
   {
    if(i%gridItemCount==0)
    {
        k = k+1;
    }
    
    while(document.getElementById("ins"+j)==undefined)
    {
        j=j+1;
    }
    
    if(document.getElementById("ins"+j)!=undefined)
    {
   // alert(document.getElementById("ins"+j).value);
    document.getElementById("ins"+j).innerText=k;
    }
    i=i+1;
    j=j+1;
   }
   }
 }
 
Array.prototype.remove=function(s){
var i=0;
var j=0;
//caldate.length=caldate.length-dec;
//caldatemonth.length=caldatemonth.length-dec;
//caldateyear.length=caldateyear.length-dec;
dec=0;
if(parseInt(document.all.gridtab.rows.length)-1==parseInt(gridItemCount))
{
    alert("Can't delete");
    return false;
}
var check=0;

while(i<caldate.length)
{

if(s==this[i])
{
if(check%parseInt(gridItemCount)==0)
{
document.getElementById('txtinsertion').value=parseInt(document.getElementById('txtinsertion').value)-1;
document.getElementById('txtpaid').value=document.getElementById('txtinsertion').value;
}
    check=parseInt(check)+1;
    this.splice(i, 1);
    
    caldatemonth.splice(i,1);
    caldateyear.splice(i,1);
   if(parseInt(document.all.gridtab.rows.length)-2==caldate.length || caldate.length>parseInt(document.all.gridtab.rows.length)-1)
   {
      var co=j;
      if(document.all.gridtab.rows(co)==null)
      {
       co=co;
      }
      else
      {
       co=co+1;
      }
      if(document.all.gridtab.rows(co)==null)
      {
        co=co-1;
      }
      document.all.gridtab.deleteRow(co);
        dec=dec+1;
        document.getElementById('hiddenrowcount').value = parseInt(document.getElementById('hiddenrowcount').value) - 1
     }
     else
     {
     var co=j * parseInt(gridItemCount);
      if(document.all.gridtab.rows(co)==null)
      {
       co=co;
      }
      else
      {
       co=co+1;
      }
      if(document.all.gridtab.rows(co)==null)
      {
        co=co-1;
      }
       
       var j1=j * parseInt(gridItemCount);
       //co=j1;
       var tot=j1 + parseInt(gridItemCount);
       for(j1;j1<tot;j1++)
       {
        document.all.gridtab.deleteRow(co);  
        document.getElementById('hiddenrowcount').value = parseInt(document.getElementById('hiddenrowcount').value) - 1
       }
      
        
        
       
//     var j1=1;
//     var co=0;
//     j1=i * gridItemCount;
//      var tot=j1 + gridItemCount;
//     j1=j1 + 1;
//    
//    for(j1;j1<=tot;j1++)
//    {
//    var l=j1-co;
//    document.all.gridtab.deleteRow(l);
//    dec=dec+1;
//    co=co+1;
//    document.getElementById('hiddenrowcount').value = parseInt(document.getElementById('hiddenrowcount').value) - 1
//    }
     }

    
    
      noofinsert = parseInt(noofinsert)-1;
     
  }
  else
  {
   if(this[i]!=undefined)
    {
    j=j+1;
    }
    i=i+1;
   
  }
}

}



function hadDoubleClick() {
   var d = new Date();
   var now = d.getTime();
   if ((now - dcAt) < dcDelay) {
     return true;
   }
   return false;
 }
	function filldate(which)
	{
	      switch (which) {
          case "click": 
       // If we've just had a doubleclick then ignore it
        if (hadDoubleClick()) return false;
         
       // Otherwise set timer to act.  It may be preempted by a doubleclick.
        savEvent = which;
        d = new Date();
        savEvtTime = d.getTime();
        savTO = setTimeout("doClick(savEvent)", dcTime);
        break;
        case "dblclick":
        doDoubleClick(which);
        break;
        default:
   }
	}
   
    /* hides <select> and <applet> objects (for IE only) */
    function hideElement( elmID, overDiv )
    {
    try
    {
      if( ie )
      {
        for( i = 0; i < document.all.tags( elmID ).length; i++ )
        {
          obj = document.all.tags( elmID )[i];
          if( !obj || !obj.offsetParent )
           {
            continue;
          }
      
          // Find the element's offsetTop and offsetLeft relative to the BODY tag.
          objLeft   = obj.offsetLeft;
          objTop    = obj.offsetTop;
          objParent = obj.offsetParent;
          
          while( objParent.tagName.toUpperCase() != "BODY" && objParent.tagName.toUpperCase() != "HTML")
          {
            objLeft  += objParent.offsetLeft;
            objTop   += objParent.offsetTop;
            objParent = objParent.offsetParent;
          }
      
          objHeight = obj.offsetHeight;
          objWidth = obj.offsetWidth;
      
          if(( overDiv.offsetLeft + overDiv.offsetWidth ) <= objLeft );
          else if(( overDiv.offsetTop + overDiv.offsetHeight ) <= objTop );
          else if( overDiv.offsetTop >= ( objTop + objHeight ));
          else if( overDiv.offsetLeft >= ( objLeft + objWidth ));
          else
          {
            obj.style.visibility = "hidden";
          }
        }
      }
      }
      catch(err)
      {}
    }
     
    /*
    * unhides <select> and <applet> objects (for IE only)
    */
    function showElement( elmID )
    {
    try
    {
      if( ie )
      {
        for( i = 0; i < document.all.tags( elmID ).length; i++ )
        {
          obj = document.all.tags( elmID )[i];
          
          if( !obj || !obj.offsetParent )
          {
            continue;
          }
        
          obj.style.visibility = "";
        }
      }
      }
      catch(err)
      {}
    }

	function HolidayRec (d, m, y, desc)
	{
	try
	{
		this.d = d
		this.m = m
		this.y = y
		this.desc = desc
		}
		catch(err)
      {}
	}

	var HolidaysCounter = 0
	var Holidays = new Array()

	function addHoliday (d, m, y, desc)
	{
	try
	{
		Holidays[HolidaysCounter++] = new HolidayRec ( d, m, y, desc )
	}
	catch(err)
      {}
	}

	if (dom)
	{
		for	(i=0;i<imgsrc.length;i++)
		{
			img[i] = new Image
			img[i].src = imgDir + imgsrc[i]
		}
		document.write ("<div onclick='bShow=true' unselectable='on' id='calendar' style='z-index:+999;position:absolute;visibility:hidden;'><table unselectable='on'	width="+((showWeekDecimal==1)?250:220)+" style='font-family:arial;font-size:11px;border-width:1;border-style:solid;border-color:black;font-family:arial; font-size:11px}'><tr bgcolor='#7daae3'><td unselectable='on'><table unselectable='on' width='"+((showWeekDecimal==1)?248:218)+"'><tr><td unselectable='on' style='padding:2px;font-family:arial; font-size:11px;'><font color='white'><B><span id='caption'></span></B></font></td><td unselectable='on' align=right><a href='javascript:hideCalendar()'><IMG SRC='"+imgDir+"close.gif' WIDTH='15' HEIGHT='13' BORDER='0' ALT='Close the Calendar'></a></td></tr></table></td></tr><tr><td unselectable='on' style='padding:5px' bgcolor=#ffffff><span id='content'></span></td></tr>")
		
		///document.write ("<div onclick='bShow=true' id='calendar'	style='z-index:+999;position:absolute;visibility:hidden;'><table	width="+((showWeekDecimal==1)?250:220)+" style='font-family:arial;font-size:11px;border-width:1;border-style:solid;border-color:#a0a0a0;font-family:arial; font-size:11px}' bgcolor='#ffffff'><tr bgcolor='#860303'><td><table width='"+((showWeekDecimal==1)?248:218)+"'><tr><td style='padding:2px;font-family:arial; font-size:11px;'><font color='#ffffff'><B><span id='caption'></span></B></font></td><td align=right><a href='javascript:hideCalendar()'><IMG SRC='"+imgDir+"close.gif' WIDTH='15' HEIGHT='13' BORDER='0' ALT='Close the Calendar'></a></td></tr></table></td></tr><tr><td style='padding:5px' bgcolor=#ffffff><span id='content'></span></td></tr>")
			
		if (showToday==1)
		{
			document.write ("<tr bgcolor=#f0f0f0><td unselectable='on' style='padding:5px' align=right><span id='lblToday'></span></td></tr>")
		}
			
		document.write ("</table></div><div unselectable='on' id='selectMonth' style='z-index:+999;position:absolute;visibility:hidden;'></div><div id='selectYear' unselectable='on' style='z-index:+999;position:absolute;visibility:hidden;'></div>");
	}

	var	monthName =	new	Array("January","February","March","April","May","June","July","August","September","October","November","December")
	var	monthName2 = new Array("JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC")
	if (startAt==0)
	{
		dayName = new Array	("Sun","Mon","Tue","Wed","Thu","Fri","Sat")
	}
	else
	{
		dayName = new Array	("Mon","Tue","Wed","Thu","Fri","Sat","Sun")
	}
	var	styleAnchor="text-decoration:none;color:black;cursor:pointer;"
	var	styleLightBorder="border-style:solid;border-width:1px;border-color:#860303"

	function swapImage(srcImg, destImg){
	try
	{
		if (ie)	{ document.getElementById(srcImg).setAttribute("src",imgDir + destImg) }
		}
		catch(err)
      {}
	}

	function init()	{
	try
	{
		if (!ns4)
		{
			if (!ie) { yearNow += 1900	}
			crossobj=(dom)?document.getElementById("calendar").style : ie? document.all.calendar : document.calendar
			hideCalendar()

			crossMonthObj=(dom)?document.getElementById("selectMonth").style : ie? document.all.selectMonth	: document.selectMonth

			crossYearObj=(dom)?document.getElementById("selectYear").style : ie? document.all.selectYear : document.selectYear

			monthConstructed=false;
			yearConstructed=false;

			if (showToday==1)
			{
				document.getElementById("lblToday").innerHTML =	todayString + " <a onmousemove='window.status=\""+gotoString+"\"' onmouseout='window.status=\"\"' title='"+gotoString+"' style='"+styleAnchor+"' href='javascript:monthSelected=monthNow;yearSelected=yearNow;constructCalendar();'>"+dayName[(today.getDay()-startAt==-1)?6:(today.getDay()-startAt)]+", " + dateNow + " " + monthName[monthNow].substring(0,3)	+ "	" +	yearNow	+ "</a>"
			}

			sHTML1="<span id='spanLeft'	style='border-style:solid;border-width:1;border-color:#7daae3;cursor:pointer' onmouseover='swapImage(\"changeLeft\",\"left1.gif\");this.style.borderColor=\"white\";window.status=\""+scrollLeftMessage+"\"' onclick='javascript:decMonth()' onmouseout='clearInterval(intervalID1);swapImage(\"changeLeft\",\"left1.gif\");this.style.borderColor=\"#7daae3\";window.status=\"\"' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartDecMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeLeft' SRC='"+imgDir+"left1.gif' width=10 height=10 BORDER=0>&nbsp</span>&nbsp;"
			sHTML1+="<span id='spanRight' style='border-style:solid;border-width:1;border-color:#7daae3;cursor:pointer'	onmouseover='swapImage(\"changeRight\",\"right1.gif\");this.style.borderColor=\"white\";window.status=\""+scrollRightMessage+"\"' onmouseout='clearInterval(intervalID1);swapImage(\"changeRight\",\"right1.gif\");this.style.borderColor=\"#7daae3\";window.status=\"\"' onclick='incMonth()' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartIncMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeRight' SRC='"+imgDir+"right1.gif'	width=10 height=10 BORDER=0>&nbsp</span>&nbsp"
			sHTML1+="<span id='spanMonth' style='border-style:solid;border-width:1;border-color:#7daae3;cursor:pointer'	onmouseover='swapImage(\"changeMonth\",\"drop1.gif\");this.style.borderColor=\"white\";window.status=\""+selectMonthMessage+"\"' onmouseout='swapImage(\"changeMonth\",\"drop1.gif\");this.style.borderColor=\"#7daae3\";window.status=\"\"' onclick='popUpMonth()'></span>&nbsp;"
			sHTML1+="<span id='spanYear' style='border-style:solid;border-width:1;border-color:#7daae3;cursor:pointer' onmouseover='swapImage(\"changeYear\",\"drop1.gif\");this.style.borderColor=\"white\";window.status=\""+selectYearMessage+"\"'	onmouseout='swapImage(\"changeYear\",\"drop1.gif\");this.style.borderColor=\"#7daae3\";window.status=\"\"'	onclick='popUpYear()'></span>&nbsp;"
			
			document.getElementById("caption").innerHTML  =	sHTML1

			bPageLoaded=true
		}
		}
		catch(err)
      {}
	}

	function hideCalendar()	{
	try
	{
//	 var consdate;
//	 var editid;
//	 
//		consdate=constructDate(dateSelected,monthSelected,yearSelected);
		///////////this is to chk whethet the selected date of edition falls with the publicatin day    
	
		crossobj.visibility="hidden"
		if (crossMonthObj != null){crossMonthObj.visibility="hidden"}
		if (crossYearObj !=	null){crossYearObj.visibility="hidden"}

	    showElement( 'SELECT' );
		showElement( 'APPLET' );
		}
		catch(err)
      {}
	}

	function padZero(num) {
	try
	{
		return (num	< 10)? '0' + num : num ;
		}
		catch(err)
      {}
	}

	function constructDate(d,m,y)
	{
	try
	{
		sTmp = dateFormat
		sTmp = sTmp.replace	("dd","<e>")
		sTmp = sTmp.replace	("d","<d>")
		sTmp = sTmp.replace	("<e>",padZero(d))
		sTmp = sTmp.replace	("<d>",d)
		sTmp = sTmp.replace	("mmmm","<p>")
		sTmp = sTmp.replace	("mmm","<o>")
		sTmp = sTmp.replace	("mm","<n>")
		sTmp = sTmp.replace	("m","<m>")
		sTmp = sTmp.replace	("<m>",m+1)
		sTmp = sTmp.replace	("<n>",padZero(m+1))
		sTmp = sTmp.replace	("<o>",monthName[m])
		sTmp = sTmp.replace	("<p>",monthName2[m])
		sTmp = sTmp.replace	("yyyy",y)
		return sTmp.replace ("yy",padZero(y%100))
		}
		catch(err)
      {}
	}
	    function hideCalendar1()
	    {
	    try
	    {
	    var consdate;
		consdate=constructDate(dateSelected,monthSelected,yearSelected);
		 document.getElementById('hiddenclickdate').value=consdate;
		var currdate=document.getElementById('txtdatetime').value;
		var fromdate=currdate;
		var todate=consdate;
		//var fdate=new Date(fromdate);
		//var tdate=new Date(todate);
		
		var dateformat=document.getElementById('hiddendateformat').value;
		//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                var txt=fromdate;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm1=txt1[1];
                var mm = txt1[1];//getMonthNo(mm1);
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(fromdate!="")
            {
                var txt=fromdate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            fromdate=fromdate;
        }
        
        //For From Date Converssion /************************************************************/
        if(dateformat=="dd/mm/yyyy")
        {
            if(todate != "")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(todate!="")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            todate=todate;
        }
		//
		
		
		
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		if(tdate<fdate && (document.getElementById('hiddenbackdatebook').value=="0" || document.getElementById('hiddenbackdatebook').value==""))
		{
		ctlToPlaceValue.value="";
		alert("Booking Date can't Be Less than Current Date");
		dummydate=tempdate;
		document.getElementById('txtdummydate').value=tempdate;
		return false;
		}
		///////this is to chk that rate has been defined for the given package or not
		/////////////this is to check that the publication is published on the specified date or not objListBox.children[i].value
		var x;
		var obj=document.getElementById('drppackagecopy')
		//alert(obj.options[0].value);
		for(x=0;x<obj.options.length;x++)
		{
		          var strid = obj.options[x].value;
                  var compcode=document.getElementById('hiddencompcode').value;
                  var strid1=strid.split('@');
                  var pkgid=strid1[0];
                  var pkgname=strid1[1];
                  pkgname=pkgname.replace("+","^");
                  var value="1";
                  var dateday=document.getElementById('txtdummydate').value;
                  
                  var strtext="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","packagename.aspx?pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&dateday="+dateday+"&pkgname="+pkgname, false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        strtext=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","packagename.aspx?pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&dateday="+dateday+"&pkgname="+pkgname, false );
                xml.Send();
                strtext=xml.responseText;
            }
                if(strtext=="0")
                {
                    alert("Day is not the publishing day");
                    document.getElementById('txtdummydate').value="";
                    //break;
                    return false;
                }
         }
		
		/////////////////////////////////////////////////////////////////////////////
	    var gridlen =  document.getElementById('hiddenrowcount').value;
	  
	    if(document.getElementById('txtrepeatingdate').value!="")
	    {
	        return false;
	    }
	     //if(parseInt(gridlen) == parseInt(caldatelength))
	     var p= parseInt(noofinsert)-1;
	     //debugger;
	     var rowlength=parseInt(document.getElementById("gridtab").rows.length) - 1;
	     var tdText="";
	     if(browser!="Microsoft Internet Explorer")
         {
            tdText=document.getElementById("gridtab").rows[rowlength].cells[3].innerHTML.split("id=");
         }
         else
         {
	        tdText=document.getElementById("gridtab").rows(rowlength).cells(3).innerHTML.split("id=");
	     }
	     var id=tdText[1].split(">");
	     //alert(id);
	     var val="";
	     if(id[0].indexOf("value")>=0)
	     {
	        var newval=id[0].split(" ");
	        val=newval[0].replace('"','');
	        val=val.replace('"','');
	        getid=val.substring(4,val.length);
	     }
	     else
	     {
	        val=id[0];
	     }
	     //debugger;
	     if(document.getElementById(val).value!="" && name=="txtdummydate")
	     {
	     if(!confirm("Do you want to increase the insertion"))
		    {
		        checkflag="0";
		         if(name=="txtdummydate")
                {
                    document.getElementById('txtdummydate').value=tempdate;
                    
                }
		        return false;
		    }
		 else
		    {
		        
		        caldate[cali]=dateSelected;
	            caldatemonth[cali]=parseInt(monthSelected)+1;
	            caldateyear[cali]=yearSelected;
	            checkflag="1";
	            var num1 = parseInt(document.getElementById('txtinsertion').value) + 1;
	             if(document.getElementById('hiddensavemod').value!="0")
                 {
                    if(document.getElementById('hiddeninsertion').value!="")
                    {
                          var len="bookdiv";
                        gridItemCount=parseInt(document.getElementById(len).getElementsByTagName('table')[0].rows.length-1)/parseInt(document.getElementById('txtinsertion').value);
                        noofinsert=parseInt(gridItemCount) * num1;
                        countGridElement=gridItemCount;
                    }
                    else
                    {
                    noofinsert=gridItemCount * num1;
                    }
	                
	             }
	             else
	             {
	                noofinsert=gridItemCount * num1;
	             }   
	                
		        insertLine();
		        
		       // return false;
		    }
		    
	        //alert("Do you want to insert more lines");
	       // return false;
	    }
	     caldate[cali]=dateSelected;
	    caldatemonth[cali]=parseInt(monthSelected)+1;
	    caldateyear[cali]=yearSelected;
	    if(caldate[cali]!=null)
	    {
	    var st;

	    var k = 0;
	    var k1=0;
	    if(checkflag=="0")
	    {
	        for(k=0;k<countGridElement;k++)
	        {
	        
	        if(document.getElementById('hiddencalendar').value=="0")
	        {
	        cali=0;
	        document.getElementById('hiddencalendar').value="1";
	        
	        }
	        
	            caldate[cali]=dateSelected;
	            caldatemonth[cali]=parseInt(monthSelected)+1;
	            caldateyear[cali]=yearSelected;
	            var mond=parseInt(monthSelected)+1;;
	            st = parseInt(cali);
	            
	            if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	            {
	                document.getElementById('Text'+st).value=mond + "/" + dateSelected + "/" + yearSelected;
	            }
	            else if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	            {
	                document.getElementById('Text'+st).value=dateSelected + "/" + mond + "/" + yearSelected;;
	            }
	            else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
	            {
	                document.getElementById('Text'+st).value=yearSelected + "/" + mond + "/" + dateSelected;;
	            }
	            cali=cali+1;
	        }
	      }
	      
	   }
	   //checkflag=0;
	    odateSelected=dateSelected;
	    constructCalendar();
	    caldatelength=caldate.length;
	    tempdate=constructDate(dateSelected,monthSelected,yearSelected);
	   }
	   catch(err)
      {}
	    //crossobj.visibility="hidden"
	        //showElement( 'SELECT' );
		    //showElement( 'APPLET' );   
	    }
        function closeCalendar1() {
        try
        {
        var ctlval=ctlToPlaceValue.value; 
		var	sTmp
		//alert("hi");
//alert("alert"+caldate.length);
ctlToPlaceValue.value =	constructDate(dateSelected,monthSelected,yearSelected)

var idvalue=globalid.id;
 if(idvalue.indexOf("Text")>=0 || idvalue.indexOf("lat")>=0)
 {
 chkdateforbook(globalid,ctlval);
 //alert(name.value);
 var consdate;
 consdate=constructDate(dateSelected,monthSelected,yearSelected);
 var editid;
 /////////////////////this is to chk that whether the selected date falls on non publication or no issue day if it does than give alert
 	if(name.indexOf("Text")==0)
		{
		        var compcode=document.getElementById('hiddencompcode').value;
                  //var strid1=strid.split('@');
                var  gtid=name.substring(4,name.length);
                editid="edit"+gtid;
                  var pkgid="";
                  var pkgname=document.getElementById(editid).value;
                  pkgname=pkgname.replace("+","^");
                  var value="1";
                  var dateday=document.getElementById(name).value;
                  
                  var strtext="";
                  
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
         
                    httpRequest.open( "GET","packagename.aspx?pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&dateday="+dateday+"&pkgname="+pkgname, false );
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) 
                    {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) 
                        {
                            strtext=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                { 
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
                    xml.Open( "GET","packagename.aspx?pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&dateday="+dateday+"&pkgname="+pkgname, false );
                    xml.Send();
                    strtext=xml.responseText;   
                }
                if(strtext=="0")
                {
                    alert("Publication day doesnot match with day");
                    document.getElementById(name).value=tempdate;
                  
                }     
                
		
		
		}

 	hideCalendar();
 	
 }

 if(idvalue=="txtrodate" )
		        {
		        chkratedate();
        		hideCalendar();
        		//return false;
        		
		        }
		         if(idvalue.indexOf("Text")>=0 )
		        {
		        chkratefromgrid(globalid);
		        hideCalendar();
		        //return false;
		        }
		        if(idvalue=="txtreceiptdate" )
		        {
		        
		        hideCalendar();
		        //return false;
		        }
if(caldate.length==0)
		{
		//ctlToPlaceValue.value =	constructDate(dateSelected,monthSelected,yearSelected)
		document.getElementById('txtrepeatingdate').disabled=false;
		}
		else{
		//ctlToPlaceValue.value="";
		document.getElementById('txtrepeatingdate').disabled=true;
		}
		if(idvalue!="txtrodate" && name=="txtdummydate")
		{
		hideCalendar1();
		}
		}
		catch(err)
      {}
	}
	function closeCalendar() {
	try
	{
		var	sTmp

		hideCalendar();
		ctlToPlaceValue.value =	constructDate(dateSelected,monthSelected,yearSelected)
		}
		catch(err)
      {}
	}

	/*** Month Pulldown	***/

	function StartDecMonth()
	{
		intervalID1=setInterval("decMonth()",80)
	}

	function StartIncMonth()
	{
		intervalID1=setInterval("incMonth()",80)
	}

	function incMonth () {
		monthSelected++
		if (monthSelected>11) {
			monthSelected=0
			yearSelected++
		}
		constructCalendar()
	}

	function decMonth () {
		monthSelected--
		if (monthSelected<0) {
			monthSelected=11
			yearSelected--
		}
		constructCalendar()
	}

	function constructMonth() {
	try
	{
		popDownYear()
		if (!monthConstructed) {
			sHTML =	""
			for	(i=0; i<12;	i++) {
				sName =	monthName[i];
				if (i==monthSelected){
					sName =	"<B>" +	sName +	"</B>"
				}
				sHTML += "<tr><td unselectable='on' id='m" + i + "' onmouseover='this.style.backgroundColor=\"#dfb64c\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='monthConstructed=false;monthSelected=" + i + ";constructCalendar();popDownMonth();event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
			}

			document.getElementById("selectMonth").innerHTML = "<table unselectable='on' width=70	style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;' bgcolor='#eeeeee' cellspacing=0 onmouseover='clearTimeout(timeoutID1)'	onmouseout='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"popDownMonth()\",100);event.cancelBubble=true'>" +	sHTML +	"</table>"

			monthConstructed=true
		}
	}
	catch(err)
      {}	
	}

	function popUpMonth() {
	try
	{
		constructMonth()
		crossMonthObj.visibility = (dom||ie)? "visible"	: "show"
		crossMonthObj.left = parseInt(crossobj.left) + 50+"px"
		crossMonthObj.top =	parseInt(crossobj.top) + 26+"px"

		hideElement( 'SELECT', document.getElementById("selectMonth") );
		hideElement( 'APPLET', document.getElementById("selectMonth") );			
		}
		catch(err)
      {}
	}

	function popDownMonth()	{
		crossMonthObj.visibility= "hidden"
	}

	/*** Year Pulldown ***/

	function incYear() {
		for	(i=0; i<7; i++){
			newYear	= (i+nStartingYear)+1
			if (newYear==yearSelected)
			{ txtYear =	"&nbsp;<B>"	+ newYear +	"</B>&nbsp;" }
			else
			{ txtYear =	"&nbsp;" + newYear + "&nbsp;" }
			document.getElementById("y"+i).innerHTML = txtYear
		}
		nStartingYear ++;
		bShow=true
	}

	function decYear() {
		for	(i=0; i<7; i++){
			newYear	= (i+nStartingYear)-1
			if (newYear==yearSelected)
			{ txtYear =	"&nbsp;<B>"	+ newYear +	"</B>&nbsp;" }
			else
			{ txtYear =	"&nbsp;" + newYear + "&nbsp;" }
			document.getElementById("y"+i).innerHTML = txtYear
		}
		nStartingYear --;
		bShow=true
	}

	function selectYear(nYear) {
		yearSelected=parseInt(nYear+nStartingYear);
		yearConstructed=false;
		constructCalendar();
		popDownYear();
	}

	function constructYear() {
	try
	{
		popDownMonth()
		sHTML =	""
		if (!yearConstructed) {

			sHTML =	"<tr><td align='right' unselectable='on'	onmouseover='this.style.backgroundColor=\"#dfb64c\"' onmouseout='clearInterval(intervalID1);this.style.backgroundColor=\"\"' style='cursor:pointer'	onmousedown='clearInterval(intervalID1);intervalID1=setInterval(\"decYear()\",30)' onmouseup='clearInterval(intervalID1)'>-</td></tr>"

			j =	0
			nStartingYear =	yearSelected-3
			for	(i=(yearSelected-3); i<=(yearSelected+3); i++) {
				sName =	i;
				if (i==yearSelected){
					sName =	"<B>" +	sName +	"</B>"
				}

				sHTML += "<tr><td unselectable='on' id='y" + j + "' onmouseover='this.style.backgroundColor=\"#dfb64c\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='selectYear("+j+");event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
				j ++;
			}

			sHTML += "<tr><td unselectable='on' align='right' onmouseover='this.style.backgroundColor=\"#dfb64c\"' onmouseout='clearInterval(intervalID2);this.style.backgroundColor=\"\"' style='cursor:pointer' onmousedown='clearInterval(intervalID2);intervalID2=setInterval(\"incYear()\",30)'	onmouseup='clearInterval(intervalID2)'>+</td></tr>"

			document.getElementById("selectYear").innerHTML	= "<table unselectable='on' width=44 style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;'	bgcolor='#eeeeee' onmouseover='clearTimeout(timeoutID2)' onmouseout='clearTimeout(timeoutID2);timeoutID2=setTimeout(\"popDownYear()\",100)' cellspacing=0>"	+ sHTML	+ "</table>"

			yearConstructed	= true
		}
		}
		catch(err)
      {}
	}

	function popDownYear() {
	try
	{
		clearInterval(intervalID1)
		clearTimeout(timeoutID1)
		clearInterval(intervalID2)
		clearTimeout(timeoutID2)
		crossYearObj.visibility= "hidden"
	}
	catch(err)
      {}	
	}

	function popUpYear() {
	try
	{
		var	leftOffset

		constructYear()
		crossYearObj.visibility	= (dom||ie)? "visible" : "show"
		leftOffset = parseInt(crossobj.left) + document.getElementById("spanYear").offsetLeft
		if (ie)
		{
			leftOffset += 6
		}
		crossYearObj.left =	leftOffset
		crossYearObj.top = parseInt(crossobj.top) +	26
	}
	catch(err)
      {}	
	}

	/*** calendar ***/
   function WeekNbr(n) {
   try
   {
      // Algorithm used:
      // From Klaus Tondering's Calendar document (The Authority/Guru)
      // hhtp://www.tondering.dk/claus/calendar.html
      // a = (14-month) / 12
      // y = year + 4800 - a
      // m = month + 12a - 3
      // J = day + (153m + 2) / 5 + 365y + y / 4 - y / 100 + y / 400 - 32045
      // d4 = (J + 31741 - (J mod 7)) mod 146097 mod 36524 mod 1461
      // L = d4 / 1460
      // d1 = ((d4 - L) mod 365) + L
      // WeekDecimal = d1 / 7 + 1
 
      year = n.getFullYear();
      month = n.getMonth() + 1;
      if (startAt == 0) {
         day = n.getDate() + 1;
      }
      else {
         day = n.getDate();
      }
 
      a = Math.floor((14-month) / 12);
      y = year + 4800 - a;
      m = month + 12 * a - 3;
      b = Math.floor(y/4) - Math.floor(y/100) + Math.floor(y/400);
      J = day + Math.floor((153 * m + 2) / 5) + 365 * y + b - 32045;
      d4 = (((J + 31741 - (J % 7)) % 146097) % 36524) % 1461;
      L = Math.floor(d4 / 1460);
      d1 = ((d4 - L) % 365) + L;
      week = Math.floor(d1/7) + 1;
 
      return week;
      }
      catch(err)
      {}
   }

	function constructCalendar () {
	try
	{
		var aNumDays = Array (31,0,31,30,31,30,31,31,30,31,30,31)

		var dateMessage
		var	startDate =	new	Date (yearSelected,monthSelected,1)
		var endDate

		if (monthSelected==1)
		{
			endDate	= new Date (yearSelected,monthSelected+1,1);
			endDate	= new Date (endDate	- (24*60*60*1000));
			numDaysInMonth = endDate.getDate()
		}
		else
		{
			numDaysInMonth = aNumDays[monthSelected];
		}

		datePointer	= 0
		dayPointer = startDate.getDay() - startAt
		
		if (dayPointer<0)
		{
			dayPointer = 6
		}

		sHTML =	"<table unselectable='on'	 border=0 style='font-family:verdana;font-size:10px;'><tr>"

		if (showWeekDecimal==1)
		{
			// vertical line Bgcolor
			sHTML += "<td width=27 unselectable='on'><b>" + weekString + "</b></td><td unselectable='on' width=1 rowspan=7 bgcolor='#860404' style='padding:0px'><img src='"+imgDir+"divider.gif' width=1></td>"
		}

		for	(i=0; i<7; i++)	{
			sHTML += "<td unselectable='on' width='27' align='right'><B>"+ dayName[i]+"</B></td>"
		}
		sHTML +="</tr><tr>"
		
		if (showWeekDecimal==1)
		{
			sHTML += "<td align=right unselectable='on'>" + WeekNbr(startDate) + "&nbsp;</td>"
		}

		for	( var i=1; i<=dayPointer;i++ )
		{
			sHTML += "<td unselectable='on'>&nbsp;</td>"
		}
		
		for	( datePointer=1; datePointer<=numDaysInMonth; datePointer++ )
		{
			dayPointer++;
			sHTML += "<td align=right unselectable='on'>"
			sStyle=styleAnchor
			var j = parseInt(datePointer)-1;
			
			
			 
			var kcal=0;
			for(kcal=0;kcal<caldate.length;kcal++)
			{
			    if((datePointer==caldate[kcal]) && (monthSelected==caldatemonth[kcal]-1) && (yearSelected==caldateyear[kcal]))
			    {
			        sStyle+=styleLightBorder;
			    }
			}
			//if ((datePointer==odateSelected) &&	(monthSelected==omonthSelected)	&& (yearSelected==oyearSelected))
			//{ sStyle+=styleLightBorder }

			sHint = ""
			for (k=0;k<HolidaysCounter;k++)
			{
				if ((parseInt(Holidays[k].d)==datePointer)&&(parseInt(Holidays[k].m)==(monthSelected+1)))
				{
					if ((parseInt(Holidays[k].y)==0)||((parseInt(Holidays[k].y)==yearSelected)&&(parseInt(Holidays[k].y)!=0)))
					{
						sStyle+="background-color:#FFDDDD;"
						sHint+=sHint==""?Holidays[k].desc:"\n"+Holidays[k].desc
					}
				}
			}
			var regexp= /\"/g
			sHint=sHint.replace(regexp,"&quot;")

			dateMessage = "onmousemove='window.status=\""+selectDateMessage.replace("[date]",constructDate(datePointer,monthSelected,yearSelected))+"\"' onmouseout='window.status=\"\"' "

			if ((datePointer==dateNow)&&(monthSelected==monthNow)&&(yearSelected==yearNow))
			{ sHTML += "<b><a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' ondblClick='javascript:dateSelected="+datePointer+";filldate(event.type);'  onClick='javascript:dateSelected="+datePointer+";filldate(event.type);'><font color=#ff0000>&nbsp;" + datePointer + "</font>&nbsp;</a></b>"}
			else if	(dayPointer % 7 == (startAt * -1)+1)
			{ sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' ondblClick='javascript:dateSelected="+datePointer+";filldate(event.type);' onClick='javascript:dateSelected="+datePointer+";filldate(event.type);'>&nbsp;<font color=#909090>" + datePointer + "</font>&nbsp;</a>" }
			else
			{ sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' ondblClick='javascript:dateSelected="+datePointer+";filldate(event.type);' onClick='javascript:dateSelected="+datePointer+";filldate(event.type);'>&nbsp;" + datePointer + "&nbsp;</a>" }

			sHTML += ""
			if ((dayPointer+startAt) % 7 == startAt) { 
				sHTML += "</tr><tr>" 
				if ((showWeekDecimal==1)&&(datePointer<numDaysInMonth))
				{
					sHTML += "<td align=right unselectable='on'>" + (WeekNbr(new Date(yearSelected,monthSelected,datePointer+1))) + "&nbsp;</td>"
				}
			}
		}

		document.getElementById("content").innerHTML   = sHTML
		document.getElementById("spanMonth").innerHTML = "&nbsp;" +	monthName[monthSelected] + "&nbsp;<IMG id='changeMonth' SRC='"+imgDir+"drop1.gif' WIDTH='10' HEIGHT='10' BORDER=0>"
		document.getElementById("spanYear").innerHTML =	"&nbsp;" + yearSelected	+ "&nbsp;<IMG id='changeYear' SRC='"+imgDir+"drop1.gif' WIDTH='10' HEIGHT='10' BORDER=0>"
		}
		catch(err)
      {}
	}
    
	function popUpCalendar(ctl,	ctl2, format)
	 {
	try
	{
	
	if(ctl2.disabled==true )
	{
	hideCalendar();
	return ;
	}
	name=ctl2.id;
	
	//////////if the user creates the cyop and that cyop has its package than cyop replaces with the package
	 if(name=="txtdummydate" && document.getElementById('tblinsert').innerHTML!="")
    {
            if(cyop_code!="" && cyop_desc!="" && document.getElementById('txtdummydate').value=="")
            {
                 var cyop_adtype=document.getElementById('hiddenadtype').value;
                 
                 var id="";
                 
                 if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
         
                    httpRequest.open( "GET","cyoptopkg.aspx?cyop_code="+cyop_code+"&cyop_desc="+cyop_desc+"&cyop_adtype="+cyop_adtype, false );
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) 
                    {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) 
                        {
                            id=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                {
                     var xml = new ActiveXObject("Microsoft.XMLHTTP");
                     xml.Open( "GET","cyoptopkg.aspx?cyop_code="+cyop_code+"&cyop_desc="+cyop_desc+"&cyop_adtype="+cyop_adtype, false );
                     xml.Send();
                     id=xml.responseText;
                }
                 var finaldesc;
                 var array_finaldesc;
                 if(id!="")
                 {
                    finaldesc=id; 
                    array_finaldesc=finaldesc.split("^");
                    var objpack=document.getElementById('drppackagecopy');
                    var i_cyop=objpack.options.length;
                    var j_cyop;
                     for(j_cyop=0;j_cyop<i_cyop;j_cyop++)
                     {
                        if(parseInt(i_cyop)>0)
                        {
                            if(array_finaldesc[1]==objpack[j_cyop].value)
                            {
                                break;
                            }
                            else
                            {
                                objpack.options.length=0;
                                document.getElementById('tblinsert').innerHTML=""
                                AddItem(document.getElementById('drppackagecopy'), array_finaldesc[0], array_finaldesc[1]);
                                return;
                            }
                        }
                     }
                                    
                 }
                 
            }
                              
        
    
    }
	
	  caldate=null;
	caldate=new Array();
	caldatemonth=null;
	caldatemonth=new Array();
	caldateyear=null;
	caldateyear=new Array();
	
	///////this is to insert the date in a temporarily variable
	if(name.indexOf("Text")==0)
    {
        tempdate=document.getElementById(name).value;
    }
    if(name=="txtdummydate")
    {
        tempdate=document.getElementById(name).value;
    }
	 if(ctl2.id=="txtdummydate")
	 {
	        noofinsert=parseInt(gridItemCount) * parseInt(document.getElementById('txtinsertion').value);
	        var tot=parseInt(noofinsert) //* parseInt(document.getElementById('txtinsertion').value)
	       // alert(noofinsert);
		//	alert(document.getElementById('txtinsertion').value);
			//alert(document.getElementById('hiddendateformat').value);
			var i1=0;
			var j1=0;
			inc=parseInt(tot)/parseInt(document.getElementById('txtinsertion').value)
			var val="";
			var k1=0;
			while(i1<tot)
			{
			    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
			    {
			    
			        //if(document.getElementById("Text"+k1)==null)
			        while(document.getElementById("Text"+k1)==null)
			        {
			         k1=k1 + inc;
			         
			        }
			       
			        val=document.getElementById("Text"+k1).value;
			        if(val!="")
			        {
			            calselect=val.split("/");
			            caldate[j1]=calselect[1];
			            caldatemonth[j1]=calselect[0];
			            caldateyear[j1]=calselect[2];
			           // alert(calselect[0]);
			            //alert(calselect[1]);
			            //alert(calselect[2]);
			        }
			    }
			    i1=i1 + inc;
			    k1=k1 + inc;
			    j1=j1 + 1;
			}
		
		}	
			caldatelength=caldate.length;
	 //alert("lata");
	// var aaaa=ctl2.value;
	//alert(ctl2.disabled);//
	//
	 
	//------------------------------
	//if(document.getElementById('txtdatetime').value
	globalid=ctl2
//	if(document.getElementById('drppackage').value!=packagename)
//	{
//	caldate=null;
//	caldate=new Array();
//	caldatemonth=null;
//	caldatemonth=new Array();
//	caldateyear=null;
//	caldateyear=new Array();
//	caldatelength=0;
//	cali=0;
//	//countGridElement = document.getElementById('hiddenrowcount').value;
//	}
	packagename=document.getElementById('drppackage').value;
	if(document.getElementById('drppackagecopy').options.length==0 && globalid.id=="txtdummydate")
	{
	    alert("Please Select Package");
	    if(document.getElementById('drppackage').disabled==false)
	    {
	    document.getElementById('drppackage').focus();
	    }
	    return false;
	}
	
//	if(ctl2.disabled==true)
//	{
//	hideCalendar();
//	return ;
//	}
	var abc=document.getElementById('hiddendateformat').value;
	if(abc==null || abc=="" || abc=="undefined")
	{
	format="mm/dd/yyyy";
	}
	else
	{
		format=abc;
	}	
		var	leftpos=100
		var	toppos=0

		if (bPageLoaded)
		{
		    
			if ( crossobj.visibility ==	"hidden" ) {
				ctlToPlaceValue	= ctl2
				dateFormat=format;

				formatChar = " "
				aFormat	= dateFormat.split(formatChar)
				if (aFormat.length<3)
				{
					formatChar = "/"
					aFormat	= dateFormat.split(formatChar)
					if (aFormat.length<3)
					{
						formatChar = "."
						aFormat	= dateFormat.split(formatChar)
						if (aFormat.length<3)
						{
							formatChar = "-"
							aFormat	= dateFormat.split(formatChar)
							if (aFormat.length<3)
							{
								// invalid date	format
								formatChar=""
							}
						}
					}
				}

				tokensChanged =	0
				if ( formatChar	!= "" )
				{
					// use user's date
					
					aData =	ctl2.value.split(formatChar)

					for	(i=0;i<3;i++)
					{
						if ((aFormat[i]=="d") || (aFormat[i]=="dd"))
						{
							dateSelected = parseInt(aData[i], 10)
							tokensChanged ++
						}
						else if	((aFormat[i]=="m") || (aFormat[i]=="mm"))
						{
							monthSelected =	parseInt(aData[i], 10) - 1
							
							tokensChanged ++
						}
						else if	(aFormat[i]=="yyyy")
						{
							yearSelected = parseInt(aData[i], 10)
							tokensChanged ++
						}
						else if	(aFormat[i]=="mmm")
						{
							for	(j=0; j<12;	j++)
							{
								if (aData[i]==monthName[j])
								{
									monthSelected=j
									tokensChanged ++
								}
							}
						}
						else if	(aFormat[i]=="mmmm")
						{
							for	(j=0; j<12;	j++)
							{
								if (aData[i]==monthName2[j])
								{
									monthSelected=j
                                    
									tokensChanged ++
								}
							}
						}
					}
				}

				if ((tokensChanged!=3)||isNaN(dateSelected)||isNaN(monthSelected)||isNaN(yearSelected))
				{
					var ad=new Date;
					dateSelected = ad.getDate();//dateNow
					monthSelected =	ad.getMonth();//monthNow
					yearSelected = ad.getYear();//yearNow
					if(yearSelected<1000)
					    yearSelected=yearSelected+1900;
				}
                
      
				odateSelected=dateSelected
				//caldate[cali]=dateSelected;
				//alert("open" + cali);  
                //cali=cali+1;
				omonthSelected=monthSelected
				oyearSelected=yearSelected

				aTag = eval(ctl)
				var btag;
				        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");

				//crossobj.left =	fixedX==-1 ? ctl.offsetLeft	+ leftpos-250 :	fixedX
				if(document.getElementById('bookdiv')!=null && globalid.id!="txtdummydate" && ctl2.id!="txtrodate" && ctl2.id!="txtreceiptdate")
				{
                var tot=document.getElementById('bookdiv').scrollLeft;
                var tottop=document.getElementById('bookdiv').scrollHeight;
				crossobj.left =	fixedX==-1 ? ctl.offsetLeft	+ leftpos-tot+"px" :	fixedX+"px"
				
				//var totalval=parseInt(tottop)-.ctl.offsetHeight +	2 
				//alert(totalval);
				//crossobj.top = fixedY==-1 ?	ctl.offsetTop +	toppos - (parseInt(tottop)+parseInt(ctl2.scrollHeight)+50) :	fixedY
				crossobj.top=515;
				}
				else
				{
				crossobj.left =	fixedX==-1 ? ctl.offsetLeft	+ leftpos-250+"px" :	fixedX+"px"
				crossobj.top = fixedY==-1 ?	ctl.offsetTop +	toppos + ctl.offsetHeight +	2+"px" :	fixedY+"px"
				}
				
				constructCalendar (1, monthSelected, yearSelected);
				crossobj.visibility=(dom||ie)? "visible" : "show"

				hideElement( 'SELECT', document.getElementById("calendar") );
				hideElement( 'APPLET', document.getElementById("calendar") );			

				bShow = true;
			}
			else
			{
				hideCalendar()
				if (ctlNow!=ctl) {popUpCalendar(ctl, ctl2, format)}
			}
			ctlNow = ctl
		}
		}
		catch(err)
      {}
	}

	document.onkeypress = function hidecal1 () { 
	try
	{
		if (event.keyCode==27) 
		{
			hideCalendar()
		}
	}
	catch(err)
      {}	
	}
	document.onclick = function hidecal2 () { 		
	try
	{
		if (!bShow)
		{
			hideCalendar()
		}
		bShow = false
		}
		catch(err)
      {}
	}

	if(ie)
	{
		init();
	}
	else
	{
		//window.onload=init
		init();
	}
	function getMonthNo(monthname)
	{
	    var monthno="";
	    if(monthname=="Jan")
	    {
	        monthno="01";
	    }
	    else  if(monthname=="Feb")
	    {
	        monthno="02";
	    }
	     if(monthname=="Mar")
	    {
	        monthno="03";
	    }
	     if(monthname=="Apr")
	    {
	        monthno="04";
	    }
	     if(monthname=="May")
	    {
	        monthno="05";
	    }
	     if(monthname=="Jun")
	    {
	        monthno="06";
	    }
	     if(monthname=="Jul")
	    {
	        monthno="07";
	    }
	     if(monthname=="Aug")
	    {
	        monthno="08";
	    }
	     if(monthname=="Sep")
	    {
	        monthno="09";
	    }
	     if(monthname=="Oct")
	    {
	        monthno="10";
	    }
	     if(monthname=="Nov")
	    {
	        monthno="11";
	    }
	     if(monthname=="Dec")
	    {
	        monthno="12";
	    }
	    return monthno;
	}