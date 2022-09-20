
var flag;
var z=0;
var hiddentext;
var modify;
var global_ds;
var saurabh1,saurabh2,saurabh3,saurabh4,saurabh5,saurabh6;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

//function uppercase1()
//{
//document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
//return ;
//}



function loadXML(xmlFile) 
{
    var  httpRequest =null;

    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }
    cancelbox('BoxMaster');

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
}
function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
 if (xmlDoc.readyState != 4) 
 { 
   return false; 
 } 
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


function boxnew()
{
				flag="1";
                hiddentext="new";

				/*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;*/
				
			//	document.getElementById('drpedition').disabled=false;
			
			if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtboxcode').disabled=true;
    	          }
		         else
		           {
		           document.getElementById('txtboxcode').disabled=false;
    	           }
			
				document.getElementById('txtvalidfrom').disabled=false;
			//	document.getElementById('txtboxcode').disabled=false;
				document.getElementById('txtboxdes').disabled=false;
				document.getElementById('txtdispatch').disabled=false;
				document.getElementById('drpboxcharge').disabled=false;
				document.getElementById('txtnative').disabled=false;
				document.getElementById('txtinter').disabled=false;
				document.getElementById('txtremark').disabled=false;
				document.getElementById('chkmatter').disabled=false;
				document.getElementById('txtvalidtill').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				document.getElementById('drppubcenter').disabled=false;
				
			//	document.getElementById('drpedition').value="0";
				document.getElementById('txtvalidfrom').value="";
				document.getElementById('txtboxcode').value="";
				document.getElementById('txtboxdes').value="";
				document.getElementById('txtdispatch').value="";
				document.getElementById('drpboxcharge').value="0";
				document.getElementById('txtnative').value="";
				document.getElementById('txtinter').value="";
				document.getElementById('txtremark').value="";
				document.getElementById('chkmatter').checked=false;
				document.getElementById('txtvalidtill').value="";
				document.getElementById('txtalias').value="";
	          
	            chkstatus(FlagStatus);			
	            document.getElementById('btnSave').disabled = false;	
	            document.getElementById('btnNew').disabled = true;	
	            document.getElementById('btnQuery').disabled=true;
	
	if(document.getElementById('hiddenauto').value==1)
    {
         document.getElementById('txtboxdes').disabled=false;
         document.getElementById('txtboxdes').focus();
    }
    else
    {
         document.getElementById('txtboxcode').disabled=false;
         document.getElementById('txtboxcode').focus();
    }
	
	if(document.getElementById('drppubcenter').disabled==false && document.getElementById('drppubcenter').style.display!="none" )
	    document.getElementById('drppubcenter').focus();

setButtonImages();
return false;
}






function boxmodify()
{
flag= "2";
hiddentext="modify";
modify="1";

				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').focus();
				
				document.getElementById('txtvalidfrom').disabled=false;
				document.getElementById('txtboxcode').disabled=true;
				document.getElementById('txtboxdes').disabled=false;
				document.getElementById('txtdispatch').disabled=false;
				document.getElementById('drpboxcharge').disabled=false;
				document.getElementById('txtnative').disabled=false;
				document.getElementById('txtinter').disabled=false;
				document.getElementById('txtremark').disabled=false;
				document.getElementById('chkmatter').disabled=false;
				document.getElementById('txtvalidtill').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				document.getElementById('drppubcenter').disabled=false;
				
				setButtonImages();
				return false;
}

function boxsave()
{//debugger;
    var bc;
	var fromdate,todate;
	
   // bc="saurabh";
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

   if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblpubcenter').textContent;
    }
    else
    {
        bc=document.getElementById('lblpubcenter').innerText;
    }
    
    if(bc.indexOf('*')>= 0 )
    {
        if(trim(document.getElementById('drppubcenter').value)== "0" &&document.getElementById('drppubcenter').style.display!="none" )
        {   
	        alert('Please Enter '+(bc.replace('*', "")));
            document.getElementById('drppubcenter').focus();
            return false;
        }
    }
	
   
    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblboxcode').textContent;
    }
    else
    {
        bc=document.getElementById('lblboxcode').innerText;
    }
    if(document.getElementById('hiddenauto').value!=1)
    {
	    if(bc.indexOf('*')>= 0 )
        {
            if(trim(document.getElementById('txtboxcode').value)== "" )
            {   
	            alert('Please Enter '+(bc.replace('*', "")));
                document.getElementById('txtboxcode').focus();
                return false;
            }
        }
	}

    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblboxdes').textContent;
    }
    else
    {
        bc=document.getElementById('lblboxdes').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtboxdes').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtboxdes').focus();
	            return false;
	        }
	    }
    
    
    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblalias').textContent;
    }
    else
    {
        bc=document.getElementById('lblalias').innerText;
    } 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtalias').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtalias').focus();
	            return false;
	        }
	    }
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblboxcharges').textContent;
    }
    else
    {
        bc=document.getElementById('lblboxcharges').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('drpboxcharge').value)== "0" )
	        {   
	            //bc.replace('*', "")
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('drpboxcharge').focus();
	            return false;
	        }
	    }
	    
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblnative').textContent;
    }
    else
    {
        bc=document.getElementById('lblnative').innerText;
    } 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtnative').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtnative').focus();
	            return false;
	        }
	        else
	        {
	        var sau=parseFloat(document.getElementById('txtnative').value);
document.getElementById('txtnative').value=sau;
if(document.getElementById('drpboxcharge').value=="2")
{
if(sau>100)
{
    alert("For National Percentage Should Not Be Greater Than 100");
    document.getElementById('txtnative').value="";
    document.getElementById('txtnative').focus();
    return false;
    }
}
}
	    }
	    
   	
   	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblinter').textContent;
    }
    else
    {
        bc=document.getElementById('lblinter').innerText;
    } 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtinter').value)== "" && document.getElementById('txtinter').style.display!="none" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtinter').focus();
	            return false;
	        }
	        else
	        {
	            
var sau=parseFloat(document.getElementById('txtinter').value);
document.getElementById('txtinter').value=sau;
if(document.getElementById('drpboxcharge').value=="2")
{
if(sau>100)
{
    alert("For International Percentage Should Not Be Greater Than 100");
    document.getElementById('txtinter').value="";
    document.getElementById('txtinter').focus();
    return false;
}
}
	        }
	        
	    }
	
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblvalidfrom').textContent;
    }
    else
    {
        bc=document.getElementById('lblvalidfrom').innerText;
    }  
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtvalidfrom').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtvalidfrom').focus();
	            return false;
	        }
	    }
	
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblvalidtill').textContent;
    }
    else
    {
        bc=document.getElementById('lblvalidtill').innerText;
    } 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtvalidtill').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtvalidtill').focus();
	            return false;
	        }
	    } 
	    
	    if(trim(document.getElementById('txtdispatch').value)!="")
	    {
	        var dis= parseInt(document.getElementById('txtdispatch').value);
	        document.getElementById('txtdispatch').value=dis;
	    }
	
	

