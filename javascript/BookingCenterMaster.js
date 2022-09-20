// JScript File
var dsbcmexecute;
 var gbbookingcode;
 var gbbookingname;
 var gbpubname;
 var gbpubcity;
function bookingnew()
{
		document.getElementById('txtbookcentercode').value="";
		document.getElementById('txtbookcentername').value="";
		document.getElementById('drpubcentname').value="0";
		document.getElementById('txtpubctcity').value="";
			
		if(document.getElementById('hiddenauto').value==1)
		 {
		document.getElementById('txtbookcentercode').disabled=true;
    	 }
		else
		 {
		 document.getElementById('txtbookcentercode').disabled=false;
    	 }
		
		document.getElementById('txtbookcentername').disabled=false;
		document.getElementById('drpubcentname').disabled=false;
		//document.getElementById('txtpubctcity').disabled=false;
		
		chkstatus(FlagStatus);
			hiddentext="new";	
		
	
		flag=0;
		
		document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=false;
		document.getElementById('btnQuery').disabled=true;
		
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;
		
		
		
		
		return false;
}



function bookingdelete()
{
		var bookcode=document.getElementById('txtbookcentercode').value;
		var bookname=document.getElementById('txtbookcentername').value;
		var pubname=document.getElementById('drpubcentname').value;
		var pubcity=document.getElementById('txtpubctcity').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
	    boolReturn = confirm("Are you sure you wish to delete this?");
		if(boolReturn==1)
		{
			alert("Data Deleted Successfully");
			BookingCenterMaster.deletebooking(bookcode,compcode,userid); 
			BookingCenterMaster.Select(gbbookingcode, gbbookingname, gbpubname, gbpubcity, compcode, userid,delcall);
		}     
		else
		{
			return false;
		}
		return false;
}
	
function delcall(res)
{
	dsbcmexecute= res.value;
	len=dsbcmexecute.Tables[0].Rows.length;
	
	if(dsbcmexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtbookcentercode').value="";
		document.getElementById('txtbookcentername').value="";
		document.getElementById('drpubcentname').value="0";
		document.getElementById('txtpubctcity').value="";
			
		
		
		bookingcancel('BookingCenterMaster');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[0].Book_Center_Code;
		document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[0].Book_Center_Name;
		document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[0].Pub_cent_Code;
		document.getElementById('txtpubctcity').value=dsbcmexecute.Tables[0].Rows[0].City_Code;
      		
	}
	else
	{
		document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[z].Book_Center_Code;
		document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[z].Book_Center_Name;
		document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[z].Pub_cent_Code;
		document.getElementById('txtpubctcity').value=dsbcmexecute.Tables[0].Rows[z].City_Code;
      	
	}
	
	return false;
}

function bookingcancel(formname)
{
		hiddentext="clear";
		document.getElementById('txtbookcentercode').value="";
		document.getElementById('txtbookcentername').value="";
		document.getElementById('drpubcentname').value="0";
		document.getElementById('txtpubctcity').value="";
	    document.getElementById('txtbookcentercode').disabled=true;
		document.getElementById('txtbookcentername').disabled=true;
		document.getElementById('drpubcentname').disabled=true;
		document.getElementById('txtpubctcity').disabled=true;
		
	
			
		document.getElementById('btnNew').disabled=false;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;
		
		return false;
}

function bookingmodify()
{
		flag=1;
		
		
	    document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=false;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;
		
		chkstatus(FlagStatus);
		
		hiddentext="modify";
		document.getElementById('txtbookcentername').disabled=false;
		document.getElementById('drpubcentname').disabled=false;
		document.getElementById('txtpubctcity').disabled=true;
		return false;
}


