var z=0;
var flag="0";
var hiddentext;
var auto="";
var hiddentext1="";
var colds;
var glcode;
var glname;
var glalias;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;
var chknamemod;

function loadXML(xmlFile) 
{
    var  httpRequest =null;
    var browser=navigator.appName;
    //alert(browser);
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
    CancelClick4('ColorMaster');

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



function NewClick4()
{
			document.getElementById('txtColorCode').value="";
			document.getElementById('txtColorName').value="";
			document.getElementById('txtAlias').value="";
			 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtColorCode').disabled=true;
    	      }
		     else
		       {
		       document.getElementById('txtColorCode').disabled=false;
    	       }

			document.getElementById('txtColorName').disabled=false;
			document.getElementById('txtAlias').disabled=false;

			 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtColorName').focus();
    	      }
		     else
		       {
		       document.getElementById('txtColorCode').focus();
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

function CancelClick4(formname)
{

            hiddentext="clear";
			document.getElementById('txtColorCode').value="";
			document.getElementById('txtColorName').value="";
			document.getElementById('txtAlias').value="";

			document.getElementById('txtColorCode').disabled=true;
			document.getElementById('txtColorName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			//getPermission(formname);
				chkstatus(FlagStatus);
				
				givebuttonpermission(formname);
				if(document.getElementById('btnNew').disabled==false)
			        document.getElementById('btnNew').focus();
			/*	document.getElementById('btnNew').disabled=false;
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
			return false;
}

function ModifyClick4()
{
			flag=1;
			hiddentext="modify";
			document.getElementById('txtColorCode').disabled=true;
			document.getElementById('txtColorName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			
			chknamemod=document.getElementById('txtColorName').value;
			
		/*	document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;*/
			
			chkstatus(FlagStatus);
			document.getElementById('btnModify').disabled = true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;
setButtonImages();
			return false;
}


function SaveClick4()
{

        document.getElementById('txtColorName').value=trim(document.getElementById('txtColorName').value);
		 document.getElementById('txtColorCode').value=trim(document.getElementById('txtColorCode').value);
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
         	if (flag==1)
			{
					var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;

			if ((document.getElementById('txtColorCode').value=="") &&(document.getElementById('hiddenauto').value!=1))
              
			{
					alert("Please Enter Color Code");
					document.getElementById('txtColorCode').focus();
					return false;
			}
			else
			{
					var ColorCode=document.getElementById('txtColorCode').value;
			}

			if (document.getElementById('txtColorName').value=="")
			{
					alert("Please Enter Color Name");
					document.getElementById('txtColorName').focus();
					return false;
			}
			else
			{
					var ColorName=document.getElementById('txtColorName').value;
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
              
              var str=document.getElementById('txtColorName').value;
              
       
            ColorMaster.chkcolorcode(str,call_modify);
              
			
			
			return false;
			}
			else
			{
					var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;

			if ((document.getElementById('txtColorCode').value=="")&&(document.getElementById('hiddenauto').value!=1))
              
			{
					alert("Please Enter Color Code");
					document.getElementById('txtColorCode').focus();
					return false;
			}
			else
			{
					var ColorCode=document.getElementById('txtColorCode').value;
			}

			if (document.getElementById('txtColorName').value=="")
			{
					alert("Please Enter Color Name");
					document.getElementById('txtColorName').focus();
					return false;
			}
			else
			{
					var ColorName=document.getElementById('txtColorName').value;
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
            
			ColorMaster.chkcolor(ColorCode, ColorName, compcode,userid,call_save);

			return false;
}
}
function call_modify(response)
{

    var ds=response.value;
    if(chknamemod!= document.getElementById('txtColorName').value)
    {
        if(ds.Tables[0].Rows.length!=0)
        {
        alert("This Color name has already assigned !! ");
        document.getElementById('txtColorName').value="";
        document.getElementById('txtColorName').focus();

        return false;
        }
    
    }
  
    
                 var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var ColorCode=document.getElementById('txtColorCode').value;	
				var ColorName=document.getElementById('txtColorName').value;
				var Alias=document.getElementById('txtAlias').value;
				var ip2=document.getElementById('ip1').value;
            ColorMaster.modify(ColorCode,ColorName,Alias,compcode,userid,ip2);
            document.getElementById('txtColorCode').disabled=true;
			document.getElementById('txtColorName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
		     if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(1).text);
            }
			
			//alert("Data Updated Successfully");
			
		    colds.Tables[0].Rows[z].Col_Code=document.getElementById('txtColorCode').value;
			colds.Tables[0].Rows[z].Col_Name=document.getElementById('txtColorName').value;
			colds.Tables[0].Rows[z].Col_Alias=document.getElementById('txtAlias').value;
			updateStatus();
			if(z==0)
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;

			}
			if(z==colds.Tables[0].Rows.length-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
		
			}
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnprevious').disabled=false;*/
			flag=0;
    setButtonImages();
    return false;
}
function call_save(response)
{
		var ds=response.value;
		
		if(document.getElementById('hiddenauto')!="1")
		{
		   if(ds.Tables[0].Rows.length > 0)
    	    {
			    alert("This Color Code Is Already Assigned.");
			    document.getElementById('txtColorCode').value="";
			     document.getElementById('txtColorCode').focus();
			    return false;
	   	    }
        }		
		if(ds.Tables[1].Rows.length > 0)
//		 0 && ds.tables[0].Rows.length > 0)
		{
				alert("This Color Name Is Already Assigned.");
			    document.getElementById('txtColorName').value="";
			    document.getElementById('txtAlias').value="";
			    document.getElementById('txtColorName').focus();
				return false;
		}
		
//		else if(ds.tables[0].Rows.length > 0)
//		  {
//		    alert("This Color Name IS Already Assigned");
//		    return false;
//		  }
//		
		else
		 {
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var ColorCode=document.getElementById('txtColorCode').value;	
				var ColorName=document.getElementById('txtColorName').value;
				var Alias=document.getElementById('txtAlias').value;
                 var ip2=document.getElementById('ip1').value;
				ColorMaster.insert(ColorCode,ColorName,Alias,compcode,userid,ip2);
                if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }
			
				//alert("Data Saved Successfully");

				document.getElementById('txtColorCode').disabled=true;
				document.getElementById('txtColorName').disabled=true;
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
		
				CancelClick4('ColorMaster');
		}
			document.getElementById('txtColorCode').value="";
		    document.getElementById('txtColorName').value="";
			document.getElementById('txtAlias').value="";

		return false;
}

function QueryClick4()
{
			document.getElementById('txtColorCode').value="";
			document.getElementById('txtColorName').value="";
			document.getElementById('txtAlias').value="";
	
			document.getElementById('txtColorCode').disabled=false;
			document.getElementById('txtColorName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			z=0;
			hiddentext="query";
			chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
			
			setButtonImages();
			return false;
}

function ExecuteClick4()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ColorCode=document.getElementById('txtColorCode').value;
			var ColorName=document.getElementById('txtColorName').value;
			var Alias=document.getElementById('txtAlias').value; 
			
			
	            glcode=document.getElementById('txtColorCode').value;
				glname=document.getElementById('txtColorName').value;
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
ColorMaster.Select(ColorCode,ColorName,Alias,compcode,userid,call_Execute);
			updateStatus();
			
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

function call_Execute(response)
{
		//var ds=response.value;
		colds=response.value;

		if(colds.Tables[0].Rows.length>0)
		{
				document.getElementById('txtColorCode').value=colds.Tables[0].Rows[0].Col_Code;
				document.getElementById('txtColorName').value=colds.Tables[0].Rows[0].Col_Name;
				document.getElementById('txtAlias').value=colds.Tables[0].Rows[0].Col_Alias;
				
				/*glcode=document.getElementById('txtColorCode').value;
				glname=document.getElementById('txtColorName').value;
				glalias=document.getElementById('txtAlias').value;*/
				
				document.getElementById('txtColorCode').disabled=true;
				document.getElementById('txtColorName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				z=0;
		}
		else
		{
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('txtColorCode').disabled=true;
//				document.getElementById('txtColorName').disabled=true;
//				document.getElementById('txtAlias').disabled=true;
				
				CancelClick4('ColorMaster');
				alert("This Search Criteria Does Not Exist");
		}
		
		
		if(colds.Tables[0].Rows.length==1)
		{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
		
		}
		setButtonImages();
		return false;
}


function FirstClick4()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var ColorCode=document.getElementById('txtColorCode').value;
		var ColorName=document.getElementById('txtColorName').value;
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
ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_First);
		return false;
}

function call_First(response)
{
		z=0;
		//var ds=response.value;

		document.getElementById('txtColorCode').value=colds.Tables[0].Rows[0].Col_Code;
		document.getElementById('txtColorName').value=colds.Tables[0].Rows[0].Col_Name;
		document.getElementById('txtAlias').value=colds.Tables[0].Rows[0].Col_Alias;
			
		updateStatus();
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		setButtonImages();							
		return false;
}


function NextClick4()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var ColorCode=document.getElementById('txtColorCode').value;
		var ColorName=document.getElementById('txtColorName').value;
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
ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_Next);
		return false;
}

