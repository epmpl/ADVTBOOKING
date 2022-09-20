var z=0;
var flag="0";
var hiddentext;
var auto="";
var hiddentext1="";
var  lmds;
///////global variables for deletion  by dataset.........
var glcode;
var glname;
var glalias;
var chknamemod;


///************************************************************************************************************//

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
    LangCancelClick('LanguageMaster');

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





function LangNewClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			document.getElementById('txtLangCode').value="";
			document.getElementById('txtLangName').value="";
			document.getElementById('txtAlias').value="";
			 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtLangCode').disabled=true;
    	      }
		     else
		       {
		       document.getElementById('txtLangCode').disabled=false;
    	       }

			document.getElementById('txtLangName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtLangName').focus();
    	      }
		     else
		       {
		       if(document.getElementById('txtLangCode').disabled==false)
		            document.getElementById('txtLangCode').focus();
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

function LangCancelClick(formname)
{
			document.getElementById('txtLangCode').value="";
			document.getElementById('txtLangName').value="";
			document.getElementById('txtAlias').value="";
			document.getElementById('txtLangCode').disabled=true;
			document.getElementById('txtLangName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			
			chkstatus(FlagStatus);
			givebuttonpermission(formname);
			
			
			//getPermission(formname);
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
				setButtonImages();
				if(document.getElementById('btnNew').disabled==false)
				document.getElementById('btnNew').focus();
			return false;
}

function LangModifyClick()
{
	flag=1;
	 hiddentext="modify";
	document.getElementById('txtLangCode').disabled=true;
	document.getElementById('txtLangName').disabled=false;
	document.getElementById('txtAlias').disabled=false;
	document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=true;			
	document.getElementById('btnlast').disabled=true;			
	document.getElementById('btnExit').disabled=false;
			
	chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				chknamemod=trim(document.getElementById('txtLangName').value);
setButtonImages();
	return false;
}

function LangSaveClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
document.getElementById('txtLangName').value=trim(document.getElementById('txtLangName').value);
document.getElementById('txtLangCode').value=trim(document.getElementById('txtLangCode').value);
document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);

			  //if(document.getElementById('hiddenauto').value!=1)
              //{
			       if(document.getElementById('txtLangCode').value==""&&(document.getElementById('hiddenauto').value!=1))
			        {
				        alert("Please Fill Language Code");
//				         if(document.getElementById('txtLangCode').disabled==false)
//				            document.getElementById('txtLangCode').focus();
				        return false;
			        }
			//return false;
			//}
			else if(document.getElementById('txtLangName').value=="")
			{
				alert("Please Fill Language Name");
				document.getElementById('txtLangName').focus();
				return false;
			}
			else if(document.getElementById('txtAlias').value=="")
			{
				alert("Please Fill Language Alias");
				document.getElementById('txtAlias').focus();
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
			else
			{
					var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;
					var LangCode=document.getElementById('txtLangCode').value;
					var LangName=document.getElementById('txtLangName').value;
					var Alias=document.getElementById('txtAlias').value;
			
				if(flag!="1" && flag!=null)
				{
					LanguageMaster.checklangcode(LangCode,LangName,compcode,userid,call_saveclick); 					
				}
				else
				{
				var str=document.getElementById('txtLangName').value;
                    LanguageMaster.chklanguagecode(str,call_modify);
                    return false;
                     
				}
				
			}
			return false;
}
function call_modify(response)
{
    var ds=response.value;
    if(chknamemod!=document.getElementById('txtLangName').value)
    {
      if(ds.Tables[0].Rows.length!=0)
        {
            alert("This Language name has already assigned !! ");
            document.getElementById('txtLangName').value="";
            //document.getElementById('txtLangCode').value="";
            //document.getElementById('txtAlias').value="";

            document.getElementById('txtLangName').focus();

            return false;
        }
        //return false;
    }
                var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;
					var LangCode=document.getElementById('txtLangCode').value;
					var LangName=document.getElementById('txtLangName').value;
					var Alias=document.getElementById('txtAlias').value;
      
	    
	                    LanguageMaster.modify(LangCode,LangName,Alias,compcode,userid);
                        if(browser!="Microsoft Internet Explorer")
                        {
                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                        }
                        else
                        {
                        alert(xmlObj.childNodes(0).childNodes(1).text);
                        }

                        //alert("Data Modified Successfully");


                        lmds.Tables[0].Rows[z].Lang_Code=document.getElementById('txtLangCode').value;
                        lmds.Tables[0].Rows[z].Lang_Name=document.getElementById('txtLangName').value;
                        lmds.Tables[0].Rows[z].Lang_Alias=document.getElementById('txtAlias').value;

                        updateStatus();
                        document.getElementById('txtLangCode').disabled=true;
                        document.getElementById('txtLangName').disabled=true;
                        document.getElementById('txtAlias').disabled=true;

                        /*document.getElementById('btnNew').disabled=true;
                        document.getElementById('btnSave').disabled=true;
                        document.getElementById('btnModify').disabled=false;
                        document.getElementById('btnDelete').disabled=false;
                        document.getElementById('btnQuery').disabled=false;
                        document.getElementById('btnExecute').disabled=true;
                        document.getElementById('btnCancel').disabled=false;		

                        document.getElementById('btnfirst').disabled=false;				
                        document.getElementById('btnnext').disabled=false;					
                        document.getElementById('btnprevious').disabled=false;			
                        document.getElementById('btnlast').disabled=false;*/
                        if (z==0)
                        {
                        document.getElementById('btnfirst').disabled=true;
                        document.getElementById('btnprevious').disabled=true;
                        }

                        if(z==(lmds.Tables[0].Rows.length-1))
                        {
                        document.getElementById('btnnext').disabled=true;
                        document.getElementById('btnlast').disabled=true;
                        }       

                        flag="0";
                        setButtonImages();
                        return false;
	    
}

function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Language Code Is Already Exist, Try Another Code !!!!");
				document.getElementById('txtLangCode').value="";
				 if(document.getElementById('txtLangCode').disabled==false)
				    document.getElementById('txtLangCode').focus();
				return false;
			} 
			
            if(ds.Tables[1].Rows.length > 0)
            {
                alert("This Language Name Is Already Assigned.");
                document.getElementById('txtLangName').value="";
                document.getElementById('txtAlias').value="";
                document.getElementById('txtLangName').focus();
                return false;
            }
			
			else
			{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var LangCode=document.getElementById('txtLangCode').value;
				var LangName=document.getElementById('txtLangName').value;
				var Alias=document.getElementById('txtAlias').value;

				LanguageMaster.insert(LangCode,LangName,Alias,compcode,userid);

				//alert("Data Saved Successfully");
                if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }

				document.getElementById('txtLangCode').value="";
				document.getElementById('txtLangName').value="";
				document.getElementById('txtAlias').value="";
						
				document.getElementById('txtLangCode').disabled=true;
				document.getElementById('txtLangName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
								
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

LangCancelClick('LanguageMaster');
			return false;
}

