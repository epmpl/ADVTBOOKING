function runclick()
{


var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/REPORT.xml');
    
    var abc= document.getElementById('txttodate').value
      var abc1= document.getElementById('txtfromdate').value

   var alrt;
//    alrt=document.getElementById('lbadtype').innerText;
//    
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('dpdadtype').value=="0")
//        {
//            //alrt.Replace("*","");
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('dpdadtype').focus();
//            return false;
//        }
//    }
//    
//   
//    
//   alrt=document.getElementById('lbadcatgory').innerText;
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('dpadcatgory').value=="0")
//        {
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('dpadcatgory').focus();
//            return false;
//        }
//    } 
  
  alrt=document.getElementById('todate').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter to date ');
            document.getElementById('txttodate').focus();
            return false;
        }
    } 
   
   alrt=document.getElementById('fromdate').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfromdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter From Date.');
            document.getElementById('txtfromdate').focus();
            return false;
        }
    } 
    
    
//        if(document.getElementById('drpdrp2').value=="0")
//        {
//           
//            alert('Please Enter '+ abc);
//            document.getElementById('drpdrp2').focus();
//            return false;
//        }
//  
//    
//  
//        if(document.getElementById('dppubcent').value=="0")
//        {
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('dppubcent').focus();
//            return false;
//        }



  
}


function pivalidation()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate').value
      var abc1= document.getElementById('txtfromdate').value
    var alrt;
    
    alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfromdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtfromdate').focus();
            return false;
        }
    } 
   
   alrt=document.getElementById('lbToDate').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate').focus();
            return false;
      
        }
        
//         if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//        document.getElementById('txtfromdate').value="";
//       document.getElementById('txtfromdate').focus();
//       return false;

//    }
    }
    } 
    
    
    
    function pivalidationnetamt()
{

    
  
        if(document.getElementById('txtfromdate').value=="")
        {
           
            alert('Please Enter from date.');
            document.getElementById('txtfromdate').focus();
            return false;
        }
   
        if(document.getElementById('txttodate').value=="")
        {
           
            alert('Please Enter to date.');
            document.getElementById('txttodate').focus();
            return false;
      
        }
        

    } 
    
    
    
 function checkrundate()
 {  
 var dateformat=document.getElementById('txtfromdate').value;
  var abc=dateformat.split("/");
  var todate = document.getElementById('txttodate').value;
  var splittodate = todate.split("/");
  var dateformat1=document.getElementById('hiddendateformat').value;
  //var abc1 = dateformat1.split("/");
  var thisdate =  new Date();
  
  var dd   = thisdate.getDate();
  var mm   =  thisdate.getMonth()+1;
  var yyyy = thisdate.getYear();
  var label;
      if(document.getElementById('txtfromdate').value!="")
        {
            if(dateformat1=="mm/dd/yyyy")
              {
                     if(abc[2]>yyyy) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfromdate').value="";
                       document.getElementById('txtfromdate').focus();
                       return false;  
                       //break;                                      
                     }
//                     goto label;
                     else if ((abc[2]==yyyy)&&(abc[0]>mm))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfromdate').value="";
                            document.getElementById('txtfromdate').focus();
                            return false;
                     }
                     else if ((abc[2]==yyyy)&&(abc[0]==mm)&&(abc[1]>dd))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfromdate').value="";
                            document.getElementById('txtfromdate').focus();
                            return false;
                     }
                     
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfromdate').value="";
//                            document.getElementById('txtfromdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfromdate').value="";
//                            document.getElementById('txtfromdate').focus();
//                            return true;
//                         }
                        
                         
                         //label;
                        
                       else if(abc[2]>splittodate[2]) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfromdate').value="";
                       document.getElementById('txtfromdate').focus();
                       return false;  
                       //break;                                      
                     }
                     
                            else if((abc[2] == splittodate[2])&& (abc[0]> splittodate[0]) )
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfromdate').value="";
                              document.getElementById('txtfromdate').focus();
                              return false;  
                           }
                           
                           else if((abc[0] == splittodate[0])&& (abc[2] == splittodate[2]) && (abc[1] > splittodate[1]))
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfromdate').value="";
                              document.getElementById('txtfromdate').focus();
                              return false;
                           }
                           else 
                           {
//                           if(abc[1] < splittodate[1])
//                           { 
//                              alert("From Date should not be greater than To date."); 
//                              document.getElementById('txtfromdate').value="";
//                              document.getElementById('txtfromdate').focus();
//                              return false;
//                           }
                           }
                             }
                                       
              }
}



 function checkrundatenetamt()
 {  
 var dateformat=document.getElementById('txtfromdate').value;
  var abc=dateformat.split("/");
  var todate = document.getElementById('txttodate').value;
  var splittodate = todate.split("/");
  var dateformat1=document.getElementById('hiddendateformat').value;
  //var abc1 = dateformat1.split("/");
  var thisdate =  new Date();
  
  var dd   = thisdate.getDate();
  var mm   =  thisdate.getMonth()+1;
  var yyyy = thisdate.getYear();
  var label;
  
    if(document.getElementById('txtfromdate').value=="")
        {      
            alert('Please select from date')  ;
            document.getElementById('txtfromdate').focus();
            return false;
              
        }
        if(document.getElementById('txttodate').value=="")
        {      
            alert('Please select to date')  ;
            document.getElementById('txttodate').focus();
            return false;
              
        }
  
    if(document.getElementById('drpdrp1').value==document.getElementById('drpdrp2').value)
        {      
            alert('Row and Column can not be same')  ;
            document.getElementById('drpdrp1').focus();
            return false;
              
        }
      if(document.getElementById('txtfromdate').value!="")
        {
            if(dateformat1=="mm/dd/yyyy")
              {
                     if(abc[2]>yyyy) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfromdate').value="";
                       document.getElementById('txtfromdate').focus();
                       return false;  
                       //break;                                      
                     }
//                     goto label;
                     else if ((abc[2]==yyyy)&&(abc[0]>mm))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfromdate').value="";
                            document.getElementById('txtfromdate').focus();
                            return false;
                     }
                     else if ((abc[2]==yyyy)&&(abc[0]==mm)&&(abc[1]>dd))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfromdate').value="";
                            document.getElementById('txtfromdate').focus();
                            return false;
                     }
                     
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfromdate').value="";
//                            document.getElementById('txtfromdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfromdate').value="";
//                            document.getElementById('txtfromdate').focus();
//                            return true;
//                         }
                        
                         
                         //label;
                        
                       else if(abc[2]>splittodate[2]) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfromdate').value="";
                       document.getElementById('txtfromdate').focus();
                       return false;  
                       //break;                                      
                     }
                     
                            else if((abc[2] == splittodate[2])&& (abc[0]> splittodate[0]) )
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfromdate').value="";
                              document.getElementById('txtfromdate').focus();
                              return false;  
                           }
                           
                           else if((abc[0] == splittodate[0])&& (abc[2] == splittodate[2]) && (abc[1] > splittodate[1]))
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfromdate').value="";
                              document.getElementById('txtfromdate').focus();
                              return false;
                           }
                           else 
                           {
//                           if(abc[1] < splittodate[1])
//                           { 
//                              alert("From Date should not be greater than To date."); 
//                              document.getElementById('txtfromdate').value="";
//                              document.getElementById('txtfromdate').focus();
//                              return false;
//                           }
                           }
                             }
                                       
              }
              
              
       
              
              var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 }       
              
              
}





