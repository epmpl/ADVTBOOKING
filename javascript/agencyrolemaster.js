var modify;
var z=0;
var hiddentext;
var agroleds;
var gcode;
var gname;
var gagcode;
var gagsubcode;
var chknamemod;

function agencynew()
{
  var msg=checkSession();
    if(msg==false)
    return false;
			
	   if(document.getElementById('hiddenauto').value==1)
       {
         document.getElementById('txtcode').disabled=true;
       }
       else
       {
         document.getElementById('txtcode').disabled=false;
       }
        document.getElementById('txtcode').value="";
	    document.getElementById('txtnameofrole').value="";
	    document.getElementById('txtnameofrole').disabled=false;
	    hiddentext="new";
			
			
		 if(document.getElementById('hiddenauto').value==1)
         {
          document.getElementById('txtnameofrole').focus();
         }
         else
         {
          document.getElementById('txtcode').focus();
         }
		        
		chkstatus(FlagStatus);	
		document.getElementById('btnSave').disabled = false;	
        document.getElementById('btnNew').disabled = true;	
        document.getElementById('btnQuery').disabled=true;	
	      	
	     modify="0";
		 z=0;
		 setButtonImages();
        return false;
}

function agencycancel(formname)
{
            chkstatus(FlagStatus);
            givebuttonpermission(formname);
            
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
		    document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
		    modify="0";
			
			
		    /*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;*/
			setButtonImages();
			if(document.getElementById('btnNew').disabled==false)
             document.getElementById('btnNew').focus();

			return false;

}

function agencymodify()
{
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=false;
		    modify="1";
			hiddentext="modify";
			chkstatus(FlagStatus);

            document.getElementById('btnSave').disabled = false;
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnExecute').disabled=true;
            document.getElementById('btnSave').focus();
            
            chknamemod=document.getElementById('txtnameofrole').value;
			 /*   document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;*/
			setButtonImages();

return false;
}