if(dis==0)
{
    alert("No. of dispatches should not be zero");
    document.getElementById('txtdispatch').value="";
    document.getElementById('txtdispatch').focus();
    return false;
}
else if(dis==NaN)
{
    document.getElementById('txtdispatch').value="";
    document.getElementById('txtdispatch').focus();
}
else if(dis=="NaN")
{
    document.getElementById('txtdispatch').value="";
    document.getElementById('txtdispatch').focus();
}	    
else if(dis=='NaN')
{
    document.getElementById('txtdispatch').value="";
    document.getElementById('txtdispatch').focus();
}

		
	//var editioncode = document.getElementById('drpedition').value;
	var boxcode = trim(document.getElementById('txtboxcode').value);
	var boxname = trim(document.getElementById('txtboxdes').value);
	var alias= trim(document.getElementById('txtalias').value);
	var dispatch= document.getElementById('txtdispatch').value;
	var boxcharge = document.getElementById('drpboxcharge').value;
	var native1 = document.getElementById('txtnative').value;
	var inter = document.getElementById('txtinter').value;
			//var fromdate = document.getElementById('txtvalidfrom').value;
			//var todate= document.getElementById('txtvalidtill').value;
	var remarks = trim(document.getElementById('txtremark').value);
	var inc_matter=trim(document.getElementById('chkmatter').value);
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var pubcenter = document.getElementById('drppubcenter').value;


			
		if(dateformat=="dd/mm/yyyy")
							{
								var txtfrom=document.getElementById('txtvalidfrom').value;
								var txtto=document.getElementById('txtvalidtill').value;
								
								var txt1=txtfrom.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtvalidfrom').value;
								todate=document.getElementById('txtvalidtill').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtvalidfrom').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtvalidtill').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtvalidfrom').value;
								todate=document.getElementById('txtvalidtill').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			alert("Valid To date must be greater than Valid From date");
			document.getElementById('txtvalidtill').disabled=false;
			document.getElementById('txtvalidtill').value="";
			document.getElementById('txtvalidtill').focus();
			return false;
			}

		}

		if(flag=="1")		
		{
	       BoxMaster.savechk(boxcode,boxname,compcode,userid,pubcenter,callsave)
		    return false;
		}

		else
		{

        BoxMaster.modifychk(boxcode,boxname,compcode,userid,pubcenter,callmodify)
        return false;
        }
//	BoxMaster.update(editioncode,boxcode,boxname,alias,dispatch,boxcharge,native1,inter,fromdate,todate,remarks,compcode,userid)


       


return  false;
}

function callmodify(rr)
{
    var ds=rr.value;

    if(ds.Tables[0].Rows.length>0)
    {
    alert('This Box Description Already Exists.');
    document.getElementById('txtboxdes').disabled=false;
    document.getElementById('txtboxdes').value="";
    document.getElementById('txtboxdes').focus();
    }
    else
    {
    
        var fromdate,todate;
        
    var boxcode = trim(document.getElementById('txtboxcode').value);
	var boxname = trim(document.getElementById('txtboxdes').value);
	var alias= trim(document.getElementById('txtalias').value);
	var dispatch= document.getElementById('txtdispatch').value;
	var boxcharge = document.getElementById('drpboxcharge').value;
	var native1 = document.getElementById('txtnative').value;
	var inter = document.getElementById('txtinter').value;
			//var fromdate = document.getElementById('txtvalidfrom').value;
			//var todate= document.getElementById('txtvalidtill').value;
	var remarks = trim(document.getElementById('txtremark').value);
	var inc_matter=trim(document.getElementById('chkmatter').value);
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var pubcenter = document.getElementById('drppubcenter').value;


			
		if(dateformat=="dd/mm/yyyy")
							{
								var txtfrom=document.getElementById('txtvalidfrom').value;
								var txtto=document.getElementById('txtvalidtill').value;
								
								var txt1=txtfrom.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtvalidfrom').value;
								todate=document.getElementById('txtvalidtill').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtvalidfrom').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtvalidtill').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtvalidfrom').value;
								todate=document.getElementById('txtvalidtill').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			alert("Valid To date must be greater than Valid From date");
			document.getElementById('txtvalidtill').disabled=false;
			document.getElementById('txtvalidtill').value="";
			document.getElementById('txtvalidtill').focus();
			return false;
			}

		}
        
        var ip2=document.getElementById('ip1').value;
           if(document.getElementById('chkmatter').checked==false)
             inc_matter ='N';
             else
               inc_matter ='Y';  
 BoxMaster.update(boxcode,boxname,alias,dispatch,boxcharge,native1,inter,fromdate,todate,remarks,compcode,userid,pubcenter,ip2,inc_matter)

					document.getElementById('txtboxcode').disabled=true;
					document.getElementById('txtvalidfrom').disabled=true;
					document.getElementById('txtboxdes').disabled=true;
					document.getElementById('txtdispatch').disabled=true;
					document.getElementById('drpboxcharge').disabled=true;
					document.getElementById('txtnative').disabled=true;
					document.getElementById('txtinter').disabled=true;
				
					document.getElementById('chkmatter').disabled=false;
					document.getElementById('txtvalidtill').disabled=true;
					document.getElementById('txtalias').disabled=true;
					
					document.getElementById('drppubcenter').disabled=true;
		flag=0;
updateStatus();
        var x=global_ds.Tables[0].Rows.length;
	y=z;	
if (z==0)
{
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
}

if(z==(global_ds.Tables[0].Rows.length-1))
{
    document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
}
        document.getElementById('btnModify').focus();
//		alert(xmlObj.childNodes(0).childNodes(1).text);
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }  
        setButtonImages();
		return false;
		}
		setButtonImages();
		return false;
}