function bookingsave()
{

        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        if ((document.getElementById('txtbookcentercode').value=="")&& (document.getElementById('hiddenauto').value!=1))
            {
            alert("Please Enter Booking Center Code");
            document.getElementById('txtbookcentercode').focus();
            return false;
            }
        else if(document.getElementById('txtbookcentername').value=="")
            {
            alert("Please Enter Booking Center Name");
            document.getElementById('txtbookcentername').focus();
            return false;
            }
        else if(document.getElementById('drpubcentname').value=="0")
            {
            alert("Please Enter Publication Center Name");
             document.getElementById('drpubcentname').focus();
            return false;
            }
     
        else if(document.getElementById('txtpubctcity').value=="")
            {
            alert("Please Select Publication Center City");
            document.getElementById('txtpubctcity').focus();
            return false;
            }

      
        var bookingcode=document.getElementById('txtbookcentercode').value;
        var bookingname=document.getElementById('txtbookcentername').value;
        var pubname=document.getElementById('drpubcentname').value;

        var pubcity=document.getElementById('txtpubctcity').value;
      
         if (flag==1)
        {

        BookingCenterMaster.modify(bookingcode, bookingname, pubname, pubcity,  compcode, userid);
        
        document.getElementById('btnSave').disabled=true;
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnNew').disabled=true;
        document.getElementById('btnModify').disabled=false;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnDelete').disabled=true;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        document.getElementById('btnnext').disabled=false;
        document.getElementById('btnlast').disabled=false;
        document.getElementById('btnExit').disabled=false;
        updateStatus();
        
        dsbcmexecute.Tables[0].Rows[z].Book_Center_Code=document.getElementById('txtbookcentercode').value;
	    dsbcmexecute.Tables[0].Rows[z].Book_Center_Name=document.getElementById('txtbookcentername').value;
		dsbcmexecute.Tables[0].Rows[z].Pub_cent_Code=document.getElementById('drpubcentname').value;
		dsbcmexecute.Tables[0].Rows[z].City_Code=document.getElementById('txtpubctcity').value;
      	
        document.getElementById('txtbookcentercode').disabled=true;
		document.getElementById('txtbookcentername').disabled=true;
		document.getElementById('drpubcentname').disabled=true;
		document.getElementById('txtpubctcity').disabled=true;
	    alert("Updated Successfully");
        flag=0;
        return false;
        }
        else
        {
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        BookingCenterMaster.bookingcodecheck(bookingcode, compcode, userid,callsave);

        document.getElementById('btnNew').disabled=true;
        document.getElementById('btnSave').disabled=false;
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnDelete').disabled=true;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
        document.getElementById('btnExit').disabled=false;



return false;
}
}

function callsave(res)
{
			var ds=res.value;
			if(ds.Tables[0].Rows.length==0)
			{
				 var bookingcode=document.getElementById('txtbookcentercode').value;
                var bookingname=document.getElementById('txtbookcentername').value;
                var pubname=document.getElementById('drpubcentname').value;

                var pubcity=document.getElementById('txtpubctcity').value;
    	        var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				BookingCenterMaster.insert(bookingcode, bookingname, pubname, pubcity,  compcode, userid);
				
				alert("Saved Successfully");
			    document.getElementById('txtbookcentercode').value="";
		        document.getElementById('txtbookcentername').value="";
		        document.getElementById('drpubcentname').value="0";
		        document.getElementById('txtpubctcity').value="";
        			
			    document.getElementById('txtbookcentercode').disabled=true;
		        document.getElementById('txtbookcentername').disabled=true;
		        document.getElementById('drpubcentname').disabled=true;
		        document.getElementById('txtpubctcity').disabled=true;
        	   	
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnExit').disabled=false;	
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;		
				document.getElementById('btnlast').disabled=true;
				
					
				
				return false;
			}
			else
			{
				alert("This Edition Code already Exist");
				return false;
			}
			
			bookingcancel('BookingCenterMaster');
			return false;
}

function bookingexecute()
{
		    document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnExit').disabled=false;
			
			updateStatus();
		
			  document.getElementById('txtbookcentercode').disabled=true;
		        document.getElementById('txtbookcentername').disabled=true;
		        document.getElementById('drpubcentname').disabled=true;
		        document.getElementById('txtpubctcity').disabled=true;
		         var bookingcode=document.getElementById('txtbookcentercode').value;
		        gbbookingcode=bookingcode;
                var bookingname=document.getElementById('txtbookcentername').value;
                gbbookingname=bookingname;
                var pubname=document.getElementById('drpubcentname').value;
                gbpubname=pubname;

                var pubcity=document.getElementById('txtpubctcity').value;
                gbpubcity=pubcity;
    	        var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
		
        	   	
		
			BookingCenterMaster.Select(bookingcode, bookingname, pubname, pubcity, compcode, userid,call_Execute);
			
			document.getElementById('btnfirst').disabled=true;			
			document.getElementById('btnprevious').disabled=true;
			
			return false;
}