function call_Next(response)
{
		//var ds=response.value;
var a=colds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		     document.getElementById('txtColorCode').value=colds.Tables[0].Rows[z].Col_Code;
				document.getElementById('txtColorName').value=colds.Tables[0].Rows[z].Col_Name;
				document.getElementById('txtAlias').value=colds.Tables[0].Rows[z].Col_Alias;
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



function PreviousClick4()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ColorCode=document.getElementById('txtColorCode').value;
			var ColorName=document.getElementById('txtColorName').value;
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
ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_Previous);
			return false;
}


function call_Previous(response)
{
	//	var ds=response.value;
var a=colds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
			document.getElementById('txtColorCode').value=colds.Tables[0].Rows[z].Col_Code;
			document.getElementById('txtColorName').value=colds.Tables[0].Rows[z].Col_Name;
			document.getElementById('txtAlias').value=colds.Tables[0].Rows[z].Col_Alias;

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



function LastClick4()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ColorCode=document.getElementById('txtColorCode').value;
			var ColorName=document.getElementById('txtColorName').value;
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
ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_Last);
			return false;
}

function call_Last(response)
{
		//var ds=response.value;
		var y=colds.Tables[0].Rows.length;
		z=y-1;

		document.getElementById('txtColorCode').value=colds.Tables[0].Rows[z].Col_Code;
		document.getElementById('txtColorName').value=colds.Tables[0].Rows[z].Col_Name;
		document.getElementById('txtAlias').value=colds.Tables[0].Rows[z].Col_Alias;
		
		document.getElementById('txtColorCode').disabled=true;
		document.getElementById('txtColorName').disabled=true;
		document.getElementById('txtAlias').disabled=true;

		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
setButtonImages();
		return false;
}