function validdate()
{

if(event.keyCode<= 57 && event.keyCode>=47)
{
//document.getElementById('txttodate').value
return true;
}
else
{
alert('plz enter only numeric value');
 document.getElementById('txttodate').value="";
 document.getElementById('txttodate').focus();
 return false;

}
}
function validdate1()
{

if(event.keyCode<= 57 && event.keyCode>=47)
{
//document.getElementById('txttodate').value
return true;
}
else
{
alert('plz enter only numeric value');
 document.getElementById('txttodate').value="";
 document.getElementById('txttodate').focus();
 return false;

}
}


function dateformate()

    {
    //var abc=new data('txtfromdate')
      var abc= document.getElementById('txttodate').value
      var abc1= document.getElementById('txtfromdate').value


       if(document.getElementById('txttodate').value!="")
       {
//    if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txttodate').value="";
//          document.getElementById('txttodate').focus();
//       return false;

//    }
    }
    }
    
    
    function incorrectfromdate(input)
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

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{
	
		if(input.value=="")
		{
		//input.focus();
		return true;
		}
		
		alert(" Please Fill The Date In "+dateformat+" Format");
		document.getElementById('txtfromdate').value="";
		document.getElementById('txtfromdate').focus();
		
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}

function incorrectodate(input)
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

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{
	
		if(input.value=="")
		{
		//input.focus();
		return true;
		}
		
		alert(" Please Fill The Date In "+dateformat+" Format");
		
		
		document.getElementById('txttodate').value="";
		document.getElementById('txttodate').focus();
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}







function compareDates()
{
var fromDate=document.getElementById('txtfromdate').value;
var toDate=document.getElementById('txttodate').value;
var splitChar="";
if(fromDate .indexOf ("/")>=0)
{
splitChar="/";
}
else if(fromDate .indexOf("-")>=0)
{
splitChar ="-";
}
else if(fromDate .indexOf(".")>=0)
{
splitChar =".";
}

var fromDateArray=fromDate .split(splitChar );
var toDateArray=toDate .split(splitChar);
if(document.getElementById('hiddendateformat').value="dd/mm/yyyy")
{
    var from_day=parseInt(fromDateArray [0],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [2],10);
    
    var to_day=parseInt(toDateArray [0],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [2],10);
}
else if(document.getElementById('hiddendateformat').value="mm/dd/yyyy")
{
    var from_day=parseInt(fromDateArray [1],10);
    var from_month=parseInt (fromDateArray  [0],10);
    var from_year=parseInt (fromDateArray  [2],10);

    var to_day=parseInt(toDateArray [1],10);
    var to_month=parseInt(toDateArray [0],10);
    var to_year=parseInt(toDateArray [2],10);

}
else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
{
    var from_day=parseInt(fromDateArray [2],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [0],10);

    var to_day=parseInt(toDateArray [2],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [0],10);

}
    if(to_year >from_year )
    {
        return true;
    }
    else
    {
        if(to_year ==from_year && to_month >from_month)
        {
            return true;
        }
        else if(to_year ==from_year && to_month ==from_month && to_day >=from_day )
            {
                return true;
                
            }
        else
        {    
        alert("From Date should be less than To date.");
                document.getElementById('txtfromdate').focus();
                return false;
        }
       
    }

}


