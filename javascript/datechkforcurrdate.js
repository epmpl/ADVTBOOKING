/**
 * DHTML date validation script. Courtesy of SmartWebby.com (http://www.smartwebby.com/dhtml/)
 */
// Declaring valid date character, minimum year and maximum year
/*
var dtCh= "/";
var minYear=1900;
var maxYear=2100;

function isInteger(s){
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag){
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++){   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year){
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) {
	for (var i = 1; i <= n; i++) {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}

function isDate(dtStr){
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strMonth=dtStr.substring(0,pos1)
	var strDay=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1){
		alert("The date format should be : mm/dd/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12){
		alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
		alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear){
		alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false){
		alert("Please enter a valid date")
		return false
	}
return true
}

function ValidateFormdate(){

	var dt=document.Form1.txtbusineedate;
	//var dt=ankur.value;
	if (isDate(dt.value)==false){
		dt.focus()
		return false
	}
    return true
 }
 */
 
 
 var daid;
 function abc()
 {
    alert('hit');
   
    
 }
 function settime12()
 {
     var dateformat=document.getElementById('hiddendateformat').value;
     var currdate=document.getElementById('txtdatetime').value;
      var currd=new Date(currdate);
        var rodate=new Date(daid);
       
     if((document.activeElement.id.indexOf('dan')<0 && document.activeElement.id!='') || rodate=="NaN")
     {
        alert(" Please Fill The Date In "+dateformat+" Format");
       
        daid.focus();
        daid.value="";
        
      }
      else if(rodate>currd)
      {
        alert("Ro date should be less than or equal to current date");
         daid.focus();
        daid.value="";
      
      }
     //input.focus();
 }
 function checkdateforcurr(input) {

     var flagret = "T";
     var dateformat=document.getElementById('hiddendateformat').value;
     //==================To enter Date Without "/" ============================//
     var dateInitial = "20";
     var dateenter = input.value;
     if (dateenter.indexOf('/') < 0) {
         var date12 = "";
         flagret = "F"
         if (dateformat == "mm/dd/yyyy") {
             if (dateenter.length >= "8")
                 date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateenter.substring(4, 8);
             else if (dateenter.length >= "6")
                 date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateInitial + dateenter.substring(4, 6);
             else
                 date12 = input.value;
         }
         if (dateformat == "yyyy/mm/dd") {
             if (dateenter.length >= "8")
                 date12 = dateenter.substring(0, 4) + "/" + dateenter.substring(4, 6) + "/" + dateenter.substring(6, 8);
             else if (dateenter.length >= "6")
                 date12 = dateInitial + dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateenter.substring(4, 6);
             else
                 date12 = input.value;
         }
         if (dateformat == "dd/mm/yyyy") {
             if (dateenter.length >= "8")
                 date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateenter.substring(4, 8);
             else if (dateenter.length >= "6")
                 date12 = dateenter.substring(0, 2) + "/" + dateenter.substring(2, 4) + "/" + dateInitial + dateenter.substring(4, 6);
             else
                 date12 = input.value;
         }
         input.value = date12;
     }
     //==============================================================================//
 
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

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
//alert(document.activeElement.id);
//alert(" Please Fill The Date In "+dateformat+" Format");
//popUpCalendar(document.activeElement,document.activeElement,dateformat);
setTimeout(settime12,15);
daid=input;
//return false;
return;
}
else
{ //Detailed check for valid date ranges
if(dateformat=="yyyy/mm/dd")

{
var yearfield=input.value.split("/")[0]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[2]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[0]
var dayfield=input.value.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
}

//if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}

  var currdate=document.getElementById('txtdatetime').value;
  if(dateformat=="yyyy/mm/dd")
{
var yearfield=currdate.split("/")[0]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[2]
var currd = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[0]
var dayfield=currdate.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)
}
     
        var rodate=new Date(input.value);
        //dayobj is rodate
        if(dayobj>currd)
        {
                alert("Ro date should be less than or equal to current date");
                document.getElementById('txtrodate').focus();
                input.value="";
                 returnval=false;
        }
        else
            returnval=true
 


if (returnval==false) 

input.select()
//return returnval //***Changed By Kuldeep
if (flagret == "F")
    return false;
else
    return returnval;
}
// JScript File

 function checkdateforDatetime(input)
 {
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

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
//alert(document.activeElement.id);
//alert(" Please Fill The Date In "+dateformat+" Format");
//popUpCalendar(document.activeElement,document.activeElement,dateformat);
setTimeout(settime12,15);
daid=input;
//return false;
return;
}
else
{ //Detailed check for valid date ranges
if(dateformat=="yyyy/mm/dd")

{
var yearfield=input.value.split("/")[0]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[2]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[0]
var dayfield=input.value.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
}

//if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}
}

////////////////////////new function bhanu///////////
function checkdateforDatetime_c(input)
 {
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

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
setTimeout(settime12,15);
daid=input;
return;
}
else
{ 
if(dateformat=="yyyy/mm/dd")

{
var yearfield=input.value.split("/")[0]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[2]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[0]
var dayfield=input.value.split("/")[1]
var dayobj = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[0]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
}

var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}

