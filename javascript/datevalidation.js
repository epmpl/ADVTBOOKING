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

var browser = navigator.appName;
 var daid;
 function abc()
 {
    alert('hit');
   
    
 }
 function settime1()
 {
     var dateformat=document.getElementById('hiddendateformat').value;
     if(document.activeElement.id.indexOf('dan')<0 && daid.id!='')
     {
        alert(" Please Fill The Date In "+dateformat+" Format");
        daid.focus();
        daid.value="";
        
      }
     //input.focus();
 }
 function checkdate(input) {
     var flagret = "T";
     var dateformat = document.getElementById('hiddendateformat').value;
     //==================To enter Date Without "/" ============================//
     var dateInitial = "20";
     var dateenter = input.value;
     if (dateenter.indexOf('/') < 0) {
         var date12 = "";
         flagret = "F";
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
 
 //var dateformat=document.getElementById('hiddendateformat').value;
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
setTimeout(settime1,15);
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


 
returnval=true
 


if (returnval==false) 

input.select()
//return returnval//****Changed by Kuldeep Bhati
if (flagret == "F")
    return false;
else
    return returnval;
}
function dateenter(event)
{
var key = event.keyCode ? event.keyCode : event.which;
//if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))

if ((key >= 46 && key <= 57) || (key == 38) || (key == 40) || (key == 111) || (key == 127) || (key == 191) || (key == 8) || (key == 9) || (key == 13) || (key >= 96 && key <= 105))

//if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
//if((event.keyCode>=46 && event.keyCode<=57) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13)|| (event.keyCode>=96 && event.keyCode<=105))
{
return true;
}
else
{
return false;
}
}