function callsave(res)
{
        ds=res.value;
        if(ds.Tables[0].Rows.length>0)
        {
            alert("This Box Code Alresady Exist");
            document.getElementById('txtboxcode').value="";
            document.getElementById('txtboxcode').focus();
            return false;
        }
        
        if(ds.Tables[1].Rows.length>0)
        {
          
            alert("This Box Description Is Already Assigned.");
            document.getElementById('txtboxdes').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtboxdes').focus();
            return false;
        }
        else
        {
            var fromdate,todate;
            var boxcode = trim(document.getElementById('txtboxcode').value);
            var boxname = trim(document.getElementById('txtboxdes').value);
            var alias= trim(document.getElementById('txtalias').value);
            var dispatch= document.getElementById('txtdispatch').value;
            var boxcharge = document.getElementById('drpboxcharge').value;
            var native1 = document.getElementById('txtnative').value;
            var inter = document.getElementById('txtinter').value;
            //var fromdate = document.getElementById('txtvalidfrom').value;
            //var todate= document.getElementById('txtvalidtill').value;
            var remarks = trim(document.getElementById('txtremark').value);
            var inc_matter=trim(document.getElementById('chkmatter').value);
            var compcode = document.getElementById('hiddencompcode').value;
            var userid = document.getElementById('hiddenuserid').value;
            var dateformat = document.getElementById('hiddendateformat').value;
            
            var pubcenter = document.getElementById('drppubcenter').value;



            if(dateformat=="dd/mm/yyyy")
			            {
				            var txtfrom=document.getElementById('txtvalidfrom').value;
				            var txtto=document.getElementById('txtvalidtill').value;
            				
				            var txt1=txtfrom.split("/");
				            var dd=txt1[0];
				            var mm=txt1[1];
				            var yy=txt1[2];
				            fromdate=mm+'/'+dd+'/'+yy;
				            var txtto1=txtto.split("/");
				            var dd1=txtto1[0];
				            var mm1=txtto1[1];
				            var yy1=txtto1[2];
				            todate=mm1+'/'+dd1+'/'+yy1;
            				
			            }
			            else if(dateformat=="mm/dd/yyyy")
			            {
				            fromdate=document.getElementById('txtvalidfrom').value;
				            todate=document.getElementById('txtvalidtill').value;
			            }
            				
			            else if(dateformat=="yyyy/mm/dd")
			            {
				            var txt=document.getElementById('txtvalidfrom').value;
				            var txt1=txt.split("/");
				            var yy=txt1[0];
				            var mm=txt1[1];
				            var dd=txt1[2];
				            fromdate=mm+'/'+dd+'/'+yy;
				            var txtto=document.getElementById('txtvalidtill').value;
				            var txtto1=txtto.split("/");
				            var yy1=txtto1[0];
				            var mm1=txtto1[1];
				            var dd1=txtto1[2];
				            todate=mm1+'/'+dd1+'/'+yy1;
			            }
			            if(dateformat==null || dateformat=="" || dateformat=="undefined")
			            {
				            alert("dateformat  is either null or undefined");
				            fromdate=document.getElementById('txtvalidfrom').value;
				            todate=document.getElementById('txtvalidtill').value;
			            }
            		
            if(todate != "" || todate != null || todate != "undefined")
            {
            tdate = new Date(todate);
            fdate= new Date(fromdate);
            if(tdate<fdate)
            {
            alert("Valid To date must be greater than Valid From date");
            document.getElementById('txtvalidtill').disabled=false;
            document.getElementById('txtvalidtill').focus();
            return false;
            }

            }
             var inc_matter
            if(document.getElementById('chkmatter').checked==false)
             inc_matter ='N';
             else
               inc_matter ='Y';  
            //BoxMaster.save(editioncode,boxcode,boxname,alias,dispatch,boxcharge,native1,inter,fromdate,todate,remarks,compcode,userid)
           var ip2=document.getElementById('ip1').value;
            BoxMaster.save(boxcode,boxname,alias,dispatch,boxcharge,native1,inter,fromdate,todate,remarks,compcode,userid,pubcenter,ip2,inc_matter)



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
            	
            //				document.getElementById('drpedition').value="0";
            document.getElementById('txtvalidfrom').value="";
            document.getElementById('txtboxcode').value="";
            document.getElementById('txtboxdes').value="";
            document.getElementById('txtdispatch').value="";
            document.getElementById('drpboxcharge').value="0";
            document.getElementById('txtnative').value="";
            document.getElementById('txtinter').value="";
            document.getElementById('txtremark').value="";
            document.getElementById('chkmatter').value="";
            document.getElementById('chkmatter').checked=false;
            document.getElementById('txtvalidtill').value="";
            document.getElementById('txtalias').value="";
            
            document.getElementById('drppubcenter').value="0";

            //			document.getElementById('drpedition').disabled=true;
            document.getElementById('txtboxcode').disabled=true;
            document.getElementById('txtvalidfrom').disabled=true;
            document.getElementById('txtboxdes').disabled=true;
            document.getElementById('txtdispatch').disabled=true;
            document.getElementById('drpboxcharge').disabled=true;
            document.getElementById('txtnative').disabled=true;
            document.getElementById('txtinter').disabled=true;
            document.getElementById('txtremark').disabled=true;
            document.getElementById('chkmatter').disabled=false;
            document.getElementById('txtvalidtill').disabled=true;
            document.getElementById('txtalias').disabled=true;
            
            document.getElementById('drppubcenter').disabled=true;

            //alert ("Data Saved");
             if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(0).text);
            }  
            setButtonImages();	
            return false;
        }
      
return false;

}


function boxquery()

{
				chkstatus(FlagStatus);
				document.getElementById('btnQuery').disabled=true;
	            document.getElementById('btnExecute').disabled=false;
	            document.getElementById('btnSave').disabled=true;
	            
	            hiddentext="query";
	            z=0;
	
				document.getElementById('txtvalidfrom').value="";
				document.getElementById('txtboxcode').value="";
				document.getElementById('txtboxdes').value="";
				document.getElementById('txtdispatch').value="";
				document.getElementById('drpboxcharge').value="0";
				document.getElementById('txtnative').value="";
				document.getElementById('txtinter').value="";
				document.getElementById('txtremark').value="";
				document.getElementById('chkmatter').checked="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('txtalias').value="";
				
				document.getElementById('drppubcenter').value="0";
				
				document.getElementById('txtvalidfrom').disabled=true;
				document.getElementById('txtboxcode').disabled=false;
				document.getElementById('txtboxdes').disabled=false;
				document.getElementById('txtdispatch').disabled=true;
				document.getElementById('drpboxcharge').disabled=false;
				document.getElementById('txtnative').disabled=true;
				document.getElementById('txtinter').disabled=true;
				document.getElementById('txtremark').disabled=true;
				document.getElementById('chkmatter').disabled=true;
				document.getElementById('txtvalidtill').disabled=true;
				document.getElementById('txtalias').disabled=false;
				
				document.getElementById('drppubcenter').disabled=false;
				
	//			document.getElementById('drpedition').value="0";
				
				setButtonImages();
				document.getElementById('btnExecute').focus();
	

return false;
}


