var mod="0";  //PRADEEP
var z="0";
var hiddentext;
var auto="";
var hiddentext1="";

var dszoneexecute;

var dszonedelete;
////////////////////////these are the global values which are used at the time of deletion for f,p,n,l
var glaobalzonecode;
var glaobalzonename;
var glaobalzonealias;
var glaobalincid;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;
var chknamemod;

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
    ZoneCancelclick('ZoneMaster');

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
        //alert(xmlFile + "  Test"); 
        //xmlDoc.load(xmlFile);
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
        //debugger;
        //alert(xmlObj);  
        //alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
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
function ZoneNewclick()
{
             var msg=checkSession();
                if(msg==false)
                return false;

				document.getElementById('txtzonecode').value="";
				document.getElementById('txtzonename').value="";
				document.getElementById('txtzonealias').value = "";
				document.getElementById('txtinc').value = "";
				 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtzonecode').disabled=true;
    	          }
		         else
		           {
		           document.getElementById('txtzonecode').disabled=false;
    	           }
				
				document.getElementById('txtzonename').disabled=false;
				document.getElementById('txtzonealias').disabled = false;
				document.getElementById('txtinc').disabled = false;
				if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtzonename').focus();
    	          }
		         else
		           {
		           document.getElementById('txtzonecode').focus();
    	           }
				
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
function ZoneModifyclick()
{
				document.getElementById('txtzonecode').disabled=true;
				document.getElementById('txtzonename').disabled=false;
				document.getElementById('txtzonealias').disabled=false;
				document.getElementById('txtinc').disabled=false;
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				chknamemod=document.getElementById('txtzonename').value;
			//document.getElementById('btnSave').disabled = false;
			//document.getElementById('btnQuery').disabled=true;

				mod="1";
				 hiddentext="modify";
				 setButtonImages();	
				 document.getElementById('btnSave').focus();
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
				
				return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function ZoneQueryclick()
{
				document.getElementById('txtzonecode').value="";
				document.getElementById('txtzonename').value="";	
				document.getElementById('txtzonealias').value="";
				document.getElementById('txtinc').value="";
				z=0;
				document.getElementById('txtzonecode').disabled=false;
				document.getElementById('txtzonename').disabled=false;
				document.getElementById('txtzonealias').disabled=false;
				
				chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	setButtonImages();
	document.getElementById('btnExecute').focus();
				hiddentext="query";
				
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

			
				return false;
}
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//
function ZoneCancelclick(formname)
{

             var msg=checkSession();
                if(msg==false)
                return false;
				document.getElementById('txtzonecode').value="";
				document.getElementById('txtzonename').value="";	
				document.getElementById('txtzonealias').value="";
					document.getElementById('txtinc').value="";
				document.getElementById('txtzonecode').disabled=true;
				document.getElementById('txtzonename').disabled=true;
				document.getElementById('txtzonealias').disabled=true;
				
			//getPermission(formname);
				mod="0";
				
					chkstatus(FlagStatus);
					
			document.getElementById('btnNew').disabled=false;
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
				document.getElementById('btnlast').disabled=true;
					givebuttonpermission(formname);
					setButtonImages();
					if(document.getElementById('btnNew').disabled==false)
					document.getElementById('btnNew').focus();
				return false;
}
			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//
function ZoneSaveclick()
{
 // event.keyCode==32;
  var msg=checkSession();
    if(msg==false)
    return false;
 document.getElementById('txtzonecode').value=document.getElementById('txtzonecode').value.toUpperCase();
 document.getElementById('txtzonecode').value=trim(document.getElementById('txtzonecode').value);
 document.getElementById('txtzonename').value=trim(document.getElementById('txtzonename').value);
 document.getElementById('txtzonealias').value=trim(document.getElementById('txtzonealias').value);
 document.getElementById('txtinc').value=trim(document.getElementById('txtinc').value);
 

			if(document.getElementById('hiddenauto').value!=1)
              {
			if(document.getElementById('txtzonecode').value=="")
			{
			alert("Please Fill Zone Code");
			document.getElementById('txtzonecode').focus();
			return false;
			}
			return false;
			}
			
            if(document.getElementById('txtzonecode').value==""&&(document.getElementById('hiddenauto').value!=1))
            {
                alert("Please Fill Zone Code");
                document.getElementById('txtzonecode').focus();
                return false;
            }
			else if((document.getElementById('txtzonename').value==""))
			{
			    alert("Please Fill Zone Name");
			    document.getElementById('txtzonename').focus();
			    return false;
			}
			else if(document.getElementById('txtzonealias').value=="")
			{
			    alert("Please Fill Zone Alias");
			    document.getElementById('txtzonealias').focus();
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
			var companycode=document.getElementById('hiddencomcode').value;
			var zonecode=document.getElementById('txtzonecode').value;
			var zonename=document.getElementById('txtzonename').value;
			zonename=trim(zonename);
						
			var alias=document.getElementById('txtzonealias').value;
			var int_id=document.getElementById('txtinc').value;
			var UserId=document.getElementById('hiddenuserid').value;			

			if(mod!="1" && mod!=null)
			{
			
               ZoneMaster.chkzonecode(companycode,UserId,zonecode,zonename,int_id,call_saveclick);
			return false;
			}
			else
			{
			    var str=document.getElementById('txtzonename').value;
				ZoneMaster.chkzonecodename(str,call_modify);
				return false;
			}
			return false;
}
function call_modify(response)
{
        var ds=response.value;
        if(chknamemod!=document.getElementById('txtzonename').value)
        {
            if(ds.Tables[0].Rows.length!=0)
            {
                alert("This Zone name has already assigned !! ");
                document.getElementById('txtzonename').value="";	
                document.getElementById('txtzonename').focus();
                return false;
            }
        }
  
        
                var companycode=document.getElementById('hiddencomcode').value;
                var zonecode=document.getElementById('txtzonecode').value;
                var zonename=document.getElementById('txtzonename').value;
                zonename=trim(zonename);

                var alias=document.getElementById('txtzonealias').value;
                var int_id=document.getElementById('txtinc').value;
                var UserId=document.getElementById('hiddenuserid').value;	
                
                ZoneMaster.Advmodify1(companycode,zonecode,zonename,alias,int_id,UserId);

                dszoneexecute.Tables[0].Rows[z].Zone_Code=document.getElementById('txtzonecode').value;
				dszoneexecute.Tables[0].Rows[z].Zone_Name=document.getElementById('txtzonename').value;
				dszoneexecute.Tables[0].Rows[z].Zone_Alias=document.getElementById('txtzonealias').value;
				dszoneexecute.Tables[0].Rows[z].Zone_incid=document.getElementById('txtinc').value;

			//alert("Data Modified Successfully");
			if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(1).text);
            }
			


			document.getElementById('txtzonecode').disabled=true;
			document.getElementById('txtzonename').disabled=true;
			document.getElementById('txtzonealias').disabled=true;
			document.getElementById('txtinc').disabled=true;
			
		    
			updateStatus();
			mod="0";
			
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
            if (z==0)
            {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            }

            if(z==(dszoneexecute.Tables[0].Rows.length-1))
            {
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            }
            setButtonImages(); 
            document.getElementById('btnModify').focus();
			return false;
			
}

