// JScript File


 var daid;
 function abc()
 {
    alert('hit');
   
    
 }
 function settime1forbook()
 {
     var dateformat=document.getElementById('hiddendateformat').value;
     if(document.activeElement.id.indexOf('dan')<0 && document.activeElement.id!='')
     {
        alert(" Please Fill The Date In "+dateformat+" Format");
        //daid.focus();
        daid.value="";
        return false;
      }
     //input.focus();
 }
 function checkdateforbook(input)
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
setTimeout(settime1forbook,15);
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
input.select()
input.value="";
input.focus();
return false;
}


 
returnval=true
 


if (returnval==false) 

input.select()

        var currdate=document.getElementById('txtdatetime').value;
		var fromdate=currdate;
		var todate=input.value;
		
		var dateformat=document.getElementById('hiddendateformat').value;
		//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                if(fromdate.indexOf('-')>=0)
                {
                    var txt=fromdate;
                    var txt1=txt.split("-");
                    var dd=txt1[0];
                    var mm1=txt1[1];
                    var mm = getMonthNo(mm1);
                    var yy=txt1[2];
                    fromdate=mm+'/'+dd+'/'+yy;
                }
                else
                {
                    var txt=fromdate;
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm1=txt1[1];
                    var mm = txt1[1];//getMonthNo(mm1);
                    var yy=txt1[2];
                    fromdate=mm+'/'+dd+'/'+yy;
                }
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
		
		if(document.getElementById('drppackage').value=="0")
	{
	    alert("Please Select Package");
	    if(document.getElementById('drppackage').disabled==false)
	    {
	    document.getElementById('drppackage').focus();
	    }
	    return false;
	}
		
		
		if(tdate<fdate && (document.getElementById('hiddenbackdatebook').value=="0" || document.getElementById('hiddenbackdatebook').value=="N"))
		{
		
		alert("Booking Date can't Be Less than Current Date");
		input.value="";
		input.focus();
		return false;
		}
		var checkflag="0";
	//	var cali=0;
		//var countGridElement=0;
		var st;
		var k=0;
		// insertLine();
		  if(checkflag=="0")
	    {
	        
		         for(k=0;k<countGridElement;k++)
	                {
	                    		 
                        if(date1.toString().length==1)
                        {
                            date1="0"+date1;
                        }
	                    caldate[cali]=date1;
	                    if(abcd.toString().length==1)
	                        abcd="0"+abcd;
	                    caldatemonth[cali]=abcd;
	                    caldateyear[cali]=year1;
	                    st = parseInt(cali);
        	            if(document.getElementById('Text'+st)==null)
        	            {
        	                document.getElementById('chktfn').focus();
        	                return false;
        	            }    
	                    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldatemonth[cali] + "/" + caldate[cali] + "/" + caldateyear[cali];
	                        }    
	                    }
	                    else if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldate[cali] + "/" + caldatemonth[cali] + "/" + caldateyear[cali];
	                         }   
	                    }
	                    else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldateyear[cali] + "/" + caldatemonth[cali] + "/" + caldate[cali];;
	                        }    
	                    }
	                    cali=cali+1;
	                }
	               
	        }
return returnval;

}


 function checkdateforbook_b(input)
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
setTimeout(settime1forbook,15);
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
input.select()
input.value="";
input.focus();
return false;
}


 
returnval=true
 


if (returnval==false) 

