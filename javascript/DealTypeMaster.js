// JScript File

var mod="0";
var z="0";
var hiddentext;
var auto="";
var hiddentext1="";

var dsdealexecute;

var dszonedelete;
////////////////////////these are the global values which are used at the time of deletion for f,p,n,l
var glaobaldealcode;
var glaobaldealname;
var glaobaldealalias;
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
    DealCancelclick('DealTypeMaster');
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
function DealNewclick()
{
				document.getElementById('txtdealcode').value="";
				document.getElementById('txtdealname').value="";	
				document.getElementById('txtdealalias').value="";
				
					document.getElementById('txtdealname').disabled=false;
				document.getElementById('txtdealalias').disabled=false;
				
				 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtdealcode').disabled=true;
		          document.getElementById('txtdealname').focus();
    	          }
		         else
		           {
		           document.getElementById('txtdealcode').disabled=false;
		           document.getElementById('txtdealcode').focus();
    	           }
				
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
function DealModifyclick()
{
				document.getElementById('txtdealcode').disabled=true;
				document.getElementById('txtdealname').disabled=false;
				document.getElementById('txtdealalias').disabled=false;
				
				chkstatus(FlagStatus);
                chknamemod=document.getElementById('txtdealname').value;
                
				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').focus();
				
				mod="1";
				hiddentext="modify";
				setButtonImages();	
		        return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function DealQueryclick()
{
				document.getElementById('txtdealcode').value="";
				document.getElementById('txtdealname').value="";	
				document.getElementById('txtdealalias').value="";
				z=0;
				document.getElementById('txtdealcode').disabled=false;
				document.getElementById('txtdealname').disabled=false;
				document.getElementById('txtdealalias').disabled=false;
				
			
				hiddentext="query";
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
function DealCancelclick(formname)
{
				document.getElementById('txtdealcode').value="";
				document.getElementById('txtdealname').value="";	
				document.getElementById('txtdealalias').value="";
				
				document.getElementById('txtdealcode').disabled=true;
				document.getElementById('txtdealname').disabled=true;
				document.getElementById('txtdealalias').disabled=true;
				
				chkstatus(FlagStatus);
			    givebuttonpermission(formname);
				mod="0";
				

				setButtonImages();
				if(document.getElementById('btnNew')==false)
				    document.getElementById('btnNew').focus();
			   return false;
}
			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//
function DealSaveclick()
{
        document.getElementById('txtdealname').value=trim(document.getElementById('txtdealname').value);
		document.getElementById('txtdealcode').value=trim(document.getElementById('txtdealcode').value);
		document.getElementById('txtdealalias').value=trim(document.getElementById('txtdealalias').value);
		

			// if(document.getElementById('hiddenauto').value!=1)
             //{
//			    if((document.getElementById('txtdealcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
//			    {
//			    alert("Please Fill Deal Code");
//			    document.getElementById('txtdealcode').focus();
//			    return false;
//			    }
//			
//			//}
			 if((document.getElementById('txtdealcode').value=="") &&(document.getElementById('hiddenauto').value!=1))
			 {
			    alert("Please Fill Deal Code");
			    document.getElementById('txtdealcode').focus();
			    return false;
			 }
			
			else if(document.getElementById('txtdealname').value=="")
			{
			alert("Please Fill Deal Name");
			document.getElementById('txtdealname').focus();
			return false;
			}
			else if(document.getElementById('txtdealalias').value=="")
			{
			alert("Please Fill Deal Alias");
			document.getElementById('txtdealalias').focus();
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
			var dealcode=document.getElementById('txtdealcode').value;
			var dealname=document.getElementById('txtdealname').value;
			var dealalias=document.getElementById('txtdealalias').value;
			var userid=document.getElementById('hiddenuserid').value;			

			if(mod!="1" && mod!=null)
			{
		       DealTypeMaster.dealcode(companycode,userid,dealcode,dealname,call_saveclick);
			}
			else
			{
			       if(chknamemod==document.getElementById('txtdealname').value)
                   {
                    updatestate();
                   }
                   else
                   {
                     DealTypeMaster.dealcode(companycode,userid,dealcode,dealname,call_modclick);
                     return false; 
                   }
			 
			}
	return false;
}

//*******************************************************************************//
function updatestate()
{
        var companycode=document.getElementById('hiddencomcode').value;
		var dealcode=document.getElementById('txtdealcode').value;
		var dealname=document.getElementById('txtdealname').value;
		var dealalias=document.getElementById('txtdealalias').value;
		var userid=document.getElementById('hiddenuserid').value;	
        
        DealTypeMaster.DealModify(companycode,userid,dealcode,dealname,dealalias);

        dsdealexecute.Tables[0].Rows[z].Deal_Code=document.getElementById('txtdealcode').value;
		dsdealexecute.Tables[0].Rows[z].Deal_Name=document.getElementById('txtdealname').value;
		dsdealexecute.Tables[0].Rows[z].Deal_Alias=document.getElementById('txtdealalias').value;
				

	   if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }

	    document.getElementById('txtdealcode').disabled=true;
	    document.getElementById('txtdealname').disabled=true;
	    document.getElementById('txtdealalias').disabled=true;
	
		updateStatus();
	    mod="0";
	
        if(z==0)
        {
        document.getElementById('btnfirst').disabled=true;				
        document.getElementById('btnprevious').disabled=true;
        }
        if(z==dsdealexecute.Tables[0].Rows.length-1)
        {
        document.getElementById('btnnext').disabled=true;					
        document.getElementById('btnlast').disabled=true;
        }
       setButtonImages(); 
        return false;
}

function call_modclick(response)
{
         var ds=response.value;
         if(chknamemod!=document.getElementById('txtdealname').value)
		 {
		   if(ds.Tables.length>1)
	       {
			    if(ds.Tables[1].Rows.length > 0)
			    {
			        alert("This Deal Name Is Already Exist, Try Another Code !!!!");
			        document.getElementById('txtdealname').value="";
			        return false;
			    } 
			    
			}
			updatestate();
		}	
}
//******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			  alert("This Deal Code Is Already Exist, Try Another Code !!!!");
			  document.getElementById('txtdealcode').value="";
			return false;
			} 
			else  if(ds.Tables.length>1)
	        {
			    if(ds.Tables[1].Rows.length > 0)
			    {
			    alert("This Deal Name Is Already Exist, Try Another Code !!!!");
			      document.getElementById('txtdealname').value="";
			    return false;
			    } 
		    }
//			else
//			{
				var companycode=document.getElementById('hiddencomcode').value;
				var dealcode=document.getElementById('txtdealcode').value;
				var dealname=document.getElementById('txtdealname').value;
				var dealalias=document.getElementById('txtdealalias').value;
				var userid=document.getElementById('hiddenuserid').value;			

				DealTypeMaster.DealSave(companycode,userid,dealcode,dealname,dealalias);		

				//alert("Data Saved Successfully");
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }

				document.getElementById('txtdealcode').value="";
				document.getElementById('txtdealname').value="";
				document.getElementById('txtdealalias').value="";
						
				document.getElementById('txtdealcode').disabled=true;
				document.getElementById('txtdealname').disabled=true;
				document.getElementById('txtdealalias').disabled=true;
								
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
			//}
			DealCancelclick('DealTypeMaster');
			return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function DealExecuteclick()
{

//var glaobaldealcode;
//var glaobaldealname;
//var glaobaldealalias;
			    
			    var companycode=document.getElementById('hiddencomcode').value;
			var dealcode=document.getElementById('txtdealcode').value;
			glaobaldealcode=dealcode;
			var dealname=document.getElementById('txtdealname').value;
			glaobaldealname=dealname;
			var dealalias=document.getElementById('txtdealalias').value;
			glaobaldealalias=dealalias;
			var userid=document.getElementById('hiddenuserid').value;			

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
DealTypeMaster.dealexe(companycode,dealcode,dealname,dealalias,checkcall);//userid,;	
					
			updateStatus();
			
			
			document.getElementById('txtdealcode').disabled=true;
			document.getElementById('txtdealname').disabled=true;
			document.getElementById('txtdealalias').disabled=true;
			
			mod="0";
			
			
//		chkstatus(FlagStatus);
//       givebuttonpermission('DealTypeMaster');
            
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
			
	
						document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;	
						
						if(document.getElementById('btnModify').disabled==false)
						    document.getElementById('btnModify').focus();
	       
			return false;
}
				
				
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
			//var ds=response.value;
			dsdealexecute=response.value;
			if(dsdealexecute.Tables[0].Rows.length > 0)
			{
				document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[0].Deal_Code;
				document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[0].Deal_Name;
				document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[0].Deal_Alias;
					
				document.getElementById('txtdealcode').disabled=true;
				document.getElementById('txtdealname').disabled=true;
				document.getElementById('txtdealalias').disabled=true;
			} 
			else
			{
				alert("Your Search Produce No Result!!!!");
				DealCancelclick('DealTypeMaster');
			}
			if(dsdealexecute.Tables[0].Rows.length ==1)
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
//function Dealfirstclick()
//{
//			//DealTypeMaster.dealfpnl(firstcall);
//						
//			document.getElementById('txtdealcode').disabled=true;
//			document.getElementById('txtdealname').disabled=true;
//			document.getElementById('txtdealalias').disabled=true;
//			
//			document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnnext').disabled=false;
//			
//			document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=true;
//			document.getElementById('btnCancel').disabled=false;		
//			document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnnext').disabled=false;					
//			document.getElementById('btnprevious').disabled=true;			
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnExit').disabled=false;
//			
//			return false;
//}
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
//function firstcall(response)
function Dealfirstclick()
{
	chkstatus(FlagStatus);
			//var dsdealexecute=response.value;
	
			document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[0].Deal_Code;
			document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[0].Deal_Name;
			document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[0].Deal_Alias;
			z=0;
			updateStatus();
           document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		setButtonImages();
		if(document.getElementById('btnModify').disabled==false)
			document.getElementById('btnModify').focus();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
//function Deallastclick()
//{
//			//DealTypeMaster.dealfpnl(lastcall);

//			document.getElementById('txtdealcode').disabled=true;
//			document.getElementById('txtdealname').disabled=true;
//			document.getElementById('txtdealalias').disabled=true;
//						
//			return false;
//}
//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
//function lastcall(response)
function Deallastclick()
{
	chkstatus(FlagStatus);
			//var dsdealexecute=response.value;
			var y=dsdealexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[a].Deal_Code;
			document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[a].Deal_Name;
			document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[a].Deal_Alias;
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
//function Dealpreviousclick()
//{			
//			//DealTypeMaster.dealfpnl(previouscall);

//			document.getElementById('txtdealcode').disabled=true;
//			document.getElementById('txtdealname').disabled=true;
//			document.getElementById('txtdealalias').disabled=true;
//			return false;
//}

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
//function previouscall(response)
function Dealpreviousclick()
{
	chkstatus(FlagStatus);
		//var dsdealexecute=response.value;
		var a=dsdealexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[z].Deal_Code;
				document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[z].Deal_Name;
				document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[z].Deal_Alias;
			updateStatus();
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
					
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
		if(document.getElementById('btnModify').disabled==false)
		    document.getElementById('btnModify').focus();
		return false;
}

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//
//function Dealnextclick()
//{
//		//DealTypeMaster.dealfpnl(nextcall);

//		document.getElementById('txtdealcode').disabled=true;
//		document.getElementById('txtdealname').disabled=true;
//		document.getElementById('txtdealalias').disabled=true;
//		
//		return false;
//}
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
//function nextcall(response)
function Dealnextclick()
{
	chkstatus(FlagStatus);
	//var dsdealexecute=response.value;
	var a=dsdealexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[z].Deal_Code;
			document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[z].Deal_Name;
			document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[z].Deal_Alias;
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
document.getElementById('txtdealcode').value=document.getElementById('txtdealcode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtdealalias').value=document.getElementById('txtdealalias').value.toUpperCase();
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
function DealDeleteclick()
{
updateStatus();

		var companycode=document.getElementById('hiddencomcode').value;
		var dealcode=document.getElementById('txtdealcode').value;
		var dealname=document.getElementById('txtdealname').value;
		var dealalias=document.getElementById('txtdealalias').value;
		var userid=document.getElementById('hiddenuserid').value;			
		boolReturn = confirm("Are you sure you wish to delete this?");
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
		
DealTypeMaster.dealdelete(companycode,dealcode,userid);//,dealname,dealalias,userid);
		
		DealTypeMaster.dealexe(companycode,glaobaldealcode,glaobaldealname,glaobaldealalias,/*userid,*/delcall);	
		
		return false;
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
	 dsdealexecute= res.value;
	len=dsdealexecute.Tables[0].Rows.length;
	
	if(dsdealexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtdealcode').value="";
		document.getElementById('txtdealname').value="";	
		document.getElementById('txtdealalias').value="";
		DealCancelclick('DealTypeMaster');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[0].Deal_Code;
		document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[0].Deal_Name;
		document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[0].Deal_Alias;
		return false;
	}
	else
	{
		document.getElementById('txtdealcode').value=dsdealexecute.Tables[0].Rows[z].Deal_Code;
		document.getElementById('txtdealname').value=dsdealexecute.Tables[0].Rows[z].Deal_Name;
		document.getElementById('txtdealalias').value=dsdealexecute.Tables[0].Rows[z].Deal_Alias;
		return false;
	}
		
setButtonImages();	
return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//
function DealExitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}


//*********************************************Auto Generate***********************
function dealautogeneratedcode()
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
            document.getElementById('txtdealname').value=document.getElementById('txtdealname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtdealname').value=document.getElementById('txtdealname').value.toUpperCase();
		document.getElementById('txtdealname').value=trim(document.getElementById('txtdealname').value);
			lstr=document.getElementById('txtdealname').value;
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
		    if(document.getElementById('txtdealname').value!="")
                {
                 
        
		document.getElementById('txtdealname').value=document.getElementById('txtdealname').value.toUpperCase();
	    document.getElementById('txtdealalias').value=document.getElementById('txtdealname').value;
	      document.getElementById('txtdealalias').focus();
		 //str=document.getElementById('txtdealname').value;
		 str=mstr;
		 //cod=document.getElementById('txtdealcode').value;
		DealTypeMaster.chkdealcodename(str/*,cod*/,fillcall);
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
		    alert("This Deal name has already assigned !! ");
		    document.getElementById('txtdealname').value="";
		    document.getElementById('txtdealalias').value="";
		    document.getElementById('txtdealname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Deal_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;//.substr(2,4);
		                        code++;
		                        document.getElementById('txtdealcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtdealcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtdealcode').disabled=false;
        document.getElementById('txtdealname').value=document.getElementById('txtdealname').value.toUpperCase();
        document.getElementById('txtdealalias').value=document.getElementById('txtdealname').value;
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
//if(event.keycode==39)
//     event.keycode=39
    
   // givebuttonpermission('DealTypeMaster');

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