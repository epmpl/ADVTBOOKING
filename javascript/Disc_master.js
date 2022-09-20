// JScript File
var hiddentext;
var mod="0";
var z=0;
var show;
var edinsert="0";
var glaobaldisccode,glaobaldisdes,glaobaladtyp,glaobalstat,glaobaldisctyp,glaobaldisprem;
function btnNewClick2()
{
    document.getElementById('txtdisccode').value="";
    document.getElementById('txtdiscdes').value="";
    document.getElementById('adtype').value="0";
    document.getElementById('drpstatus').value="1"; 
    document.getElementById('drpdisctyp').value="0";
    document.getElementById('txtdiscprm').value=""; 

    //chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
		
	hiddentext="new";
	show="2";
	if(document.getElementById('hiddenauto').value==1)
	{
	document.getElementById('txtdisccode').disabled=true;
	
	}
	else
	{
	document.getElementById('txtdisccode').disabled=false;
	
	}
//	 document.getElementById('txtdisccode').disabled=false;
    document.getElementById('txtdiscdes').disabled=false;
    document.getElementById('adtype').disabled=false;
    document.getElementById('drpstatus').disabled=false; 
    document.getElementById('drpdisctyp').disabled=false;
    document.getElementById('txtdiscprm').disabled=false;
    
    if(document.getElementById('hiddenauto').value==1)
	{
	document.getElementById('txtdiscdes').focus();
	
	}
	else
	{
	document.getElementById('txtdisccode').focus();
	
	}
    
setButtonImages();
return false;
}
function btnCancelClick2(formname)
{
//chkstatus(FlagStatus);
//givebuttonpermission(formname);

    document.getElementById('txtdisccode').value="";
    document.getElementById('txtdiscdes').value="";
    document.getElementById('adtype').value="0";
    document.getElementById('drpstatus').value="1"; 
    document.getElementById('drpdisctyp').value="0";
    document.getElementById('txtdiscprm').value="";
    
     document.getElementById('txtdisccode').disabled=true;
    document.getElementById('txtdiscdes').disabled=true;
    document.getElementById('adtype').disabled=true;
    document.getElementById('drpstatus').disabled=true; 
    document.getElementById('drpdisctyp').disabled=true;
    document.getElementById('txtdiscprm').disabled=true;
    
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnDelete').disabled=true;
	document.getElementById('btnfirst').disabled=true;
	document.getElementById('btnprevious').disabled=true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnSave').disabled=true;
				
				mod="0";
    
    if(document.getElementById('btnNew').disabled==false)
    {
    document.getElementById('btnNew').focus();
    }
    else
    {
    document.getElementById('btnNew').disabled=false;
	document.getElementById('btnNew').focus();
	}
	
setButtonImages();
return false;
}
function btnModifyClick2()
{
 mod="1";
	 hiddentext="mod";
	 show="2";	
    document.getElementById('txtdisccode').disabled=true;
    document.getElementById('txtdiscdes').disabled=true;
    document.getElementById('adtype').disabled=false;
    document.getElementById('drpstatus').disabled=false; 
    document.getElementById('drpdisctyp').disabled=false;
    document.getElementById('txtdiscprm').disabled=false;
    chkstatus(FlagStatus);
    document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnModify').disabled=false;
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnSave').focus();
    setButtonImages();
return false;
}
function saveclick()
{
 document.getElementById('txtdisccode').value=trim(document.getElementById('txtdisccode').value);
 document.getElementById('txtdiscdes').value=trim(document.getElementById('txtdiscdes').value);
 document.getElementById('txtdiscprm').value=trim(document.getElementById('txtdiscprm').value);
 
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
    if(document.getElementById('txtdisccode').value=="" && document.getElementById('hiddenauto').value!=1)
        {
        alert("Please Enter Discont Code.");
        document.getElementById('txtdisccode').focus();
        return false;
        }
     if(document.getElementById('txtdiscdes').value=="")
        {
        alert("Please Enter Discont Desc.");
        document.getElementById('txtdiscdes').focus();
        return false;
        }
     if(document.getElementById('adtype').value=="" || document.getElementById('adtype').value=="0")
        {
        alert("Please Enter Ad Type.");
        document.getElementById('adtype').focus();
        return false;
        }
//     if(document.getElementById('drpstatus').value=="" || document.getElementById('drpstatus').value=="0")
//        {
//        alert("Please Enter Status.");
//        document.getElementById('drpstatus').focus();
//        return false;
//        }
      if(document.getElementById('drpdisctyp').value=="" || document.getElementById('drpdisctyp').value=="0")
        {
        alert("Please Enter Discont Type.");
        document.getElementById('drpdisctyp').focus();
        return false;
        }  
    if(document.getElementById('txtdiscprm').value=="")
        {
        alert("Please Enter Discont Premium.");
        document.getElementById('txtdiscprm').focus();
        return false;
        }
var compcode=document.getElementById('hiddencompcode').value;
var disccode=document.getElementById('txtdisccode').value.toUpperCase();
var discdes = document.getElementById('txtdiscdes').value.toUpperCase();
var adtype = document.getElementById('adtype').value.toUpperCase(); 
if(mod !="1")
    {
        Disc_master.chkdup(compcode, disccode, discdes, adtype, callsave);
    return false;
    }
    else
    {
     updatedesc();
    }
}
function  updatedesc()
{
var compcode=document.getElementById('hiddencompcode').value;
var disccode=document.getElementById('txtdisccode').value.toUpperCase();
var adtype=document.getElementById('adtype').value;
var status=document.getElementById('drpstatus').value;
var disctyp=document.getElementById('drpdisctyp').value;
var discprm=document.getElementById('txtdiscprm').value;

Disc_master.update(compcode,disccode,adtype,status,disctyp,discprm);

dspubexecute.Tables[0].Rows[z].AD_TYPE=document.getElementById('adtype').value;
dspubexecute.Tables[0].Rows[z].STATUS=document.getElementById('drpstatus').value;
dspubexecute.Tables[0].Rows[z].DISC_TYPE=document.getElementById('drpdisctyp').value;
dspubexecute.Tables[0].Rows[z].DESC_PREM=document.getElementById('txtdiscprm').value;

 alert("Data Updated Successfully");
        updateStatus();
        if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dspubexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       

    document.getElementById('txtdisccode').disabled=true;
    document.getElementById('txtdiscdes').disabled=true;
    document.getElementById('adtype').disabled=true;
    document.getElementById('drpstatus').disabled=true; 
    document.getElementById('drpdisctyp').disabled=true;
    document.getElementById('txtdiscprm').disabled=true;
         setButtonImages();
			 if(document.getElementById('btnModify').disabled==false)      
	          document.getElementById('btnModify').focus();
	mod="0";
			return false;
}   
    
