//modify variable 0 for save and 1 for update
var modify="0";
//for f,p,n,l
var z;
var hiddentext;
var auto="";
var hiddentext1="";

var dsstateexecute;

var dsstatedelete;
////////////////////////these are the global values which are used at the time of deletion for f,p,n,l
var glastatecode;
var glastatename;
var glastataealias;
var glaIncid;
var glacountryname;
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
    StateCancelclick('StateMaster');

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
function StateNewclick()
{
     var msg=checkSession();
        if(msg==false)
        return false;
        
				document.getElementById('txtstatecode').value="";
				document.getElementById('txtstatename').value="";	
				document.getElementById('txtstatealias').value="";
				document.getElementById('txtincid').value="";
				document.getElementById('drpcountryname').value = "0";
				document.getElementById('txtgststcd').value = "";
                if(document.getElementById('hiddenauto').value==1)
			    {
			    document.getElementById('txtstatecode').disabled=true;
    			
			    }
			  else
			    {
			    
			    document.getElementById('txtstatecode').disabled=false;
    			
			    }
				document.getElementById('txtstatename').disabled=false;
				document.getElementById('txtstatealias').disabled=false;
				document.getElementById('txtincid').disabled=false;
				document.getElementById('drpcountryname').disabled=false;
				 if(document.getElementById('hiddenauto').value==1)
			    {
			    document.getElementById('drpcountryname').focus();
			  // document.getElementById('txtstatename').focus();
    			
			    }
			  else
			    {
			    document.getElementById('drpcountryname').focus();
    			
			    }
				 document.getElementById('txtgststcd').disabled = false;
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
				chkstatus(FlagStatus);
				hiddentext="new";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnNew').disabled = false;
//			document.getElementById('btnNew').focus();
setButtonImages();
				return false;

}


