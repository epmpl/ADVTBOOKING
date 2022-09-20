var z=0;
var flag="0";

var hiddentext;
var auto="";
var hiddentext1="";
var dsadexecute;
var mod="0";
var dszonedelete;
////////////////////////these are the global values which are used at the time of deletion for f,p,n,l
var glaobaladcode;
var glaobaladname;
var glaobaladalias;

//            document.getElementById('txtadtypecode').disabled=false;			
//			document.getElementById('txtadtypename').disabled=false;
//			document.getElementById('txtalias').disabled=false;
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
//*******************************************************************************//
function advnewclick()
{
			    var msg=checkSession();
                if(msg==false)
                return false;
				document.getElementById('txtadtypecode').value="";
				document.getElementById('txtadtypename').value="";	
				document.getElementById('txtalias').value="";
				 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtadtypecode').disabled=true;
    	          }
		         else
		           {
		           document.getElementById('txtadtypecode').disabled=false;
    	           }
				
				document.getElementById('txtadtypename').disabled=false;
				document.getElementById('txtalias').disabled=false;
				if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtadtypename').focus();
    	          }
		         else
		           {
		            if(document.getElementById('txtadtypecode').disabled==false)
		           document.getElementById('txtadtypecode').focus();
    	           }
				
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
				
				//chkstatus(FlagStatus);
				hiddentext="new";
			chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		setButtonImages();
				return false;

}


//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function advmodify()
{
				document.getElementById('txtadtypecode').disabled=true;
				document.getElementById('txtadtypename').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
			//document.getElementById('btnSave').disabled = false;
			//document.getElementById('btnQuery').disabled=true;

				mod="1";
				 hiddentext="modify";	
				/*document.getElementById('btnNew').disabled=true;
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
				document.getElementById('btnSave').focus();
				return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function advquery()
{
				document.getElementById('txtadtypecode').value="";
				document.getElementById('txtadtypename').value="";	
				document.getElementById('txtalias').value="";
				z=0;
				document.getElementById('txtadtypecode').disabled=false;
				document.getElementById('txtadtypename').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
				hiddentext="query";
				
				/*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExecute').disabled=false;*/
				setButtonImages();
                document.getElementById('btnExecute').focus();
			
				return false;
}
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//
function advcancel(formname)
{
				document.getElementById('txtadtypecode').value="";
				document.getElementById('txtadtypename').value="";	
				document.getElementById('txtalias').value="";
				
				document.getElementById('txtadtypecode').disabled=true;
				document.getElementById('txtadtypename').disabled=true;
				document.getElementById('txtalias').disabled=true;
				
			//getPermission(formname);
				mod="0";
				
					chkstatus(FlagStatus);
					
				/*document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
			    document.getElementById('btnCancel').disabled=false;
			
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
			
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;*/
					givebuttonpermission(formname);
					setButtonImages();
					if(document.getElementById('btnNew').disabled==false)
					document.getElementById('btnNew').focus();
				return false;
}
			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//

function advsave()
{
			    var msg=checkSession();
                if(msg==false)
                return false;
 // event.keyCode==32;
 document.getElementById('txtadtypecode').value=trim(document.getElementById('txtadtypecode').value);
 document.getElementById('txtadtypename').value=trim(document.getElementById('txtadtypename').value);
 document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
			var bc="";
			
			if(browser!="Microsoft Internet Explorer")
            {
                bc=document.getElementById('AdvTypeCode').textContent;
            }
            else
            {
                bc=document.getElementById('AdvTypeCode').innerText;
            }
			  
			// if(document.getElementById('hiddenauto').value!=1)
             // {
                      if(bc.indexOf('*')>= 0 )
	                {
			                if(document.getElementById('txtadtypecode').value=="")
			                {
			                 alert('Please Enter '+(bc.replace('*', "")));
			                 if(document.getElementById('txtadtypecode').disabled==false)
			                document.getElementById('txtadtypecode').focus();
			                return false;
			                }
			        }
			//return false;
			  //  }
			
			if(browser!="Microsoft Internet Explorer")
            {
                bc=document.getElementById('AdvTypeName').textContent;
            }
            else
            {
                bc=document.getElementById('AdvTypeName').innerText;
            }
			
//			 bc=document.getElementById('AdvTypeName').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtadtypename').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtadtypename').focus();
	            return false;
	        }
	    }
			if(browser!="Microsoft Internet Explorer")
            {
                bc=document.getElementById('Alias').textContent;
            }
            else
            {
                bc=document.getElementById('Alias').innerText;
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

			
			var companycode=document.getElementById('hiddencomcode').value;
			var adtypecode=document.getElementById('txtadtypecode').value;
			var adtypename=document.getElementById('txtadtypename').value;
			adtypename=trim(adtypename);
						
			var alias=document.getElementById('txtalias').value;
			var UserId=document.getElementById('hiddenuserid').value;			

			if(mod!="1" && mod!=null)
			{
		    AdvTypeMaster2.advcheck(companycode,UserId,adtypecode,adtypename,call_saveclick);
			}
			else
			{
			AdvTypeMaster2.Advmodifychk(companycode,adtypecode,adtypename,alias,UserId,modifychk);
            return false;
            }
			return false;
}