function callsave(res)
{
var ds;
ds=res.value;
if(ds.Tables[0].Rows.length > 0)
    {
    alert("This Discont Code is already assigned.");
    document.getElementById('txtdisccode').focus();
    return false;
    }
if(ds.Tables[1].Rows.length > 0)
    {
    alert("This Discont Desc. is already assigned.");
    document.getElementById('txtdiscdes').focus();
    return false;
    }
var compcode=document.getElementById('hiddencompcode').value;
var disccode=document.getElementById('txtdisccode').value.toUpperCase();
var discdesc=document.getElementById('txtdiscdes').value.toUpperCase();
var adtype=document.getElementById('adtype').value;
var status=document.getElementById('drpstatus').value;
var disctyp=document.getElementById('drpdisctyp').value;
var discprm=document.getElementById('txtdiscprm').value; 
var userid=document.getElementById('hiddenuserid').value; 
Disc_master.save(compcode,disccode,discdesc,adtype,status,disctyp,discprm,userid) 

document.getElementById('btnNew').disabled=false;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnQuery').disabled=false;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;

document.getElementById('txtdisccode').disabled=true;
document.getElementById('txtdiscdes').disabled=true;
document.getElementById('adtype').disabled=true;
document.getElementById('drpstatus').disabled=true; 
document.getElementById('drpdisctyp').disabled=true;
document.getElementById('txtdiscprm').disabled=true;
alert("Data Saved Sucessfully");
    document.getElementById('txtdisccode').value="";
    document.getElementById('txtdiscdes').value="";
    document.getElementById('adtype').value="0";
    document.getElementById('drpstatus').value="1"; 
    document.getElementById('drpdisctyp').value="0";
    document.getElementById('txtdiscprm').value="";
//document.getElementById('drpuncent').focus();
btnCancelClick2('Disc_master');

return false;
}
function btnQueryClick2()
{
chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	hiddentext="query";
z=0;
    document.getElementById('txtdisccode').value="";
    document.getElementById('txtdiscdes').value="";
    document.getElementById('adtype').value="0";
    document.getElementById('drpstatus').value="1"; 
    document.getElementById('drpdisctyp').value="0";
    document.getElementById('txtdiscprm').value=""; 

document.getElementById('txtdisccode').disabled=false;
document.getElementById('txtdiscdes').disabled=false;
document.getElementById('adtype').disabled=false;
document.getElementById('drpstatus').disabled=false; 
document.getElementById('drpdisctyp').disabled=false;
document.getElementById('txtdiscprm').disabled=false;
setButtonImages();

return false;
}
function btnExecuteClick2()
{
z=0;
var compcode=document.getElementById('hiddencompcode').value.toUpperCase();
var discode=document.getElementById('txtdisccode').value;
glaobaldisccode=discode;
var disdes=document.getElementById('txtdiscdes').value.toUpperCase();
glaobaldisdes=disdes;
var adtyp=document.getElementById('adtype').value;
glaobaladtyp=adtyp;
var stat=document.getElementById('drpstatus').value; 
glaobalstat=stat;
var disctyp=document.getElementById('drpdisctyp').value;
glaobaldisctyp=disctyp;
var disprem=document.getElementById('txtdiscprm').value;
glaobaldisprem=disprem;

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
Disc_master.execute(compcode,discode,disdes,adtyp,stat,disctyp,disprem,callexec);
    updateStatus();
    
document.getElementById('txtdisccode').disabled=true;
document.getElementById('txtdiscdes').disabled=true;
document.getElementById('adtype').disabled=true;
document.getElementById('drpstatus').disabled=true; 
document.getElementById('drpdisctyp').disabled=true;
document.getElementById('txtdiscprm').disabled=true;
     
    mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						
					    if(document.getElementById('btnModify').disabled==false)
			                document.getElementById('btnModify').focus();
			return false;
    
}
function callexec(response)
{
    var ds=response.value;
	dspubexecute=response.value;
	    if(dspubexecute.Tables[0].Rows.length > 0)
	    {
			 	document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[0].DISC_CODE;
                document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[0].DISC_DESC;
                document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[0].AD_TYPE;
                document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[0].STATUS;
                document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[0].DISC_TYPE;
                document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[0].DESC_PREM;
				
				document.getElementById('txtdisccode').disabled=true;
                document.getElementById('txtdiscdes').disabled=true;
                document.getElementById('adtype').disabled=true;
                document.getElementById('drpstatus').disabled=true; 
                document.getElementById('drpdisctyp').disabled=true;
                document.getElementById('txtdiscprm').disabled=true;
	    }
	    else
	    {
	        alert("Your Search Produce No Result!!!!");
			btnCancelClick2('Disc_master');
		}

         if(dspubexecute.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}
function firstclick()
{
            document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[0].DISC_CODE;
            document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[0].DISC_DESC;
            document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[0].AD_TYPE;
            document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[0].STATUS;
            document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[0].DISC_TYPE;
            document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[0].DESC_PREM;
				
				z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnExit').disabled=false;
		//fillAdCat1();
		setButtonImages();
			return false;
}
function previousclick()
{
var a=dspubexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			    document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[z].DISC_CODE;
                document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[z].DISC_DESC;
                document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[z].AD_TYPE;
                document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[z].STATUS;
                document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[z].DISC_TYPE;
                document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[z].DESC_PREM;
			updateStatus();
				document.getElementById('btnfirst').disabled=false;				
		        document.getElementById('btnnext').disabled=false;				
		        document.getElementById('btnprevious').disabled=false;				
		        document.getElementById('btnlast').disabled=false;			
		        document.getElementById('btnExit').disabled=false;
				//fillAdCat1();
			}
			else
			{
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
			}
		}
		else
		{		document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
		}
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		setButtonImages();
		return false;
}
function nextclick()
{
var a=dspubexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		    document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[z].DISC_CODE;
            document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[z].DISC_DESC;
            document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[z].AD_TYPE;
            document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[z].STATUS;
            document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[z].DISC_TYPE;
            document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[z].DESC_PREM;
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			//fillAdCat1();
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
	if(z==a-1)
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	setButtonImages();
	return false;
}
function lastclick()
{
var y=dspubexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[z].DISC_CODE;
            document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[z].DISC_DESC;
            document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[z].AD_TYPE;
            document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[z].STATUS;
            document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[z].DISC_TYPE;
            document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[z].DESC_PREM;
			
			updateStatus();
			//fillAdCat1();
		    document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            document.getElementById('btnfirst').disabled=false;
            document.getElementById('btnprevious').disabled=false;
            setButtonImages();
			return false;
}
//function exitclick()
//{
//    if (confirm("Do You Want To Skip This Page")) {
//        
//        window.close();
//        return false;
//    }
//    else {
//        return false;
//    }
//}




function exitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        
        window.close();
        return false;
    }
    else {
        return false;
    }
}
function deleteclick()
{
    updateStatus();
var discode=document.getElementById('txtdisccode').value;
var compcode=document.getElementById('hiddencompcode').value;
    
    if( confirm("Are You Sure To Delete The Data ?"));
			{
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
       Disc_master.discdelete(compcode, discode);

			alert ("Data Deleted Successfully");
			document.getElementById('txtdisccode').value="";
            document.getElementById('txtdiscdes').value="";
            document.getElementById('adtype').value="0";
            document.getElementById('drpstatus').value="1"; 
            document.getElementById('drpdisctyp').value="0";
            document.getElementById('txtdiscprm').value=""; 
		

		       Disc_master.execute(compcode, glaobaldisccode, glaobaldisdes, glaobaladtyp, glaobalstat, glaobaldisctyp, glaobaldisprem,delcall);
		     }
		     return false;
}
function delcall(res)
{
 dspubexecute= res.value;
	len=dspubexecute.Tables[0].Rows.length;
	
	if(dspubexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
	        document.getElementById('txtdisccode').value="";
            document.getElementById('txtdiscdes').value="";
            document.getElementById('adtype').value="0";
            document.getElementById('drpstatus').value="1"; 
            document.getElementById('drpdisctyp').value="0";
            document.getElementById('txtdiscprm').value="";
		 btnCancelClick2('Disc_master');
		return false;
	}
	        else if(z>=len || z==-1)
	        {
			document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[0].DISC_CODE;
            document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[0].DISC_DESC;
            document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[0].AD_TYPE;
            document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[0].STATUS;
            document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[0].DISC_TYPE;
            document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[0].DESC_PREM;
        			
	        }
	        else
	        {
	        document.getElementById('txtdisccode').value=dspubexecute.Tables[0].Rows[z].DISC_CODE;
            document.getElementById('txtdiscdes').value=dspubexecute.Tables[0].Rows[z].DISC_DESC;
            document.getElementById('adtype').value=dspubexecute.Tables[0].Rows[z].AD_TYPE;
            document.getElementById('drpstatus').value=dspubexecute.Tables[0].Rows[z].STATUS;
            document.getElementById('drpdisctyp').value=dspubexecute.Tables[0].Rows[z].DISC_TYPE;
            document.getElementById('txtdiscprm').value=dspubexecute.Tables[0].Rows[z].DESC_PREM;
	        }
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dspubexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
            if(dspubexecute.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
	setButtonImages();
return false;
}
function LTrim( value )
 {
	
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
function autoornot()
 {
    if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    }
//else
//    {
//    userdefine();
//    }
}
// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
    if(hiddentext=="new")
		{
        document.getElementById('txtdiscdes').value=trim(document.getElementById('txtdiscdes').value);
            lstr=document.getElementById('txtdiscdes').value;
            cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
	
	
            
		    if(document.getElementById('txtdiscdes').value!="")
                {
                 
		        document.getElementById('txtdiscdes').value=document.getElementById('txtdiscdes').value.toUpperCase();
		        str = mstr.toUpperCase();
		        Disc_master.chkcode(str,fillcall);
		        //return false;
                }
 return false;
           
           }
      
return false;
}
function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
//		    if(ds.Tables[0].Rows.length!=0)
//		    {
//		    alert("This Discont Desc. has already assigned !! ");
//		    document.getElementById('txtdisccode').value="";
//            document.getElementById('txtdiscdes').value="";
//            document.getElementById('txtdiscdes').focus();
//    		
//		    return false;
//		    }
		
