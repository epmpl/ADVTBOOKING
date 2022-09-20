// JScript File

function tabvalue()
{
if(event.keyCode==13)
{

if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
event.keyCode=13;
//document.getElementById('savesT').focus();
return event.keycode ;
}
else
{
//document.getElementById('savesT').focus();
event.keyCode=9;
//document.getElementById('dropcheck').focus();
//return event.keyCode==13;
return event.keycode;
}
}
}







/***********************************************************/
//function shortcuts(event)
//{
//////this is  for short cut keys whern ctrl+d is press than ad detail tab is open
//   /* if(event.ctrlKey==true && event.keyCode==68)// && document.getElementById('LinkButton1').disabled==false)
//    {
//        changediv();
//    }
//    ////when ctrl+g than page detail tab is open
//    else if(event.ctrlKey==true && event.keyCode==71 && document.getElementById('LinkButton2').disabled==false)
//    {
//        changediv1();
//    }
//    ////when ctrl+t than Rate detail tab is open
//    else if(event.ctrlKey==true && event.keyCode==84 && document.getElementById('LinkButton4').disabled==false)
//    {
//        changedivrate();
//    }*/
//    ////when ctrl+c than package detail tab is open
//    if(event.ctrlKey==true && event.keyCode==67 )//&& document.getElementById(currentid)!=null)
//    {
//       paste_selected()
//    }
//    ////when ctrl+s than save is open
//    else if(event.ctrlKey==true && event.keyCode==83)// && document.getElementById('LinkButton3').disabled==false)
//    {
//        savedialog();
//    }
//    ////when ctrl+x than box detail tab is open
//    /*else if(event.ctrlKey==true && event.keyCode==88 && document.getElementById('LinkButton6').disabled==false)
//    {
//        openboxpopup();
//    }*/

//}
//////function chkvalue(e)
//////{
////////var flag="";
//////////return allamount121(e);
////////element=document.getElementById(e);//.value;
//////////alert(e);
//////////alert(e.value);
//////////var fld=e.value;
////////var fld=e.value;
////////		if(fld!="")
////////			{s
////////			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
////////			if(fld.match(/^\d+(\.\d{1,2})?$/i))
////////			{
////////			//return true;
////////			//checkpackagerate();
////////			flag="t";
////////			return flag;
////////			}
////////			else
////////			{
////////			alert("Input Error")
////////			//alert(e.id);
////////			var str=e.id;
////////			e.value="";
////////			document.getElementById(str).focus();
////////			flag="f";
////////			//e.id.focus();
////////			return flag;
////////			}
////////			}
//////			
//////			}