//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function StateModifyclick()
{
				document.getElementById('txtstatecode').disabled=true;
				document.getElementById('txtstatename').disabled=false;
				document.getElementById('txtstatealias').disabled=false;
				document.getElementById('drpcountryname').disabled = false;
				document.getElementById('txtgststcd').disabled = false;
				document.getElementById('txtincid').disabled=false;
                  document.getElementById('txtstatename').focus();

				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
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
				
				chknamemod=document.getElementById('txtstatename').value;
				setButtonImages();
				document.getElementById('btnSave').focus();
                hiddentext="modify";
				 modify="1";
			     return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function StateQueryclick()
{
	z=0;
				hiddentext="query";
				document.getElementById('txtstatecode').value="";
				document.getElementById('txtstatename').value="";	
				document.getElementById('txtstatealias').value="";
				document.getElementById('drpcountryname').value="0";
				document.getElementById('txtincid').value = "";
				document.getElementById('txtgststcd').value = "";
				document.getElementById('txtstatecode').disabled=false;
				document.getElementById('txtstatename').disabled=false;
				document.getElementById('txtstatealias').disabled=false;
				document.getElementById('drpcountryname').disabled=false;
				document.getElementById('txtincid').disabled = false;
				document.getElementById('txtgststcd').disabled = false;
			chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
			    document.getElementById('btnNew').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExecute').disabled=false;
				
				chkstatus(FlagStatus);

			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			setButtonImages();
			document.getElementById('btnExecute').focus();

				return false;
}
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//
function StateCancelclick(formname)
{
				chkstatus(FlagStatus);
				givebuttonpermission(formname);
				document.getElementById('txtstatecode').value="";
				document.getElementById('txtstatename').value="";	
				document.getElementById('txtstatealias').value="";
				document.getElementById('txtstatealias').value="";
				document.getElementById('drpcountryname').value = "0";
				document.getElementById('txtgststcd').value = "";
document.getElementById('txtincid').value="";
				document.getElementById('txtstatecode').disabled=true;
				document.getElementById('txtstatename').disabled=true;
				document.getElementById('txtstatealias').disabled=true;
				document.getElementById('txtstatealias').disabled=true;
				document.getElementById('drpcountryname').disabled = true;
				document.getElementById('txtgststcd').disabled = true;
document.getElementById('txtincid').disabled=true;
			//getPermission(formname);
				modify="0";
				
				
			   document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				setButtonImages();
				if(document.getElementById('btnNew').disable==false)
				  document.getElementById('btnNew').focus();
				return false;
}


			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//
function StateSaveclick()
{
 var msg=checkSession();
    if(msg==false)
    return false;

document.getElementById('txtstatecode').value=trim(document.getElementById('txtstatecode').value);
document.getElementById('txtstatename').value=trim(document.getElementById('txtstatename').value);
document.getElementById('txtstatealias').value=trim(document.getElementById('txtstatealias').value);
document.getElementById('txtincid').value = trim(document.getElementById('txtincid').value);
document.getElementById('txtgststcd').value =trim (document.getElementById('txtgststcd').value);

    var bc="";
    
    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbcountryname').textContent;
    }
    else
    {
        bc=document.getElementById('lbcountryname').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('drpcountryname').value=="0")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('drpcountryname').focus();
	        return false;
	    }
	}
			
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbstatecode').textContent;
    }
    else
    {
        bc=document.getElementById('lbstatecode').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if((trim(document.getElementById('txtstatecode').value)=="")&&(document.getElementById('hiddenauto').value!=1))
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('txtstatecode').focus();
	        return false;
	    }
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbstatename').textContent;
    }
    else
    {
        bc=document.getElementById('lbstatename').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('txtstatename').value=="")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('txtstatename').focus();
	        return false;
	    }
	}	
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbalias').textContent;
    }
    else
    {
        bc=document.getElementById('lbalias').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('txtstatealias').value=="")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('txtstatealias').focus();
	        return false;
	    }
	}
	
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lblgststcd').textContent;
    }
    else {
        bc = document.getElementById('lblgststcd').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txtgststcd').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtgststcd').focus();
            return false;
        }
    }

		var companycode=document.getElementById('hiddencomcode').value;
		var statecode=document.getElementById('txtstatecode').value;
		var statename=document.getElementById('txtstatename').value;
		var alias=document.getElementById('txtstatealias').value;
		var Incid=document.getElementById('txtincid').value;
		var countryname=document.getElementById('drpcountryname').value;
		var UserId=document.getElementById('hiddenuserid').value;	

		var ssss = document.getElementById('drpcountryname').value;
		var gststcd = document.getElementById('txtgststcd').value;
	    
		//str=document.getElementById('txtstatename').value;
		//str=mstr;
		//StateMaster.chkstatcodename(statename,ssss,fcl);
		
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


    if(modify!="1" && modify!=null)
    {
        var dl="";

        //alert(browser);

        if(browser!="Microsoft Internet Explorer")
        {
            
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) 
            {
                httpRequest.overrideMimeType('text/xml'); 
            }

            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","chkstate.aspx?statename="+statename+"&ssss="+ssss+"&statecode="+statecode, false );
            httpRequest.send('');
             if (httpRequest.readyState == "00") 
             {
                     alert('Session Expired Please Login Again.');
                    return false;
             }
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
               //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    dl=httpRequest.responseText;
                }
                else 
                {
                    alert('Session Expired Please Login Again.');
                    return false;
                }
            }
        }
        else
        {

            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","chkstate.aspx?statename="+statename+"&ssss="+ssss+"&statecode="+statecode, false );
            xml.Send();
            dl=xml.responseText;
        }
        if(dl=="00")
        {
              alert('Session Expired Please Login Again.');
                    return false;
        }
        if(dl!="YES")
        {
            var res=dl.split(',');
            if(res[0]==document.getElementById('txtstatecode').value)
            {
                alert("This State Code has already assigned. ");
                document.getElementById('txtstatecode').value="";
                document.getElementById('txtstatecode').disabled=false;
                document.getElementById('txtstatecode').focus();
                return false;
            }
            
            else if(res[1]==document.getElementById('txtstatename').value)
            {
                alert("This State Name has already assigned. ");
                document.getElementById('txtstatename').value="";
                document.getElementById('txtstatename').disabled=false;
                document.getElementById('txtstatename').focus();
                return false;
            }
        }

        StateMaster.chkstatecode(companycode,UserId,statecode,call_saveclick);
        return false;

    }
    else
    {
        if(	chknamemod==document.getElementById('txtstatename').value)
           {
            updatestate();
            return false; 
           }
           else
           {
            StateMaster.chkstatename(statename,countryname,companycode,'',call_modifyclick);
            return false; 
        }
    }
	//return false;			
				
}