//		        else
//		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                            newstr = ds.Tables[1].Rows[0].DISC_CODE;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtdisccode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtdisccode').value=str.substr(0,2)+ "0";
		                          }
//		     }
	return false;
		}
function chkprem()
{
var sau=parseFloat(document.getElementById('txtdiscprm').value);
//document.getElementById('txtsharing').value=sau;

if(sau>100 && document.getElementById('drpdisctyp').value=="P")
{
    alert("Discont Premium should not be greater than 100");
    document.getElementById('txtdiscprm').value="";
    document.getElementById('txtdiscprm').focus();
    return false;
}
var num=document.getElementById('txtdiscprm').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtdiscprm').value="";
document.getElementById('txtdiscprm').focus();

return false; 

}
}
//=========function to change image of buttons
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

function openedit()
{
  if(document.getElementById('txtdisccode').value=="")
    {
    alert('Please Enter The DISC. Code');
    //document.getElementById('txtcurrcode').focus();s
    return false;
    }
        var disccode=document.getElementById('txtdisccode').value;
        var disctype=document.getElementById('drpdisctyp').value;
        var mp1 = document.getElementById("drpdisctyp").selectedIndex;
           if (mp1 != -1)
               var disctypename = document.getElementById("drpdisctyp").options[mp1].text;
           else
               var disctypename = "";
   if(document.getElementById('txtdiscprm').value=="")
   {
       alert('Please Enter discount prem.');
        //document.getElementById('txtcurrcode').focus();s
        return false;
    }
   
        var discountprem=document.getElementById('txtdiscprm').value;
	//var validationco=ds.Tables[0].Rows[0].ValidationCode;

    //var editcode1,periodicity1,alias1;
for ( var index = 0; index < 200; index++ ) 
  { 
  
popwin1=window.open('edition_wise_discount.aspx?disccode='+disccode+'&disctype='+disctype+' &htext='+hiddentext+' &show='+show+' &discountprem='+discountprem+' &disctypename='+disctypename,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');
popwin1.focus();

return false;
   
}
}

function submitclick()
{
       var page;
        var edition="";
        var date1="";
        var date2="";
        var date3="";
        var ds="";

		 

var dateformat=document.getElementById('hiddendateformat').value;
var txtdate="";
var txtaddate="";
var year="";


if(document.getElementById('txtdistype').value=="")
{
alert("Please Enter Discount Type");
document.getElementById('txtdistype').focus();
return false;
}
if( document.getElementById('txtdiscount').value=="0")
{
alert("Please Fill Discount");
document.getElementById('txtdiscount').focus();
return false;
}
if(document.getElementById('txtfrmedition').value=="0")
{
  alert("Please Fill  From Edition.");
document.getElementById('txtfrmedition').focus();
return false;
}
if(document.getElementById('txttoedition').value=="0")
{
  alert("Please Fill  To Edition.");
document.getElementById('txttoedition').focus();
return false;
}
if(parseInt(document.getElementById('txtfrmedition').value)>parseInt(document.getElementById('txttoedition').value))
{
alert("To Edition Should be greater than From Edition")
return false;
}
var fromdate=document.getElementById('txtdiscount').value;
var todate=document.getElementById('txtfrmedition').value;
var txteditionname=document.getElementById('txtdistype').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=document.getElementById('hiddeneditcode').value; 
var year=document.getElementById('txttoedition').value;
var unit=document.getElementById('hdnunit').value;

if(edinsert!="1" && edinsert!=null)
{

if((document.getElementById('DataGrid1'))!=null  )
{
    if(document.getElementById('DataGrid1').rows.length-1==1)
    {
    alert('Single row should de inserted.');
    return false;
    }
} 
        var page="";
        var edition=editcode;
        var date1="";
        var date2="";
        var date3="";
     
          var id;

	 if(document.getElementById('htext').value=="new")	
	 {
	    edition="save";
	     var id;
        var dateformat=document.getElementById('hiddendateformat').value;
        var flag="0"; 
	    edition_wise_discount.chkdup(compcode, editcode,unit,call_insert);	 
   	 window.location=window.location;
   	  return false;	
	 }
      
      else              
	{
	opener.document.getElementById('hiddendisctype').value=txteditionname;
	opener.document.getElementById('hiddendiscount').value=fromdate;
    opener.document.getElementById('hiddenfrmedition').value=todate;
    opener.document.getElementById('hiddentoedition').value=year;
    opener.document.getElementById('hiddencompcode').value=compcode;
    opener.document.getElementById('hiddenuserid').value=userid;
    
    opener.document.getElementById('hiddenunit').value=unit;
    opener.document.getElementById('hiddendateformat').value=dateformat;
    opener.document.getElementById('hiddendiscode').value=editcode;
    edition_wise_discount.chkdup(compcode, editcode,unit,call_insert);	 
   	 window.location=window.location;
return false;
	}
}
else
{
opener.document.getElementById('hiddendisctype').value=txteditionname;
	opener.document.getElementById('hiddendiscount').value=fromdate;
    opener.document.getElementById('hiddenfrmedition').value=todate;
    opener.document.getElementById('hiddentoedition').value=year;
    opener.document.getElementById('hiddencompcode').value=compcode;
    opener.document.getElementById('hiddenuserid').value=userid;
    
    opener.document.getElementById('hiddenunit').value=unit;
    opener.document.getElementById('hiddendateformat').value=dateformat;
    opener.document.getElementById('hiddendiscode').value=editcode;
    


edition_wise_discount.chkupdate(txteditionname,fromdate,todate,compcode,userid,editcode,unit,call_update);
//edition_wise_discount.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);
document.getElementById('btndelete').disabled=true;
edinsert="0";

}



return false;


}

function call_insert(response)
{

var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("Discount Code has already been assigned ");
	return false;
	}
	else
		{
            var txteditionname=document.getElementById('txtdistype').value;
            var compcode=document.getElementById('hiddencompcode').value; 
            var userid=document.getElementById('hiddenuserid').value; 
            var dateformat=document.getElementById('hiddendateformat').value; 
            var editcode=document.getElementById('hiddeneditcode').value; 
            var unit=document.getElementById('hdnunit').value; 
            var year=document.getElementById('txttoedition').value



var txtdate=document.getElementById('txtdiscount').value;
var txtaddate=document.getElementById('txtfrmedition').value;
var createddate=document.getElementById('hdndate').value;
var  updateddate="";
var updatedby="";
opener.document.getElementById('hiddendisctype').value=txteditionname;
	opener.document.getElementById('hiddendiscount').value=txtdate;
    opener.document.getElementById('hiddenfrmedition').value=txtaddate;
    opener.document.getElementById('hiddentoedition').value=year;
    opener.document.getElementById('hiddencompcode').value=compcode;
    opener.document.getElementById('hiddenuserid').value=userid;
    
    opener.document.getElementById('hiddenunit').value=unit;
    opener.document.getElementById('hiddendateformat').value=createddate;
    opener.document.getElementById('hiddendiscode').value=editcode;
    


//opener.document.getElementById('hiddeneditalias').value="";
//opener.document.getElementById('hiddeneditdate').value="";
//opener.document.getElementById('hiddeneditaddate').value="";

 edition_wise_discount.insert(compcode,unit,txtaddate,year,txteditionname,txtdate,createddate,userid,updateddate,updatedby,editcode,dateformat);		

document.getElementById('txtdistype').value="";
document.getElementById('txtdiscount').value="";
document.getElementById('txtfrmedition').value="";
document.getElementById('txttoedition').value="";
window.location=window.location
    }
	//	window.location=window.location
		return false;
}


