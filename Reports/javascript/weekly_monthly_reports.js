// JScript File
function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;

}
function logoutpage()
{
    var c;
    //alert(typeof(formopen));
    //alert(win);
    if(typeof(win)!="undefined")
    {
        win.close();
    }
    window.location.href="../logout.aspx";
    window.close();
    return false;
}

function print1()
     {
     window.print();
     }
     
     
 var id="";
var xmlFile = "xml/disschreg.xml";
var browser = navigator.appName;    
function checkrundatenetamt_agency()
 {  
 var alrt;
// if (browser != "Microsoft Internet Explorer") 
//{
// 
//httpRequest= new XMLHttpRequest();    
//httpRequest.onreadystatechange = function() {alertContents_name(httpRequest) };
//httpRequest.open("GET", xmlFile, false);
//httpRequest.send('');
//id=httpRequest.responseText;
//    
//}
//else
//{
//var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 

//loadXML('xml/disschreg.xml');
//}
    //alrt=document.getElementById('lbDateFrom').innerText;
    if (browser != "Microsoft Internet Explorer") 
   alrt=document.getElementById('lbDateFrom').textContent;
 else
   alrt=document.getElementById('lbDateFrom').innerText;
   
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="" || document.getElementById('txtfrmdate').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    }
   var alrt;
   // alrt=document.getElementById('lbToDate').innerText;
   if (browser != "Microsoft Internet Explorer") 
   alrt=document.getElementById('lbDateFrom').textContent;
 else
   alrt=document.getElementById('lbDateFrom').innerText;
   
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="" || document.getElementById('txttodate1').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate1').focus();
            return false;
        }
    } 
   var destination = document.getElementById('Txtdest').value;
   //var mainagency = document.getElementById('hdnagency').value;
   var fromdate = document.getElementById('txtfrmdate').value;
   var todate = document.getElementById('txttodate1').value;
   var based_on=document.getElementById('dpdbasedon').value;
   var printingcenter = document.getElementById('dpd_printcent').value;
   var mp= document.getElementById("dpd_printcent").selectedIndex;
   var printingcenter_name= document.getElementById("dpd_printcent").options[mp].text;
   if(printingcenter_name == "--Select Printing Center--" || printingcenter_name == "") 
   {
    printingcenter_name = "";
   }
   
   
   // for date validdation   
 var flg=datecheck(fromdate,todate)
 if(flg==true)
 {
    alert("From date should less than to date");
    document.getElementById('txttodate1').value="";
    document.getElementById('txttodate1').focus();
    return false;
 }
 // end here publication_name ad_type
   var branch = document.getElementById('dpd_branch').value;
   var mm= document.getElementById("dpd_branch").selectedIndex;
   if(mm!=-1)
   var branch_name= document.getElementById("dpd_branch").options[mm].text;   
   else
   var branch_name ="";
   if(branch_name == "--Select Branch--" || branch_name == "") 
   {
    branch_name = "";
   } 
   
   var publication = document.getElementById('dppub1').value;
   var pn= document.getElementById("dppub1").selectedIndex;
   if(pn!=-1)
   var publication_name= document.getElementById("dppub1").options[pn].text;   
   else
   var publication_name ="";
   if(publication_name == "--Select Publication--" || publication_name == "") 
   {
    publication_name = "";
   }
   
     
    if(document.getElementById('txtfrmdate').value=="")
    {       
        alert('Please Enter from date.');
        document.getElementById('txtfrmdate').focus();
        return false;
    }
    if(document.getElementById('txttodate1').value=="")
    {       
        alert('Please Enter to date.');
        document.getElementById('txttodate1').focus();
        return false;  
    } 
   
  var dateformat=document.getElementById('txtfrmdate').value;
  var abc=dateformat.split("/");
  var todate = document.getElementById('txttodate1').value;
  var splittodate = todate.split("/");
  var dateformat1=document.getElementById('hiddendateformat').value;
  var thisdate =  new Date();  
  var dd   = thisdate.getDate();
  var mm   =  thisdate.getMonth()+1;
  var yyyy = thisdate.getYear();
  var label;
      if(document.getElementById('txtfrmdate').value!="")
        {
            if(dateformat1=="mm/dd/yyyy")
              {
                     if(abc[2]>yyyy) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfrmdate').value="";
                       document.getElementById('txtfrmdate').focus();
                       return false;  
                       //break;                                      
                     }
//                     goto label;
                     else if ((abc[2]==yyyy)&&(abc[0]>mm))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     else if ((abc[2]==yyyy)&&(abc[0]==mm)&&(abc[1]>dd))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                       else if(abc[2]>splittodate[2]) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfrmdate').value="";
                       document.getElementById('txtfrmdate').focus();
                       return false;  
                       //break;                                      
                     }
                     
                            else if((abc[2] == splittodate[2])&& (abc[0]> splittodate[0]) )
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;  
                           }
                           
                           else if((abc[0] == splittodate[0])&& (abc[2] == splittodate[2]) && (abc[1] > splittodate[1]))
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;
                           }
                           else 
                           {
                           }
                             }
                                       
              }
              
         var ext1="";
         var ext2="";
         var ext3="";
         var ext4="";
         var ext5="";
         var ext6="";
         var ext7="";
         var ext8="";
         var ext9="";
         var ext10="";    
    //"&ad_type=" + ad_type +"&adcat="+adcat+"&ad_category="+ad_category+ "&extra1=" + ext1 + "&extra2="+ ext2+ "&extra3="+ ext3+ "&extra4="+ ext4+ "&extra5="+ ext5
        window.open ("weekly_monthly_reports_view.aspx?destination="+destination+"&fromdate=" + fromdate + "&todate="+ todate+ "&printingcenter_name="+ printingcenter_name+ "&printingcenter="+ printingcenter+"&branch="+branch+"&branch_name="+branch_name+ "&publication_code="+publication+ "&pub_name="+publication_name+ "&based_on="+based_on+ "&ext1="+ext1+ "&ext2="+ext2+ "&ext3="+ext3+ "&ext4="+ext4+ "&ext5="+ext5+ "&ext6="+ext6+ "&ext7="+ext7+ "&ext8="+ext8+ "&ext9="+ext9+ "&ext10="+ext10,'gaurav','resizable=yes,scrollbars=yes,toolbar=yes,titlebar=yes,menubar=yes,status=yes');
        return false;
}