//*******************************************************************************//
//********************This Is The Responce Of The Save and modify Button*******************//
//*******************************************************************************//
function call_modifyclick(response)
{
			var companycode=document.getElementById('hiddencomcode').value;
			var statecode=document.getElementById('txtstatecode').value;
			var statename=document.getElementById('txtstatename').value;
			var alias=document.getElementById('txtstatealias').value;
			var Incid=document.getElementById('txtincid').value;
			var countryname=document.getElementById('drpcountryname').value;
			var UserId=document.getElementById('hiddenuserid').value;	
			var gststcd = document.getElementById('txtgststcd').value;
			var ds=response.value;
		if(	chknamemod!=document.getElementById('txtstatename').value)
			{
                if(ds.Tables[0].Rows.length >= 1)
                {
                alert("This State Name Already Exists.");
                document.getElementById('txtstatename').value="";
                return false;
                }
                 updatestate();
			}
	}	
	
function updatestate()
			{
			
			var companycode=document.getElementById('hiddencomcode').value;
			var statecode=document.getElementById('txtstatecode').value;
			var statename=document.getElementById('txtstatename').value;
			var alias=document.getElementById('txtstatealias').value;
			var Incid=document.getElementById('txtincid').value;
			var countryname=document.getElementById('drpcountryname').value;
			var UserId=document.getElementById('hiddenuserid').value;	
			var ip2 = document.getElementById('ip1').value;
			var gststcd = document.getElementById('txtgststcd').value;

				StateMaster.Advmodify1(companycode,statecode,statename,alias,countryname,UserId,Incid,ip2,gststcd);
                
                dsstateexecute.Tables[0].Rows[z].State_Code=document.getElementById('txtstatecode').value;
                dsstateexecute.Tables[0].Rows[z].State_Name=document.getElementById('txtstatename').value;
                dsstateexecute.Tables[0].Rows[z].State_Alias=document.getElementById('txtstatealias').value;
                dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID=document.getElementById('txtincid').value;
                dsstateexecute.Tables[0].Rows[z].Country_Code = document.getElementById('drpcountryname').value;
                dsstateexecute.Tables[0].Rows[z].GST_STATE_CODE = document.getElementById('txtgststcd').value;
                
				//alert("Data Modified Successfully");
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }

			    updateStatus();
			
			    var x=dsstateexecute.Tables[0].Rows.length;
	            y=z;	
                if (z==0)
                {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

                if(z==(dsstateexecute.Tables[0].Rows.length-1))
                {
                    document.getElementById('btnnext').disabled=true;
	                document.getElementById('btnlast').disabled=true;
                }
				
				document.getElementById('txtstatecode').disabled=true;
				document.getElementById('txtstatename').disabled=true;
				document.getElementById('txtstatealias').disabled=true;
				document.getElementById('txtincid').disabled=true;
				document.getElementById('drpcountryname').disabled = true;
				document.getElementById('txtgststcd').disabled = true;
setButtonImages();
                document.getElementById('btnModify').focus();
				
				modify="0";
				
								
//StateCancelclick('StateMaster');
			return false;
}
function call_saveclick(response)
{
			var ds=response.value;
			
			
			
			if(document.getElementById('txtstatename').value=="")
			{
			   // alert("Please Enter State Name");
			   // if(document.getElementById('txtstatename').disabled==false)
				//{
				    document.getElementById('txtstatename').focus();
				//}
			    return false;
			}
			
			
			
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This State Code Already Exists.");
			document.getElementById('txtstatecode').value="";
			if(document.getElementById('txtstatecode').disabled==false)
			document.getElementById('txtstatecode').focus();
			return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var statecode=document.getElementById('txtstatecode').value;
				var statename=document.getElementById('txtstatename').value;
				var alias=document.getElementById('txtstatealias').value;
				var Incid=document.getElementById('txtincid').value;
				var countryname=document.getElementById('drpcountryname').value;
				var UserId=document.getElementById('hiddenuserid').value;	
				var ip2 = document.getElementById('ip1').value;
				var gststcd = document.getElementById('txtgststcd').value;
				StateMaster.Advsave1(companycode,statecode,statename,alias,countryname,UserId,ip2,Incid,gststcd);		

				//alert("Data Saved Successfully");
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }


				document.getElementById('txtstatecode').value="";
				document.getElementById('txtstatename').value="";
				document.getElementById('txtstatealias').value="";
				document.getElementById('txtincid').value="";
				document.getElementById('drpcountryname').value="0";
		
				document.getElementById('txtstatecode').disabled=true;
				document.getElementById('txtstatename').disabled=true;
				document.getElementById('txtstatealias').disabled=true;
				document.getElementById('drpcountryname').disabled = true;
				document.getElementById('txtgststcd').disabled = true;
				
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
StateCancelclick('StateMaster');
			return false;
}