//*******************************************************************************//
//********************This Is The Response To check whether name already exist or not******************//
//*******************************************************************************//

function modifychk(res)
{

var ds=res.value;
if(ds.Tables[0].Rows.length > 0)
		
{
alert("Ad Type Name has already been assigned");
document.getElementById('txtadtypename').value="";
document.getElementById('txtalias').value="";
document.getElementById('txtadtypename').focus();

 return false;
}
else
{
	var companycode=document.getElementById('hiddencomcode').value;
	var adtypecode=document.getElementById('txtadtypecode').value;
	var adtypename=document.getElementById('txtadtypename').value;
			adtypename=trim(adtypename);
						
			var alias=document.getElementById('txtalias').value;
			var UserId=document.getElementById('hiddenuserid').value;			

AdvTypeMaster2.Advmodify(companycode,adtypecode,adtypename,alias,UserId);

                 dsadexecute.Tables[0].Rows[z].Adv_Type_Code=document.getElementById('txtadtypecode').value;
				dsadexecute.Tables[0].Rows[z].Adv_Type_Name=document.getElementById('txtadtypename').value;
				dsadexecute.Tables[0].Rows[z].Adv_Type_Alias=document.getElementById('txtalias').value;
				


			//alert("Data Modified Successfully");
			if(browser!="Microsoft Internet Explorer")
                {
                   
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }


			document.getElementById('txtadtypecode').disabled=true;
			document.getElementById('txtadtypename').disabled=true;
			document.getElementById('txtalias').disabled=true;
			
		    updateStatus();
			mod="0";
		    
		    if(z==0)
		    {
		   //alert('as');
		        document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				//document.getElementById('btnExecute').disabled=true;
//				document.getElementById('btnnext').disabled=false;
//				document.getElementById('btnlast').disabled=false;
		    
		    }
		    
		    if(z==dsadexecute.Tables[0].Rows.length-1)
		    {
		   // alert(z);
		        document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
		    }
		    
			
			setButtonImages();
			 document.getElementById('btnModify').focus();
			return false;
			}
			}