function datecheck(frmdate,todate)
{
var flag=false;
    var frmd="";
    var tod="";
    var dtform=document.getElementById('hiddendateformat').value;
    var fdt =frmdate.split("/");
    var tdt=todate.split("/");
    if(dtform=="dd/mm/yyyy")
    {
        frmd=fdt[1]+"/"+fdt[0]+"/"+fdt[2]
        tod=tdt[1]+"/"+tdt[0]+"/"+tdt[2]    
    }
    else if(dtform=="mm/dd/yyyy")
    {        
    }
    else
    {
        frmd=fdt[1]+"/"+fdt[2]+"/"+fdt[0]
        tod=tdt[1]+"/"+tdt[2]+"/"+tdt[0]
    }
    var fr=new Date(frmd);
    var to=new Date(tod);
    if(fr>to)
    {      
        flag=true;
    }
    return flag;
}


function DateDifference(id)
{
    t1=document.getElementById('txtfrmdate').value;
    t2=document.getElementById('txttodate1').value;

 
   
       var one_day=1000*60*60*24; 

       if(t1 !== "" && t2 !="")
       {
        var x=t1.split("/");     
        var y=t2.split("/");
  

        var date1=new Date(x[2],(x[1]-1),x[0]);
  
        var date2=new Date(y[2],(y[1]-1),y[0])
        var month1=x[1]-1;
        var month2=y[1]-1;
        
                       
        _Diff=Math.ceil((date2.getTime()-date1.getTime())/(one_day));
 
        if(_Diff > "61")
        {
        alert(" Please Fill The Date In 2 Months Difference");
         document.getElementById('txttodate1').value="";
		 document.getElementById('txttodate1').focus()
        }
        }
    
}

function checkdate(input,input1)
{
    var kk=document.activeElement.id;
	var dateformat=document.getElementById('hiddendateformat').value;
	if(dateformat=="mm/dd/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	 
	}
	if(dateformat=="yyyy/mm/dd")
	 
	{
		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
	}
	if(dateformat=="dd/mm/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	}

	if (!validformat.test(input))
	{
		if(input=="")
		{
		return true;
		}
		alert(" Please Fill The Date In "+dateformat+" Format");
		 document.getElementById(input1).value="";
		  document.getElementById(input1).focus()
		return false;
	}
	DateDifference()
}