function deleteClick()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var ColorCode=document.getElementById('txtColorCode').value;	
		var ColorName=document.getElementById('txtColorName').value;
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
       var ip2=document.getElementById('ip1').value;
ColorMaster.deletecolor(ColorCode,compcode,userid,ip2);
			//alert("Value Deleted Sucessfully");
			if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(2).text);
            }
			
			ColorMaster.Select(glcode,glname,glalias,compcode,userid,call_deleteclick);
			
			
		//	ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_deleteclick);
		  
			//document.getElementById('txtColorCode').disabled=true;
			//document.getElementById('txtColorName').disabled=true;
			//document.getElementById('txtAlias').disabled=true;
		}
		return false;
}

function call_deleteclick(response)
{
	colds=response.value;
	//var ds=response.value;
	var a=colds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("No more data is here to be deleted");
			document.getElementById('txtColorCode').value="";
			document.getElementById('txtColorName').value="";
			document.getElementById('txtAlias').value="";
			CancelClick4('ColorMaster');
			return false;
	}
	
	else if(z==-1 ||z>=a)
	{
			document.getElementById('txtColorCode').value=colds.Tables[0].Rows[0].Col_Code;
			document.getElementById('txtColorName').value=colds.Tables[0].Rows[0].Col_Name;
			document.getElementById('txtAlias').value=colds.Tables[0].Rows[0].Col_Alias;
			return false;
	}
	else
	{
			document.getElementById('txtColorCode').value=colds.Tables[0].Rows[z].Col_Code;
			document.getElementById('txtColorName').value=colds.Tables[0].Rows[z].Col_Name;
			document.getElementById('txtAlias').value=colds.Tables[0].Rows[z].Col_Alias;
			
			//updateStatus();		
	}
setButtonImages();	
	return false;
}

function ExitClick4()
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
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    return false;
    }
else
    {
    userdefine();

    //return false;
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
            document.getElementById('txtColorName').value=document.getElementById('txtColorName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		     document.getElementById('txtColorName').value=trim(document.getElementById('txtColorName').value);
	         lstr=document.getElementById('txtColorName').value;
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
	
	
		    if(document.getElementById('txtColorName').value!="")
                {
                 document.getElementById('txtColorName').value=document.getElementById('txtColorName').value.toUpperCase();
	            document.getElementById('txtAlias').value=document.getElementById('txtColorName').value;
		       // str=document.getElementById('txtColorName').value;
		       str=mstr;
		        ColorMaster.chkcolorcode(str,fillcall);
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
		    alert("This Color name has already assigned !! ");
		    document.getElementById('txtColorName').value="";
		    document.getElementById('txtColorCode').value="";
		    document.getElementById('txtAlias').value="";
    
		    document.getElementById('txtColorName').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Col_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                         code++;
		                         str=str.toUpperCase();
		                        document.getElementById('txtColorCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtColorCode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtColorCode').disabled=false;
        document.getElementById('txtColorName').value=document.getElementById('txtColorName').value.toUpperCase();
        document.getElementById('txtAlias').value=document.getElementById('txtColorName').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

//return false;
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