function boxexe()
{
//		var editioncode = document.getElementById('drpedition').value;
		var boxcode = document.getElementById('txtboxcode').value;
		var boxname = document.getElementById('txtboxdes').value;
		var alias= document.getElementById('txtalias').value;
		var boxcharge = document.getElementById('drpboxcharge').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		
		var pubcenter = document.getElementById('drppubcenter').value;
		
		 saurabh1 = document.getElementById('txtboxcode').value;
		 saurabh2 = document.getElementById('txtboxdes').value;
		 saurabh3= document.getElementById('txtalias').value;
		 saurabh4 = document.getElementById('drpboxcharge').value;
		 saurabh5 = document.getElementById('hiddencompcode').value;
		 saurabh6 = document.getElementById('hiddenuserid').value;
		 saurabh7 = document.getElementById('drppubcenter').value;
		
		//var dispatch= document.getElementById('txtdispatch').value;
		//var native1 = document.getElementById('txtnative').value;
		//var inter = document.getElementById('txtinter').value;
		//var fromdate = document.getElementById('txtvalidfrom').value;
		//var todate= document.getElementById('txtvalidtill').value;
		//var remarks = document.getElementById('txtremark').value;
		//var dateformat = document.getElementById('hiddendateformat').value;
		
//		BoxMaster.exebox(editioncode,boxcode,boxname,alias,boxcharge,compcode,userid,exeboxcall)
		
		BoxMaster.exebox(boxcode,boxname,alias,boxcharge,compcode,userid,pubcenter,exeboxcall)
		
				
		updateStatus();
		
       
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	
	
						
return false;
}


function exeboxcall(response)
		{
		//alert("hi");
		var fromdate,todate;
		
		global_ds=response.value;
		 if(global_ds.Tables[0].Rows.length>0)
		{		
				var num=global_ds.Tables[0].Rows[0].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[0].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
				//var native2=num.toFixed(2);//to convert the number into a string with decimal representation with the given no. of decimal places
				//document.getElementById('txtnative').value=native2;
				document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[0].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[0].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);//to convert the number into a string with decimal representation with the given no. of decimal places
//				document.getElementById('txtinter').value=native3;
                document.getElementById('txtinter').value=num1;
				}
				
			//	document.getElementById('drpedition').value=global_ds.Tables[0].Rows[0].Edition_Code;
				document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[0].Box_Code;
				document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[0].Box_Name;
				document.getElementById('txtalias').value=global_ds.Tables[0].Rows[0].Box_Alias;
				document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[0].Box_Charges_Type;
				document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].pub_center;
				//document.getElementById('hiddencompcode').value=global_ds.Tables[0].Rows[0].length;
				//document.getElementById('hiddenuserid').value=global_ds.Tables[0].Rows[0].length;
				if(global_ds.Tables[0].Rows[0].Dispatches==null || global_ds.Tables[0].Rows[0].Dispatches=="null")
				{
				    document.getElementById('txtdispatch').value="";
				}
				else
				{
				    document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[0].Dispatches;
				}
				//document.getElementById('txtnative').value=global_ds.Tables[0].Rows[0].Box_Charges_Native;
				//document.getElementById('txtinter').value=global_ds.Tables[0].Rows[0].Box_Charges_Inter;
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[0].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[0].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[0].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtvalidfrom').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
				if(global_ds.Tables[0].Rows[0].Remarks==null || global_ds.Tables[0].Rows[0].Remarks=="null")
				{
				    document.getElementById('txtremark').value="";
				}
				else
				{
				    document.getElementById('txtremark').value=global_ds.Tables[0].Rows[0].Remarks;
				}
				
				
				if(global_ds.Tables[0].Rows[0].INC_WORD_MATTER==null || global_ds.Tables[0].Rows[0].INC_WORD_MATTER=="null")
				{
				    document.getElementById('chkmatter').checked=false;
				}
				else
				{
				    if(global_ds.Tables[0].Rows[0].INC_WORD_MATTER=="Y")
				    document.getElementById('chkmatter').checked=true;
				     else
				    document.getElementById('chkmatter').checked=false;
				}
				
				
			
						
			//			document.getElementById('drpedition').disabled=true;
						document.getElementById('txtboxcode').disabled=true;
						document.getElementById('txtvalidfrom').disabled=true;
						document.getElementById('txtboxdes').disabled=true;
						document.getElementById('txtdispatch').disabled=true;
						document.getElementById('drpboxcharge').disabled=true;
						document.getElementById('txtnative').disabled=true;
						document.getElementById('txtinter').disabled=true;
						document.getElementById('txtremark').disabled=true;
						document.getElementById('txtvalidtill').disabled=true;
						document.getElementById('txtalias').disabled=true;
						
						document.getElementById('drppubcenter').disabled=true;
						
						if(global_ds.Tables[0].Rows.length==1)
		                {
			                document.getElementById('btnfirst').disabled=true;
			                document.getElementById('btnnext').disabled=true;
			                document.getElementById('btnlast').disabled=true;
			                //document.getElementById('btnExit').disabled=false;
			                document.getElementById('btnprevious').disabled=true;
		
		                }
		                setButtonImages();;
                        return false;
		}

		else
		{
			alert("Your Search Criteria Does Not Produce Any Result");
			
			cancelbox('BoxMaster');
			return false;
		}
		setButtonImages();
		return false;
}


function boxfirst()