/*************   gk *****************************/
      var pcompcode=document.getElementById('hiddencompcode').value;
      
      var puserid= document.getElementById('hiddenuserid').value
      var pentrydate=document.getElementById('txtdatetime').value
      var pdateformat=document.getElementById('hiddendateformat').value;
      var pextra1=""
      var pextra2=""
      if(pdateformat=="dd/mm/yyyy")
      {
        var tmpdata=pentrydate.split("/")
        seldt=tmpdata[1]+"/"+tmpdata[0]+"/"+tmpdata[2]
      }  
      else if(pdateformat=="yyyy/mm/dd")
      {
        var tmpdata=pentrydate.split("/")
        seldt=tmpdata[1]+"/"+tmpdata[2]+"/"+tmpdata[0]
      }  
      var dt=new Date()
      var seldt=new Date(seldt)
      if(dt.toString().substring(0,10)!=seldt.toString().substring(0,10))
      {
            var ds=Classified_Booking.backdate_validate(pcompcode,pformname,puserid,pentrydate,pdateformat,pextra1,pextra2);
            if(ds.error!=null)
            {
                alert(ds.error);
                return false;
            }
            else if(ds.value=='N')
            {
                alert('You can not enter data for this date !!');
                document.getElementById('txtdatetime').focus();
                return false;
            }
            else
            {
            }
      }



}

function checkdateforDatetime_b(input)
 {
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

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
setTimeout(settime12,15);
daid=input;
return;
}
else
{ 
if(dateformat=="yyyy/mm/dd")

{
var yearfield=input.value.split("/")[0]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[2]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[0]
var dayfield=input.value.split("/")[1]
var dayobj = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[0]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
}

var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}

/*************   gk *****************************/
      var pcompcode=document.getElementById('hiddencompcode').value;
      //var pformname="Booking_master"
      var puserid= document.getElementById('hiddenuserid').value
      var pentrydate=document.getElementById('txtdatetime').value
      var pdateformat=document.getElementById('hiddendateformat').value;
      var pextra1=""
      var pextra2=""
      if(pdateformat=="dd/mm/yyyy")
      {
        var tmpdata=pentrydate.split("/")
        seldt=tmpdata[1]+"/"+tmpdata[0]+"/"+tmpdata[2]
      }  
      else if(pdateformat=="yyyy/mm/dd")
      {
        var tmpdata=pentrydate.split("/")
        seldt=tmpdata[1]+"/"+tmpdata[2]+"/"+tmpdata[0]
      }  
      var dt=new Date()
      var seldt=new Date(seldt)
      if(dt.toString().substring(0,10)!=seldt.toString().substring(0,10))
      {
            var ds=Booking_master.backdate_validate(pcompcode,pformname,puserid,pentrydate,pdateformat,pextra1,pextra2);
            if(ds.error!=null)
            {
                alert(ds.error);
                return false;
            }
            else if(ds.value=='N')
            {
                alert('You can not enter data for this date !!');
                document.getElementById('txtdatetime').focus();
                return false;
            }
            else
            {
            }
      }



}
function compareDatewithBilledDate(dateformat,insertiondate,billdate,status,finalstatus)
{
var currdate=document.getElementById('currdate').value;
var insertiondateD=insertiondate;
var billdateD=billdate;
  if(dateformat=="yyyy/mm/dd")
{
var yearfield=currdate.split("/")[0]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[2]
var currd = new Date(yearfield, monthfield-1, dayfield);
yearfield=insertiondate.split("/")[0]
monthfield=insertiondate.split("/")[1]
dayfield=insertiondate.split("/")[2]
insertiondateD= new Date(yearfield, monthfield-1, dayfield);
yearfield=billdate.split("/")[0]
monthfield=billdate.split("/")[1]
dayfield=billdate.split("/")[2]
billdateD= new Date(yearfield, monthfield-1, dayfield);
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[0]
var dayfield=currdate.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)
yearfield=insertiondate.split("/")[2]
monthfield=insertiondate.split("/")[0]
dayfield=insertiondate.split("/")[1]
insertiondateD= new Date(yearfield, monthfield-1, dayfield);
yearfield=billdate.split("/")[2]
monthfield=billdate.split("/")[0]
dayfield=billdate.split("/")[1]
billdateD= new Date(yearfield, monthfield-1, dayfield);
}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)
yearfield=insertiondate.split("/")[2]
monthfield=insertiondate.split("/")[1]
dayfield=insertiondate.split("/")[0]
insertiondateD= new Date(yearfield, monthfield-1, dayfield);
yearfield=billdate.split("/")[2]
monthfield=billdate.split("/")[1]
dayfield=billdate.split("/")[0]
billdateD= new Date(yearfield, monthfield-1, dayfield);
}
var flag=false;
//if(insertiondateD > billdateD && insertiondateD>currd)
if(document.getElementById('hiddenrateauditflag').value!="rateaudit")
{
//if(insertiondateD > billdateD && insertiondateD>currd)
    if (insertiondateD >= billdateD && status == "booked" && finalstatus == "billed")
    flag=true;
    
  }
  else
  {flag=true;
  if (insertiondateD < billdateD || (status == "publish"&&finalstatus=="billed"))
    flag=false;
  
  }
return flag;    
}
function getRepeat(currdate,repeatday,dateformat)
{
    if(repeatday=="")
        repeatday="1";
if(dateformat=="yyyy/mm/dd")
{
    var yearfield=currdate.split("/")[0]
    var monthfield=currdate.split("/")[1]
    var dayfield=currdate.split("/")[2]
    var currd = new Date(yearfield, monthfield-1, dayfield);
}
else if(dateformat=="mm/dd/yyyy")

{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[0]
var dayfield=currdate.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)
}
else if(dateformat=="dd/mm/yyyy")
{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)
}
currd.setDate(currd.getDate()+parseInt(repeatday,10));
var d=currd.getDate();
var m=currd.getMonth()+1;
var y=currd.getFullYear();
if(m.toString().length==1)
    m="0"+m;
if(d.toString().length==1)
    d="0"+d;    
if(dateformat=="yyyy/mm/dd")
      currdate=y+ "/" + m + "/" + d;
else if(dateformat=="dd/mm/yyyy")
      currdate=d+ "/" + m + "/" + y;
else if(dateformat=="mm/dd/yyyy")
      currdate=m+ "/" + d + "/" + y;          
 return currdate;            
}