function call_Execute(response)
{
		 dsbcmexecute=response.value;
		if (dsbcmexecute.Tables[0].Rows.length>0)
		{
			document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[0].Book_Center_Code;
			document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[0].Book_Center_Name;
			document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[0].Pub_cent_Code;
			autofillcity();
			        z=0;
		}
		else
		{
			alert("Search Criteria Does Not Exist");
			bookingcancel('BookingCenterMaster');
			return false;
		}
		return false;
}

function bookingquery()
{
	   document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnExecute').disabled=false;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;
		z=0;
		chkstatus(FlagStatus);
			hiddentext="query";

				
		document.getElementById('txtbookcentercode').value="";
		document.getElementById('txtbookcentername').value="";
		document.getElementById('drpubcentname').value="0";
		document.getElementById('txtpubctcity').value="";
		
        document.getElementById('txtbookcentercode').disabled=false;
		document.getElementById('txtbookcentername').disabled=false;
		document.getElementById('drpubcentname').disabled=false;
		document.getElementById('txtpubctcity').disabled=false;
	

			
	
		return false;
}

function bookingfirst()
{
		   var bookingcode=document.getElementById('txtbookcentercode').value;
           var bookingname=document.getElementById('txtbookcentername').value;
           var pubname=document.getElementById('drpubcentname').value;
           var pubcity=document.getElementById('txtpubctcity').value;
           var compcode=document.getElementById('hiddencompcode').value;
    	   var userid=document.getElementById('hiddenuserid').value;
		BookingCenterMaster.Selectfnpl(bookingcode, bookingname, pubname, pubcity, compcode, userid,call_First);

		 document.getElementById('txtbookcentercode').disabled=true;
		  document.getElementById('txtbookcentername').disabled=true;
		  document.getElementById('drpubcentname').disabled=true;
		  document.getElementById('txtpubctcity').disabled=true;
		     

		return false;
}

function call_First(response)
{
		z=0;
		//var ds=response.value;
			document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[0].Book_Center_Code;
			document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[0].Book_Center_Name;
			document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[0].Pub_cent_Code;
			//document.getElementById('txtpubctcity').value=ds.Tables[0].Rows[0].City_Code;
      		autofillcity();
			updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;	
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnlast').disabled=false;	
}


function bookingnext()
{
		   var bookingcode=document.getElementById('txtbookcentercode').value;
           var bookingname=document.getElementById('txtbookcentername').value;
           var pubname=document.getElementById('drpubcentname').value;
           var pubcity=document.getElementById('txtpubctcity').value;
           var compcode=document.getElementById('hiddencompcode').value;
    	   var userid=document.getElementById('hiddenuserid').value;
	
		BookingCenterMaster.Selectfnpl(bookingcode, bookingname, pubname, pubcity, compcode, userid,call_Next);

		 document.getElementById('txtbookcentercode').disabled=true;
		 document.getElementById('txtbookcentername').disabled=true;
		 document.getElementById('drpubcentname').disabled=true;
		 document.getElementById('txtpubctcity').disabled=true;
		     


		return false;
}