function agencysave()
{
  var msg=checkSession();
    if(msg==false)
    return false;

       document.getElementById('txtnameofrole').value=trim(document.getElementById('txtnameofrole').value);
       document.getElementById('txtcode').value=trim(document.getElementById('txtcode').value);
       
        if((document.getElementById('txtcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
		{
		alert("Please Enter  Code");
		document.getElementById('txtcode').focus();
		return false;
		}
		
		if (document.getElementById('txtnameofrole').value=="")
		{
		alert("Please Enter  Name");
		document.getElementById('txtnameofrole').focus();
		return false;
		}
		
        var code=document.getElementById('txtcode').value;
		var nameofrole=document.getElementById('txtnameofrole').value;
		var agencycode="";
		var subcode="";
			
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		
		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       }
			
	    if(modify!="1" && modify!="")
		{
		
	  AgencyRoleMaster.chkrole(code,compcode,userid,nameofrole,call_save);
		   /* document.getElementById('btnNew').disabled=false;
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
			return false;*/
		}
			
		else
		{
		   if(chknamemod==document.getElementById('txtnameofrole').value)
           {
            updatestate();
           }
           else
           {
            AgencyRoleMaster.chkrole(code,compcode,userid,nameofrole,call_modifyclick);
            return false; 
           }
         }   
			/*AgencyRoleMaster.modifyrole(code,nameofrole,agencycode,subcode,compcode,userid);
	       		
			 alert("Data Update Sucessfully");
			 agroleds.Tables[0].Rows[z].Agency_Role_Code=code;
             agroleds.Tables[0].Rows[z].Agency_Role_Name=nameofrole;
             agroleds.Tables[0].Rows[z].Agency_code=agencycode;
             gagsubcode=agroleds.Tables[0].Rows[z].Agency_Sub_Code=subcode;
			
			updateStatus();
			modify="0";
			
			if(agroleds.Tables[0].Rows.length==1)
			{
			    document.getElementById('btnfirst').disabled=true;
			    document.getElementById('btnprevious').disabled=true;				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			}
			if(z==0)
			{
			    document.getElementById('btnfirst').disabled=true;
			    document.getElementById('btnprevious').disabled=true;				
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
			}
			else if(z==agroleds.Tables[0].Rows.length-1)
			{
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			}
			
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			document.getElementById('btnModify').focus();
		    return false;
		}*/
            return false;
}

//-----------------------------------------------------------------------------//
function call_modifyclick(response)
{
	    var code=document.getElementById('txtcode').value;
		var nameofrole=document.getElementById('txtnameofrole').value;
		var agencycode="";
		var subcode="";
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
			
		var ds=response.value;
		if(	chknamemod!=document.getElementById('txtnameofrole').value)
			{
                if(ds.Tables[1].Rows.length >= 1)
                {
                    alert("This Role Name Already Exists.");
                    document.getElementById('txtnameofrole').value="";
                    return false;
                }
                 updatestate();
			}
	}	
	
function updatestate()
{
	    var code=document.getElementById('txtcode').value;
		var nameofrole=document.getElementById('txtnameofrole').value;
		var agencycode="";
		var subcode="";
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		AgencyRoleMaster.modifyrole(code,nameofrole,agencycode,subcode,compcode,userid);
	       		
			 alert("Data Update Sucessfully");
			 agroleds.Tables[0].Rows[z].Agency_Role_Code=code;
             agroleds.Tables[0].Rows[z].Agency_Role_Name=nameofrole;
             agroleds.Tables[0].Rows[z].Agency_code=agencycode;
             gagsubcode=agroleds.Tables[0].Rows[z].Agency_Sub_Code=subcode;
			
			updateStatus();
			modify="0";
			
			if(agroleds.Tables[0].Rows.length==1)
			{
			    document.getElementById('btnfirst').disabled=true;
			    document.getElementById('btnprevious').disabled=true;				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			}
			if(z==0)
			{
			    document.getElementById('btnfirst').disabled=true;
			    document.getElementById('btnprevious').disabled=true;				
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
			}
			else if(z==agroleds.Tables[0].Rows.length-1)
			{
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			}
			
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			setButtonImages();
			document.getElementById('btnModify').focus();
		    return false;
}

//================================================================================//
function call_save(response)

{
            var ds=response.value;
            if(document.getElementById('txtcode').value=="")
			{
			    alert("Please Enter Code");
			    if(document.getElementById('txtcode').disabled==false)
				{
				    document.getElementById('txtcode').focus();
				}
			    return false;
			}
            if(ds.Tables[0].Rows.length > 0)
            {
                alert("This code has been assigned");
                document.getElementById('txtcode').value="";
				if(document.getElementById('txtcode').disabled==false)
				{
				    document.getElementById('txtcode').focus();
				    return false;
				}
				return false;
            }
            if(ds.Tables[1].Rows.length > 0)
            {
                alert("This Name has been assigned");
                document.getElementById('txtnameofrole').value="";
				if(document.getElementById('txtnameofrole').disabled==false)
				{
				    document.getElementById('txtnameofrole').focus();
				    return false;
				}
				return false;
            }
			var code=document.getElementById('txtcode').value;
			var nameofrole=document.getElementById('txtnameofrole').value;
		    var agencycode="";
			var subcode="";
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			AgencyRoleMaster.saveinsert(code,nameofrole,agencycode,subcode,compcode,userid);
			alert("Data Saved Sucessfully");
			agencycancel('AgencyRoleMaster');
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			
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
setButtonImages();
return false;
}

function agencyquery()
{
			document.getElementById('txtcode').disabled=false;
			document.getElementById('txtnameofrole').disabled=false;
			var agencycode="";
			var subcode="";
			
			chkstatus(FlagStatus);

            document.getElementById('btnQuery').disabled=true;
            document.getElementById('btnExecute').disabled=false;
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnExecute').focus();
//		        document.getElementById('btnNew').disabled=true;
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('btnQuery').disabled=true;
//				document.getElementById('btnExecute').disabled=false;
//				document.getElementById('btnCancel').disabled=false;		
//				document.getElementById('btnfirst').disabled=true;				
//				document.getElementById('btnnext').disabled=true;					
//				document.getElementById('btnprevious').disabled=true;			
//				document.getElementById('btnlast').disabled=true;			
//				document.getElementById('btnExit').disabled=false;
				
				document.getElementById('txtcode').value="";
			    document.getElementById('txtnameofrole').value="";
			    document.getElementById('btnExecute').focus();
			    
hiddentext="query";
			
setButtonImages();
return false;
}

function agencyexecute()
{
  var msg=checkSession();
    if(msg==false)
    return false;
			var code=document.getElementById('txtcode').value;
			var nameofrole=document.getElementById('txtnameofrole').value;
		    var agencycode="";
			var subcode="";
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			z=0;
			
			updateStatus();
		    //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AgencyRoleMaster.agencyexecute(code,nameofrole,agencycode,subcode,compcode,userid,call_exe);
		    updateStatus();
		    
		    document.getElementById('btnfirst').disabled=true;				
            document.getElementById('btnnext').disabled=false;					
            document.getElementById('btnprevious').disabled=true;			
            document.getElementById('btnlast').disabled=false;	
            if(document.getElementById('btnModify').disabled==false)					
            document.getElementById('btnModify').focus();
            	
		    gcode=code;
            gname=nameofrole;
            gagcode=agencycode;
            gagsubcode=subcode;
		
		    return false;
}

function call_exe(response)
{
        agroleds=response.value;
        if(agroleds==null)
        {
            alert(response.error.description);
            return false;
        }   
        if(agroleds.Tables[0].Rows.length <= 0)
		{
		    alert("Search Not Valid");
		    agencycancel('AgencyRoleMaster');
		    setButtonImages();
		    return false;
		}
		else
		{
			document.getElementById('txtcode').value=agroleds.Tables[0].Rows[0].Agency_Role_Code;
			document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[0].Agency_Role_Name;
		    /*document.getElementById('btnfirst').disabled=true;				
		    document.getElementById('btnprevious').disabled=true;
		    document.getElementById('btnnext').disabled=false;
		    document.getElementById('btnlast').disabled=false;*/
		   				
			if(agroleds.Tables[0].Rows.length==1)
		   	{
   	            document.getElementById('btnprevious').disabled=true;	
                document.getElementById('btnlast').disabled=true;	
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnnext').disabled=true;
            }
			  setButtonImages();      
			return false;
			
		}
		setButtonImages();
return false;
}

function agencyfirst()
{
  var msg=checkSession();
    if(msg==false)
    return false;
        document.getElementById('txtcode').disabled=true;
		document.getElementById('txtnameofrole').disabled=true;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;

	   //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AgencyRoleMaster.first(compcode,userid,call_first);

	   document.getElementById('btnfirst').disabled=true;				
	   document.getElementById('btnprevious').disabled=true;	
		
		
		
return false;
}

function call_first(response)
{
//var ds=response.value;
    z=0;
    document.getElementById('txtcode').value=agroleds.Tables[0].Rows[0].Agency_Role_Code;
	document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[0].Agency_Role_Name;


    updateStatus();

    document.getElementById('btnCancel').disabled=false;
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnlast').disabled=false;
    document.getElementById('btnExit').disabled=false;
    setButtonImages();
	return false;
}

function agencyprevious()
{
          var msg=checkSession();
            if(msg==false)
            return false;
            var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
		
            //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AgencyRoleMaster.first(compcode,userid,call_pre);
  setButtonImages();
            return false;

}

function call_pre(response)
{	
			z--;
	//	var ds=response.value;
		var x=agroleds.Tables[0].Rows.length;
		
			if(z>x)
			{
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			  setButtonImages();
			return false;
			}
		if(z!=-1 && z>=0)
		{
			if(agroleds.Tables[0].Rows.length != z)
			{
			    document.getElementById('txtcode').value=agroleds.Tables[0].Rows[z].Agency_Role_Code;
			    document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[z].Agency_Role_Name;
    				
			    updateStatus();
    		
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
			  setButtonImages();	
			return false;		
		}
		setButtonImages();
		return false;
		
}

function agencynext()
{
            var msg=checkSession();
            if(msg==false)
            return false;
            
            var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
            document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
		
            //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AgencyRoleMaster.first(compcode,userid,call_next);
            return false;

}

function call_next(response)
{

		z++;
	//var ds=response.value;
	var x=agroleds.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(agroleds.Tables[0].Rows.length != z && z !=-1)
		{
			document.getElementById('txtcode').value=agroleds.Tables[0].Rows[z].Agency_Role_Code;
			document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[z].Agency_Role_Name;
			
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
		setButtonImages();
		return false;
}

function agencylast()
{
  var msg=checkSession();
    if(msg==false)
    return false;
    var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
			
    document.getElementById('txtcode').disabled=true;
	document.getElementById('txtnameofrole').disabled=true;
	
    //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AgencyRoleMaster.first(compcode,userid,call_last);
    return false;
}

function call_last(response)
{
//var ds=response.value;
		var y=agroleds.Tables[0].Rows.length;
		var a=y-1;
		z=a;
		
		document.getElementById('txtcode').value=agroleds.Tables[0].Rows[a].Agency_Role_Code;
		document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[a].Agency_Role_Name;
		updateStatus();
			
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
setButtonImages();
return false;
}

function agroleexit()
{
if(confirm("Do You Want To Skip This Page"))
	{
	//window.location.href='EnterPage.aspx';
	window.close();
	return false;
	}
	
	return false;
}


function deteagrol()
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var doccode=document.getElementById('txtcode').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AgencyRoleMaster.del(compcode,userid,doccode);
	        AgencyRoleMaster.agencyexecute(gcode,gname,gagcode,gagsubcode,compcode,userid,delcall);	

	}     
	else
	{
	   return false;
	}	
	return false;
	}
	
	function delcall(res)
	{
	 agroleds= res.value;
	len=agroleds.Tables[0].Rows.length;
	
	if(agroleds.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			//document.getElementById('drpagencycode').value="0";
			//document.getElementById('drpsubcode').value="0";
		agencycancel('AgencyRoleMaster');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
		document.getElementById('txtcode').value=agroleds.Tables[0].Rows[0].Agency_Role_Code;
			document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[0].Agency_Role_Name;
			//document.getElementById('drpagencycode').value=agroleds.Tables[0].Rows[0].Agency_code;
			//document.getElementById('drpsubcode').value=agroleds.Tables[0].Rows[0].Agency_Sub_Code;
	}
	
	else
	{
		document.getElementById('txtcode').value=agroleds.Tables[0].Rows[z].Agency_Role_Code;
			document.getElementById('txtnameofrole').value=agroleds.Tables[0].Rows[z].Agency_Role_Name;
		//	document.getElementById('drpagencycode').value=agroleds.Tables[0].Rows[z].Agency_code;
		//	document.getElementById('drpsubcode').value=agroleds.Tables[0].Rows[z].Agency_Sub_Code;
	}
	alert ("Data Deleted Sucessfully");	
				
	setButtonImages();
	return false;
	}
	
	
	
	
	
	
	
	function autoornot()
    {
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
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

function changeoccured()
{
if(hiddentext=="new" )
			{
	
            uppercase3();
           
           }
            else
            {
              document.getElementById('txtnameofrole').value=trim(document.getElementById('txtnameofrole').value);
              document.getElementById('txtnameofrole').value=document.getElementById('txtnameofrole').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		    if(document.getElementById('txtnameofrole').value!="")
                {
                document.getElementById('txtnameofrole').value=trim(document.getElementById('txtnameofrole').value);
                 document.getElementById('txtnameofrole').value=document.getElementById('txtnameofrole').value.toUpperCase();
	           // document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
		        str=document.getElementById('txtnameofrole').value;
		        AgencyRoleMaster.chksrolecode(str,fillcall);
		        return false;
                }
		     return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    
		    document.getElementById('txtnameofrole').value="";
		    alert("This Name has already assigned !! ");
		    
		    document.getElementById('txtnameofrole').focus();
		    
 
    		
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
		                         newstr=ds.Tables[1].Rows[0].Agency_Role_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        code=newstr;
		                        code++;
		                        document.getElementById('txtcode').value=str.substr(0,2)+ code;
		                       // document.getElementById('txtcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtcode').disabled=false;
        document.getElementById('txtcode').value=document.getElementById('txtcode').value.toUpperCase();
        document.getElementById('txtnameofrole').value=document.getElementById('txtnameofrole').value.toUpperCase();
        //document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
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

function trim( value) 
{
      return (value.replace(/^\s+/g, '').replace(/\s+$/g, ''));
	
}
 
function uppercase1()
{
document.getElementById('txtcode').value=document.getElementById('txtcode').value.toUpperCase();
return ;
}
function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}	

function cleardest()
{

givebuttonpermission('AgencyRoleMaster');
agencycancel('AgencyRoleMaster');

}
	
	
	