function LangQueryClick()
{
    hiddentext="query";
			document.getElementById('txtLangCode').value="";
			document.getElementById('txtLangName').value="";
			document.getElementById('txtAlias').value="";
			z=0;
			document.getElementById('txtLangCode').disabled=false;
			document.getElementById('txtLangName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			//document.getElementById('hiddencompcode').disabled=false;
			//document.getElementById('hiddenuserid').disabled=false;

			chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	setButtonImages();
	document.getElementById('btnExecute').focus();
	
				return false;
}

function LangExecuteClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var LangCode=document.getElementById('txtLangCode').value;
			var LangName=document.getElementById('txtLangName').value;
			var Alias=document.getElementById('txtAlias').value;
			
			
			
		        glcode=document.getElementById('txtLangCode').value;
				glname=document.getElementById('txtLangName').value;
				glalias=document.getElementById('txtAlias').value;

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
LanguageMaster.Select(LangCode,LangName,Alias,compcode,userid,call_Execute);
			updateStatus();
			
			
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;*/		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		//	document.getElementById('btnExit').disabled=false;

			return false;
}

function call_Execute(response)
{
			//var ds=response.value;
			lmds=response.value;
			if (lmds.Tables[0].Rows.length>0)	
			{		
				document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[0].Lang_Code;
				document.getElementById('txtLangName').value=lmds.Tables[0].Rows[0].Lang_Name;
				document.getElementById('txtAlias').value=lmds.Tables[0].Rows[0].Lang_Alias;
				
				
				/*glcode=document.getElementById('txtLangCode').value;
				glname=document.getElementById('txtLangName').value;
				glalias=document.getElementById('txtAlias').value;*/
				
				
				
				
				
				document.getElementById('txtLangCode').disabled=true;
				document.getElementById('txtLangName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				z=0;
			}
			else
			{
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('txtLangCode').disabled=true;
				document.getElementById('txtLangName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				alert("Search Criteria Does Not Match");
				LangCancelClick('LanguageMaster')
			}
			
			if(lmds.Tables[0].Rows.length==1)
			
			{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			
			
			}
			setButtonImages();
			return false;
}

function LangFirstClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var LangCode=document.getElementById('txtLangCode').value;
			var LangName=document.getElementById('txtLangName').value;
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
LanguageMaster.Selectfnpl(LangCode,LangName,Alias,compcode,userid,call_First);
			return false;
}

function call_First(response)
{
			z=0;
			//var ds=response.value;
			document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[0].Lang_Code;
			document.getElementById('txtLangName').value=lmds.Tables[0].Rows[0].Lang_Name;
			document.getElementById('txtAlias').value=lmds.Tables[0].Rows[0].Lang_Alias;
			
			updateStatus();
			document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;	
		setButtonImages();	
			return false;
}

function LangNextClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var LangCode=document.getElementById('txtLangCode').value;
			var LangName=document.getElementById('txtLangName').value;
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
LanguageMaster.Selectfnpl(LangCode,LangName,Alias,compcode,userid,call_Next);
			return false;
}