{
		
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;

		//BoxMaster.fnplbox(compcode,userid)//,firstcall)
		
//		updateStatus();

//  		    document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnnext').disabled=false;
				
				
		
//		return false;
//}

//function firstcall(response)
//		{
//		//alert("hi")
//		 z = 0;
//				global_ds=response.value;
	//	document.getElementById('drpedition').value=global_ds.Tables[0].Rows[0].Edition_Code;
	z=0;
				document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[0].Box_Code;
				document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[0].Box_Name;
				document.getElementById('txtalias').value=global_ds.Tables[0].Rows[0].Box_Alias;
				document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[0].Box_Charges_Type;
				
				document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].pub_center;
				//document.getElementById('hiddencompcode').value=global_ds.Tables[0].Rows[0].length;
				//document.getElementById('hiddenuserid').value=global_ds.Tables[0].Rows[0].length;
				if(global_ds.Tables[0].Rows[0].Dispatches==null || global_ds.Tables[0].Rows[0].Dispatches=="null")
				{
				    document.getElementById('txtdispatch').value="";
				}
				else
				{
				    document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[0].Dispatches;
				}
				//document.getElementById('txtnative').value=global_ds.Tables[0].Rows[0].Box_Charges_Native;
				//document.getElementById('txtinter').value=global_ds.Tables[0].Rows[0].Box_Charges_Inter;
				
				
				var num=global_ds.Tables[0].Rows[0].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[0].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
//				var native2=num.toFixed(2);
//				document.getElementById('txtnative').value=native2;
                document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[0].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[0].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);
//				document.getElementById('txtinter').value=native3;
				document.getElementById('txtinter').value=num1;
				}
		
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[0].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[0].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[0].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
										
				document.getElementById('txtvalidfrom').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
				if(global_ds.Tables[0].Rows[0].Remarks==null || global_ds.Tables[0].Rows[0].Remarks=="null")
				{
				    document.getElementById('txtremark').value="";
				}
				else
				{
				    document.getElementById('txtremark').value=global_ds.Tables[0].Rows[0].Remarks;
				}
				
				
					if(global_ds.Tables[0].Rows[0].INC_WORD_MATTER==null || global_ds.Tables[0].Rows[0].INC_WORD_MATTER=="null")
				{
				    document.getElementById('chkmatter').checked=false;
				}
				else
				{
				    if(global_ds.Tables[0].Rows[0].INC_WORD_MATTER=="Y")
				    document.getElementById('chkmatter').checked=true;
				     else
				    document.getElementById('chkmatter').checked=false;
				}
				
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




function boxpre()
{
var compcode = document.getElementById('hiddencompcode').value;
var userid = document.getElementById('hiddenuserid').value;


//BoxMaster.fnplbox(compcode,userid)//,precall)

//return false;

//}

//function precall(response)
//	{
//	z--;
//	global_ds=response.value;
	z--;
	var x=global_ds.Tables[0].Rows.length;
	
	

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
					if(global_ds.Tables[0].Rows.length != z)
					{
					//	document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].Edition_Code;
						document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[z].Box_Code;
						document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[z].Box_Name;
						document.getElementById('txtalias').value=global_ds.Tables[0].Rows[z].Box_Alias;
						document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[z].Box_Charges_Type;
						
						document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].pub_center;
						//document.getElementById('hiddencompcode').value=ds.Tables[0].Rows[0].length;
						//document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[0].length;
						if(global_ds.Tables[0].Rows[z].Dispatches==null || global_ds.Tables[0].Rows[z].Dispatches=="null")
						{
						    document.getElementById('txtdispatch').value="";
						}
						else
						{
						    document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[z].Dispatches;
						}
						//document.getElementById('txtnative').value=ds.Tables[0].Rows[z].Box_Charges_Native;
						//document.getElementById('txtinter').value=ds.Tables[0].Rows[z].Box_Charges_Inter;
						
		var num=global_ds.Tables[0].Rows[z].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[z].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
//				var native2=num.toFixed(2);
//				document.getElementById('txtnative').value=native2;
				document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[z].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[z].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);
//				document.getElementById('txtinter').value=native3;
				document.getElementById('txtinter').value=num1;
				}
				
						var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[z].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[z].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[z].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
					document.getElementById('txtvalidfrom').value=fromdate;
					document.getElementById('txtvalidtill').value=todate;
					if(global_ds.Tables[0].Rows[z].Remarks==null || global_ds.Tables[0].Rows[z].Remarks=="null")
					{
					    document.getElementById('txtremark').value="";
					}
					else
					{
					    document.getElementById('txtremark').value=global_ds.Tables[0].Rows[z].Remarks;
					}
					
					
	if(global_ds.Tables[0].Rows[z].INC_WORD_MATTER==null || global_ds.Tables[0].Rows[z].INC_WORD_MATTER=="null")
				{
				    document.getElementById('chkmatter').checked=false;
				}
				else
				{
				    if(global_ds.Tables[0].Rows[z].INC_WORD_MATTER=="Y")
				    document.getElementById('chkmatter').checked=true;
				     else
				    document.getElementById('chkmatter').checked=false;
				}

					
					
					
									updateStatus();
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
		//document.getElementById('btnModify').focus();
							
					}
					else
					{
							document.getElementById('btnnext').disabled=true;
							document.getElementById('btnlast').disabled=false;
							document.getElementById('btnfirst').disabled=true;
							document.getElementById('btnprevious').disabled=false;
							//document.getElementById('btnModify').focus();
							return false;
		
					}
			
			
			}
				else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			return false;
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
				