//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function StateExecuteclick()
{
 var msg=checkSession();
    if(msg==false)
    return false;
//var glastatecode;
//var glastatename;
//var glastataealias;
//var glacountryname;
			var companycode=document.getElementById('hiddencomcode').value;
			
			var statecode=document.getElementById('txtstatecode').value;
			glastatecode=statecode;
			
			var statename=document.getElementById('txtstatename').value;
			glastatename=statename;
			
			var alias=document.getElementById('txtstatealias').value;
			glastataealias=alias;
			var Incid=document.getElementById('txtincid').value;
			glaIncid=Incid;
			var countryname=document.getElementById('drpcountryname').value;
			glacountryname=countryname;
			
			var UserId=document.getElementById('hiddenuserid').value;			

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
StateMaster.Advexecute1(companycode,statecode,statename,alias,countryname,UserId,checkcall);
						
			updateStatus();
			document.getElementById('txtstatecode').disabled=true;
			document.getElementById('txtstatename').disabled=true;
			document.getElementById('txtstatealias').disabled=true;
			document.getElementById('txtincid').disabled = true;
			document.getElementById('drpcountryname').disabled = true;
			document.getElementById('txtgststcd').disabled = true;

		
			modify="0";
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;
			setButtonImages();	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	

			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;

			return false;
}
				
				
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
			//var ds=response.value;
			dsstateexecute=response.value;
			if(dsstateexecute==null)
			{
			    alert(response.error.description);
			    return false;
			}    
			if(dsstateexecute.Tables[0].Rows.length > 0)
			{
				document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[0].State_Code;
				document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[0].State_Name;
				document.getElementById('txtstatealias').value=dsstateexecute.Tables[0].Rows[0].State_Alias;
				if(dsstateexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[0].INTEGRATION_ID;
				}
				document.getElementById('drpcountryname').value = dsstateexecute.Tables[0].Rows[0].Country_Code;

				document.getElementById('txtgststcd').value=dsstateexecute.Tables[0].Rows[0].GST_STATE_CODE  ;
	
				document.getElementById('txtstatecode').disabled=true;
				document.getElementById('txtstatename').disabled=true;
				document.getElementById('txtstatealias').disabled=true;
				document.getElementById('txtincid').disabled=true;
				document.getElementById('drpcountryname').disabled=true;
				document.getElementById('txtgststcd').value.disabled = true;
				if(dsstateexecute.Tables[0].Rows.length==1)
		                {
			                document.getElementById('btnfirst').disabled=true;
			                document.getElementById('btnnext').disabled=true;
			                document.getElementById('btnlast').disabled=true;
			                //document.getElementById('btnExit').disabled=false;
			                document.getElementById('btnprevious').disabled=true;
		
		                }
		                setButtonImages();
		        return false;
				
			} 
			else
			{
				alert("Your Search Criteria Does Not Produce Any Result");
				StateCancelclick('StateMaster');
				return false;
			}
			
