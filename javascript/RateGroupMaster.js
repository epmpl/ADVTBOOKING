var z=0;
var auto="";
var  hiddentext;
var rgset;
var glrgcode;
var glrgname;
var glalias;
var chknamemod;

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
    CancelClick3('RateGroupMaster');

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

function NewClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;

          if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtRtGroupCode').disabled=true;
    	      }
		     else
		       {
		       document.getElementById('txtRtGroupCode').disabled=false;
    	       }

    
	document.getElementById('txtRtGroupCode').value="";
	document.getElementById('txtRtGroupName').value="";
	document.getElementById('txtAlias').value="";

	//document.getElementById('txtRtGroupCode').disabled=false;
	document.getElementById('txtRtGroupName').disabled=false;
	document.getElementById('txtAlias').disabled=false;

 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtRtGroupName').focus();
    	      }
		     else
		       {
		       document.getElementById('txtRtGroupCode').focus();
    	       }

	chkstatus(FlagStatus);
	hiddentext="new";
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	
	flag=0;
	setButtonImages();
	return false;
}

function CancelClick3(formname)
{

document.getElementById('txtRtGroupCode').value="";
document.getElementById('txtRtGroupName').value="";
document.getElementById('txtAlias').value="";

document.getElementById('txtRtGroupCode').disabled=true;
document.getElementById('txtRtGroupName').disabled=true;
document.getElementById('txtAlias').disabled=true;

//getPermission('RateGroupMaster');

	chkstatus(FlagStatus);
givebuttonpermission(formname);
setButtonImages();
if(document.getElementById('btnNew').disabled==false)
    document.getElementById('btnNew').focus();

return false;
}


function ModifyClick3()
{
    flag=1;
    hiddentext="modify";
    chkstatus(FlagStatus);

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnSave').focus();

    document.getElementById('txtRtGroupCode').disabled=true;
    document.getElementById('txtRtGroupName').disabled=false;
    document.getElementById('txtAlias').disabled=false;
    chknamemod=document.getElementById('txtRtGroupName').value;
    setButtonImages();
    return false;
}

var flag="";


function SaveClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
document.getElementById('txtRtGroupCode').value=trim(document.getElementById('txtRtGroupCode').value);
document.getElementById('txtRtGroupName').value=trim(document.getElementById('txtRtGroupName').value);
document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);
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
//if (document.getElementById('txtEditonCode').value!="1")
if (flag==1)
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if (document.getElementById('txtRtGroupCode').value==""&& (document.getElementById('hiddenauto').value!=1))
{
alert("Please Enter Rate Group Code");
document.getElementById('txtRtGroupCode').focus();
return false;
}
else
{
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
}

if (document.getElementById('txtRtGroupName').value=="")
{
alert("Please Enter Rate Group Name");
document.getElementById('txtRtGroupName').focus();
return false;
}
else
{
var RtGroupName=document.getElementById('txtRtGroupName').value;
}

if (document.getElementById('txtAlias').value=="")
{
alert("Please Enter Alias");
document.getElementById('txtAlias').focus();
return false;
}
else
{
var Alias=document.getElementById('txtAlias').value;
}

var str=document.getElementById('txtRtGroupName').value;
//RateGroupMaster.chkrgroupcode(str,call_modify);

RateGroupMaster.chkrategroup(RtGroupCode,RtGroupName,compcode,userid,call_modify)


flag=0;
return false;
}
else
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if (document.getElementById('txtRtGroupCode').value==""&& (document.getElementById('hiddenauto').value!=1))
{
alert("Please Enter Rate Group Code");
document.getElementById('txtRtGroupCode').focus();
return false;
}
else
{
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
}

if (document.getElementById('txtRtGroupName').value=="")
{
alert("Please Enter Rate Group Name");
document.getElementById('txtRtGroupName').focus();
return false;
}
else
{
var RtGroupName=document.getElementById('txtRtGroupName').value;
}

if (document.getElementById('txtAlias').value=="")
{
alert("Please Enter Alias");
document.getElementById('txtAlias').focus();
return false;
}
else
{
var Alias=document.getElementById('txtAlias').value;
}

RateGroupMaster.chkrategroup(RtGroupCode,RtGroupName,compcode,userid,call_save)


return false;
}
}


