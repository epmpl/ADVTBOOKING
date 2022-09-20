// JScript File
var hiddentext;
var mod="0";
var z=0;
var glaobalpubname;
function btnNewClick2()
{
    document.getElementById('drpuncent').value="0";
    document.getElementById('txtengboxadd').value="";
    document.getElementById('txthinboxadd').value="";
    document.getElementById('txtpunboxadd').value=""; 

    //chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
		
	hiddentext="new";
	 document.getElementById('drpuncent').disabled=false;
    document.getElementById('txtengboxadd').disabled=false;
    document.getElementById('txthinboxadd').disabled=false;
    document.getElementById('txtpunboxadd').disabled=false; 
    
    document.getElementById('drpuncent').focus();
   // flag=0;
setButtonImages();
return false;
}
function btnCancelClick2(formname)
{
//chkstatus(FlagStatus);
//givebuttonpermission(formname);

    document.getElementById('drpuncent').value="0";
    document.getElementById('txtengboxadd').value="";
    document.getElementById('txthinboxadd').value="";
    document.getElementById('txtpunboxadd').value="";
    
     document.getElementById('drpuncent').disabled=true;
    document.getElementById('txtengboxadd').disabled=true;
    document.getElementById('txthinboxadd').disabled=true;
    document.getElementById('txtpunboxadd').disabled=true;
    
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
    document.getElementById('drpuncent').disabled=true;
    document.getElementById('txtengboxadd').disabled=false;
    document.getElementById('txthinboxadd').disabled=false;
    document.getElementById('txtpunboxadd').disabled=false;
    chkstatus(FlagStatus);
    document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnModify').disabled=false;
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnSave').focus();
    setButtonImages();
return false;
}
//var flag="";
function saveclick()
{
 document.getElementById('txtengboxadd').value=trim(document.getElementById('txtengboxadd').value);
 document.getElementById('txthinboxadd').value=trim(document.getElementById('txthinboxadd').value);
 document.getElementById('txtpunboxadd').value=trim(document.getElementById('txtpunboxadd').value);
 
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
    if(document.getElementById('drpuncent').value=="" || document.getElementById('drpuncent').value=="0")
        {
        alert("Please Enter Center Code.");
        document.getElementById('drpuncent').focus();
        return false;
        }
    if(document.getElementById('txtengboxadd').value=="" && document.getElementById('txthinboxadd').value=="" && document.getElementById('txtpunboxadd').value=="")
        {
        alert("Please Enter Any Box Address.");
        document.getElementById('txtengboxadd').focus();
        return false;
        }
var pubcent=document.getElementById('drpuncent').value;
var compcode=document.getElementById('hiddencompcode').value;
var engbox=document.getElementById('txtengboxadd').value;
var hinbox=document.getElementById('txthinboxadd').value;
var punbox=document.getElementById('txtpunboxadd').value;
if(mod !="1")
    {
    Pub_Cent_Box_Add.chkcenter(compcode,pubcent,callsave);
    return false;
    }
    else
    {
     updatepubcent();
    }
}
function  updatepubcent()
{
var pubcent=document.getElementById('drpuncent').value;
var compcode=document.getElementById('hiddencompcode').value;
var engbox=document.getElementById('txtengboxadd').value;
var hinbox=document.getElementById('txthinboxadd').value;
var punbox=document.getElementById('txtpunboxadd').value;

Pub_Cent_Box_Add.update(compcode,pubcent,engbox,hinbox,punbox);

dspubexecute.Tables[0].Rows[z].ENGLISH_BOX=document.getElementById('txtengboxadd').value;
dspubexecute.Tables[0].Rows[z].HINDI_BOX=document.getElementById('txthinboxadd').value;
dspubexecute.Tables[0].Rows[z].PUNJABI_BOX=document.getElementById('txtpunboxadd').value;

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

    document.getElementById('drpuncent').disabled=true;
    document.getElementById('txtengboxadd').disabled=true;
    document.getElementById('txthinboxadd').disabled=true;
    document.getElementById('txtpunboxadd').disabled=true;
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
    alert("This Center is already assigned.");
    document.getElementById('drpuncent').focus();
    return false;
    }
 var pubcent=document.getElementById('drpuncent').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var engbox=document.getElementById('txtengboxadd').value;
var hinbox=document.getElementById('txthinboxadd').value;
var punbox=document.getElementById('txtpunboxadd').value;  
Pub_Cent_Box_Add.pubsave(pubcent,compcode,userid,engbox,hinbox,punbox) 

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

 document.getElementById('drpuncent').disabled=true;
