// JScript File
//----------------------------------------------------------------------------------------------------------

function datevalidation()

{  
  var dateformat=document.getElementById('txtfrmdate').value;
  var abc=dateformat.split("/");
  var todate = document.getElementById('txttodate1').value;
  var splittodate = todate.split("/");
  var dateformat1=document.getElementById('hiddendateformat').value;
  //var abc1 = dateformat1.split("/");
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
                     
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;
//                         }
                        
                         
                         //label;
                        
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
//                           if(abc[1] < splittodate[1])
//                           { 
//                              alert("From Date should not be greater than To date."); 
//                              document.getElementById('txtfrmdate').value="";
//                              document.getElementById('txtfrmdate').focus();
//                              return false;
//                           }
                           }
                     }
                     else if(dateformat1=="dd/mm/yyyy")
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
                     else if ((abc[2]==yyyy)&&(abc[1]>mm))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     else if ((abc[2]==yyyy)&&(abc[1]==mm)&&(abc[0]>dd))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;
//                         }
                        
                         
                         //label;
                        
                       else if(abc[2]>splittodate[2]) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfrmdate').value="";
                       document.getElementById('txtfrmdate').focus();
                       return false;  
                       //break;                                      
                     }
                     
                            else if((abc[2] == splittodate[2])&& (abc[1]> splittodate[1]) )
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;  
                           }
                           
                           else if((abc[1] == splittodate[1])&& (abc[2] == splittodate[2]) && (abc[0] > splittodate[0]))
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;
                           }
                           else 
                           {
//                           if(abc[1] < splittodate[1])
//                           { 
//                              alert("From Date should not be greater than To date."); 
//                              document.getElementById('txtfrmdate').value="";
//                              document.getElementById('txtfrmdate').focus();
//                              return false;
//                           }
                           }
                     }
                     
                     else if(dateformat1=="yyyy/mm/dd")
                     {
                           if(abc[0]>yyyy) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfrmdate').value="";
                       document.getElementById('txtfrmdate').focus();
                       return false;  
                       //break;                                      
                     }
//                     goto label;
                     else if ((abc[0]==yyyy)&&(abc[1]>mm))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     else if ((abc[0]==yyyy)&&(abc[1]==mm)&&(abc[2]>dd))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;
//                         }
                        
                         
                         //label;
                        
                       else if(abc[0]>splittodate[0]) 
                     {   
//                       alert("From Date should not be greater than current date."); 
//                       document.getElementById('txtfrmdate').value="";
//                       document.getElementById('txtfrmdate').focus();
//                       return false;  
                       //break;                                      
                     }
                     
                            else if((abc[0] == splittodate[0])&& (abc[1]> splittodate[1]) )
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;  
                           }
                           
                           else if((abc[1] == splittodate[1])&& (abc[0] == splittodate[0]) && (abc[2] > splittodate[2]))
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;
                           }
                           else 
                           {
//                           if(abc[1] < splittodate[1])
//                           { 
//                              alert("From Date should not be greater than To date."); 
//                              document.getElementById('txtfrmdate').value="";
//                              document.getElementById('txtfrmdate').focus();
//                              return false;
//                           }
                           }
                     }
                                       
              }
        }
 

   
function pivalidation()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
    alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
   
   alrt=document.getElementById('lbToDate').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        
//         if(abc<abc1)
//    {
//        
//       //alert('todate cant be less from fromdate ');
//       alert('Fromdate should not be greater then Todate')
//       document.getElementById('txtfrmdate').value="";
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }

    }
  } 


function validdate()
{

        if(event.keyCode<= 57 && event.keyCode>=47)
        {
        //document.getElementById('txttodate1').value
        return true;
        }
        else
        {

        alert('plz enter only numeric value');
         document.getElementById('txtfrmdate').value="";
         document.getElementById('txtfrmdate').focus();
        return false;
        }
}
function validdate1()
{

    if(event.keyCode<= 57 && event.keyCode>=48)
    {
    //document.getElementById('txttodate1').value
    return true;
    }
    else
    {
     alert('plz enter only numeric value');
     document.getElementById('txttodate1').value="";
     document.getElementById('txttodate1').focus();
     return false;
    }
}



//function incorrectdate()
//{
////    var str= document.getElementById('txtfrmdate').value;
////    var str1 = str.indexof('/');
////    alert()



//  var fromdate=document.getElementById('txtfrmdate').value;
//  var todate = document.getElementById('txttodate1').value;


//          if(fromdate != "mm/dd/yyyy")
//          { 
////                 alert('Plz fill date in correct formate');
//                 document.getElementById('txtfrmdate').value="";
//                 document.getElementById('txtfrmdate').focus();
//           }
//         if(todate != "mm/dd/yyyy")
//           {
//                  alert('Plz fill date in correct formate');
//                  document.getElementById('txttodate1').value="";
//                  document.getElementById('txttodate1').focus();
//           }
//       
//   
//}

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
		document.getElementById('txtfrmdate').value="";
		document.getElementById('txtfrmdate').focus();
		
		
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
		
		
		document.getElementById('txttodate1').value="";
		document.getElementById('txttodate1').focus();
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}
 
 