function call_Next(response)
{
		//var ds=response.value;
var a=lmds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		    document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[z].Lang_Code;
			document.getElementById('txtLangName').value=lmds.Tables[0].Rows[z].Lang_Name;
			document.getElementById('txtAlias').value=lmds.Tables[0].Rows[z].Lang_Alias;
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


function LangPreviousClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var LangCode=document.getElementById('txtLangCode').value;
			var LangName=document.getElementById('txtLangName').value;
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
LanguageMaster.Selectfnpl(LangCode,LangName,Alias,compcode,userid,call_Previous);
			return false;
}

function call_Previous(response)
{
		//var ds=response.value;
var a=lmds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
			document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[z].Lang_Code;
				document.getElementById('txtLangName').value=lmds.Tables[0].Rows[z].Lang_Name;
				document.getElementById('txtAlias').value=lmds.Tables[0].Rows[z].Lang_Alias;

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

return false;
		
}

function LangLastClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var LangCode=document.getElementById('txtLangCode').value;
			var LangName=document.getElementById('txtLangName').value;
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
LanguageMaster.Selectfnpl(LangCode,LangName,Alias,compcode,userid,call_Last);
			return false;
}

function call_Last(response)
{
		//	var ds=response.value;
			var y=lmds.Tables[0].Rows.length;
			z=y-1;

			document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[z].Lang_Code;
			document.getElementById('txtLangName').value=lmds.Tables[0].Rows[z].Lang_Name;
			document.getElementById('txtAlias').value=lmds.Tables[0].Rows[z].Lang_Alias;
			
			document.getElementById('txtLangCode').disabled=true;
			document.getElementById('txtLangName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			
			updateStatus();
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
setButtonImages();
			return false;
}

function LangExitClick()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;	
}

function LangdeleteClick()
{
    var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var LangCode=document.getElementById('txtLangCode').value;
			var LangName=document.getElementById('txtLangName').value;
			var Alias=document.getElementById('txtAlias').value;
			
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
LanguageMaster.deletelang(LangCode,compcode,userid);
					//alert("Value Deleted Sucessfully");
					if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                    }
                    else
                    {
                        alert(xmlObj.childNodes(0).childNodes(2).text);
                    }

	                LanguageMaster.Select(glcode,glname,glalias,compcode,userid,call_deleteclick);
					
					//LanguageMaster.Selectfnpl(LangCode,LangName,Alias,compcode,userid,call_deleteclick);
					
					//document.getElementById('txtLangCode').disabled=true;
					//document.getElementById('txtLangName').disabled=true;
					//document.getElementById('txtAlias').disabled=true;
			}
			return false;
}