function call_modify(response)
{
    var ds=response.value;
   if(chknamemod!=document.getElementById('txtRtGroupName').value)
   {
           if(ds.Tables[1].Rows.length!=0)
        {
            alert("This Rate Group name has already assigned !! ");
            document.getElementById('txtRtGroupName').focus();
            flag=1;
            return false;
        }
   }
        var RtGroupName=document.getElementById('txtRtGroupName').value;
        var Alias=document.getElementById('txtAlias').value;   
        var RtGroupCode=document.getElementById('txtRtGroupCode').value;     
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;

        RateGroupMaster.modify(RtGroupCode,RtGroupName,Alias,compcode,userid);


        document.getElementById('txtRtGroupCode').disabled=true;
        document.getElementById('txtRtGroupName').disabled=true;
        document.getElementById('txtAlias').disabled=true;


     updateStatus();

//alert("Update Successfully");
       if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }
                rgset.Tables[0].Rows[z].Rate_Gr_Code=document.getElementById('txtRtGroupCode').value;
                rgset.Tables[0].Rows[z].Rate_Gr_Name=document.getElementById('txtRtGroupName').value;
                rgset.Tables[0].Rows[z].Rate_Gr_Alias=document.getElementById('txtAlias').value;
                rgset.Tables[0].Rows[z].Comp_Code=document.getElementById('hiddencompcode').value;
                rgset.Tables[0].Rows[z].UserId=document.getElementById('hiddenuserid').value;


         if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(rgset.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              } 


setButtonImages();
        return false;
}




function call_save(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("This Code Has Been Assigned");
	document.getElementById('txtRtGroupCode').value="";
	if(document.getElementById('txtRtGroupCode').disabled==false)
	  document.getElementById('txtRtGroupCode').focus();
	return false;
	}
	else if(ds.Tables[1].Rows.length > 0)
	{
	    alert("This Name Has Been Assigned");
	    document.getElementById('txtRtGroupName').value="";
	    if(document.getElementById('txtRtGroupName').disabled==false)
	       document.getElementById('txtRtGroupName').focus();
	    return false;
	}
	else
	{
	var RtGroupCode=document.getElementById('txtRtGroupCode').value;
	var RtGroupName=document.getElementById('txtRtGroupName').value;
	var Alias=document.getElementById('txtAlias').value;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	
	RateGroupMaster.insert(RtGroupCode,RtGroupName,Alias,compcode,userid)
	
	


//alert("Save Successfully");
if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
    }
    else
    {
        alert(xmlObj.childNodes(0).childNodes(0).text);
    }
    document.getElementById('txtRtGroupCode').value="";
    document.getElementById('txtRtGroupName').value="";
    document.getElementById('txtAlias').value="";
    document.getElementById('txtRtGroupCode').disabled=true;
    document.getElementById('txtRtGroupName').disabled=true;
    document.getElementById('txtAlias').disabled=true;
    document.getElementById('hiddencompcode').disabled=true;
    document.getElementById('hiddenuserid').disabled=true;
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
}


CancelClick3('RateGroupMaster');
	return false;

}



function QueryClick3()
{
	chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;



document.getElementById('txtRtGroupCode').value="";
document.getElementById('txtRtGroupName').value="";
document.getElementById('txtAlias').value="";




document.getElementById('hiddencompcode').disabled=false;
document.getElementById('hiddenuserid').disabled=false;
document.getElementById('txtRtGroupCode').disabled=false;
document.getElementById('txtRtGroupName').disabled=false;
document.getElementById('txtAlias').disabled=false;;

hiddentext="query";
setButtonImages();
document.getElementById('btnExecute').focus();
return false;
}

function ExecuteClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
var RtGroupName=document.getElementById('txtRtGroupName').value;
var Alias=document.getElementById('txtAlias').value;


glrgcode=document.getElementById('txtRtGroupCode').value;
glrgname=document.getElementById('txtRtGroupName').value;
glalias=document.getElementById('txtAlias').value



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
RateGroupMaster.Select(RtGroupCode,RtGroupName,Alias,compcode,userid,call_Execute);
updateStatus();
document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();


return false;
}

function call_Execute(response)

{
//var ds=response.value;
rgset=response.value;
if(rgset==null)
{
    alert(response.error.description);
    return false;
}   
if (rgset.Tables[0].Rows.length > 0)
{
document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[0].Rate_Gr_Code;
document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[0].Rate_Gr_Name;
document.getElementById('txtAlias').value=rgset.Tables[0].Rows[0].Rate_Gr_Alias;
document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[0].Comp_Code;
document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[0].UserId;

document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
document.getElementById('txtRtGroupCode').disabled=true;
document.getElementById('txtRtGroupName').disabled=true;
document.getElementById('txtAlias').disabled=true;


z=0;
}
else
{
document.getElementById('btnModify').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('txtRtGroupCode').disabled=true;
document.getElementById('txtRtGroupName').disabled=true;
document.getElementById('txtAlias').disabled=true;
CancelClick3('RateGroupMaster');

alert("Search Not Match");
}
if(rgset.Tables[0].Rows.length==1)
{

         document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;	

}
setButtonImages();
return false;
}


function FirstClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
var RtGroupName=document.getElementById('txtRtGroupName').value;
var Alias=document.getElementById('txtAlias').value;
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
RateGroupMaster.Selectfnpl(RtGroupCode,RtGroupName,Alias,compcode,userid,call_First);
return false;
}

function call_First(response)
{
z=0;
//var ds=response.value;
document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[0].Rate_Gr_Code;
document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[0].Rate_Gr_Name;
document.getElementById('txtAlias').value=rgset.Tables[0].Rows[0].Rate_Gr_Alias;
document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[0].Comp_Code;
document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[0].UserId;

updateStatus();
    document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=false;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnExit').disabled=false;
	setButtonImages();	
}


function NextClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
var RtGroupName=document.getElementById('txtRtGroupName').value;
var Alias=document.getElementById('txtAlias').value;
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
RateGroupMaster.Selectfnpl(RtGroupCode,RtGroupName,Alias,compcode,userid,call_Next);
return false;
}

function call_Next(response)
{

//var ds=response.value;
var y=rgset.Tables[0].Rows.length;
z++;
var k=y-1;

//if(document.getElementById('btnprevious').disabled=true)
//	{
//		document.getElementById('btnprevious').disabled=false;
//	}
//	if(document.getElementById('btnfirst').disabled=true)
//	{
//		document.getElementById('btnfirst').disabled=false;
//	}


if(z<y)
{
document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[z].Rate_Gr_Code;
document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[z].Rate_Gr_Name;
document.getElementById('txtAlias').value=rgset.Tables[0].Rows[z].Rate_Gr_Alias;
document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[z].Comp_Code;
document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[z].UserId;
//document.getElementById('txtRtGroupCode').disabled=true;
//document.getElementById('txtRtGroupName').disabled=true;
//document.getElementById('txtAlias').disabled=true;

updateStatus();
document.getElementById('btnnext').disabled=false;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnfirst').disabled=false;
document.getElementById('btnprevious').disabled=false;


if(z==k)
{
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
		return false;
}
}
else
{
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		return false;
}
//document.getElementById('btnModify').focus();

setButtonImages();
return false;
}


function PreviousClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
var RtGroupName=document.getElementById('txtRtGroupName').value;
var Alias=document.getElementById('txtAlias').value;
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
RateGroupMaster.Selectfnpl(RtGroupCode,RtGroupName,Alias,compcode,userid,call_Previous);
return false;
}




function call_Previous(response)
{
//var ds=response.value;
		var a=rgset.Tables[0].Rows.length;
       if(z>a)
	   {
		    document.getElementById('btnfirst').disabled=false;				
		    document.getElementById('btnnext').disabled=true;					
		    document.getElementById('btnprevious').disabled=false;			
		    document.getElementById('btnlast').disabled=true;
		    return false;
	    }
		z--;
		if(z != -1  )
		{
		if(z >= 0 && z < a)
		{


            document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[z].Rate_Gr_Code;
            document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[z].Rate_Gr_Name;
            document.getElementById('txtAlias').value=rgset.Tables[0].Rows[z].Rate_Gr_Alias;
            document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[z].Comp_Code;
            document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[z].UserId;

            updateStatus();
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;				
			document.getElementById('btnprevious').disabled=false;				
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;
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
		
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		setButtonImages();
		  if(document.getElementById('btnModify').disabled==false)
		    document.getElementById('btnModify').focus();
		return false;
}

function LastClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var RtGroupCode=document.getElementById('txtRtGroupCode').value;
var RtGroupName=document.getElementById('txtRtGroupName').value;
var Alias=document.getElementById('txtAlias').value;
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
RateGroupMaster.Selectfnpl(RtGroupCode,RtGroupName,Alias,compcode,userid,call_Last);
return false;
}

function call_Last(response)
{
//var ds=response.value;
var y=rgset.Tables[0].Rows.length;
z=y-1;

document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[z].Rate_Gr_Code;
document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[z].Rate_Gr_Name;
document.getElementById('txtAlias').value=rgset.Tables[0].Rows[z].Rate_Gr_Alias;
document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[z].Comp_Code;
document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[z].UserId;



document.getElementById('txtRtGroupCode').disabled=true;
document.getElementById('txtRtGroupName').disabled=true;
document.getElementById('txtAlias').disabled=true;

	updateStatus();
	document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;
setButtonImages();
return false;


}

function ExitClick3()
{
if(confirm("Do You Want To Skip This Page"))
{
//window.location.href='Enterpage.aspx';
window.close();
return false;
}
return false;
}

function DeleteClick3()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	var RtGroupCode=document.getElementById('txtRtGroupCode').value;
	var RtGroupName=document.getElementById('txtRtGroupName').value;
	var Alias=document.getElementById('txtAlias').value;
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
RateGroupMaster.deleteRate(RtGroupCode,compcode,userid);
  //alert("Value Deleted Sucessfully");
  if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
  
  RateGroupMaster.Select(glrgcode,glrgname,glalias,compcode,userid,call_deleteclick);
 
 //RateGroupMaster.Selectfnpl(glrgcode,glrgname,glalias,compcode,userid,call_deleteclick);
 // RateGroupMaster.Selectfnpl(RtGroupCode,RtGroupName,Alias,compcode,userid,call_deleteclick);
  
  }
  return false;
}
function call_deleteclick(response)
{

 rgset=response.value;
//var ds=response.value;
  len=rgset.Tables[0].Rows.length;
	//var a=rgset.Tables[0].Rows.length;
	//var y=a-1;
	
	if(rgset.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtRtGroupCode').value="";
		document.getElementById('txtRtGroupName').value="";
		document.getElementById('txtAlias').value="";
		CancelClick3('RateGroupMaster');
		
		return false;
	}
	
	else if(z>=len || z==-1)
	{
					document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[0].Rate_Gr_Code;
                    document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[0].Rate_Gr_Name;
                    document.getElementById('txtAlias').value=rgset.Tables[0].Rows[0].Rate_Gr_Alias;
                    document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[0].Comp_Code;
                    document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[0].UserId;
			
	}
	else
	       {	      
	                   document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[z].Rate_Gr_Code;
                        document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[z].Rate_Gr_Name;
                        document.getElementById('txtAlias').value=rgset.Tables[0].Rows[z].Rate_Gr_Alias;
                        document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[z].Comp_Code;
                        document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[z].UserId;
	         }
	
	
	
	         if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==rgset.Tables[0].Rows.length)
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              }   
              if(document.getElementById('btnModify').disabled==false)	    
	             document.getElementById('btnModify').focus();
	
	
