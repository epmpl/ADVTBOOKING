
var browser=navigator.appName;
function checkSession()
{
    if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
            httpRequest.open( "GET","sessiontimeout.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtext=httpRequest.responseText;
                    if(strtext=="yes")
                    {
                        alert("Session Expired. Please Login Again");
                        window.location.href="login.aspx";
                        return false;
                    }    
                }
                else 
                {
                     alert("Session Expired. Please Login Again");
                     window.location.href="login.aspx";
                     return false;
                }
            }
        }
        else
        {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            // var adcat=document.getElementById('drpadcategory').value;
             xml.Open( "GET","sessiontimeout.aspx", false );
             xml.Send();
             strtext=xml.responseText;
             if(strtext=="yes")
               {
                    alert("Session Expired. Please Login Again");
                   window.location.href="login.aspx";
                    return false;
               }    
        }
}        
function ClientUpperCase(q)
{
	//ClientisNumber();
	document.getElementById(q).value=trim(document.getElementById(q).value.toUpperCase());
	return false;
}


//URL Check Validator Function		
function ClientUrlCheck(q)
 {
     var theurl=document.Form1.txtUrl.value;
	 var tomatch= /[A-Za-z0-9\.-]{3,}\.[A-Za-z]{3}/
     if (tomatch.test(theurl) || document.getElementById('txtUrl').value=="")
     {
		return true;
     }
     else
     {
         window.alert("Invalid URL ");
         document.getElementById(q).focus();
         return false; 
     }
}

//Email Validator

function ClientEmailCheck(q) 
{
	var theurl=document.Form1.txtemailid.value;

	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value=="")
	{
		return (true)
	}
	alert("Invalid E-mail Address! Please re-enter.")
	document.getElementById(q).focus();
	return (false)
}


//Number Only Validator

function ClientisNumber(event)
{
var browser=navigator.appName;
//alert(event.which);
if(event.shiftKey==true)
    return false;
 if(browser!="Microsoft Internet Explorer")
 {
	if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==0) || (event.which==8) ||(event.which==11)|| (event.which==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}
else
{
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}	
	
}
//Special Character Check Validator Function
function ClientSpecialchar(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)|| (event.which==0) ||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||( event.which==32)||(event.which>=65 && event.which<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
 }
 else
 {
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}	
}

//Character Check Validator Function
function Clientchar()
{
	if((event.keyCode==32) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{	
		return false;
	}
}

//Pan Card Check Validator Function
function ClientPanchar()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)|(event.keyCode==9)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||event.keyCode>=65 && event.keyCode<=90)
	{
		return true;
	}
	else
	{
		return false;
	}
}



/*=============================================================================================*/


//Validations
function UpperCase(q)
{
	document.getElementById(q).value=document.getElementById(q).value.toUpperCase();
	return false;
}

function Specialchar()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode==37)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}
function charValidate()
{
	if((event.keyCode==32) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{	
		return false;
	}
}


function categorychar()
{
	if((event.keyCode==32) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11))
	{
		return true;
	}
	else
	{	
		return false;
	}
}

function RetCheckdate(input)
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
		alert(" Please Fill The Date In "+dateformat+" Format");
		return false;
	}
}

//Remove Space

function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}
//function check()
//{
//    document.getElementById('TextBox1').value=trim(document.getElementById('TextBox1').value);
//    alert(document.getElementById('TextBox1').value);
//    return false;
//}

function Multiply(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
	if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==8) || (event.which==0) ||(event.which==11)||(event.which==46))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}
else
{
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)||(event.keyCode==46))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}	
} 
function StringBuilder(value)
{
    this.strings = new Array("");
    this.append(value);
}

// Appends the given value to the end of this instance.

StringBuilder.prototype.append = function (value)
{
    if (value)
    {
        this.strings.push(value);
    }
}

// Clears the string buffer

StringBuilder.prototype.clear = function ()
{
    this.strings.length = 1;
}

// Converts this instance to a String.

StringBuilder.prototype.toString = function ()
{
    return this.strings.join("");
}

function notchar2_book(event,strValue) 
{
var num=document.getElementById(strValue.id).value;
////var tomatch=/^\d*(\.\d{1,2})?$/;
//if (tomatch.test(num))
var res=rateenter12(event);
if(res==false)
    return false;
if(document.getElementById(strValue.id).value.indexOf(".")>=0)
{
if(event.keyCode==46)
{
alert("Input error");
document.getElementById(strValue.id).value="";
document.getElementById(strValue.id).focus();
return false;
}
else
return true; 
}
else
{
//alert("Input error");
//document.getElementById(strValue.id).value="";
//document.getElementById(strValue.id).focus();

return true; 

}
 }
 function rateenter12(evt)
{
//alert(evt.keyCode);
var charCode = (evt.which) ? evt.which : event.keyCode
if((charCode>=46 && charCode<=57 && charCode!=47)||(charCode==127)||(charCode==8)||(charCode==9))
{
return true;
}
else
{
return false;
}
 }


 function CHKDATE(userdate) {
     var mycondate = ""
     if (userdate == null || userdate == "") {
         mycondate = ""
         userdate = "";
         return mycondate
     }
     var dateformate = document.getElementById('hiddendateformat').value;
     if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
         var spmonth = "'" + userdate + "'";
         var pp = spmonth.split(" ");
         var mon = pp[1];
         var myDate = new Date(userdate);
         var date = myDate.getDate();

         if (date == 1 || date == 2 || date == 3 || date == 4 || date == 5 || date == 6 || date == 7 || date == 8 || date == 9)
             date = "0" + date;
         var month = myDate.getMonth() + 1;
         if (month == 1 || month == 2 || month == 3 || month == 4 || month == 5 || month == 6 || month == 7 || month == 8 || month == 9)
             month = "0" + month;
         var year = myDate.getFullYear();
         mycondate = date + "/" + month + "/" + year;
         return mycondate;
     }
     else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
         var spmonth = "'" + userdate + "'";
         var pp = spmonth.split(" ");
         var mon = pp[1];
         var myDate = new Date(userdate);
         var date = myDate.getDate();
         var month = myDate.getMonth() + 1;
         var year = myDate.getFullYear();
         mycondate = month + "/" + date + "/" + year;
         return mycondate;
     }
     else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
         var spmonth = "'" + userdate + "'";
         var pp = spmonth.split(" ");
         var mon = pp[1];
         var myDate = new Date(userdate);
         var date = myDate.getDate();
         var month = myDate.getMonth() + 1;
         var year = myDate.getFullYear();
         mycondate = year + "/" + month + "/" + date;
         return mycondate;
     }
 }

 function padDigits(number, digits) {
     return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
 }