function boxnextt()
{
var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;

//BoxMaster.fnplbox(compcode,userid)

//return false;



//}



//function nextcall(response)
//{
//	z++;
//	global_ds=response.value;
z++;
	var x=global_ds.Tables[0].Rows.length;
	var a=x;
	
	if(z <= x && z!=-1)

	{
		if(global_ds.Tables[0].Rows.length != z && z>=0)
		
		{
	//	document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].Edition_Code;
				document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[z].Box_Code;
				document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[z].Box_Name;
				document.getElementById('txtalias').value=global_ds.Tables[0].Rows[z].Box_Alias;
				document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[z].Box_Charges_Type;
				
				document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].pub_center;
				
				//document.getElementById('hiddencompcode').value=global_ds.Tables[0].Rows[0].length;
				//document.getElementById('hiddenuserid').value=global_ds.Tables[0].Rows[0].length;
				if(global_ds.Tables[0].Rows[z].Dispatches==null || global_ds.Tables[0].Rows[z].Dispatches=="null")
				{
				    document.getElementById('txtdispatch').value="";
				}
				else
				{
				    document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[z].Dispatches;
				}
				//document.getElementById('txtnative').value=global_ds.Tables[0].Rows[z].Box_Charges_Native;
				//document.getElementById('txtinter').value=global_ds.Tables[0].Rows[z].Box_Charges_Inter;
				
				
		var num=global_ds.Tables[0].Rows[z].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[z].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
//				var native2=num.toFixed(2);
//				document.getElementById('txtnative').value=native2;
				document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[z].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[z].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);
//				document.getElementById('txtinter').value=native3;
                document.getElementById('txtinter').value=num1;
				}
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[z].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[z].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[z].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
						
				document.getElementById('txtvalidfrom').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
				if(global_ds.Tables[0].Rows[z].Remarks==null || global_ds.Tables[0].Rows[z].Remarks=="null")
				{
				    document.getElementById('txtremark').value="";
				}
				else
				{
				    document.getElementById('txtremark').value=global_ds.Tables[0].Rows[z].Remarks;
				}
				
				
					if(global_ds.Tables[0].Rows[z].INC_WORD_MATTER==null || global_ds.Tables[0].Rows[z].INC_WORD_MATTER=="null")
				{
				    document.getElementById('chkmatter').checked=false;
				}
				else
				{
				    if(global_ds.Tables[0].Rows[z].INC_WORD_MATTER=="Y")
				    document.getElementById('chkmatter').checked=true;
				     else
				    document.getElementById('chkmatter').checked=false;
				}
				
				
				    
              updateStatus();
              document.getElementById('btnnext').disabled=false;
              document.getElementById('btnlast').disabled=false;
              document.getElementById('btnfirst').disabled=false;
              document.getElementById('btnprevious').disabled=false;
					//return false;	
		}
		else
		{
            document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			//document.getElementById('btnModify').focus();
			return false;
					
		}
		
		
    }
    else
	    {
            document.getElementById('btnfirst').disabled=false;				
		    document.getElementById('btnnext').disabled=true;					
		    document.getElementById('btnprevious').disabled=false;			
		    document.getElementById('btnlast').disabled=true;
		    return false;
    					
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



		
function boxlast()
{
var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;

//BoxMaster.fnplbox(compcode,userid);
//return false;

//}


//function lastcall(response)
//			{
//				//alert("hi");
//			 global_ds= response.value;
				var x=global_ds.Tables[0].Rows.length;
				z=x-1;
				x=x-1;
				
			//	document.getElementById('drpedition').value=global_ds.Tables[0].Rows[x].Edition_Code;
				document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[x].Box_Code;
				document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[x].Box_Name;
				document.getElementById('txtalias').value=global_ds.Tables[0].Rows[x].Box_Alias;
				document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[x].Box_Charges_Type;
				
				document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[x].pub_center;
				//document.getElementById('hiddencompcode').value=global_ds.Tables[0].Rows[0].length;
				//document.getElementById('hiddenuserid').value=global_ds.Tables[0].Rows[0].length;
				if(global_ds.Tables[0].Rows[x].Dispatches==null || global_ds.Tables[0].Rows[x].Dispatches=="null")
				{
				    document.getElementById('txtdispatch').value="";
				}
				else
				{
				    document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[x].Dispatches;
				}
				//document.getElementById('txtnative').value=global_ds.Tables[0].Rows[x].Box_Charges_Native;
				//document.getElementById('txtinter').value=global_ds.Tables[0].Rows[x].Box_Charges_Inter;
				
				
		var num=global_ds.Tables[0].Rows[x].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[x].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
//				var native2=num.toFixed(2);
//				document.getElementById('txtnative').value=native2;
                document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[x].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[x].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);
//				document.getElementById('txtinter').value=native3;
                document.getElementById('txtinter').value=num1;
				}
				
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[x].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[x].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[x].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
						
				document.getElementById('txtvalidfrom').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
				if(global_ds.Tables[0].Rows[x].Remarks==null || global_ds.Tables[0].Rows[x].Remarks=="null")
				{
				    document.getElementById('txtremark').value="";
				}
				else
				{
				    document.getElementById('txtremark').value=global_ds.Tables[0].Rows[x].Remarks;
				}
				
				
					if(global_ds.Tables[0].Rows[x].INC_WORD_MATTER==null || global_ds.Tables[0].Rows[x].INC_WORD_MATTER=="null")
				{
				    document.getElementById('chkmatter').checked=false;
				}
				else
				{
				    if(global_ds.Tables[0].Rows[x].INC_WORD_MATTER=="Y")
				    document.getElementById('chkmatter').checked=true;
				     else
				    document.getElementById('chkmatter').checked=false;
				}
				
				
				updateStatus();
				//document.getElementById('btnModify').focus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;


setButtonImages();
return false;
}

function cancelbox(formname)
{
                chkstatus(FlagStatus);
                givebuttonpermission(formname);
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
				document.getElementById('btnExit').disabled=false;	
				document.getElementById('btnDelete').disabled = true;*/
				
		//		document.getElementById('drpedition').value="0";
				document.getElementById('txtvalidfrom').value="";
				document.getElementById('txtboxcode').value="";
				document.getElementById('txtboxdes').value="";
				document.getElementById('txtdispatch').value="";
				document.getElementById('drpboxcharge').value="0";
				document.getElementById('txtnative').value="";
				document.getElementById('txtinter').value="";
				document.getElementById('txtremark').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('txtalias').value="";
				
				document.getElementById('drppubcenter').value="0";
				
				
				//	document.getElementById('drpedition').disabled=true;
					document.getElementById('txtboxcode').disabled=true;
					document.getElementById('txtvalidfrom').disabled=true;
					document.getElementById('txtboxdes').disabled=true;
					document.getElementById('txtdispatch').disabled=true;
					document.getElementById('drpboxcharge').disabled=true;
					document.getElementById('txtnative').disabled=true;
					document.getElementById('txtinter').disabled=true;
					document.getElementById('txtremark').disabled=true;
					document.getElementById('txtvalidtill').disabled=true;
					document.getElementById('txtalias').disabled=true;
					
					document.getElementById('drppubcenter').disabled=true;
					setButtonImages();
					if(document.getElementById('btnNew').disabled==false)
					{
					    document.getElementById('btnNew').focus();
					}
                    return false;
}




function deletebox()
{
            updateStatus();
		//	var editioncode = document.getElementById('drpedition').value;
			var boxcode = document.getElementById('txtboxcode').value;
			var compcode = document.getElementById('hiddencompcode').value;
			var userid = document.getElementById('hiddenuserid').value;
			
			if(confirm("Are you sure you want to delete the data."))
			{
		//	BoxMaster.boxdelete(editioncode,boxcode,compcode,userid);
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
       var ip2=document.getElementById('ip1').value;
BoxMaster.boxdelete(boxcode,compcode,userid,ip2);
		
			//alert("Data Deleted Successfully");
			
			if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(2).text);
            }
			
			
			BoxMaster.exebox(saurabh1,saurabh2,saurabh3,saurabh4,saurabh5,saurabh6,saurabh7,call_deletebox)
			
		//	BoxMaster.fnplbox(compcode,userid,call_deletebox);
			
			}
						
	return false;
}