function selectclick(ab)
{
var id=ab;
if(document.getElementById(id).checked==false)
{
document.getElementById('txtdistype').value="0";

document.getElementById('txtdiscount').value="";
document.getElementById('txtfrmedition').value="";
document.getElementById('txttoedition').value="";


document.getElementById('btndelete').disabled=true;
document.getElementById('btnsubmit').disabled=true;
document.getElementById(id).checked=false;

return;
}
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
var unitcode=trim(document.getElementById('hdnunit').value);

var j;
var k=0;


var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{

	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;


     if(id==str)
        {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;

	code10=document.getElementById(str).value;
	chk123=document.getElementById(id);
	}
	}
	}
	if(k==1)
	{
    if(document.getElementById('hiddenshow').value=="1")
	    {
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnsubmit').disabled=false;
	    }
	edition_wise_discount.selected(compcode,userid,unitcode,code10,call_select12);
	
	}
	else if(k==0)
	{

	document.getElementById('txtdistype').value="0";

document.getElementById('txtdiscount').value="";
document.getElementById('txtfrmedition').value="";
document.getElementById('txttoedition').value="";
	return false;
	}
	document.getElementById(ab).checked=true;
	
	//return false;



}

function call_select12(response)
{
var ds=response.value;
edinsert="1";
var txteditionname=document.getElementById('txtdistype').value=ds.Tables[0].Rows[0].DISC_TYPE;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 

//this is for from date
document.getElementById('txtfrmedition').value=ds.Tables[0].Rows[0].FROM_EDITION;
document.getElementById('txttoedition').value=ds.Tables[0].Rows[0].TO_EDITION;

document.getElementById('txtdiscount').value=ds.Tables[0].Rows[0].DISCOUNT;



return false;
}