function call_Next(response)
{
	z++;
	//ds=response.value;
	var x=dsbcmexecute.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(dsbcmexecute.Tables[0].Rows.length != z && z !=-1)
		{
			document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[z].Book_Center_Code;
			document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[z].Book_Center_Name;
			document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[z].Pub_cent_Code;
			//document.getElementById('txtpubctcity').value=ds.Tables[0].Rows[z].City_Code;
			autofillcity();
      	
			
    		updateStatus();
		
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;
			
		} 
		else
		{
		    document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		}
		else
		{
		    document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		if(z==x-1)
		{
		    document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		return false;
	}

function bookingprevious()
{
		  var bookingcode=document.getElementById('txtbookcentercode').value;
           var bookingname=document.getElementById('txtbookcentername').value;
           var pubname=document.getElementById('drpubcentname').value;
           var pubcity=document.getElementById('txtpubctcity').value;
           var compcode=document.getElementById('hiddencompcode').value;
    	   var userid=document.getElementById('hiddenuserid').value;
	
		BookingCenterMaster.Selectfnpl(bookingcode, bookingname, pubname, pubcity, compcode, userid,call_Previous);

		
		 document.getElementById('txtbookcentercode').disabled=true;
		 document.getElementById('txtbookcentername').disabled=true;
		 document.getElementById('drpubcentname').disabled=true;
		 document.getElementById('txtpubctcity').disabled=true;
			return false;
}

function call_Previous(response)
{
	z--;
	//ds=response.value;
	var x=dsbcmexecute.Tables[0].Rows.length;
	
	if(z>x)
	{
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			return false;
	}
			
	if(z!=-1 && z>=0)
	{
			if(dsbcmexecute.Tables[0].Rows.length != z)
			{
				document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[z].Book_Center_Code;
			    document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[z].Book_Center_Name;
			    document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[z].Pub_cent_Code;
			    //document.getElementById('txtpubctcity').value=ds.Tables[0].Rows[z].City_Code;
          	     autofillcity();
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=false;
				
			}
			else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
	}	
	else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
	
	if (z<=0)
	{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			return false;		
	}
	return false;
}

function bookinglast()
{
		   var bookingcode=document.getElementById('txtbookcentercode').value;
           var bookingname=document.getElementById('txtbookcentername').value;
           var pubname=document.getElementById('drpubcentname').value;
           var pubcity=document.getElementById('txtpubctcity').value;
           var compcode=document.getElementById('hiddencompcode').value;
    	   var userid=document.getElementById('hiddenuserid').value;
		 BookingCenterMaster.Selectfnpl(bookingcode, bookingname, pubname, pubcity, compcode, userid,call_Last);
	     document.getElementById('txtbookcentercode').disabled=true;
		 document.getElementById('txtbookcentername').disabled=true;
		 document.getElementById('drpubcentname').disabled=true;
		 document.getElementById('txtpubctcity').disabled=true;
		
			return false;
}

function call_Last(response)
{
			//ds= response.value;
			var x=dsbcmexecute.Tables[0].Rows.length;
			z=x-1;
			x=x-1;
			
			document.getElementById('txtbookcentercode').value=dsbcmexecute.Tables[0].Rows[x].Book_Center_Code;
			document.getElementById('txtbookcentername').value=dsbcmexecute.Tables[0].Rows[x].Book_Center_Name;
			document.getElementById('drpubcentname').value=dsbcmexecute.Tables[0].Rows[x].Pub_cent_Code;
			//document.getElementById('txtpubctcity').value=ds.Tables[0].Rows[x].City_Code;
			autofillcity();
		    document.getElementById('btnnext').disabled=true;
		    document.getElementById('btnlast').disabled=true;
		    document.getElementById('btnfirst').disabled=false;
		    document.getElementById('btnprevious').disabled=false;
			    return false;
}


function bookingexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;
}

function autofillcity()
{
  strpub=document.getElementById('drpubcentname').value;
   var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
	if(	document.getElementById('drpubcentname').value!="0")
	    {          
        BookingCenterMaster.selcity(strpub,compcode,userid,fillcity);
        }
    else
          {
          document.getElementById('txtpubctcity').value="";
          return false;
          }
          
  return false;
  }
  
  function fillcity(res)
  {
  ds=res.value;
  document.getElementById('txtpubctcity').value=ds.Tables[0].Rows[0].City_Name;
  return false;
  }
		       




function autoornot()
 {
  if(document.getElementById('hiddenauto').value==1)
    {
    autochange();
    
    return false;
    }
else
    {
    userdefine();

    return false;
    }
return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function autochange()
{
if(hiddentext=="new" )
			{
	
            UPPERCASE();
           
           }
            else
            {
            document.getElementById('txtbookcentername').value=document.getElementById('txtbookcentername').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASE()
		{
		     if(document.getElementById('txtbookcentername').value!="")
		     {
		         str=document.getElementById('txtbookcentername').value;
                 strpub=document.getElementById('drpubcentname').value;
                 BookingCenterMaster.bookcentermaster(str,strpub,fillcall);
		        }
		       	       
               
 return false;
		
}



function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Booking Center name has already assigned in this Publication center!! ");
		    //document.getElementById('txtEditionName').focus();
    		
		    return false;
		    }
		
		        else
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Book_Center_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr.substr(2,4);
		                        code++;
		                        document.getElementById('txtbookcentercode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtbookcentercode').value=str.substr(0,2)+ "0";
		                          }
		               
		document.getElementById('txtbookcentername').value=document.getElementById('txtbookcentername').value.toUpperCase();
	 	
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtbookcentercode').disabled=false;
        document.getElementById('txtbookcentername').value=document.getElementById('txtbookcentername').value.toUpperCase();
         auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}
	
		
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