function call_deletebox(response)
{
var global_ds=response.value;
var a= global_ds.Tables[0].Rows.length;
var y=a;
if( y <=0 )
	{
	alert("There Is No Data In The Database");
//	document.getElementById('drpedition').value="0";
				document.getElementById('txtvalidfrom').value="";
				document.getElementById('txtboxcode').value="";
				document.getElementById('txtboxdes').value="";
				document.getElementById('txtdispatch').value="";
				document.getElementById('drpboxcharge').value="0";
				document.getElementById('txtnative').value="";
				document.getElementById('txtinter').value="";
				document.getElementById('txtremark').value="";
				document.getElementById('txtvalidtill').value="";
				document.getElementById('txtalias').value="";
cancelbox('BoxMaster');
	}
	
	else if(z==-1 ||z>=a)
	{
	
//document.getElementById('drpedition').value=global_ds.Tables[0].Rows[0].Edition_Code;
				document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[0].Box_Code;
				document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[0].Box_Name;
				document.getElementById('txtalias').value=global_ds.Tables[0].Rows[0].Box_Alias;
				document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[0].Box_Charges_Type;
				//document.getElementById('hiddencompcode').value=global_ds.Tables[0].Rows[0].length;
				//document.getElementById('hiddenuserid').value=global_ds.Tables[0].Rows[0].length;
				if(global_ds.Tables[0].Rows[0].Dispatches==null || global_ds.Tables[0].Rows[0].Dispatches=="null")
				{
				    document.getElementById('txtdispatch').value="";
				}
				else
				{
				    document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[0].Dispatches;
				}
				//document.getElementById('txtnative').value=global_ds.Tables[0].Rows[0].Box_Charges_Native;
				//document.getElementById('txtinter').value=global_ds.Tables[0].Rows[0].Box_Charges_Inter;
				
				
				var num=global_ds.Tables[0].Rows[0].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[0].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
//				var native2=num.toFixed(2);
//				document.getElementById('txtnative').value=native2;
                document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[0].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[0].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);
//				document.getElementById('txtinter').value=native3;
                document.getElementById('txtnative').value=num1;
				}
		
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[0].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[0].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[0].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
										
				document.getElementById('txtvalidfrom').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
				if(global_ds.Tables[0].Rows[0].Remarks==null || global_ds.Tables[0].Rows[0].Remarks=="null")
				{
				    document.getElementById('txtremark').value="";
				}
				else
				{
				    document.getElementById('txtremark').value=global_ds.Tables[0].Rows[0].Remarks;
				}
				
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnnext').disabled=true;
				
				
				
return false;
	}
	
	else
	{
	
                //document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].Edition_Code;
				document.getElementById('txtboxcode').value=global_ds.Tables[0].Rows[z].Box_Code;
				document.getElementById('txtboxdes').value=global_ds.Tables[0].Rows[z].Box_Name;
				document.getElementById('txtalias').value=global_ds.Tables[0].Rows[z].Box_Alias;
				document.getElementById('drpboxcharge').value=global_ds.Tables[0].Rows[z].Box_Charges_Type;
				//document.getElementById('hiddencompcode').value=global_ds.Tables[0].Rows[0].length;
				//document.getElementById('hiddenuserid').value=global_ds.Tables[0].Rows[0].length;
				if(global_ds.Tables[0].Rows[z].Dispatches!=null)
				{
				document.getElementById('txtdispatch').value=global_ds.Tables[0].Rows[z].Dispatches;
				}
				else
				{
				    document.getElementById('txtdispatch').value="";
				}
				//document.getElementById('txtnative').value=global_ds.Tables[0].Rows[z].Box_Charges_Native;
				//document.getElementById('txtinter').value=global_ds.Tables[0].Rows[z].Box_Charges_Inter;
				
				
		        var num=global_ds.Tables[0].Rows[z].Box_Charges_Native;
				if(global_ds.Tables[0].Rows[z].Box_Charges_Native==null)
				{
				document.getElementById('txtnative').value="";
				}
				else
				{
//				var native2=num.toFixed(2);
//				document.getElementById('txtnative').value=native2;
                document.getElementById('txtnative').value=num;
				}
				
				var num1=global_ds.Tables[0].Rows[z].Box_Charges_Inter;
				if(global_ds.Tables[0].Rows[z].Box_Charges_Inter==null)
				{
				document.getElementById('txtinter').value="";
				}
				else
				{
//				var native3=num1.toFixed(2);
//				document.getElementById('txtinter').value=native3;
                document.getElementById('txtnative').value=num1;
				}
				
				var dateformat = document.getElementById('hiddendateformat').value;
				var txt=global_ds.Tables[0].Rows[z].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(global_ds.Tables[0].Rows[z].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=global_ds.Tables[0].Rows[z].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
						
				document.getElementById('txtvalidfrom').value=fromdate;
				document.getElementById('txtvalidtill').value=todate;
				if(global_ds.Tables[0].Rows[z].Remarks!=null)
				{
				document.getElementById('txtremark').value=global_ds.Tables[0].Rows[z].Remarks;
				}
				else
				{
				    document.getElementById('txtremark').value="";
				}
				
				        
	
if (z==0)
{
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
return false;
}

if(z==(global_ds.Tables[0].Rows.length-1))
{
    document.getElementById('btnNext').disabled=true;
	document.getElementById('btnLast').disabled=true;
	return false;
}

				
				
				
return false;
	}
setButtonImages();
}



function boxexit()
{
if(confirm("Do You Want To Skip This Page"))
	{
	window.close();
	return false;
	}
	
	return false;
}

function autoornot()
{
    document.getElementById('txtboxdes').value=trim(document.getElementById('txtboxdes').value);
    if(document.getElementById('hiddenauto').value=="1")
    {
    changeoccured();
    return false ;
    }
else
    {
    userdefine();

    return false;
    }
//    }
//return ;
}

function changeoccured()
{

  
  //if(document.getElementById('hiddenauto').value=="1" )
			//{
	  if(hiddentext=="new")
        {
            uppercase3();
           
           }
            else
            {
             document.getElementById('txtboxdes').value=document.getElementById('txtboxdes').value.toUpperCase();
             document.getElementById('txtalias').value=trim(document.getElementById('txtboxdes').value);
            return ;
            }
//return false;
return;
}

