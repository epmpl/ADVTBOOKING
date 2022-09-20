var mod="0";
var z=0;
var hiddentext;
var auto="";
var hiddentext1="";

var dscountryexecute;

////////////////////////these are the global values which are used at the time of deletion for f,p,n,l


var glacountrycode;
var glacountryname;
var glacountryalias;

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
    CountryCancelclick('CountryMaster');

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

//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************/
function CountryNewclick()	
{		
   var msg=checkSession();
    if(msg==false)
    return false;		
                mod="0";
				document.getElementById('txtcountrycode').value="";
				document.getElementById('txtcountryname').value="";
				document.getElementById('txtcountryalias').value = "";
				document.getElementById('txtintegration').value = "";
				if(document.getElementById('hiddenauto').value==1)
			    {
			    document.getElementById('txtcountrycode').disabled=true;
    			
			    }
			  else
			    {
			    document.getElementById('txtcountrycode').disabled=false;
    			
			    }
				document.getElementById('txtcountryname').disabled=false;
				document.getElementById('txtcountryalias').disabled=false;
				if(document.getElementById('hiddenauto').value==1)
			    {
			    document.getElementById('txtcountryname').focus();
    			
			    }
			  else
			    {
			    document.getElementById('txtcountrycode').focus();
    			
			    }
			    document.getElementById('txtintegration').disabled = false;
                document.getElementById('btnNew').disabled=true;
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
                document.getElementById('btnExit').disabled=false;
				
                hiddentext="new";
                chkstatus(FlagStatus);
                document.getElementById('btnSave').disabled = false;	
                document.getElementById('btnNew').disabled = true;	
                document.getElementById('btnQuery').disabled=true;
                setButtonImages();
				return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function CountryQueryclick()		
{
			z=0;
			chkstatus(FlagStatus);
            hiddentext="query";
			document.getElementById('txtcountrycode').value="";
			document.getElementById('txtcountryname').value="";
			document.getElementById('txtcountryalias').value="";
			document.getElementById('txtintegration').value="";								
			document.getElementById('txtcountrycode').disabled=false;
			document.getElementById('txtcountryname').disabled=false;
			document.getElementById('txtcountryalias').disabled=false;
			chkstatus(FlagStatus);
				
	        document.getElementById('btnQuery').disabled=true;
	        document.getElementById('btnExecute').disabled=false;
	        document.getElementById('btnSave').disabled=true;
	        setButtonImages();
	        document.getElementById('btnExecute').focus();
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnCancel').disabled=false;				
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;	
			document.getElementById('btnlast').disabled=true;				
			document.getElementById('btnExit').disabled=false;

			return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function CountryExecuteclick()
{
    var msg=checkSession();
    if(msg==false)
    return false;
	var companycode=document.getElementById('hiddencomcode').value;
	var code=document.getElementById('txtcountrycode').value;
	
	glacountrycode=code;
	
	var name=document.getElementById('txtcountryname').value;
	
	glacountryname=name;
	
	var alias=document.getElementById('txtcountryalias').value;
	
	 glacountryalias=alias;
	 
	 
	var UserId=document.getElementById('hiddenuserid').value;
	var integration = document.getElementById('txtintegration').value;	
	    
        
       
	
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
       CountryMaster.Advexecute(companycode, code, name, alias, UserId, integration, checkcall);		
	
	updateStatus();
	
	document.getElementById('txtcountrycode').disabled=true;
	document.getElementById('txtcountryname').disabled=true;
	document.getElementById('txtcountryalias').disabled = true;
	document.getElementById('txtintegration').disabled = true;
	
	        document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled= false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled= true;
			document.getElementById('btnCancel').disabled=false;				
			document.getElementById('btnfirst').disabled= true;			
			document.getElementById('btnprevious').disabled= true;
			document.getElementById('btnnext').disabled= false;				
			document.getElementById('btnlast').disabled= false;	
			setButtonImages();
			if(document.getElementById('btnModify').disabled==false)
			document.getElementById('btnModify').focus();			
			document.getElementById('btnExit').disabled=false;

	return false;			
}
				
				
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
	dscountryexecute=response.value;
	if(dscountryexecute==null)
	{
	    alert(response.error.description);
	    return false;
	}    
	if (dscountryexecute.Tables[0].Rows.length <= 0)
	{
		alert("Your search can't produce any result");
		CountryCancelclick('CountryMaster');
		return false;
	}
	else
	{
//	var companycode=document.getElementById('hiddencomcode').value;
//	var code=document.getElementById('txtcountrycode').value;
//	var name=document.getElementById('txtcountryname').value;
//	var alias=document.getElementById('txtcountryalias').value;
//	var UserId = document.getElementById('hiddenuserid').value;
//	var integration = document.getElementById('txtintegration').value;

//	var response=CountryMaster.Advexecute1(companycode, code, name, alias, UserId, integration);							
//	dscountryexecute=response.value;
//	
	document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[0].Country_Code;
	document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[0].Country_Name;
        if(dscountryexecute.Tables[0].Rows[0].Country_Alias==null)
        {
        document.getElementById('txtcountryalias').value="";
        }
        else{
        document.getElementById('txtcountryalias').value=dscountryexecute.Tables[0].Rows[0].Country_Alias;
        }
        if(dscountryexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
        {
        document.getElementById('txtintegration').value="";
        }
        else{
            document.getElementById('txtintegration').value = dscountryexecute.Tables[0].Rows[0].INTEGRATION_ID;
        }
	if(dscountryexecute.Tables[0].Rows.length==1)
	{
		    document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
	
	}
	setButtonImages();;
	
	return false;
	}
}
						
function checkcall1(response)
{
	dscountryexecute=response.value;
	document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[0].Country_Code;
	document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[0].Country_Name;
	document.getElementById('txtcountryalias').value=dscountryexecute.Tables[0].Rows[0].Country_Alias;
	if(dscountryexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
	{
	document.getElementById('txtintegration').value="";
	}
	else{
	document.getElementById('txtintegration').value = dscountryexecute.Tables[0].Rows[0].INTEGRATION_ID;
	}
	if(dscountryexecute.Tables[0].Rows.length==1)
	{
		    document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
	
	}
	setButtonImages();;
	return false;
}
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//
function CountryCancelclick(formname)
{
        mod="0";
         hiddentext1="clear";
       document.getElementById('txtcountrycode').disabled=false;
			
       document.getElementById('txtcountrycode').value="";
		document.getElementById('txtcountryname').value="";
		document.getElementById('txtcountryalias').value="";
		document.getElementById('txtintegration').disabled = true;
		document.getElementById('txtintegration').value = "";
		document.getElementById('txtcountrycode').disabled=true;
		document.getElementById('txtcountryname').disabled=true;
		document.getElementById('txtcountryalias').disabled=true;
		
		        document.getElementById('btnNew').disabled=false;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;
				
				chkstatus(FlagStatus);
				givebuttonpermission(formname);
				setButtonImages();
				if(document.getElementById('btnNew').disabled==false)
				document.getElementById('btnNew').focus();
		
		//getPermission('CountryMaster');

		return false;
}

			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//
function CountrySaveclick()
{
 var msg=checkSession();
 if(msg==false)
    return false;
document.getElementById('txtcountryname').value=trim(document.getElementById('txtcountryname').value);
document.getElementById('txtcountrycode').value=trim(document.getElementById('txtcountrycode').value);
document.getElementById('txtcountryalias').value = trim(document.getElementById('txtcountryalias').value);
document.getElementById('txtintegration').value = trim(document.getElementById('txtintegration').value);
 

            if(document.getElementById('hiddenauto').value!=1)
            {
                if(document.getElementById('txtcountrycode').value=="")
			    {
				    alert("Please Fill Country Code");
				    document.getElementById('txtcountrycode').focus();
				    return false;
			    }
			//return false;
			}
			
			 if(document.getElementById('txtcountryname').value=="")
			{
				alert("Please Fill Country Name");
				document.getElementById('txtcountryname').focus();
				return false;
			}
			else if(document.getElementById('txtcountryalias').value=="")
			{
				alert("Please Fill Country Alias");
				document.getElementById('txtcountryalias').focus();
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
//			else
//			{
			
				var companycode=document.getElementById('hiddencomcode').value;
				var code=document.getElementById('txtcountrycode').value;
				var name=document.getElementById('txtcountryname').value;
				var alias=document.getElementById('txtcountryalias').value;
				var UserId = document.getElementById('hiddenuserid').value;
				var integration = document.getElementById('txtintegration').value;	
				 
				
			
				if(mod!="1" && mod!=null)
				{
				
                 CountryMaster.chkcountrycode(companycode,UserId,code,name,call_saveclick);
				}
				else
				{
				    var str=document.getElementById('txtcountryname').value;
					CountryMaster.chkcode(str,call_modify);
						
				}
//			}
			return false;
}
function call_modify(response)
{
         var ds=response.value;
        if(chknamemod!=document.getElementById('txtcountryname').value)
        {
            if(ds.Tables[0].Rows.length!=0)
            {
                alert("This Country name has already assigned !! ");
                document.getElementById('txtcountryname').value="";
                document.getElementById('txtcountryname').focus();
                return false;
            }
        }

        
                    var companycode=document.getElementById('hiddencomcode').value;
                    var code=document.getElementById('txtcountrycode').value;
                    var name=document.getElementById('txtcountryname').value;
                    var alias=document.getElementById('txtcountryalias').value;
                    var UserId = document.getElementById('hiddenuserid').value;
                    var integration = document.getElementById('txtintegration').value;

                    var ip2 = document.getElementById('ip1').value;
                    CountryMaster.Advmodify(companycode,code,name,alias,UserId,ip2,integration); 
			        
			        if(dscountryexecute.Tables[0].Rows[z].Country_Code!=null)
			        {
			        dscountryexecute.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountrycode').value;
			       dscountryexecute.Tables[0].Rows[z].Country_Name=document.getElementById('txtcountryname').value;
			        dscountryexecute.Tables[0].Rows[z].Country_Alias=document.getElementById('txtcountryalias').value;
			        }
					if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                        //document.getElementById('txtintegration').value="";
                    }
                    else
                    {
                        alert(xmlObj.childNodes(0).childNodes(1).text);
                        //document.getElementById('txtintegration').value="";
                    }
					//alert("Data Modified Successfully");
					updateStatus();
					document.getElementById('txtcountrycode').disabled=true;
					document.getElementById('txtcountryname').disabled=true;
					document.getElementById('txtcountryalias').disabled = true;
					document.getElementById('txtintegration').disabled = true;
					
				    document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
											
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					updateStatus();
					if(z==0)
					{
					    document.getElementById('btnfirst').disabled=true;
					    document.getElementById('btnprevious').disabled=true;
					}
					else if(z==dscountryexecute.Tables[0].Rows.length-1)
					{
					    document.getElementById('btnnext').disabled=true;
					    document.getElementById('btnlast').disabled=true;
					}
					if(dscountryexecute.Tables[0].Rows.length==1)
            {
                        document.getElementById('btnnext').disabled=true;
					    document.getElementById('btnlast').disabled=true;
					    document.getElementById('btnfirst').disabled=true;
					    document.getElementById('btnprevious').disabled=true;
            
            }
					
					setButtonImages();
					
					mod="0";

return false;
        
}

//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			var ds=response.value;
			if(document.getElementById('txtcountrycode').value=="")
			{
			    alert("Please Enter Country Code");
			    if(document.getElementById('txtcountrycode').disabled==false)
				{
				    document.getElementById('txtcountrycode').focus();
				}
			    return false;
			}
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Country Code Is Already Exist, Try Another Code !!!!");
				document.getElementById('txtcountrycode').value="";
				if(document.getElementById('txtcountrycode').disabled==false)
				{
				    document.getElementById('txtcountrycode').focus();
				    return false;
				}
				return false;
			} 
			
            if(ds.Tables[1].Rows.length > 0)
            {
                alert("This Country Name Is Already Assigned.");
                document.getElementById('txtcountryname').value="";
                document.getElementById('txtcountryalias').value="";
                document.getElementById('txtcountryname').focus();
                return false;
            }
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var code=document.getElementById('txtcountrycode').value;
				var name=document.getElementById('txtcountryname').value;
				var alias=document.getElementById('txtcountryalias').value;
				var UserId = document.getElementById('hiddenuserid').value;
				var integration = document.getElementById('txtintegration').value;	
                var ip2=document.getElementById('ip1').value;
                CountryMaster.Advsave(companycode, code, name, alias, UserId, ip2,integration);
                if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }
				//alert("Data Saved Successfully");

				document.getElementById('txtcountrycode').value="";
				document.getElementById('txtcountryname').value="";
				document.getElementById('txtcountryalias').value="";
				document.getElementById('txtintegration').value = "";	
                	
				document.getElementById('txtcountrycode').disabled=true;
				document.getElementById('txtcountryname').disabled=true;
				document.getElementById('txtcountryalias').disabled=true;
				document.getElementById('txtintegration').disabled = true;	
                			
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
			//setButtonImages();
CountryCancelclick('CountryMaster');
			return false;
}