//	if(a-1 > z || z != -1)
//	{
//			document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[z].Rate_Gr_Code;
//document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[z].Rate_Gr_Name;
//document.getElementById('txtAlias').value=rgset.Tables[0].Rows[z].Rate_Gr_Alias;
//document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[z].Comp_Code;
//document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[z].UserId;
//		
//	}
//	if( a > 0 && z==a-1 && z!=0)
//	{
//			document.getElementById('txtRtGroupCode').value=rgset.Tables[0].Rows[z].Rate_Gr_Code;
//document.getElementById('txtRtGroupName').value=rgset.Tables[0].Rows[z].Rate_Gr_Name;
//document.getElementById('txtAlias').value=rgset.Tables[0].Rows[z].Rate_Gr_Alias;
//document.getElementById('hiddencompcode').value=rgset.Tables[0].Rows[z].Comp_Code;
//document.getElementById('hiddenuserid').value=rgset.Tables[0].Rows[z].UserId;
//			
//	}
//	if( a <=0 )
//	{
//			alert("There Is No Data");
//		document.getElementById('txtRtGroupCode').value="";
//		document.getElementById('txtRtGroupName').value="";
//		document.getElementById('txtAlias').value="";
//		CancelClick3('RateGroupMaster');
//	}
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

    }

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
            document.getElementById('txtRtGroupName').value=document.getElementById('txtRtGroupName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		
		document.getElementById('txtRtGroupName').value=document.getElementById('txtRtGroupName').value.toUpperCase();
//		document.getElementById('txtRtGroupCode').value=trim(document.getElementById('txtRtGroupCode').value);
 document.getElementById('txtRtGroupName').value=trim(document.getElementById('txtRtGroupName').value);
 document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);
 lstr=document.getElementById('txtRtGroupName').value;
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
		    if(document.getElementById('txtRtGroupName').value!="")
                {
                
                 document.getElementById('txtRtGroupName').value=document.getElementById('txtRtGroupName').value.toUpperCase();
	            document.getElementById('txtAlias').value=document.getElementById('txtRtGroupName').value;
		       // str=document.getElementById('txtRtGroupName').value;
		       str=mstr;
		        RateGroupMaster.chkrgroupcode(str,fillcall);
		        return false;
                }
		     return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		if(ds!=null && ds.Tables[0].Rows.length!=null)
		{
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Rate Group name has already assigned !! ");
		    document.getElementById('txtRtGroupName').value="";
		    document.getElementById('txtAlias').value="";
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
		                         newstr=ds.Tables[1].Rows[0].Rate_Gr_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('txtRtGroupCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtRtGroupCode').value=str.substr(0,2)+ "0";
		                          }
		     }
		}
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtRtGroupCode').disabled=false;
        document.getElementById('txtRtGroupName').value=trim(document.getElementById('txtRtGroupName').value.toUpperCase());
        document.getElementById('txtAlias').value=document.getElementById('txtRtGroupName').value;
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

