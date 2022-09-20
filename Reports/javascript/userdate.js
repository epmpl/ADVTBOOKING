// Declaring valid date character, minimum year and maximum year
var dtCh= "/";
var minYear=1900;
var maxYear=2100;
var chk_user_flag="False"
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

function isDate(dtStr,txtid,dateformat,hiddenvalue)
{
   
        if(trim(document.getElementById(txtid).value)=="")
        {
            document.getElementById(txtid).value="";
        }


                else
                {
           
                       if(document.getElementById(dateformat.id).value=="mm/dd/yyyy")
                     {
                       
	                    var daysInMonth = DaysArray(12);
	                    var pos1=dtStr.indexOf(dtCh);
	                    var pos2=dtStr.indexOf(dtCh,pos1+1);
	                    var strMonth=dtStr.substring(0,pos1);
	                    var strDay=dtStr.substring(pos1+1,pos2);
	                    var strYear=dtStr.substring(pos2+1);
	                    strYr=strYear;
	                    if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	                    if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	                    for (var i = 1; i <= 3; i++) 
	                    {
		                    if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	                    }
	                    month=parseInt(strMonth);
	                    day=parseInt(strDay);
	                    year=parseInt(strYr);
	                    if (pos1==-1 || pos2==-1)
	                    {
		                    alert("The date format should be : mm/dd/yyyy")
		                    chk_user_flag="true"
		                    document.getElementById(txtid).focus();
		                    return false;
	                    }
                    }
	
	
	            else if((document.getElementById(dateformat.id).value=="dd/mm/yyyy"))
            {
	            var daysInMonth = DaysArray(12);
	            var pos1=dtStr.indexOf(dtCh);
	            var pos2=dtStr.indexOf(dtCh,pos1+1);
	            var strDay=dtStr.substring(0,pos1);
	            var strMonth=dtStr.substring(pos1+1,pos2);
	            var strYear=dtStr.substring(pos2+1);
	            strYr=strYear;
	            if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	            if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	            for (var i = 1; i <= 3; i++) 
	            {
		            if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	            }
	            day=parseInt(strDay);
	            month=parseInt(strMonth);
	            year=parseInt(strYr);
	            if (pos1==-1 || pos2==-1)
	            {
		            alert("The date format should be : dd/mm/yyyy")
		            chk_user_flag="true"
		            document.getElementById(txtid).focus();
		            return false;
	            }
	           
            }


                  
                   else
                   
                {

                    var daysInMonth = DaysArray(12);
	                var pos1=dtStr.indexOf(dtCh);
	                var pos2=dtStr.indexOf(dtCh,pos1+1);
	                var strYear=dtStr.substring(0,pos1);
	                var strMonth=dtStr.substring(pos1+1,pos2);
	                var strDay=dtStr.substring(pos2+1);
	                strYr=strYear;
	                if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	                if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	                for (var i = 1; i <= 3; i++) 
	                {
		                if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	                }
	                day=parseInt(strDay);
	                month=parseInt(strMonth);
	                year=parseInt(strYr);
	                if (pos1==-1 || pos2==-1)
	                {
		                alert("The date format should be : yyyy/mm/dd")
		                chk_user_flag="true"
		                document.getElementById(txtid).focus();
		                return false;
	                }
	                else
	                {
	                     chk_user_flag="False"
	                }
                }
                
            
	
	            
	            if (strMonth.length<1 || month<1 || month>12)
	            {
		            alert("Please enter a valid month")
		            chk_user_flag="true"
		            document.getElementById(txtid).focus();
		            return false;
	            }
	else
	{
	     chk_user_flag="False"
	}
	
	            if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
	            {
		            alert("Please enter a valid day")
		            chk_user_flag="true"
		            document.getElementById(txtid).focus();
		            return false;
	            }
	            else
	            {
	                 chk_user_flag="False"
	            }
	
	
	            if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
	            {
		            alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		            chk_user_flag="true"
		            document.getElementById(txtid).focus();
		            return false;
	            }
	            else
	            {
	                 chk_user_flag="False"
	            }
	            
	            
	            if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
	            {
		            alert("Please enter a valid date")
		            chk_user_flag="true"
		            document.getElementById(txtid).focus();
		            return false;
	            }
	            else
	            {
	                 chk_user_flag="False"
	            }
	
	
	}
//	if(chk_user_flag=="False")
//	{
//	   if(Date.parse(dtStr)<Date.parse(hiddenvalue))
//	    {
//	        alert('Please select date greater then today date');
//	        document.getElementById(txtid).value=""
//	        document.getElementById(txtid).focus();
//	        
//	        chk_user_flag="False"
//	    }
//	}
	
	if(txtid == "txtPVTodate")
	{
	     chkdate11();   
	}
	else if(txtid == "txttilldate")
	{
	     chkdate12(); 
	}
}

function chkdate11()
{
    var todate  = document.getElementById('txtPVTodate').value;
    var fromdate = document.getElementById('txtPVFromdate').value;
    
    if((todate != "")&&(fromdate != ""))
    {
       if(fromdate>todate)   
       {
               alert('Please Select tilldate greater than or equal to fromdate.');
               document.getElementById('txtPVTodate').value = "";
               document.getElementById('txtPVTodate').focus();
               return false;
       }
    }


}


function chkdate12()
{
    var todate  = document.getElementById('txttilldate').value;
    var fromdate = document.getElementById('txtvalidityfrom').value;
    
    if((todate != "")&&(fromdate != ""))
    {
       if(fromdate>todate)   
       {
               alert('Please Select todate greater than or equal to fromdate.');
               document.getElementById('txttilldate').value = "";
               document.getElementById('txttilldate').focus();
               return false;
       }
    }


}


function trim(stringToTrim) 
 {
	 return stringToTrim.replace(/^\s+|\s+$/g,"");
 }