//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function CountryModifyclick()
{
//z=0;
				document.getElementById('txtcountrycode').disabled=true;
				document.getElementById('txtcountryname').disabled=false;
				document.getElementById('txtcountryalias').disabled=false;
				document.getElementById('txtintegration').disabled = false;
				chkstatus(FlagStatus);
			    
				mod="1";
				hiddentext="modify";
				document.getElementById('btnNew').disabled=true;
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
				document.getElementById('btnExit').disabled=false;
				
				chknamemod=document.getElementById('txtcountryname').value;
				
				setButtonImages();
				return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
function Countryfirstclick()
{
             var msg=checkSession();
             if(msg==false)
                return false;

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
CountryMaster.Advfirst(firstcall);
					
				document.getElementById('txtcountrycode').disabled=true;
				document.getElementById('txtcountryname').disabled=true;
				document.getElementById('txtcountryalias').disabled = true;
				document.getElementById('txtintegration').disabled = true;
				
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;	
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				setButtonImages();
				if(document.getElementById('btnModify').disabled==false)	
		          document.getElementById('btnModify').focus();
				return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function firstcall(response)
{
				//ds=response.value;
				document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[0].Country_Code;
				document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[0].Country_Name;
				document.getElementById('txtcountryalias').value = dscountryexecute.Tables[0].Rows[0].Country_Alias;
				if(dscountryexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
				{
				document.getElementById('txtintegration').value="";
				}
				else{
				document.getElementById('txtintegration').value = dscountryexecute.Tables[0].Rows[0].INTEGRATION_ID;
				}
				updateStatus();
				document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		setButtonImages();
		if(document.getElementById('btnModify').disabled==false)
	    document.getElementById('btnModify').focus();
				z=0;
				return false;
}

//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//
function Countrypreviousclick()
{
   var msg=checkSession();
 if(msg==false)
    return false;
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
CountryMaster.Advfirst(previouscall);
				
				document.getElementById('txtcountrycode').disabled=true;
				document.getElementById('txtcountryname').disabled=true;
				document.getElementById('txtcountryalias').disabled = true;
				document.getElementById('txtintegration').disabled = true;
				setButtonImages();
				if(document.getElementById('btnModify').disabled==false)
	              document.getElementById('btnModify').focus();
		return false;
}

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function previouscall(response)
{
		z--;
		//ds=response.value;
		var x=dscountryexecute.Tables[0].Rows.length;
	
		
		if(z>x)
		{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=true;
				return false;
		}
		if(z!=-1 && z>=0)
		{
		if(dscountryexecute.Tables[0].Rows.length != z)
		{
				document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[z].Country_Code;
				document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[z].Country_Name;
				document.getElementById('txtcountryalias').value = dscountryexecute.Tables[0].Rows[z].Country_Alias;
				if(dscountryexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				document.getElementById('txtintegration').value="";
				}
				else{
				document.getElementById('txtintegration').value = dscountryexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
				updateStatus();				
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
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
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;	
				setButtonImages();
				return false;		
		}
		setButtonImages();	
		if(document.getElementById('btnModify').disabled==false)
		   document.getElementById('btnModify').focus();
		
		return false;
		
}

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//
function Countrynextclick()
{
             var msg=checkSession();
             if(msg==false)
                return false;
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
CountryMaster.Advfirst(nextcall);
				
				document.getElementById('txtcountrycode').disabled=true;
				document.getElementById('txtcountryname').disabled=true;
				document.getElementById('txtcountryalias').disabled = true;
				document.getElementById('txtintegration').disabled = true;
				setButtonImages();
				if(document.getElementById('btnModify').disabled==false)
				  document.getElementById('btnModify').focus();
				return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function nextcall(response)
{
		z++;
		//ds=response.value;
		var x=dscountryexecute.Tables[0].Rows.length;
		if(z <= x && z >= 0)
		{
			if(dscountryexecute.Tables[0].Rows.length != z && z !=-1)
			{
				document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[z].Country_Code;
				document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[z].Country_Name;
				document.getElementById('txtcountryalias').value = dscountryexecute.Tables[0].Rows[z].Country_Alias;
				if(dscountryexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				document.getElementById('txtintegration').value="";
				}
				else{
				document.getElementById('txtintegration').value = dscountryexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
				updateStatus();
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
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
		 if(document.getElementById('btnModify').disabled==false)
	            document.getElementById('btnModify').focus();
	return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
function Countrylastclick()
{		
             var msg=checkSession();
             if(msg==false)
                return false;
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
CountryMaster.Advfirst(lastcall);
				
				document.getElementById('txtcountrycode').disabled=true;
				document.getElementById('txtcountryname').disabled=true;
				document.getElementById('txtcountryalias').disabled = true;
				document.getElementById('txtintegration').disabled = true;
				setButtonImages();
				if(document.getElementById('btnModify').disabled==false)
				  document.getElementById('btnModify').focus();
				return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function lastcall(response)
{
		// ds= response.value;
     	 var x=dscountryexecute.Tables[0].Rows.length;
		 z=x-1;
		 x=x-1;

		document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[x].Country_Code;
		document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[x].Country_Name;
		document.getElementById('txtcountryalias').value = dscountryexecute.Tables[0].Rows[x].Country_Alias;
            if(dscountryexecute.Tables[0].Rows[x].INTEGRATION_ID==null)
            {
                document.getElementById('txtintegration').value="";
            }
            else{
                document.getElementById('txtintegration').value = dscountryexecute.Tables[0].Rows[x].INTEGRATION_ID;
            }
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();	
		if(document.getElementById('btnModify').disabled==false)
		 document.getElementById('btnModify').focus();
		
		return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//
function CountryExitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
			window.close();
			return false;
			}
			return false;
}
/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txtcountrycode').value=document.getElementById('txtcountrycode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtcountryalias').value=document.getElementById('txtcountryalias').value.toUpperCase();
return ;
}


		
function charval()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function charval1()
{
if((event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
{
return true;
}
else
{
return false;
}
}
//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//
function CountryDeleteclick()
{
         var msg=checkSession();
         if(msg==false)
            return false;
		var companycode=document.getElementById('hiddencomcode').value;
		var code=document.getElementById('txtcountrycode').value;
		var name=document.getElementById('txtcountryname').value;
		var alias=document.getElementById('txtcountryalias').value;
		var UserId = document.getElementById('hiddenuserid').value;
		
		
		
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
       var ip2=document.getElementById('ip1').value;
CountryMaster.Advdelete(companycode,code,name,alias,UserId,ip2);
		//alert("Data deleted Successfully");
		if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
    }
    else
    {
        alert(xmlObj.childNodes(0).childNodes(2).text);
    }
		CountryMaster.Advexecute(companycode,glacountrycode,glacountryname,glacountryalias,UserId,delcall);	
		
		
	}     
	else
	{
	return false;
	}
	setButtonImages();
return false;
}

//var glacountrycode;
//var glacountryname;
//var glacountryalias;
//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function delcall(res)
{
	dscountryexecute= res.value;
	
	len=dscountryexecute.Tables[0].Rows.length;
	
	if(dscountryexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtcountrycode').value="";
		document.getElementById('txtcountryname').value="";
		document.getElementById('txtcountryalias').value="";
		CountryCancelclick('CountryMaster');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[0].Country_Code;
		document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[0].Country_Name;
		document.getElementById('txtcountryalias').value=dscountryexecute.Tables[0].Rows[0].Country_Alias;
	}
	else
	{
		document.getElementById('txtcountrycode').value=dscountryexecute.Tables[0].Rows[z].Country_Code;
		document.getElementById('txtcountryname').value=dscountryexecute.Tables[0].Rows[z].Country_Name;
		document.getElementById('txtcountryalias').value=dscountryexecute.Tables[0].Rows[z].Country_Alias;
	}
	//alert ("Data Deleted Successfully");	
//	if(browser!="Microsoft Internet Explorer")
//    {
//        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
//    }
//    else
//    {
//        alert(xmlObj.childNodes(0).childNodes(2).text);
//    }
				
	setButtonImages();
return false;
}


//*********************************************Auto Generate***********************
function autoornot()
 {
 document.getElementById('txtcountryname').value=document.getElementById('txtcountryname').value.toUpperCase();
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
            document.getElementById('txtcountryname').value=document.getElementById('txtcountryname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtcountryname').value=trim(document.getElementById('txtcountryname').value);
           lstr=document.getElementById('txtcountryname').value;
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
	
        
		    if(document.getElementById('txtcountryname').value!="")
                {
                
        
		document.getElementById('txtcountryname').value=document.getElementById('txtcountryname').value.toUpperCase();
	    document.getElementById('txtcountryalias').value=document.getElementById('txtcountryname').value;
	    document.getElementById('txtcountryalias').focus();
		str=document.getElementById('txtcountryname').value;
		str=mstr;
			//str=str.replace(" ","");
	
		CountryMaster.chkcode(str,fillcall);
		 
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
		    alert("This Country name has already assigned !! ");
		    document.getElementById('txtcountryname').value="";
            document.getElementById('txtcountrycode').value="";
            document.getElementById('txtcountryalias').value="";
 
		    document.getElementById('txtcountryname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Country_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtcountrycode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtcountrycode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtcountrycode').disabled=false;
        document.getElementById('txtcountryname').value=document.getElementById('txtcountryname').value.toUpperCase();
        document.getElementById('txtcountryalias').value=document.getElementById('txtcountryname').value;
          document.getElementById('txtcountryalias').focus();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}
	
//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
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