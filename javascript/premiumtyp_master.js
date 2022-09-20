//this is to update when 0 then save and when 1 then to update
var modify="0";;
//this is for f,p,n,l
var z="0";
//this is for the permission
var flag="";
var chknamemod;
var hiddentext;
var auto="";
var ptds;
//////////////////////global variables for deletion  by dataset.........
var gladvtype;
var glpretypcode;
var glalias;
var glpredesc;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

function loadXML(xmlFile) 
{
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
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
    cancelclick('Premium_typ_master');
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




function newclick()
{
		
		
				
		document.getElementById('drpadvtype').value="0";
		document.getElementById('txtpretycode').value="";
		document.getElementById('txtalias').value="";
		document.getElementById('txtpredesc').value="";

		document.getElementById('drpadvtype').disabled=false;
	//	document.getElementById('txtpretycode').disabled=false;
		document.getElementById('txtalias').disabled=false;
		document.getElementById('txtpredesc').disabled=false;

        if(document.getElementById('hiddenauto').value==1)
		 {
		 document.getElementById('drpadvtype').focus();
		      document.getElementById('txtpretycode').disabled=true;
         }
         else
		 {
		  document.getElementById('drpadvtype').focus();
		      document.getElementById('txtpretycode').disabled=false;
         }
	/*	 if(document.getElementById('hiddenauto').value==1)
		 {
		     document.getElementById('drpadvtype').focus();
    	 }
		 */    

		chkstatus(FlagStatus);
		hiddentext="new";
		document.getElementById('btnSave').disabled = false;	
		document.getElementById('btnNew').disabled = true;	
		document.getElementById('btnQuery').disabled=true;
		flag=0;
		setButtonImages();
		return false;

}
function modifyclick()
{
		document.getElementById('drpadvtype').disabled=false;
		document.getElementById('txtpretycode').disabled=true;
		document.getElementById('txtalias').disabled=false;
		document.getElementById('txtpredesc').disabled=false;
        
        chkstatus(FlagStatus);

		document.getElementById('btnSave').disabled = false;
		document.getElementById('btnQuery').disabled = true;
		document.getElementById('btnExecute').disabled=true;
		
		chknamemod=document.getElementById('txtpredesc').value;
		hiddentext="modify";
		modify="1";		
		flag=1;	
		setButtonImages();	
		return false;
}

function queryclick()
{
        z=0;
        hiddentext="query";
		document.getElementById('drpadvtype').disabled=false;
		document.getElementById('txtpretycode').disabled=false;
		document.getElementById('txtalias').disabled=false;
		document.getElementById('txtpredesc').disabled=false;

		document.getElementById('drpadvtype').value="0";
		document.getElementById('txtpretycode').value="";
		document.getElementById('txtalias').value="";
		document.getElementById('txtpredesc').value="";

		chkstatus(FlagStatus);
				
	    document.getElementById('btnQuery').disabled=true;
	    document.getElementById('btnExecute').disabled=false;
	    document.getElementById('btnSave').disabled=true;
        document.getElementById('btnExecute').focus();
//		document.getElementById('btnQuery').disabled=true;
//		document.getElementById('btnExecute').disabled=false;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnNew').disabled=true;
	
		modify="0";
setButtonImages();
		return false;

}
function cancelclick(formname)
{
		document.getElementById('drpadvtype').value="0";
		document.getElementById('txtpretycode').value="";
		document.getElementById('txtalias').value="";
		document.getElementById('txtpredesc').value="";

		document.getElementById('drpadvtype').disabled=true;
		document.getElementById('txtpretycode').disabled=true;
		document.getElementById('txtalias').disabled=true;
		document.getElementById('txtpredesc').disabled=true;

		//getPermission(formname);
		chkstatus(FlagStatus);
		givebuttonpermission(formname);
		//if(document.getElementById('btnNew').disable==false)
             document.getElementById('btnNew').focus();		
		modify="0";
		
			setButtonImages();	
		return false;
}
function exitclick()
{
		if(confirm("Do You Want To Skip This Page"))
		{
		//window.location.href='enterpage.aspx';
		window.close();
		return false;
		}
		return false;
}


function saveclick()
{

        document.getElementById('txtpredesc').value=trim(document.getElementById('txtpredesc').value);
        document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
		if(document.getElementById('drpadvtype').value=="0")
		{
		alert("Please Fill Adv Type");
		document.getElementById('drpadvtype').focus();
		return false;
		}
		if(document.getElementById('hiddenauto').value!=1)
		{
		document.getElementById('txtpretycode').value=trim(document.getElementById('txtpretycode').value);
		if(document.getElementById('txtpretycode').value=="")
		{
		alert("Please Fill premium Code");
		document.getElementById('txtpretycode').focus();
		return false;
		}
		}
		if(document.getElementById('txtpredesc').value=="")
		{
		alert("Please Fill Premium Description");
		document.getElementById('txtpredesc').focus();
		return false;
		}
		if(document.getElementById('txtalias').value=="")
		{
		alert("Please Fill Alias");
		document.getElementById('txtalias').focus();
		return false;
		}
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

		var advtype=document.getElementById('drpadvtype').value;
		var premcode=document.getElementById('txtpretycode').value;
		var alias=document.getElementById('txtalias').value;
		var premdesc=document.getElementById('txtpredesc').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;

		if(modify!="1" && modify!=null)
		{
		 Premium_typ_master.checkprem(premcode,compcode,userid,premdesc,advtype,call_saveclick);
		return false; 
		}
		else
		{
		   if(chknamemod==document.getElementById('txtpredesc').value)
           {
                updatestate();
           }
           else
           {
                Premium_typ_master.checkprem(premcode,compcode,userid,premdesc,advtype,call_modclick);
                return false; 
           }
		}
}

//------------------------------------------------------------------------------//
 function updatestate()
 {
        var advtype=document.getElementById('drpadvtype').value;
		var premcode=document.getElementById('txtpretycode').value;
		var alias=document.getElementById('txtalias').value;
		var premdesc=document.getElementById('txtpredesc').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
        
        Premium_typ_master.update(advtype,premcode,alias,premdesc,compcode,userid);
		document.getElementById('drpadvtype').disabled=true;
		document.getElementById('txtpretycode').disabled=true;
		document.getElementById('txtalias').disabled=true;
		document.getElementById('txtpredesc').disabled=true;

		flag=0;
		updateStatus();
		//alert("Data Updated Successfully");
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
		
		ptds.Tables[0].Rows[z].adv_type_code=document.getElementById('drpadvtype').value;
	    ptds.Tables[0].Rows[z].prem_type_code=document.getElementById('txtpretycode').value;
	    ptds.Tables[0].Rows[z].prem_type_alias=document.getElementById('txtalias').value;
	    ptds.Tables[0].Rows[z].prem_type_name=document.getElementById('txtpredesc').value;
		
		modify="0";
	    if(z==0)
        {
            document.getElementById('btnfirst').disabled=true;				
            document.getElementById('btnprevious').disabled=true;
        }
        if(z==ptds.Tables[0].Rows.length-1)
        {
            document.getElementById('btnnext').disabled=true;					
            document.getElementById('btnlast').disabled=true;
        }
        setButtonImages();
		document.getElementById('btnModify').focus();
		return false;
 }
 
 function call_modclick(response)
 {
    var ds=response.value;
	ds=response.value;

if(	chknamemod!=document.getElementById('txtpredesc').value)
{
	if(ds.Tables.length>1)
	{
	    if(ds.Tables[1].Rows.length > 0)
	    {
	          alert("This Description Is Already Assigned");
		      document.getElementById('txtpredesc').value="";
              document.getElementById('txtalias').value="";
	   	      return false;
	    } 
	}
	updatestate();
 }	
}
//------------------------------------------------------------------------------//
function call_saveclick(response)
{
	var ds=response.value;
	ds=response.value;

	if(ds.Tables[0].Rows.length > 0)
	{
		alert("This  Code Is Already Exist.");
	    document.getElementById('txtpretycode').value="";
        document.getElementById('txtpretycode').focus();
		return false;
	} 
	//====================================//
	else if(ds.Tables.length>1)
	{
	     if(ds.Tables[1].Rows.length > 0)
	    {
	        alert("This Description Is Already Assigned");
	        document.getElementById('txtpredesc').value="";
			return false;
	    } 
    }
//	else
//	{
		var advtype=document.getElementById('drpadvtype').value;
		var premcode=document.getElementById('txtpretycode').value;
		var alias=document.getElementById('txtalias').value;
		var premdesc=document.getElementById('txtpredesc').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;

		Premium_typ_master.insert(advtype,premcode,alias,premdesc,compcode,userid);

		//alert("Data Saved Successfully");
		if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }

		document.getElementById('drpadvtype').value="0";
		document.getElementById('txtpretycode').value="";
		document.getElementById('txtalias').value="";
		document.getElementById('txtpredesc').value="";

		document.getElementById('drpadvtype').disabled=true;
		document.getElementById('txtpretycode').disabled=true;
		document.getElementById('txtalias').disabled=true;
		document.getElementById('txtpredesc').disabled=true;


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
					
		

 // }
cancelclick('Premium_typ_master');
return false;
}