function call_update(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("Discount Code has already been assigned ");
	return false;
	}
	else
		{
var txteditionname=document.getElementById('txtdistype').value;
            var compcode=document.getElementById('hiddencompcode').value; 
            var userid=document.getElementById('hiddenuserid').value; 
            var dateformat=document.getElementById('hiddendateformat').value; 
            var editcode=document.getElementById('hiddeneditcode').value; 
            var unit=document.getElementById('hdnunit').value; 
            var year=document.getElementById('txttoedition').value
var txtdate=document.getElementById('txtdiscount').value;
var txtaddate=document.getElementById('txtfrmedition').value;
var createddate="";
var  updateddate=document.getElementById('hdndate').value;;
var updatedby=document.getElementById('hiddenuserid').value;

edition_wise_discount.update(compcode,unit,txtaddate,year,txteditionname,txtdate,createddate,userid,updateddate,updatedby,editcode,dateformat);	
		}
		window.location=window.location
		return false;
}


function deletegridclick()
{

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=document.getElementById('hiddeneditcode').value; 
var unit=document.getElementById('hdnunit').value; 
if(document.getElementById('DataGrid1').rows.length-1==1)
{
    alert('One row should be present here');
    return false;
} 

 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            if (httpRequest.readyState == 4) 
            {
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    if(browser!="Microsoft Internet Explorer")
                    {
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
edition_wise_discount.deletegrid(compcode,userid,editcode,unit); 
document.getElementById('txtdiscount').enabled=true;
document.getElementById('txtfrmedition').enabled=true;
document.getElementById('txttoedition').enabled=true;
document.getElementById('txtdistype').enabled=true;
window.location=window.location;
return false;
}


function clearclick()
{

document.getElementById('txtdiscount').value="";
document.getElementById('txtfrmedition').value="";
document.getElementById('txttoedition').value="";
document.getElementById('txtdistype').value="0";

//document.getElementById('txteditionname').value="";
  //chk123.checked=false;
return false;
}

function notchar2(event) {
              
           if(browser!="Microsoft Internet Explorer")
  {  
    if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46)||(event.which==0))
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
          if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
          {
              return true;
          }
          else
          {   
              return false;
          }
          
          }
          
          if(document.getElementById('txtdiscount').value >100 ||document.getElementById('txtfrmedition').value >100 ||document.getElementById('txttoedition').value >100)
          {
          alert("can not insert the value of greater than 100");
          document.getElementById('txtdiscount').focus;
          }
      }