function call_deleteclick(response)
{
	lmds=response.value;
	//var ds=response.value;
	var a=lmds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("There Is No Data");
			document.getElementById('txtLangCode').value="";
		    document.getElementById('txtLangName').value="";
			document.getElementById('txtAlias').value="";
			LangCancelClick('LanguageMaster')
			
			return false;
	}
	
	else if(z==-1 ||z>=a)
	{
			document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[0].Lang_Code;
			document.getElementById('txtLangName').value=lmds.Tables[0].Rows[0].Lang_Name;
			document.getElementById('txtAlias').value=lmds.Tables[0].Rows[0].Lang_Alias;
			return false;
	}
	else
	{
			document.getElementById('txtLangCode').value=lmds.Tables[0].Rows[z].Lang_Code;
			document.getElementById('txtLangName').value=lmds.Tables[0].Rows[z].Lang_Name;
			document.getElementById('txtAlias').value=lmds.Tables[0].Rows[z].Lang_Alias;
	}
	setButtonImages();
	return false;
}

function autoornot()
 {
  
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    //return false;
    }
else
    {
    userdefine();

    //return false;
    }
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
			{
	
          
		    document.getElementById('txtLangName').value=trim(document.getElementById('txtLangName').value);
            lstr=document.getElementById('txtLangName').value;
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
	
		    if(document.getElementById('txtLangName').value!="")
                {
               
		   document.getElementById('txtLangName').value=document.getElementById('txtLangName').value.toUpperCase();
	       
	       document.getElementById('txtAlias').value=document.getElementById('txtLangName').value.substring(0,50);
		     str=mstr;
		     //document.getElementById('txtLangName').value=mstr;
	       // document.getElementById('txtAlias').value=mstr;
		   
		     //str=document.getElementById('txtLangName').value;
		    LanguageMaster.chklanguagecode(str,fillcall);
		      //return false;
                }
        
		       
               
 return false;
           
           }
            else
            {
            document.getElementById('txtLangName').value=document.getElementById('txtLangName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		
		    document.getElementById('txtLangName').value=trim(document.getElementById('txtLangName').value);
            lstr=document.getElementById('txtLangName').value;
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
	
		    if(document.getElementById('txtLangName').value!="")
                {
               
		   document.getElementById('txtLangName').value=document.getElementById('txtLangName').value.toUpperCase();
	       document.getElementById('txtAlias').value=document.getElementById('txtLangName').value;
		     str=mstr;
		     //document.getElementById('txtLangName').value=mstr;
	       // document.getElementById('txtAlias').value=mstr;
		   
		     //str=document.getElementById('txtLangName').value;
		    LanguageMaster.chklanguagecode(str,fillcall);
		      return false;
                }
        
		       
               
 return false;
		
}*/
function fillcallName(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Language name has already assigned !! ");
		    document.getElementById('txtLangName').value="";
            document.getElementById('txtLangCode').value="";
            document.getElementById('txtAlias').value="";

		    document.getElementById('txtLangName').focus();
    		
		    return false;
		    }
	}	    
function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Language name has already assigned !! ");
		    document.getElementById('txtLangName').value="";
            document.getElementById('txtLangCode').value="";
            document.getElementById('txtAlias').value="";

		    document.getElementById('txtLangName').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Lang_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        //var code=newstr.substr(2,4);
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtLangCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtLangCode').value=str.substr(0,2)+ "0";
		                          }
		     }
		    // document.getElementById('btnSave').focus();
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtLangCode').disabled=false;
        document.getElementById('txtLangName').value=document.getElementById('txtLangName').value.toUpperCase();
        document.getElementById('txtAlias').value=document.getElementById('txtLangName').value.substring(0,50);
        auto=document.getElementById('hiddenauto').value;
         LanguageMaster.chklanguagecode(document.getElementById('txtLangName').value,fillcallName);
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

function ClientUpperCase1(vr)
{
    
    document.getElementById(vr).value = document.getElementById(vr).value.toUpperCase();
    return false;
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