function executeclick()
{
	var advtype=document.getElementById('drpadvtype').value;
	var premcode=document.getElementById('txtpretycode').value;
	var alias=document.getElementById('txtalias').value;
	var premdesc=document.getElementById('txtpredesc').value;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	
				
	gladvtype=document.getElementById('drpadvtype').value;
	glpretypcode=document.getElementById('txtpretycode').value;
	glalias=document.getElementById('txtalias').value;
	glpredesc=document.getElementById('txtpredesc').value;
	
			

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
          Premium_typ_master.execute(advtype,premcode,alias,premdesc,compcode,userid,call_executeclick);

			document.getElementById('drpadvtype').disabled=true;
			document.getElementById('txtpretycode').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtpredesc').disabled=true;

			updateStatus();
			modify="0";
            document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			if(document.getElementById('btnModify').disabled==false)					
               document.getElementById('btnModify').focus();
			return false;
}

function call_executeclick(response)
{
//var ds=response.value;
ptds=response.value;
if(ptds.Tables[0].Rows.length > 0)
	{
	document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[0].adv_type_code;
	document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[0].prem_type_code;
	document.getElementById('txtalias').value=ptds.Tables[0].Rows[0].prem_type_alias;
	document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[0].prem_type_name;
	
	
	document.getElementById('drpadvtype').disabled=true;
    document.getElementById('txtpretycode').disabled=true;
    document.getElementById('txtalias').disabled=true;
    document.getElementById('txtpredesc').disabled=true;
	
	} 
	else
	{
	    cancelclick('Premium_typ_master');
	    alert("Your Search Produce No Result!!!!");
	
	}
	
	
	if(ptds.Tables[0].Rows.length==1)
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
Premium_typ_master.first(call_first);
document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpretycode').disabled=true;
document.getElementById('txtalias').disabled=true;
document.getElementById('txtpredesc').disabled=true;



return false;
}
function call_first(response)
{
//var ptds=response.value;
document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[0].adv_type_code;
	document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[0].prem_type_code;
	document.getElementById('txtalias').value=ptds.Tables[0].Rows[0].prem_type_alias;
	document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[0].prem_type_name;
	z=0;
	updateStatus();

    document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;
	document.getElementById('btnnext').disabled=false;				
	document.getElementById('btnlast').disabled=false;	
	setButtonImages();	
	return false;
}