//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			var ds=response.value;
			if(document.getElementById('txtzonecode').value=="")
			{
			    alert("Please Enter Zone Code");
			    document.getElementById('txtzonecode').disabled
			    if(document.getElementById('txtzonecode').disabled==false)
				{
				    document.getElementById('txtzonecode').focus();
				}
			    return false;
			}
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This Zone Code Is Already Exist, Try Another Code !!!!");
			document.getElementById('txtzonecode').value="";
			 if(document.getElementById('txtzonecode').disabled==false)
				{
				    document.getElementById('txtzonecode').focus();
				    return false;
				}
//			document.getElementById('txtzonecode').value="";
//			document.getElementById('txtzonecode').focus();
			return false;
			} 
			
            if(ds.Tables[1].Rows.length > 0)
            {
            alert("This Zone Name Is Already Assigned.");
            document.getElementById('txtzonename').value="";
            document.getElementById('txtzonealias').value="";
            document.getElementById('txtinc').value="";
            document.getElementById('txtzonename').focus();
            return false;
            }
            
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var zonecode=document.getElementById('txtzonecode').value;
				var zonename=document.getElementById('txtzonename').value;
				var alias=document.getElementById('txtzonealias').value;
				var UserId=document.getElementById('hiddenuserid').value;			
				var int_id=document.getElementById('txtinc').value;

				ZoneMaster.Advsave1(companycode,zonecode,zonename,alias,UserId,int_id);		

				//alert("Data Saved Successfully");
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}


				document.getElementById('txtzonecode').value="";
				document.getElementById('txtzonename').value="";
				document.getElementById('txtzonealias').value="";
				document.getElementById('txtinc').value = "";
                		
				document.getElementById('txtzonecode').disabled=true;
				document.getElementById('txtzonename').disabled=true;
				document.getElementById('txtzonealias').disabled=true;
				document.getElementById('txtinc').disabled=true;
								
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
			ZoneCancelclick('ZoneMaster');
			return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function ZoneExecuteclick()
{

//var glaobalzonecode;
//var glaobalzonename;
//var glaobalzonealias;
         var msg=checkSession();
            if(msg==false)
            return false;
			var companycode=document.getElementById('hiddencomcode').value;
			var zonecode=document.getElementById('txtzonecode').value;
			glaobalzonecode=zonecode;
			var zonename=document.getElementById('txtzonename').value;
			glaobalzonename=zonename;
			var alias=document.getElementById('txtzonealias').value;
			glaobalzonealias=alias;
			var int_id=document.getElementById('txtinc').value;
			glaobalincid=int_id;
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
ZoneMaster.Advexecute1(companycode,zonecode,zonename,alias,UserId,checkcall);			
			updateStatus();
			document.getElementById('txtzonecode').disabled=true;
			document.getElementById('txtzonename').disabled=true;
			document.getElementById('txtzonealias').disabled=true;
			document.getElementById('txtinc').disabled=true;
			
			mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						setButtonImages();
						if(document.getElementById('btnModify').disabled==false)
			              document.getElementById('btnModify').focus();	
					//	document.getElementById('btnDelete').disabled=false;
							
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
			dszoneexecute=response.value;
			if(dszoneexecute.Tables[0].Rows.length > 0)
			{
			 	document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[0].Zone_Code;
				document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[0].Zone_Name;
				document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[0].Zone_Alias;
				if(dszoneexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
				{
				}
				else{
				document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[0].INTEGRATION_ID;
				}
					
				document.getElementById('txtzonecode').disabled=true;
				document.getElementById('txtzonename').disabled=true;
				document.getElementById('txtzonealias').disabled=true;
				document.getElementById('txtinc').disabled=true;
				if(document.getElementById('btnModify').disabled==false)
				    document.getElementById('btnModify').focus();
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
				ZoneCancelclick('ZoneMaster');
			}

            if(dszoneexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;
//			    if(document.getElementById('btnModify').disabled==false)
//			       document.getElementById('btnModify').focus();
			}
			
			
			setButtonImages();
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
function Zonefirstclick()
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
ZoneMaster.Zonefpnl(firstcall);
						
			document.getElementById('txtzonecode').disabled=true;
			document.getElementById('txtzonename').disabled=true;
			document.getElementById('txtzonealias').disabled=true;
			document.getElementById('txtinc').disabled=true;
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
//			document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;
				
			
			return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function firstcall(response)
{
			//var dszoneexecute=response.value;
	
			document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[0].Zone_Code;
			document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[0].Zone_Name;
			document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[0].Zone_Alias;
			if(dszoneexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
				{
				}
				else{
				document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[0].INTEGRATION_ID;
				}
			z=0;
			updateStatus();
             document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
		document.getElementById('btnfirst').disabled=true;	
		setButtonImages();			
		 if(document.getElementById('btnprevious').disabled==false && document.getElementById('btnModify').disabled==false )
		    document.getElementById('btnModify').focus();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
function Zonelastclick()
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
ZoneMaster.Zonefpnl(lastcall);

			document.getElementById('txtzonecode').disabled=true;
			document.getElementById('txtzonename').disabled=true;
			document.getElementById('txtzonealias').disabled=true;
			document.getElementById('txtinc').disabled=true;
						
			return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function lastcall(response)
{
			//var dszoneexecute=response.value;
			var y=dszoneexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[a].Zone_Code;
			document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[a].Zone_Name;
			document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[a].Zone_Alias;
		if(dszoneexecute.Tables[0].Rows[a].INTEGRATION_ID==null)
				{
				}
				else{
				document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[a].INTEGRATION_ID;
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
//***********************This Function For Previous Button***********************//
//*******************************************************************************//
function Zonepreviousclick()
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
ZoneMaster.Zonefpnl(previouscall);

			document.getElementById('txtzonecode').disabled=true;
			document.getElementById('txtzonename').disabled=true;
			document.getElementById('txtzonealias').disabled=true;
			document.getElementById('txtinc').disabled=true;
			return false;
}

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function previouscall(response)
{
		//var dszoneexecute=response.value;
		var a=dszoneexecute.Tables[0].Rows.length;
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
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[z].Zone_Code;
				document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[z].Zone_Name;
				document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[z].Zone_Alias;
			if(dszoneexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				}
				else{
				document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
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
				setButtonImages();
				return false;
			}
		}
		else
		{		document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				setButtonImages();
				return false;
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

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//
function Zonenextclick()
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
ZoneMaster.Zonefpnl(nextcall);

		document.getElementById('txtzonecode').disabled=true;
		document.getElementById('txtzonename').disabled=true;
		document.getElementById('txtzonealias').disabled=true;
		document.getElementById('txtinc').disabled=true;
		
		return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function nextcall(response)
{
	//var dszoneexecute=response.value;
	var a=dszoneexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[z].Zone_Code;
			document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[z].Zone_Name;
			document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[z].Zone_Alias;
			if(dszoneexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
				{
				}
				else{
				document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[z].INTEGRATION_ID;
				}
			
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
	        if(document.getElementById('btnModify').disabled==false)
	            document.getElementById('btnModify').focus();
	return false;

}

/*----- Change the text box from lower case to upper case --------*/


function uppercase1()
{
document.getElementById('txtzonecode').value=document.getElementById('txtzonecode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtzonealias').value=document.getElementById('txtzonealias').value.toUpperCase();
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
function ZoneDeleteclick()
{

        updateStatus();
//var glaobalzonecode;
//var glaobalzonename;
//var glaobalzonealias;

 var msg=checkSession();
    if(msg==false)
    return false;
		var companycode=document.getElementById('hiddencomcode').value;
		var zonecode=document.getElementById('txtzonecode').value;
		var zonename=document.getElementById('txtzonename').value;
		var alias=document.getElementById('txtzonealias').value;
		var Incid=document.getElementById('txtinc').value;
		var UserId=document.getElementById('hiddenuserid').value;			
		boolReturn = confirm("Are you sure you wish to delete this?");
		if(boolReturn==1)
		{
		//alert ("Data Deleted Successfully");
		
		
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
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
		    alert(xmlObj.childNodes(0).childNodes(2).text);
		}
ZoneMaster.Advdelete(companycode,zonecode,zonename,alias,Incid,UserId);
		
		ZoneMaster.Advexecute1(companycode,glaobalzonecode,glaobalzonename,glaobalzonealias,glaobalincid,UserId,delcall);	
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
	 dszoneexecute= res.value;
	len=dszoneexecute.Tables[0].Rows.length;
	
	if(dszoneexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtzonecode').value="";
		document.getElementById('txtzonename').value="";	
		document.getElementById('txtzonealias').value="";
		document.getElementById('txtinc').value="";
		ZoneCancelclick('ZoneMaster');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[0].Zone_Code;
		document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[0].Zone_Name;
		document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[0].Zone_Alias;
		if(dszoneexecute.Tables[0].Rows[0].INTEGRATION_ID==null)
		{
		}
		else{
		document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[0].INTEGRATION_ID;
		}
	}
	else
	{
		document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[z].Zone_Code;
		document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[z].Zone_Name;
		document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[z].Zone_Alias;
			if(dszoneexecute.Tables[0].Rows[z].INTEGRATION_ID==null)
		{
		}
		else{
		document.getElementById('txtinc').value=dszoneexecute.Tables[0].Rows[z].INTEGRATION_ID;
		}
	}
		
	setButtonImages();
return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//
function ZoneExitclick()
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
        //uppercase3();   
        document.getElementById('txtzonename').value=trim(document.getElementById('txtzonename').value);
        lstr=document.getElementById('txtzonename').value;
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

        if(document.getElementById('txtzonename').value!="")
        {
            document.getElementById('txtzonename').value=document.getElementById('txtzonename').value.toUpperCase();
            document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
            document.getElementById('txtzonealias').focus();
            // str=document.getElementById('txtzonename').value;
            str=mstr;
            ZoneMaster.chkzonecodename(str,fillcall);
            //return false;
        }
            return false;
    }
    else
    {
        document.getElementById('txtzonename').value=document.getElementById('txtzonename').value.toUpperCase();
         document.getElementById('txtzonealias').focus();
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
		    alert("This Zone name has already assigned !! ");
		    
		         document.getElementById('txtzonecode').value="";
				document.getElementById('txtzonename').value="";	
				document.getElementById('txtzonealias').value="";
				//newchange
			    if(document.getElementById('txtzonename').disabled==false)
		           document.getElementById('txtzonename').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Zone_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        document.getElementById('txtzonename').value=trim(document.getElementById('txtzonename').value);
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtzonecode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                            str=str.toUpperCase();
		                          document.getElementById('txtzonecode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
       // alert('rinki');
        document.getElementById('txtzonecode').disabled=false;
        document.getElementById('txtzonecode').value=document.getElementById('txtzonecode').value.toUpperCase();
        document.getElementById('txtzonename').value=document.getElementById('txtzonename').value.toUpperCase();
        document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
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
//Remove space
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
function trim( value ) {
	
	return LTrim(RTrim(value));
	
}
function check()
{
    document.getElementById('txtzonename').value=trim(document.getElementById('txtzonename').value);
    
    

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