input.select()

        var currdate=document.getElementById('txtdatetime').value;
		var fromdate=currdate;
		var todate=input.value;
		
		var dateformat=document.getElementById('hiddendateformat').value;
		//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                if(fromdate.indexOf('-')>=0)
                {
                    var txt=fromdate;
                    var txt1=txt.split("-");
                    var dd=txt1[0];
                    var mm1=txt1[1];
                    var mm = getMonthNo(mm1);
                    var yy=txt1[2];
                    fromdate=mm+'/'+dd+'/'+yy;
                }
                else
                {
                    var txt=fromdate;
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm1=txt1[1];
                    var mm = txt1[1];//getMonthNo(mm1);
                    var yy=txt1[2];
                    fromdate=mm+'/'+dd+'/'+yy;
                }
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
		
		if(document.getElementById('drppackage').value=="0")
	{
	    alert("Please Select Package");
	    if(document.getElementById('drppackage').disabled==false)
	    {
	    document.getElementById('drppackage').focus();
	    }
	    return false;
	}
		
		
		if(tdate<fdate && (document.getElementById('hiddenbackdatebook').value=="0" || document.getElementById('hiddenbackdatebook').value=="N"))
		{
		
		alert("Booking Date can't Be Less than Current Date");
		input.value="";
		input.focus();
		return false;
		}
		//for backdays check
		 var pcompcode=document.getElementById('hiddencompcode').value;
      var pformname="Booking_master"
      var puserid= document.getElementById('hiddenuserid').value
      var pentrydate=document.getElementById('txtdummydate').value
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
                 document.getElementById('txtdummydate').value="";
                document.getElementById('txtdummydate').focus();
                return false;
            }
            else
            {
            }
      }
		var checkflag="0";
	//	var cali=0;
		//var countGridElement=0;
		var st;
		var k=0;
		// insertLine();
		  if(checkflag=="0")
	    {
	        
		         for(k=0;k<countGridElement;k++)
	                {
	                    		 
                        if(date1.toString().length==1)
                        {
                            date1="0"+date1;
                        }
	                    caldate[cali]=date1;
	                    if(abcd.toString().length==1)
	                        abcd="0"+abcd;
	                    caldatemonth[cali]=abcd;
	                    caldateyear[cali]=year1;
	                    st = parseInt(cali);
        	            if(document.getElementById('Text'+st)==null)
        	            {
        	                document.getElementById('chktfn').focus();
        	                return false;
        	            }    
	                    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldatemonth[cali] + "/" + caldate[cali] + "/" + caldateyear[cali];
	                        }    
	                    }
	                    else if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldate[cali] + "/" + caldatemonth[cali] + "/" + caldateyear[cali];
	                         }   
	                    }
	                    else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldateyear[cali] + "/" + caldatemonth[cali] + "/" + caldate[cali];;
	                        }    
	                    }
	                    cali=cali+1;
	                }
	               
	        }
return returnval;

}

 function checkdateforbook_c(input)
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
setTimeout(settime1forbook,15);
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
input.select()
input.value="";
input.focus();
return false;
}


 
returnval=true
 


if (returnval==false) 

input.select()

        var currdate=document.getElementById('txtdatetime').value;
		var fromdate=currdate;
		var todate=input.value;
		
		var dateformat=document.getElementById('hiddendateformat').value;
		//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                if(fromdate.indexOf('-')>=0)
                {
                    var txt=fromdate;
                    var txt1=txt.split("-");
                    var dd=txt1[0];
                    var mm1=txt1[1];
                    var mm = getMonthNo(mm1);
                    var yy=txt1[2];
                    fromdate=mm+'/'+dd+'/'+yy;
                }
                else
                {
                    var txt=fromdate;
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm1=txt1[1];
                    var mm = txt1[1];//getMonthNo(mm1);
                    var yy=txt1[2];
                    fromdate=mm+'/'+dd+'/'+yy;
                }
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
		
		if(document.getElementById('drppackage').value=="0")
	{
	    alert("Please Select Package");
	    if(document.getElementById('drppackage').disabled==false)
	    {
	    document.getElementById('drppackage').focus();
	    }
	    return false;
	}
		
		
		if(tdate<fdate && (document.getElementById('hiddenbackdatebook').value=="0" || document.getElementById('hiddenbackdatebook').value=="N"))
		{
		
		alert("Booking Date can't Be Less than Current Date");
		input.value="";
		input.focus();
		return false;
		}
		//for backdays check
		 var pcompcode=document.getElementById('hiddencompcode').value;
      var pformname="Classified_Booking"
      var puserid= document.getElementById('hiddenuserid').value
      var pentrydate=document.getElementById('txtdummydate').value
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
                 document.getElementById('txtdummydate').value="";
                document.getElementById('txtdummydate').focus();
                return false;
            }
            else
            {
            }
      }
		var checkflag="0";
	//	var cali=0;
		//var countGridElement=0;
		var st;
		var k=0;
		// insertLine();
		  if(checkflag=="0")
	    {
	        
		         for(k=0;k<countGridElement;k++)
	                {
	                    		 
                        if(date1.toString().length==1)
                        {
                            date1="0"+date1;
                        }
	                    caldate[cali]=date1;
	                    if(abcd.toString().length==1)
	                        abcd="0"+abcd;
	                    caldatemonth[cali]=abcd;
	                    caldateyear[cali]=year1;
	                    st = parseInt(cali);
        	            if(document.getElementById('Text'+st)==null)
        	            {
        	                document.getElementById('chktfn').focus();
        	                return false;
        	            }    
	                    if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldatemonth[cali] + "/" + caldate[cali] + "/" + caldateyear[cali];
	                        }    
	                    }
	                    else if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldate[cali] + "/" + caldatemonth[cali] + "/" + caldateyear[cali];
	                         }   
	                    }
	                    else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
	                    {
	                        if(document.getElementById('Text'+st).value=='')
	                        {
	                            document.getElementById('Text'+st).value=caldateyear[cali] + "/" + caldatemonth[cali] + "/" + caldate[cali];;
	                        }    
	                    }
	                    cali=cali+1;
	                }
	               
	        }
return returnval;

}