function lastclick()
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
Premium_typ_master.first(call_last);
document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpretycode').disabled=true;
document.getElementById('txtalias').disabled=true;
document.getElementById('txtpredesc').disabled=true;


			
return false;
}
function call_last(response)
{
//var ds=response.value;
var y=ptds.Tables[0].Rows.length;
var a=y-1;
z=a;
document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[a].adv_type_code;
	document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[a].prem_type_code;
	document.getElementById('txtalias').value=ptds.Tables[0].Rows[a].prem_type_alias;
	document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[a].prem_type_name;
	
updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;	
	setButtonImages();
	return false;
}
function previousclick()
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
Premium_typ_master.first(call_previous);
document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpretycode').disabled=true;
document.getElementById('txtalias').disabled=true;
document.getElementById('txtpredesc').disabled=true;


			
return false;
}

function call_previous(response)
{
//var ds=response.value;
var a=ptds.Tables[0].Rows.length;
z--;
if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			
			    updateStatus();
		        document.getElementById('btnfirst').disabled=false;				
		        document.getElementById('btnnext').disabled=false;				
		        document.getElementById('btnprevious').disabled=false;				
		        document.getElementById('btnlast').disabled=false;			
		        document.getElementById('btnExit').disabled=false;
    		
			    document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[z].adv_type_code;
			    document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[z].prem_type_code;
			    document.getElementById('txtalias').value=ptds.Tables[0].Rows[z].prem_type_alias;
			    document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[z].prem_type_name;
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
		{
		    document.getElementById('btnnext').disabled=false;
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
Premium_typ_master.first(call_next);
document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpretycode').disabled=true;
document.getElementById('txtalias').disabled=true;
document.getElementById('txtpredesc').disabled=true;
return false;
}
function call_next(response)
{
//var ds=response.value;
var a=ptds.Tables[0].Rows.length;
z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		    updateStatus();
		    document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[z].adv_type_code;
			document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[z].prem_type_code;
			document.getElementById('txtalias').value=ptds.Tables[0].Rows[z].prem_type_alias;
			document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[z].prem_type_name;
		  document.getElementById('btnnext').disabled=false;
          document.getElementById('btnlast').disabled=false;
          document.getElementById('btnfirst').disabled=false;
          document.getElementById('btnprevious').disabled=false;
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
function deleteclick()
{
		var advtype=document.getElementById('drpadvtype').value;
		var premcode=document.getElementById('txtpretycode').value;
		var alias=document.getElementById('txtalias').value;
		var premdesc=document.getElementById('txtpredesc').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		
		if(confirm("Are You Sure To Delete The Data"))
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
       Premium_typ_master.deleted(premcode,compcode,userid);
				
				//alert("Data Deleted Sucessfully");
				if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
				
				
				
				Premium_typ_master.execute(gladvtype,glpretypcode,glalias,glpredesc,compcode,userid,call_delete);
				
				//Premium_typ_master.first(call_delete);
				
							
				document.getElementById('drpadvtype').disabled=true;
				document.getElementById('txtpretycode').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtpredesc').disabled=true;
				
		}
		return false;

}
function call_delete(response)
{

ptds=response.value;

//var ds=response.value;
	var a=ptds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("There Is No Data");
			document.getElementById('drpadvtype').value="0";
			document.getElementById('txtpretycode').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('txtpredesc').value="";
			
			cancelclick('Premium_typ_master');
			return false
	}
	
	else if(z==-1 ||z>=a )
	{
	        document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[0].adv_type_code;
			document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[0].prem_type_code;
			document.getElementById('txtalias').value=ptds.Tables[0].Rows[0].prem_type_alias;
			document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[0].prem_type_name;
			return false
	}
	else
	{
	        document.getElementById('drpadvtype').value=ptds.Tables[0].Rows[z].adv_type_code;
			document.getElementById('txtpretycode').value=ptds.Tables[0].Rows[z].prem_type_code;
			document.getElementById('txtalias').value=ptds.Tables[0].Rows[z].prem_type_alias;
			document.getElementById('txtpredesc').value=ptds.Tables[0].Rows[z].prem_type_name;
	}
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

   // return false;
    }