//			if(dsstateexecute.Tables[0].Rows.length==1)
//			
//			{
//			
//				document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=true;	
//			document.getElementById('btnnext').disabled=true;
//			}
			setButtonImages();
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
function Statefirstclick()
{

//StateMaster.Statefirst(firstcall);
			 var msg=checkSession();
            if(msg==false)
            return false;
			document.getElementById('txtstatecode').disabled=true;
			document.getElementById('txtstatename').disabled=true;
			document.getElementById('txtstatealias').disabled=true;
			document.getElementById('drpcountryname').disabled = true;
			document.getElementById('txtgststcd').disabled = true;

			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnnext').disabled=false;
//			return false;
//}
////*******************************************************************************//
////********************This Is The Responce Of The First Button*******************//
////*******************************************************************************//	
//function firstcall(response)
//{
//			//var ds=response.value;
			z=0;
			document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[0].State_Code;
			document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[0].State_Name;
			document.getElementById('txtstatealias').value = dsstateexecute.Tables[0].Rows[0].State_Alias;
			if(dsstateexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[0].INTEGRATION_ID;
				}
			document.getElementById('drpcountryname').value = dsstateexecute.Tables[0].Rows[0].Country_Code;
			document.getElementById('txtgststcd').value = dsstateexecute.Tables[0].Rows[0].GST_STATE_CODE;
			updateStatus();

//            	document.getElementById('btnNew').disabled=true;
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=false;
//				//document.getElementById('btnDelete').disabled=false;
//				document.getElementById('btnQuery').disabled=false;
//				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
			setButtonImages();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
function Statelastclick()
{

//StateMaster.Statefirst(lastcall);
			var msg=checkSession();
            if(msg==false)
            return false;
			document.getElementById('txtstatecode').disabled=true;
			document.getElementById('txtstatename').disabled=true;
			document.getElementById('txtstatealias').disabled=true;
			document.getElementById('txtincid').disabled=true;
			document.getElementById('drpcountryname').disabled = true;
			document.getElementById('txtgststcd').disabled = true;

//			document.getElementById('btnprevious').disabled=false;	
//			document.getElementById('btnlast').disabled=true;	
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnnext').disabled=true;
//			return false;
//}
////*******************************************************************************//
////********************This Is The Responce Of The last Button*******************//
////*******************************************************************************//
//function lastcall(response)
//{
			//var ds=response.value;
			var y=dsstateexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[z].State_Code;
			document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[z].State_Name;
			document.getElementById('txtstatealias').value=dsstateexecute.Tables[0].Rows[z].State_Alias;
			if(dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
			document.getElementById('drpcountryname').value = dsstateexecute.Tables[0].Rows[z].Country_Code;
			document.getElementById('txtgststcd').value = dsstateexecute.Tables[0].Rows[z].GST_STATE_CODE;
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
			return false;
}

//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//
function Statepreviousclick()
{			
//	StateMaster.Statefirst(previouscall);
			 var msg=checkSession();
            if(msg==false)
            return false;
			document.getElementById('txtstatecode').disabled=true;
			document.getElementById('txtstatename').disabled=true;
			document.getElementById('txtstatealias').disabled=true;
			document.getElementById('txtincid').disabled=true;
			document.getElementById('drpcountryname').disabled = true;
			document.getElementById('txtgststcd').disabled = true;

//			return false;
//}

////*******************************************************************************//
////********************This Is The Responce Of The Previous Button****************//
////*******************************************************************************//
//function previouscall(response)
//{
		//var ds=response.value;
		var a=dsstateexecute.Tables[0].Rows.length;
		z--;
		
		if(z>a)
			{
						document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						setButtonImages();
						return false;
			}
		
		
		if(z != -1 && z>=0)
		{
			if(dsstateexecute.Tables[0].Rows.length != z)
			{
				document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[z].State_Code;
				document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[z].State_Name;
				document.getElementById('txtstatealias').value=dsstateexecute.Tables[0].Rows[z].State_Alias;
				if(dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
				document.getElementById('drpcountryname').value = dsstateexecute.Tables[0].Rows[z].Country_Code;
				document.getElementById('txtgststcd').value = dsstateexecute.Tables[0].Rows[z].GST_STATE_CODE;
			updateStatus();
				document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
			
			}
			else
			{
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=false;
				setButtonImages();
				return false;
			}
		}
		else
		{
				document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			setButtonImages();
				return false;
		}
		if(z<=0)
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

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//
function Statenextclick()
{
//		StateMaster.Statefirst(nextcall);
            var msg=checkSession();
            if(msg==false)
            return false;
		document.getElementById('txtstatecode').disabled=true;
		document.getElementById('txtstatename').disabled=true;
		document.getElementById('txtstatealias').disabled=true;
		document.getElementById('txtincid').disabled=true;
		document.getElementById('drpcountryname').disabled = true;
		document.getElementById('txtgststcd').disabled = true;
//		return false;
//}
////*******************************************************************************//
////********************This Is The Responce Of The Next Button*******************//
////*******************************************************************************//
//function nextcall(response)
//{
	z++;
	//var ds=response.value;
	var a=dsstateexecute.Tables[0].Rows.length;
	
	if(z <= a && z!=-1)

	{
		if(dsstateexecute.Tables[0].Rows.length != z && z>=0)
		
		{
			document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[z].State_Code;
			document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[z].State_Name;
			document.getElementById('txtstatealias').value=dsstateexecute.Tables[0].Rows[z].State_Alias;
			if(dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
			document.getElementById('txtgststcd').value = dsstateexecute.Tables[0].Rows[z].GST_STATE_CODE;
			document.getElementById('drpcountryname').value=dsstateexecute.Tables[0].Rows[z].Country_Code;
			updateStatus();
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
			setButtonImages();
			return false
	}
	}
	else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			setButtonImages();
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

/*----- Change the text box from lower case to upper case --------*/


function uppercase1()
{
document.getElementById('txtstatecode').value=document.getElementById('txtstatecode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtstatealias').value=document.getElementById('txtstatealias').value.toUpperCase();
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
function StateDeleteclick()
{
 var msg=checkSession();
    if(msg==false)
    return false;
//var glastatecode;
//var glastatename;
//var glastataealias;
//var glacountryname;
		var companycode=document.getElementById('hiddencomcode').value;
		var statecode=document.getElementById('txtstatecode').value;
		var statename=document.getElementById('txtstatename').value;
		var alias=document.getElementById('txtstatealias').value;
		
		var countryname = document.getElementById('drpcountryname').value;
		var gststcd=document.getElementById('txtgststcd').value;
		var UserId=document.getElementById('hiddenuserid').value;			
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
StateMaster.Advdelete(companycode,statecode,statename,alias,countryname,UserId,ip2);
//StateMaster.Advexecute1(companycode,statecode,statename,alias,countryname,UserId,checkcall);		
		StateMaster.Advexecute1(companycode,glastatecode,glastatename,glastataealias,glacountryname,UserId,delcall);
		
		}     
	else
	{
	return false;
	}
	return false;
}

//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function delcall(responsed)
{
	dsstateexecute= responsed.value;
	len=dsstateexecute.Tables[0].Rows.length;
	
	if(dsstateexecute.Tables[0].Rows.length==0)
	{
	    
	    if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
	    
		
		
		document.getElementById('drpcountryname').value="0";
		document.getElementById('txtstatecode').value="";
		document.getElementById('txtstatename').value="";
		document.getElementById('txtstatealias').value = "";
		document.getElementById('txtgststcd').value = "";
		
		alert("No More Data is here to be deleted");
		
		StateCancelclick('StateMaster')
	 }
	else if(z==-1 ||z>=len)
	{
		document.getElementById('drpcountryname').value=dsstateexecute.Tables[0].Rows[0].Country_Code;
		document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[0].State_Code;
		document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[0].State_Name;
		document.getElementById('txtstatealias').value = dsstateexecute.Tables[0].Rows[0].State_Alias;
		document.getElementById('txtgststcd').value = dsstateexecute.Tables[0].Rows[0].GST_STATE_CODE;
		if(dsstateexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[0].INTEGRATION_ID;
				}
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
		
		return false;
	}
	else
	{
		document.getElementById('drpcountryname').value=dsstateexecute.Tables[0].Rows[z].Country_Code;
		document.getElementById('txtstatecode').value=dsstateexecute.Tables[0].Rows[z].State_Code;
		document.getElementById('txtstatename').value=dsstateexecute.Tables[0].Rows[z].State_Name;
		document.getElementById('txtstatealias').value = dsstateexecute.Tables[0].Rows[z].State_Alias;
		document.getElementById('txtgststcd').value = dsstateexecute.Tables[0].Rows[z].GST_STATE_CODE;
		if(dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				document.getElementById('txtincid').value="";
				}
				else{
				
				document.getElementById('txtincid').value=dsstateexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
		
		
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
		
		return false;
	}
	//alert ("Data Deleted Successfully");	
	
	
return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//
function StateExitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
			window.close();
			return false;
			}
			return false;
}



//*********************************************Auto Generate***********************
function autoornot()
{
document.getElementById('txtstatename').value=document.getElementById('txtstatename').value.toUpperCase();
if(hiddentext=="new" )
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
            document.getElementById('txtstatename').value=document.getElementById('txtstatename').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		
		document.getElementById('txtstatename').value=trim(document.getElementById('txtstatename').value);
        document.getElementById('txtstatealias').value=trim(document.getElementById('txtstatealias').value);
		
		lstr=document.getElementById('txtstatename').value;
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
		    if(document.getElementById('txtstatename').value!="")
                {
                
                
////document.getElementById('txtstatecode').value=trim(document.getElementById('txtstatecode').value);
//document.getElementById('txtstatename').value=trim(document.getElementById('txtstatename').value);
//document.getElementById('txtstatealias').value=trim(document.getElementById('txtstatealias').value);
                
        document.getElementById('txtstatename').value=document.getElementById('txtstatename').value.toUpperCase();
	    document.getElementById('txtstatealias').value=document.getElementById('txtstatename').value;
	    document.getElementById('txtstatealias').focus();
	    
	    var ssss=document.getElementById('drpcountryname').value;
	    
	    var statecode="";
	    
		//str=document.getElementById('txtstatename').value;
		str=mstr;
		StateMaster.chkstatcodename(str,ssss,statecode,fillcall);
		 return false;
                }
		       
               
 return false;
		
}

function fillcall(res)
{
    var ds=res.value;
    var newstr;
    if(ds.Tables[1].Rows[0].STATE_CODE1 != null)
    {
    if(ds.Tables[0].Rows.length!=0)
    {
        alert("This State name has already assigned. ");
        document.getElementById('txtstatecode').value="";
        document.getElementById('txtstatename').value="";	
        document.getElementById('txtstatealias').value="";
        //document.getElementById('drpcountryname').value="0";
        document.getElementById('txtstatename').focus();
        return false;
    }
    if (ds.Tables[1].Rows.length == 0) {
        newstr = null;
    }
    else {
        newstr = ds.Tables[1].Rows[0].STATE_CODE1;
    }
    if (newstr != null) {
        // var code=newstr.substr(2,4);
        var code = newstr;
        code++;
        document.getElementById('txtstatecode').value = str.substr(0, 2) + code;
    }
    else {
        document.getElementById('txtstatecode').value = str.substr(0, 2) + "0";
    }
    }

    else
    {
        if(ds.Tables[1].Rows.length==0)
        {
            newstr=null;
        }
        else
        {
            newstr=ds.Tables[1].Rows[0].STATE_CODE1;
        }
        if(newstr !=null )
        {
        // var code=newstr.substr(2,4);
        var code=newstr;
        code++;
        document.getElementById('txtstatecode').value=str.substr(0,2)+ code;
        }
        else
        {
        document.getElementById('txtstatecode').value=str.substr(0,2)+ "0";
        }
    }
    return false;
}

function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtstatecode').disabled=false;
        document.getElementById('txtstatename').value=document.getElementById('txtstatename').value.toUpperCase();
        document.getElementById('txtstatealias').value=document.getElementById('txtstatename').value;
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