document.getElementById('txtengboxadd').disabled=true;
document.getElementById('txthinboxadd').disabled=true;
document.getElementById('txtpunboxadd').disabled=true;
alert("Data Saved Sucessfully");
document.getElementById('drpuncent').value="0";
document.getElementById('txtengboxadd').value="";
document.getElementById('txthinboxadd').value="";
document.getElementById('txtpunboxadd').value=""; 
//document.getElementById('drpuncent').focus();
btnCancelClick2('Pub_Cent_Box_Add');

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
document.getElementById('drpuncent').value="0";
document.getElementById('txtengboxadd').value="";
document.getElementById('txthinboxadd').value="";
document.getElementById('txtpunboxadd').value=""; 

 document.getElementById('drpuncent').disabled=false;
document.getElementById('txtengboxadd').disabled=true;
document.getElementById('txthinboxadd').disabled=true;
document.getElementById('txtpunboxadd').disabled=true;
setButtonImages();

return false;
}

function btnExecuteClick2()
{
z=0;
var pubcent=document.getElementById('drpuncent').value;
var compcode=document.getElementById('hiddencompcode').value;
glaobalpubname=pubcent;

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
Pub_Cent_Box_Add.pubcentexecute(compcode,pubcent,callexec);
    updateStatus();
    
     document.getElementById('drpuncent').disabled=true;
    document.getElementById('txtengboxadd').disabled=true;
    document.getElementById('txthinboxadd').disabled=true;
    document.getElementById('txtpunboxadd').disabled=true;
     
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
			 	document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[0].CENTERCODE;
			 	if(dspubexecute.Tables[0].Rows[0].ENGLISH_BOX != null)
				document.getElementById('txtengboxadd').value=dspubexecute.Tables[0].Rows[0].ENGLISH_BOX;
				else
				document.getElementById('txtengboxadd').value="";
				if(dspubexecute.Tables[0].Rows[0].HINDI_BOX != null)
				document.getElementById('txthinboxadd').value=dspubexecute.Tables[0].Rows[0].HINDI_BOX;
				else
				document.getElementById('txthinboxadd').value="";
				if(dspubexecute.Tables[0].Rows[0].PUNJABI_BOX != null)
				document.getElementById('txtpunboxadd').value=dspubexecute.Tables[0].Rows[0].PUNJABI_BOX;
				else
				document.getElementById('txtpunboxadd').value="";
				
				document.getElementById('drpuncent').disabled=true;
                document.getElementById('txtengboxadd').disabled=true;
                document.getElementById('txthinboxadd').disabled=true;
                document.getElementById('txtpunboxadd').disabled=true;
	    }
	    else
	    {
	        alert("Your Search Produce No Result!!!!");
			btnCancelClick2('Pub_Cent_Box_Add');
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
function pubcentfirstclick()
{
            document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[0].CENTERCODE;
            if(dspubexecute.Tables[0].Rows[0].ENGLISH_BOX != null)
			document.getElementById('txtengboxadd').value=dspubexecute.Tables[0].Rows[0].ENGLISH_BOX;
			else
			document.getElementById('txtengboxadd').value="";
			if(dspubexecute.Tables[0].Rows[0].HINDI_BOX != null)
			document.getElementById('txthinboxadd').value=dspubexecute.Tables[0].Rows[0].HINDI_BOX;
			else
			document.getElementById('txthinboxadd').value="";
			if(dspubexecute.Tables[0].Rows[0].PUNJABI_BOX != null)
			document.getElementById('txtpunboxadd').value=dspubexecute.Tables[0].Rows[0].PUNJABI_BOX;
			else
			document.getElementById('txtpunboxadd').value="";
				
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
function pubcentpreviousclick()
{
var a=dspubexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			    document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
			    if(dspubexecute.Tables[0].Rows[z].ENGLISH_BOX != null)
			    document.getElementById('txtengboxadd').value=dspubexecute.Tables[0].Rows[z].ENGLISH_BOX;
			    else
			    document.getElementById('txtengboxadd').value="";
			    if(dspubexecute.Tables[0].Rows[z].HINDI_BOX != null)
			    document.getElementById('txthinboxadd').value=dspubexecute.Tables[0].Rows[z].HINDI_BOX;
			    else
			    document.getElementById('txthinboxadd').value="";
			    if(dspubexecute.Tables[0].Rows[z].PUNJABI_BOX != null)
			    document.getElementById('txtpunboxadd').value=dspubexecute.Tables[0].Rows[z].PUNJABI_BOX;
			    else
			    document.getElementById('txtpunboxadd').value="";
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
function pubcentnextclick()
{
var a=dspubexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		    document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
		    if(dspubexecute.Tables[0].Rows[z].ENGLISH_BOX != null)
		    document.getElementById('txtengboxadd').value=dspubexecute.Tables[0].Rows[z].ENGLISH_BOX;
		    else
		    document.getElementById('txtengboxadd').value="";
		    if(dspubexecute.Tables[0].Rows[z].HINDI_BOX != null)
		    document.getElementById('txthinboxadd').value=dspubexecute.Tables[0].Rows[z].HINDI_BOX;
		    else
		    document.getElementById('txthinboxadd').value="";
		    if(dspubexecute.Tables[0].Rows[z].PUNJABI_BOX != null)
		    document.getElementById('txtpunboxadd').value=dspubexecute.Tables[0].Rows[z].PUNJABI_BOX;
		    else
		    document.getElementById('txtpunboxadd').value="";
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
function pubcatlastclick()
{
var y=dspubexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
			if(dspubexecute.Tables[0].Rows[z].ENGLISH_BOX != null)
		    document.getElementById('txtengboxadd').value=dspubexecute.Tables[0].Rows[z].ENGLISH_BOX;
		    else
		    document.getElementById('txtengboxadd').value="";
		    if(dspubexecute.Tables[0].Rows[z].HINDI_BOX != null)
		    document.getElementById('txthinboxadd').value=dspubexecute.Tables[0].Rows[z].HINDI_BOX;
		    else
		    document.getElementById('txthinboxadd').value="";
		    if(dspubexecute.Tables[0].Rows[z].PUNJABI_BOX != null)
		    document.getElementById('txtpunboxadd').value=dspubexecute.Tables[0].Rows[z].PUNJABI_BOX;
		    else
		    document.getElementById('txtpunboxadd').value="";
			
			updateStatus();
			//fillAdCat1();
		    document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            document.getElementById('btnfirst').disabled=false;
            document.getElementById('btnprevious').disabled=false;
            setButtonImages();
			return false;
}
function pubcatexitclick()
{
//if(confirm("Do You Want To Skip This Page"))
			//{
				window.close();
				return false;
			//}
			//return false;
}
function pubcatdeleteclick()
{
    updateStatus();
var pubcent=document.getElementById('drpuncent').value;
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
       Pub_Cent_Box_Add.pubcentdelete(compcode, pubcent);

			alert ("Data Deleted Successfully");
			document.getElementById('drpuncent').value="0";
            document.getElementById('txtengboxadd').value="";
            document.getElementById('txthinboxadd').value="";
            document.getElementById('txtpunboxadd').value=""; 
		

		       Pub_Cent_Box_Add.pubcentexecute(compcode,glaobalpubname,delcall);
		     }
		     return false;
}
function delcall(res)
{
 dscatexecute1= res.value;
	len=dscatexecute1.Tables[0].Rows.length;
	
	if(dscatexecute1.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
	        document.getElementById('drpuncent').value="0";
            document.getElementById('txtengboxadd').value="";
            document.getElementById('txthinboxadd').value="";
            document.getElementById('txtpunboxadd').value="";
		 btnCancelClick2('Pub_Cent_Box_Add');
		return false;
	}
	        else if(z>=len || z==-1)
	        {
			document.getElementById('drpuncent').value=dscatexecute1.Tables[0].Rows[0].CENTERCODE;
			if(dscatexecute1.Tables[0].Rows[0].ENGLISH_BOX != null)
            document.getElementById('txtengboxadd').value=dscatexecute1.Tables[0].Rows[0].ENGLISH_BOX;
            else
            document.getElementById('txtengboxadd').value="";
            if(dscatexecute1.Tables[0].Rows[0].HINDI_BOX != null)
            document.getElementById('txthinboxadd').value=dscatexecute1.Tables[0].Rows[0].HINDI_BOX;
            else
            document.getElementById('txthinboxadd').value="";
            if(dscatexecute1.Tables[0].Rows[0].PUNJABI_BOX != null)
            document.getElementById('txtpunboxadd').value=dscatexecute1.Tables[0].Rows[0].PUNJABI_BOX;
            else
            document.getElementById('txtpunboxadd').value="";
        			
	        }
	        else
	        {
	        document.getElementById('drpuncent').value=dscatexecute1.Tables[0].Rows[z].CENTERCODE;
	        if(dscatexecute1.Tables[0].Rows[z].ENGLISH_BOX != null)
            document.getElementById('txtengboxadd').value=dscatexecute1.Tables[0].Rows[z].ENGLISH_BOX;
            else
            document.getElementById('txtengboxadd').value="";
            if(dscatexecute1.Tables[0].Rows[z].HINDI_BOX != null)
            document.getElementById('txthinboxadd').value=dscatexecute1.Tables[0].Rows[z].HINDI_BOX;
            else
            document.getElementById('txthinboxadd').value="";
            if(dscatexecute1.Tables[0].Rows[z].PUNJABI_BOX != null)
            document.getElementById('txtpunboxadd').value=dscatexecute1.Tables[0].Rows[z].PUNJABI_BOX;
            else
            document.getElementById('txtpunboxadd').value="";
	        }
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dscatexecute1.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
            if(dscatexecute1.Tables[0].Rows.length ==1)
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