//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This Ad Type Code Already Exists.");
			document.getElementById('txtadtypecode').value="";
			if(document.getElementById('txtadtypecode').disabled==false)
			    document.getElementById('txtadtypecode').focus();
			return false;
			} 
			if(ds.Tables[1].Rows.length > 0)
			{
			alert("This Ad Type Name Already Exists.");
			document.getElementById('txtadtypename').value="";
			
			document.getElementById('txtadtypename').focus();
			return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var adtypecode=document.getElementById('txtadtypecode').value;
				var adtypename=document.getElementById('txtadtypename').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;			

				AdvTypeMaster2.Advsave(companycode,adtypecode,adtypename,alias,UserId);		

				//alert("Data Saved Successfully");
				if(browser!="Microsoft Internet Explorer")
                {
                
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }


				document.getElementById('txtadtypecode').value="";
				document.getElementById('txtadtypename').value="";
				document.getElementById('txtalias').value="";
						
				document.getElementById('txtadtypecode').disabled=true;
				document.getElementById('txtadtypename').disabled=true;
				document.getElementById('txtalias').disabled=true;
								
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
			advcancel('AdvTypeMaster2');
			return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function advexecute()
{

//var glaobaladcode;
//var glaobaladname;
//var glaobaladalias;
			    var msg=checkSession();
                if(msg==false)
                return false;
			var companycode=document.getElementById('hiddencomcode').value;
			var adtypecode=document.getElementById('txtadtypecode').value;
			glaobaladcode=adtypecode;
			var adtypename=document.getElementById('txtadtypename').value;
			glaobaladname=adtypename;
			var alias=document.getElementById('txtalias').value;
			glaobaladalias=alias;
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
AdvTypeMaster2.Advexecute1(companycode,adtypecode,adtypename,alias,UserId,checkcall);			
			updateStatus();
			document.getElementById('txtadtypecode').disabled=true;
			document.getElementById('txtadtypename').disabled=true;
			document.getElementById('txtalias').disabled=true;
			
			mod="0";
			          	document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	
							
			/*document.getElementById('btnNew').disabled=true;
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
			document.getElementById('btnExit').disabled=false;*/

			return false;
}
				
				
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
			//var ds=response.value;
			dsadexecute=response.value;
			if(dsadexecute==null)
			{
			    alert(response.error.description);
			    return false;
			}  
			if(dsadexecute.Tables[0].Rows.length > 0)
			{
			 	document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Code;
				document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Name;
				document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Alias;
					
				document.getElementById('txtadtypecode').disabled=true;
				document.getElementById('txtadtypename').disabled=true;
				document.getElementById('txtalias').disabled=true;
						
			}
			
			else
			{
				alert("Your search criteria does not exist");
				advcancel('AdvTypeMaster2');
			}

            if(dsadexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
/*function advfirst()
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
AdvTypeMaster2.Advfpnl(firstcall);
						
			document.getElementById('txtadtypecode').disabled=true;
			document.getElementById('txtadtypename').disabled=true;
			document.getElementById('txtalias').disabled=true;
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;
			
			return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function advfirst()
{
			//var dsadexecute=response.value;
			    var msg=checkSession();
                if(msg==false)
                return false;	
			document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Code;
			document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Name;
			document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Alias;
			z=0;
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

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
/*function advlast()
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
AdvTypeMaster2.Advfpnl(lastcall);

			document.getElementById('txtadtypecode').disabled=true;
			document.getElementById('txtadtypename').disabled=true;
			document.getElementById('txtalias').disabled=true;
						
			return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function advlast()
{
			    var msg=checkSession();
                if(msg==false)
                return false;
			//var dsadexecute=response.value;
			var y=dsadexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[a].Adv_Type_Code;
			document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[a].Adv_Type_Name;
			document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[a].Adv_Type_Alias;
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
/*function advprevious()
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
AdvTypeMaster2.Advfpnl(previouscall);

			document.getElementById('txtadtypecode').disabled=true;
			document.getElementById('txtadtypename').disabled=true;
			document.getElementById('txtalias').disabled=true;
			return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function advprevious()
{
			    var msg=checkSession();
                if(msg==false)
                return false;
		//var dsadexecute=response.value;
		var a=dsadexecute.Tables[0].Rows.length;
		z--;
		if(z>a)
			{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=true;
				return false;
			}
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Code;
				document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Name;
				document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Alias;
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

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//
/*function advnext()
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
AdvTypeMaster2.Advfpnl(nextcall);

		document.getElementById('txtadtypecode').disabled=true;
		document.getElementById('txtadtypename').disabled=true;
		document.getElementById('txtalias').disabled=true;
		
		return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function advnext()
{
			    var msg=checkSession();
                if(msg==false)
                return false;
//debugger;
	//var dsadexecute=response.value;
	var a=dsadexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Code;
			document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Name;
			document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Alias;
			
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

/*----- Change the text box from lower case to upper case --------*/


function uppercase1()
{
document.getElementById('txtadtypecode').value=document.getElementById('txtadtypecode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
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
function advdelete()
{

        updateStatus();
//var glaobaladcode;
//var glaobaladname;
//var glaobaladalias;
		var companycode=document.getElementById('hiddencomcode').value;
		var adtypecode=document.getElementById('txtadtypecode').value;
		var adtypename=document.getElementById('txtadtypename').value;
		var alias=document.getElementById('txtalias').value;
		var UserId=document.getElementById('hiddenuserid').value;			
		boolReturn = confirm("Are You Sure you want to delete this?");
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
		if(boolReturn==1)
		{
		//alert ("Data Deleted Successfully");
		if(browser!="Microsoft Internet Explorer")
        {
        
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
		
         AdvTypeMaster2.Advdelete(companycode,adtypecode,adtypename,alias,UserId);
		
		AdvTypeMaster2.Advexecute1(companycode,glaobaladcode,glaobaladname,glaobaladalias,UserId,delcall);	
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

function delcall(res)
{
	 dsadexecute= res.value;
	len=dsadexecute.Tables[0].Rows.length;
	
	if(dsadexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtadtypecode').value="";
		document.getElementById('txtadtypename').value="";	
		document.getElementById('txtalias').value="";
		advcancel('AdvTypeMaster2');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Code;
		document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Name;
		document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[0].Adv_Type_Alias;
		
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnnext').disabled=true;
		
		
	}
	else
	{
		document.getElementById('txtadtypecode').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Code;
		document.getElementById('txtadtypename').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Name;
		document.getElementById('txtalias').value=dsadexecute.Tables[0].Rows[z].Adv_Type_Alias;
		
		
	    if (z==0)
        {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            return false;
        }

        if(z==(dsadexecute.Tables[0].Rows.length-1))
        {
            document.getElementById('btnnext').disabled=true;
	        document.getElementById('btnLast').disabled=true;
	        return false;
        }
		
		
	}
		
	setButtonImages();
return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//
function advexit()
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
   document.getElementById('txtadtypename').value=document.getElementById('txtadtypename').value.toUpperCase();
   document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
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
            document.getElementById('txtadtypename').value=document.getElementById('txtadtypename').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtadtypename').value=document.getElementById('txtadtypename').value.toUpperCase();
		document.getElementById('txtadtypename').value=trim(document.getElementById('txtadtypename').value);
		lstr=document.getElementById('txtadtypename').value;
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
		
		    if(document.getElementById('txtadtypename').value!="")
                {

		document.getElementById('txtadtypename').value=document.getElementById('txtadtypename').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtadtypename').value;
		// str=document.getElementById('txtadtypename').value;
		str=mstr;
		AdvTypeMaster2.chkzonecodename(str,fillcall);
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
		    alert("This Ad Type name has already assigned !! ");
		    document.getElementById('txtadtypecode').value="";
				document.getElementById('txtadtypename').value="";	
				document.getElementById('txtadtypename').focus();
				document.getElementById('txtalias').value="";
			
		   //document.getElementById('txtadtypename').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Adv_Type_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        document.getElementById('txtadtypename').value=trim(document.getElementById('txtadtypename').value);
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtadtypecode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtadtypecode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtadtypecode').disabled=false;
        document.getElementById('txtadtypename').value=document.getElementById('txtadtypename').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtadtypename').value;
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

//function advsave()
//{
//			if(document.getElementById('txtadtypecode').value=="")
//			{
//				alert("Please Fill Advertisement Type Code");
//				document.getElementById('txtadtypecode').focus();
//				return false;
//			}
//			else if(document.getElementById('txtadtypename').value=="")
//			{
//				alert("Please Fill Advertisement Type Name");
//				document.getElementById('txtadtypename').focus();
//				return false;
//			}
//			else if(document.getElementById('txtalias').value=="")
//			{
//				alert("Please Fill Advertisement Type alias");
//				document.getElementById('txtalias').focus();
//				return false;
//			}
//			else
//			{
//				var companycode=document.getElementById('hiddencomcode').value;
//				var adtypecode=document.getElementById('txtadtypecode').value;
//				var adtypename=document.getElementById('txtadtypename').value;
//				var alias=document.getElementById('txtalias').value;
//				var UserId=document.getElementById('hiddenuserid').value;
//			
//				if(flag!="1" && flag!=null)
//				{
//					AdvTypeMaster2.advcheck(adtypecode,companycode,UserId,call_saveclick); 
//				}
//				else
//				{
//					AdvTypeMaster2.Advmodify(companycode,adtypecode,adtypename,alias,UserId);
//			
//					alert("Data Modified Successfully");
//					
//					document.getElementById('txtadtypecode').disabled=true;
//					document.getElementById('txtadtypename').disabled=true;
//					document.getElementById('txtalias').disabled=true;
//					
//					/*document.getElementById('btnNew').disabled=true;
//					document.getElementById('btnSave').disabled=true;
//					document.getElementById('btnModify').disabled=false;
//					document.getElementById('btnDelete').disabled=false;
//					document.getElementById('btnQuery').disabled=false;
//					document.getElementById('btnExecute').disabled=true;
//					document.getElementById('btnCancel').disabled=false;		
//											
//					document.getElementById('btnfirst').disabled=false;				
//					document.getElementById('btnnext').disabled=false;					
//					document.getElementById('btnprevious').disabled=false;			
//					document.getElementById('btnlast').disabled=false;*/
//					updateStatus();
//					flag="0";
//				}
//			}
//			return false;
//}

//function call_saveclick(response)
//{
//			var ds=response.value;
//			if(ds.Tables[0].Rows.length > 0)
//			{
//				alert("This Advertisement Type Code Is Already Exist, Try Another Code !!!!");
//				return false;
//			} 
//			else
//			{
//				var companycode=document.getElementById('hiddencomcode').value;
//				var adtypecode=document.getElementById('txtadtypecode').value;
//				var adtypename=document.getElementById('txtadtypename').value;
//				var alias=document.getElementById('txtalias').value;
//				var UserId=document.getElementById('hiddenuserid').value;

//				AdvTypeMaster2.Advsave(companycode,adtypecode,adtypename,alias,UserId);

//				alert("Data Saved Successfully");

//				document.getElementById('txtadtypecode').value="";
//				document.getElementById('txtadtypename').value="";
//				document.getElementById('txtalias').value="";
//						
//				document.getElementById('txtadtypecode').disabled=true;
//				document.getElementById('txtadtypename').disabled=true;
//				document.getElementById('txtalias').disabled=true;
//								
//				document.getElementById('btnNew').disabled=false;
//				document.getElementById('btnQuery').disabled=false;
//				document.getElementById('btnCancel').disabled=false;		
//				document.getElementById('btnExit').disabled=false;	
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('btnExecute').disabled=true;
//				document.getElementById('btnfirst').disabled=true;				
//				document.getElementById('btnnext').disabled=true;					
//				document.getElementById('btnprevious').disabled=true;			
//				document.getElementById('btnlast').disabled=true;
//			}
//advcancel('AdvTypeMaster2');
//			return false;
//			
//}

//function advmodify()
//{				
//				flag=1;
//				/*document.getElementById('btnNew').disabled=true;
//				document.getElementById('btnSave').disabled=false;
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('btnQuery').disabled=true;
//				document.getElementById('btnExecute').disabled=true;
//				document.getElementById('btnCancel').disabled=false;		
//				document.getElementById('btnfirst').disabled=true;				
//				document.getElementById('btnprevious').disabled=true;
//				document.getElementById('btnnext').disabled=true;					
//				document.getElementById('btnlast').disabled=true;			
//				document.getElementById('btnExit').disabled=false;*/
//				
//				chkstatus(FlagStatus);
//			document.getElementById('btnSave').disabled = false;
//			document.getElementById('btnQuery').disabled=true;
//				
//				document.getElementById('txtadtypecode').disabled=true;
//				document.getElementById('txtadtypename').disabled=false;   
//				document.getElementById('txtalias').disabled=false;        
//									
//				return false;
//}

//function advdelete()
//{
//		var companycode=document.getElementById('hiddencomcode').value;
//		var adtypecode=document.getElementById('txtadtypecode').value;
//		var adtypename=document.getElementById('txtadtypename').value;
//		var alias=document.getElementById('txtalias').value;
//		var UserId=document.getElementById('hiddenuserid').value;
//		
//		if(confirm("Are You To Delete The Data"))
//		{
//		AdvTypeMaster2.Advdelete(companycode,adtypecode,adtypename,alias,UserId,delcall);
//		alert("Data Deleted");
//		}
//		
//		return false;
//}
//	
//function delcall(res)
//{
//	var ds= res.value;
//	len=ds.Tables[0].Rows.length;
//	
//	
//	if(ds.Tables[0].Rows.length==0)
//	{
//		alert("No More Data is here to be deleted");
//		
//		document.getElementById('txtadtypecode').value="";
//		document.getElementById('txtadtypename').value="";
//		document.getElementById('txtalias').value="";
//		advcancel('AdvTypeMaster2');
//		return false;
//	}
//	else if(z>=len || z==-1)
//	{
//		document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[0].Adv_Type_Code;
//		document.getElementById('txtadtypename').value=ds.Tables[0].Rows[0].Adv_Type_Name;
//		document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Type_Alias;
//	}
//	else
//	{
//		document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[z].Adv_Type_Code;
//		document.getElementById('txtadtypename').value=ds.Tables[0].Rows[z].Adv_Type_Name;
//		document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Type_Alias;
//	}
//	  
//	
//return false;
//}

//function advquery()		
//{
//			/*document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=true;
//			document.getElementById('btnDelete').disabled=true;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=false;
//			document.getElementById('btnCancel').disabled=false;		
//			document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnprevious').disabled=true;
//			document.getElementById('btnnext').disabled=true;					
//			document.getElementById('btnlast').disabled=true;			
//			document.getElementById('btnExit').disabled=false;*/
//			z=0;
//			chkstatus(FlagStatus);

//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=false;
//			document.getElementById('btnSave').disabled=true;
//				
//			document.getElementById('txtadtypecode').value="";
//			document.getElementById('txtadtypename').value="";	
//			document.getElementById('txtalias').value="";
//							
//			document.getElementById('txtadtypecode').disabled=false;
//			document.getElementById('txtadtypename').disabled=false;
//			document.getElementById('txtalias').disabled=false;
//			
//			return false;
//	}
//	
//function advexecute()
//{
//	var companycode=document.getElementById('hiddencomcode').value;
//	var adtypecode=document.getElementById('txtadtypecode').value;
//	var adtypename=document.getElementById('txtadtypename').value;
//	var alias=document.getElementById('txtalias').value;
//	var UserId=document.getElementById('hiddenuserid').value;
//				
//	AdvTypeMaster2.Advexecute(companycode,adtypecode,adtypename,alias,UserId,checkcall);			
//	
//	/*document.getElementById('btnNew').disabled=true;
//	document.getElementById('btnSave').disabled=true;
//	document.getElementById('btnModify').disabled=false;
//	document.getElementById('btnDelete').disabled=false;
//	document.getElementById('btnQuery').disabled=false;
//	document.getElementById('btnExecute').disabled=true;
//	document.getElementById('btnCancel').disabled=false;		
//	document.getElementById('btnfirst').disabled=false;				
//	document.getElementById('btnprevious').disabled=false;			
//	document.getElementById('btnnext').disabled=false;					
//	document.getElementById('btnlast').disabled=false;	
//	document.getElementById('btnExit').disabled=false;*/
//	updateStatus();
//						
//	document.getElementById('txtadtypecode').disabled=true;
//	document.getElementById('txtadtypename').disabled=true;
//	document.getElementById('txtalias').disabled=true;
//	
//	document.getElementById('btnfirst').disabled=true;				
//	document.getElementById('btnprevious').disabled=true;
//	
//	return false;			
//}

//function checkcall(response)
//{
//	ds=response.value;
//	if (ds.Tables[0].Rows.length <= 0)
//	{
//		alert("Your search can't produce any result");
//		advcancel('AdvTypeMaster2');
//		return false;
//	}
//	else
//	{
//	var companycode=document.getElementById('hiddencomcode').value;
//	var adtypecode=document.getElementById('txtadtypecode').value;
//	var adtypename=document.getElementById('txtadtypename').value;
//	var alias=document.getElementById('txtalias').value;
//	var UserId=document.getElementById('hiddenuserid').value;
//				
//	AdvTypeMaster2.Advexecute1(companycode,adtypecode,adtypename,alias,UserId,checkcall1);							
//	return false;
//	}
//}
//						
//function checkcall1(response)
//{
//	ds=response.value;
//	document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[0].Adv_Type_Code;
//	document.getElementById('txtadtypename').value=ds.Tables[0].Rows[0].Adv_Type_Name;
//	document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Type_Alias;
//	return false;
//}

//function advcancel(formname)
//{
//			/*document.getElementById('btnNew').disabled=false;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=true;
//			document.getElementById('btnDelete').disabled=true;
//			document.getElementById('btnQuery').disabled=false;
//			document.getElementById('btnExecute').disabled=true;
//			document.getElementById('btnCancel').disabled=false;
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnprevious').disabled=true;
//			document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=true;
//			document.getElementById('btnExit').disabled=false;*/

//			document.getElementById('txtadtypecode').value="";
//			document.getElementById('txtadtypename').value="";
//			document.getElementById('txtalias').value="";
//			
//			//getPermission(formname);

//			document.getElementById('txtadtypecode').disabled=true;
//			document.getElementById('txtadtypename').disabled=true;
//			document.getElementById('txtalias').disabled=true;

//			return false;
//}

//function advfirst()
//{
//	AdvTypeMaster2.Advfpnl(firstcall);	
//		
//		document.getElementById('txtadtypecode').disabled=true;
//		document.getElementById('txtadtypename').disabled=true;
//		document.getElementById('txtalias').disabled=true;
//		
//		updateStatus();

//		document.getElementById('btnfirst').disabled=true;				
//		document.getElementById('btnprevious').disabled=true;		
//		
//		return false;
//}

//function firstcall(response)
//{
//		z=0;
//		ds=response.value;
//		
//		document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[0].Adv_Type_Code;
//		document.getElementById('txtadtypename').value=ds.Tables[0].Rows[0].Adv_Type_Name;
//		document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Type_Alias;
//		return false;
//}

//function advprevious()
//{
//		AdvTypeMaster2.Advfpnl(previouscall);
//		
//		document.getElementById('txtadtypecode').disabled=true;
//		document.getElementById('txtadtypename').disabled=true;
//		document.getElementById('txtalias').disabled=true;
//		
//		return false;
//}

//function previouscall(response)
//{
//		z--;
//		ds=response.value;
//		var x=ds.Tables[0].Rows.length;
//	
//		
//		if(z>x)
//		{
//			document.getElementById('btnfirst').disabled=false;				
//			document.getElementById('btnprevious').disabled=false;			
//			document.getElementById('btnnext').disabled=true;					
//			document.getElementById('btnlast').disabled=true;
//			return false;
//		}
//		if(z!=-1 && z>=0)
//		{
//		if(ds.Tables[0].Rows.length != z)
//		{
//			document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[z].Adv_Type_Code;
//			document.getElementById('txtadtypename').value=ds.Tables[0].Rows[z].Adv_Type_Name;
//			document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Type_Alias;
//			updateStatus();					
//			document.getElementById('btnfirst').disabled=false;				
//			document.getElementById('btnprevious').disabled=false;			
//			document.getElementById('btnnext').disabled=false;					
//			document.getElementById('btnlast').disabled=false;
//			
//		}
//		else
//		{
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnprevious').disabled=false;
//			document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=false;
//			return false;
//		}
//}
//else
//		{
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnprevious').disabled=false;
//			document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=false;
//			return false;
//		}
//if (z<=0)
//		{
//			document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnprevious').disabled=true;			
//			document.getElementById('btnnext').disabled=false;					
//			document.getElementById('btnlast').disabled=false;	
//			return false;		
//		}
//		return false;	
//}

//function advnext()
//{
//	AdvTypeMaster2.Advfpnl(nextcall);
//		
//		document.getElementById('txtadtypecode').disabled=true;
//		document.getElementById('txtadtypename').disabled=true;
//		document.getElementById('txtalias').disabled=true;
//		
//		return false;
//}

//function nextcall(response)
//{
//			z++;
//			ds=response.value;
//			var x=ds.Tables[0].Rows.length;
//			if(z <= x && z !=-1 )
//			{
//				if(ds.Tables[0].Rows.length != z && z >= 0)
//				{
//				document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[z].Adv_Type_Code;
//				document.getElementById('txtadtypename').value=ds.Tables[0].Rows[z].Adv_Type_Name;
//				document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Type_Alias;
//				updateStatus();
//				document.getElementById('btnfirst').disabled=false;				
//				document.getElementById('btnprevious').disabled=false;			
//				document.getElementById('btnnext').disabled=false;					
//				document.getElementById('btnlast').disabled=false;
//				
//				} 
//				else
//				{
//				document.getElementById('btnfirst').disabled=false;				
//				document.getElementById('btnprevious').disabled=false;
//				document.getElementById('btnnext').disabled=true;					
//				document.getElementById('btnlast').disabled=true;
//				return false;
//				}
//}
//else
//				{
//				document.getElementById('btnfirst').disabled=false;				
//				document.getElementById('btnprevious').disabled=false;
//				document.getElementById('btnnext').disabled=true;					
//				document.getElementById('btnlast').disabled=true;
//				return false;
//				}
//				if(z==x-1)
//		{
//		document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=true;
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnprevious').disabled=false;
//		}
//}

//function advlast()
//{
//	AdvTypeMaster2.Advfpnl(lastcall);
//		
//		document.getElementById('txtadtypecode').disabled=true;
//		document.getElementById('txtadtypename').disabled=true;
//		document.getElementById('txtalias').disabled=true;
//		
//		return false;
//}

//function lastcall(response)
//{
//		 ds= response.value;
//     	 var x=ds.Tables[0].Rows.length;
//		 z=x-1;
//		 x=x-1;

//		document.getElementById('txtadtypecode').value=ds.Tables[0].Rows[x].Adv_Type_Code;
//		document.getElementById('txtadtypename').value=ds.Tables[0].Rows[x].Adv_Type_Name;
//		document.getElementById('txtalias').value=ds.Tables[0].Rows[x].Adv_Type_Alias;
//		
//		updateStatus();
//		document.getElementById('btnnext').disabled=true;
//		document.getElementById('btnlast').disabled=true;
//		document.getElementById('btnfirst').disabled=false;
//		document.getElementById('btnprevious').disabled=false;	
//		return false;
//}

//function advexit()
//{
//		if(confirm("Do You Want To Skip This Page"))
//		{
//			window.location.href='EnterPage.aspx';
//			return false;
//		}
//			return false;
//}

function uppercase1()
{
document.getElementById('txtadtypecode').value=document.getElementById('txtadtypecode').value.toUpperCase();
document.getElementById('txtadtypename').focus();
return false;
}
//		
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return false;
}

//function uppercase3()
//{
//document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
//return false;
//}
//		
//function charval()
//{
//if((event.keyCode>=48 && event.keyCode<=57)||
//(event.keyCode==127)||(event.keyCode==37)||
//(event.keyCode>=97 && event.keyCode<=122)||
//(event.keyCode>=65 && event.keyCode<=90)||
//(event.keyCode==9))
//{
//return false;
//}
//else
//{
//return false;
//}
//}

//function charval1()
//{
//if((event.keyCode>=97 && event.keyCode<=122)||
//(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
//{
//return false;
//}
//else
//{
//return false;
//}
//}


//This Function is used where special Character Are Not Allowed
function bla() 
{
//abbreviate the reference for future freqent use
var field = document.getElementById('txtadtypename').value;
//make sure that the input will be treated as string and add
var valo = new String();
//define a string to include the allowed characters
var numere = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//split this in unique characters and set each character as a var
var chars = field.split("");
for (i = 0; i < chars.length; i++) 
{
//if the character input is among the allowed let it go and add it to the previous
if (numere.indexOf(chars[i]) != -1) valo += chars[i];
//else alert...
else
   {
         alert("No special characters allowed");

	    document.getElementById('txtadtypename').value="";
        document.getElementById('txtadtypename').focus();
        
        return false;
    }
   }
if (field.value != valo) field.value = valo;

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
function clearadv()
{
advcancel('AdvTypeMaster2');
loadXML('xml/errorMessage.xml');
document.getElementById('btnNew').focus();
givebuttonpermission('AdvTypeMaster2');

}