//auto generated
//this is used for increment in code
function uppercase3()
		{
		 document.getElementById('txtboxdes').value=trim(document.getElementById('txtboxdes').value);
		//		  document.getElementById('txtpubalias').value=document.getElementById('txtpubname').value;
		 lstr=document.getElementById('txtboxdes').value;
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
		 
		    if(document.getElementById('txtboxdes').value!="")
                {
                 
       
        
		document.getElementById('txtboxdes').value=document.getElementById('txtboxdes').value.toUpperCase();
       if(hiddentext=="new")
        {
    	   document.getElementById('txtalias').value=trim(document.getElementById('txtboxdes').value);
    	}   
		 //str=document.getElementById('txtpubname').value;
		 str=mstr;
		 var pubcenter=document.getElementById('drppubcenter').value;
		//cod=document.getElementById('txtadvcatcode').value;
		BoxMaster.adchkadvcode(str,pubcenter,fillcall);
		return false;
                }
		       
               
 return false;
		
}

function fillcall(res)
{
    		var ds=res.value;
	    	
	    	var newstr;
		    //saurabh change
		    
		    if(ds.Tables[0].Rows.length!=0)
		    {
		        if(hiddentext=="new")
		        {
		    alert("This Box Description has been already assigned.");
		    document.getElementById("txtboxdes").value="";
		    document.getElementById("txtalias").value="";
		    document.getElementById('txtboxdes').focus();
    		
		    return false;
		    }
		    }
		
		    else
		    {
		        if(hiddentext=="new")
                {
                
                var saurabh=parseInt(document.getElementById('txtboxdes').value);
                
                
		                if(ds.Tables[1].Rows.length==0)
		                {
		                   newstr=null;
		                }
		                else
		                {
		                   newstr=ds.Tables[1].Rows[0].Box_Code;
		                }
		                if(newstr !=null )
		                {
		                  //var code=newstr.substr(2,4);
		                   var code=newstr;
		                   code++;
		                   str=str.toUpperCase();
		                   document.getElementById('txtboxcode').value=str.substr(0,2)+ code;
		                }
		                else
		                {
		                    str=str.toUpperCase();
		                   document.getElementById('txtboxcode').value=str.substr(0,2)+ "0";
		                }
		           if(document.getElementById('txtalias').style.display!="none" )
		           document.getElementById('txtalias').focus();
		           
		           if(saurabh==0)
                    {
                    alert("Box Description Should Not Be Zero.");
                    document.getElementById('txtboxcode').value="";
                    document.getElementById('txtboxdes').value="";
                    document.getElementById('txtalias').value="";
                    document.getElementById('txtboxdes').focus();
                    }
                    
		        }             
		        
		    }
	        return false;
}
		
function userdefine()
    {
        //if(document.getElementById('hiddenauto').value=="1")
        //{
        if(hiddentext=="new")
        {
        
        document.getElementById('txtboxcode').disabled=false;
        document.getElementById('txtboxdes').value=document.getElementById('txtboxdes').value.toUpperCase();
     document.getElementById('txtalias').value=document.getElementById('txtboxdes').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;


}


function checkdecnative()
{
var num=document.getElementById('txtnative').value;
if (document.getElementById('txtnative').value!="")
{
    document.getElementById('txtnative').value=parseFloat(num);
    var num1=document.getElementById('txtnative').value;
    var z=parseFloat(document.getElementById('txtnative').value);
var tomatch=/^\d*(\.\d{1,2})?$/;
//PageType.saurabh(num);
if(z==0)
{
     bc=document.getElementById('lblnative').innerText; 
	 alert(''+(bc.replace('*', ""))+' Can Not Be Zero');
    //document.getElementById('txtheight').focus();
    document.getElementById('txtnative').disabled=false;
    document.getElementById('txtnative').focus();
    document.getElementById('txtnative').value="";
    return false;
}

var sau=parseFloat(document.getElementById('txtnative').value);
document.getElementById('txtnative').value=sau;
if(document.getElementById('drpboxcharge').value=="2")
{
if(sau>100)
{
    alert("For National Percentage Should Not Be Greater Than 100");
    document.getElementById('txtnative').value="";
    document.getElementById('txtnative').focus();
    return false;
}
}
if (tomatch.test(num1))
{
return;
}
else
{
document.getElementById('txtnative').value="";
alert("Input error");
document.getElementById('txtnative').value="";
document.getElementById('txtnative').focus();

return false; 
}
}
else
{
document.getElementById('txtnative').value="";
}
}

function checkdecinter()
{
var num=document.getElementById('txtinter').value;
if (document.getElementById('txtinter').value!="")
{
document.getElementById('txtinter').value=parseFloat(num);
var num1=document.getElementById('txtinter').value;
var z=parseFloat(document.getElementById('txtinter').value);

var tomatch=/^\d*(\.\d{1,2})?$/;

if(z==0)
{
    bc=document.getElementById('lblinter').innerText; 
	alert(''+(bc.replace('*', ""))+'Can Not Be Zero');
    document.getElementById('txtinter').disabled=false;
    document.getElementById('txtinter').focus();
    document.getElementById('txtinter').value="";
    return false;
}


var sau=parseFloat(document.getElementById('txtinter').value);
document.getElementById('txtinter').value=sau;
if(document.getElementById('drpboxcharge').value=="2")
{
if(sau>100)
{
    alert("For International Percentage Should Not Be Greater Than 100");
    document.getElementById('txtinter').value="";
    document.getElementById('txtinter').focus();
    return false;
}
}


if (tomatch.test(num1))
{
return true;
}
else
{
document.getElementById('txtinter').value="";
alert("Input error");
document.getElementById('txtinter').value="";
document.getElementById('txtinter').focus();
return false; 
}
}
}



function datecurr()
{
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
    {

        return true;
    }
    else
    {
        return false;
    }
}


//Special Character Check Validator Function
function ClientSpecialcharDesc()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90) || (event.ketCode!=38) || (event.ketCode!=45) || (event.ketCode!=46))
	{
		return true;
	}
	else
	{
		return false;
	}
}
function clrcharg()
{
//    if(document.getElementById('drpboxcharge').value== "2")
//    {
//        if(document.getElementById('txtnative').value >=100)
            document.getElementById('txtnative').value="";
//        if(document.getElementById('txtinter').value >=100)
            document.getElementById('txtinter').value="";
//    }
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