//return false;
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
            document.getElementById('txtpredesc').value=document.getElementById('txtpredesc').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtpredesc').value=document.getElementById('txtpredesc').value.toUpperCase();
		document.getElementById('txtpredesc').value=trim(document.getElementById('txtpredesc').value);
		
		   lstr=document.getElementById('txtpredesc').value;
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
		
		    if(document.getElementById('txtpredesc').value!="")
                {
                document.getElementById('txtpredesc').value=document.getElementById('txtpredesc').value.toUpperCase();
	            document.getElementById('txtalias').value=document.getElementById('txtpredesc').value;
		        //str=document.getElementById('txtpredesc').value;
		        str=mstr;
		        Premium_typ_master.chkptcode(str,fillcall);
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
		    alert("This Premium Type Description has already assigned !! ");
		     document.getElementById('txtpredesc').value="";
		     document.getElementById('txtalias').value="";
		    document.getElementById('txtpredesc').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].prem_type_code;
		                        }
		                    if(newstr !=null )
		                        {
//		                        var code=newstr.substr(2,4);
//		                        code++;
//		                        document.getElementById('txtpretycode').value=str.substr(0,2)+ code;
		                        //==
		                         var code=newstr;
		                        code++;
		                        document.getElementById('txtpretycode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtpretycode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtpretycode').disabled=false;
        document.getElementById('txtpredesc').value=document.getElementById('txtpredesc').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtpredesc').value;
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