// JScript File
var z=0;
var flag="0";
var hiddentext;
var auto="";
var hiddentext1="";
var supptypds;
var glcode;
var glname;
var glalias;

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
    suppCancelClick('SupplementType');

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
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



function suppNewClick()
{
			document.getElementById('txtSupptypcode').value="";
			document.getElementById('txtSuppltypname').value="";
			document.getElementById('txtAlias').value="";
			 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtSupptypcode').disabled=true;
    	      }
		     else
		       {
		       document.getElementById('txtSupptypcode').disabled=false;
    	       }

			document.getElementById('txtSuppltypname').disabled=false;
			document.getElementById('txtAlias').disabled=false;

			 if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtSuppltypname').focus();
    	      }
		     else
		       {
		       document.getElementById('txtSupptypcode').focus();
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

function suppCancelClick(formname)
{
            chkstatus(FlagStatus);
		    givebuttonpermission(formname);
		    
			document.getElementById('txtSupptypcode').value="";
			document.getElementById('txtSuppltypname').value="";
		    document.getElementById('txtAlias').value="";

			document.getElementById('txtSupptypcode').disabled=true;
			document.getElementById('txtSuppltypname').disabled=true;
		    document.getElementById('txtAlias').disabled=true;
			setButtonImages();
			if(document.getElementById('btnNew').disabled==false)
			    document.getElementById('btnNew').focus();
			
			return false;
}

function suppModifyClick()
{
			flag=1;
			hiddentext="modify";
			document.getElementById('txtSupptypcode').disabled=true;
			document.getElementById('txtSuppltypname').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			
	
			
			chkstatus(FlagStatus);
			//document.getElementById('btnModify').disabled = true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;
setButtonImages();
			return false;
}


function suppSaveClick()
{

        document.getElementById('txtSuppltypname').value=trim(document.getElementById('txtSuppltypname').value);
		 document.getElementById('txtSupptypcode').value=trim(document.getElementById('txtSupptypcode').value);
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

			if ((document.getElementById('txtSupptypcode').value=="") &&(document.getElementById('hiddenauto').value!=1))
              
			{
					alert("Please Enter Supplement Type Code");
					document.getElementById('txtSupptypcode').focus();
					return false;
			}
			else
			{
					var SupplTypCode=document.getElementById('txtSupptypcode').value;
			}

			if (document.getElementById('txtSuppltypname').value=="")
			{
					alert("Please Enter Supplement Type Name");
					document.getElementById('txtSuppltypname').focus();
					return false;
			}
			else
			{
					var SupplTypName=document.getElementById('txtSuppltypname').value;
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
             
           
            SupplementType.modifysuppchk(SupplTypCode,SupplTypName,Alias,compcode,userid,modifychk);

			return false;
			}
			else
			{
					var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;

			if ((document.getElementById('txtSupptypcode').value=="")&&  (document.getElementById('hiddenauto').value!=1))
              
			{
					alert("Please Enter Supplement Type Code");
					document.getElementById('txtSupptypcode').focus();
					return false;
			}
			else
			{
					var SupplTypCode=document.getElementById('txtSupptypcode').value;
			}

			if (document.getElementById('txtSuppltypname').value=="")
			{
					alert("Please Enter Supplement Type Name");
					document.getElementById('txtSuppltypname').focus();
					return false;
			}
			else
			{
					var SupplTypName=document.getElementById('txtSuppltypname').value;
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

			SupplementType.chksupptyp(SupplTypCode,compcode,userid,call_save);

			return false;
            }
}

function call_save(response)
{
		var ds=response.value;
//		if(document.getElementById('hiddenauto').value!=1)
//		{
		    if(ds.Tables[0].Rows.length > 0)
		    {
				    alert("This Supplement Type Code Is Already Assigned");
				    document.getElementById('txtSupptypcode').value="";
				    document.getElementById('txtSupptypcode').focus();
				    return false;
		    }
		//}
		else
		{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var SupplTypCode=document.getElementById('txtSupptypcode').value;	
				var SupplTypName=document.getElementById('txtSuppltypname').value;
		    	var Alias=document.getElementById('txtAlias').value;
			var ip2=document.getElementById('ip1').value;

				SupplementType.insert(SupplTypCode,SupplTypName,Alias,compcode,userid,ip2);
				
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
				
                //alert(xmlObj.childNodes(0).childNodes(0).text);
			
				//alert("Data Saved Successfully");

				document.getElementById('txtSupptypcode').disabled=true;
				document.getElementById('txtSuppltypname').disabled=true;
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
		
				suppCancelClick('SupplementType');
		}
				document.getElementById('txtSupptypcode').value="";
				document.getElementById('txtSuppltypname').value="";
				document.getElementById('txtAlias').value="";

		return false;
}







function modifychk(res)
{
var ds=res.value;
if(ds.Tables[0].Rows.length > 0)
		
{
alert("Supplement Type Name has already been assigned");
document.getElementById('txtSuppltypname').focus();
 return false;
}
else
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

var SupplTypCode=document.getElementById('txtSupptypcode').value;
var SupplTypName=document.getElementById('txtSuppltypname').value;
var Alias=document.getElementById('txtAlias').value;
	var ip2=document.getElementById('ip1').value;

SupplementType.modify(SupplTypCode,SupplTypName,Alias,compcode,userid,ip2);

			

			document.getElementById('txtSupptypcode').disabled=true;
			document.getElementById('txtSuppltypname').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			
			 if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }
		     //alert(xmlObj.childNodes(0).childNodes(1).text);
			
			//alert("Data Updated Successfully");
			
		    supptypds.Tables[0].Rows[z].supptypcode=document.getElementById('txtSupptypcode').value;
			supptypds.Tables[0].Rows[z].supptypename=document.getElementById('txtSuppltypname').value;
			supptypds.Tables[0].Rows[z].supptypealias=document.getElementById('txtAlias').value;
			updateStatus();
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
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(supptypds.Tables[0].Rows.length-1))
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              } 
			setButtonImages();
			return false;
}
}



function suppQueryClick()
{
			document.getElementById('txtSupptypcode').value="";
			document.getElementById('txtSuppltypname').value="";
			document.getElementById('txtAlias').value="";
	
			document.getElementById('txtSupptypcode').disabled=false;
			document.getElementById('txtSuppltypname').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			z=0;
			chkstatus(FlagStatus);
			hiddentext="query";
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
			setButtonImages();
			document.getElementById('btnExecute').focus();
			return false;
}

function suppExecuteClick()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var SupplTypCode=document.getElementById('txtSupptypcode').value;
			var SupplTypName=document.getElementById('txtSuppltypname').value;
			var Alias=document.getElementById('txtAlias').value; 
		
			
	            glcode=document.getElementById('txtSupptypcode').value;
				glname=document.getElementById('txtSuppltypname').value;
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
            SupplementType.Select(SupplTypCode,SupplTypName,Alias,compcode,userid,call_Execute);
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
		supptypds=response.value;

		if(supptypds.Tables[0].Rows.length>0)
		{
				document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[0].supptypcode;
				document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[0].supptypename;
				document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[0].supptypealias;
				
				/*glcode=document.getElementById('txtSupptypcode').value;
				glname=document.getElementById('txtSuppltypname').value;
				glalias=document.getElementById('txtAlias').value;*/
				
				document.getElementById('txtSupptypcode').disabled=true;
				document.getElementById('txtSuppltypname').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				z=0;
		}
		else
		{		
				suppCancelClick('SupplementType');
				alert("Your search criteria does not Exist");
		}
		
		
		if(supptypds.Tables[0].Rows.length==1)
		{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
		
		}
		setButtonImages();
		return false;
}


function suppFirstClick()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SupplTypCode=document.getElementById('txtSupptypcode').value;
		var SupplTypName=document.getElementById('txtSuppltypname').value;
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
        SupplementType.Selectfnpl(SupplTypCode,SupplTypName,Alias,compcode,userid,call_First);
		return false;
}

function call_First(response)
{
		z=0;
		//var ds=response.value;

		document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[0].supptypcode;
		document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[0].supptypename;
		document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[0].supptypealias;
			
		updateStatus();
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		setButtonImages();							
		return false;
}


function suppNextClick()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SupplTypCode=document.getElementById('txtSupptypcode').value;
		var SupplTypName=document.getElementById('txtSuppltypname').value;
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
SupplementType.Selectfnpl(SupplTypCode,SupplTypName,Alias,compcode,userid,call_Next);
		return false;
}

function call_Next(response)
{
		//var ds=response.value;
var a=supptypds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		      document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[z].supptypcode;
			  document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[z].supptypename;
			  document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[z].supptypealias;
              updateStatus();
              document.getElementById('btnnext').disabled=false;
              document.getElementById('btnlast').disabled=false;
              document.getElementById('btnfirst').disabled=false;
              document.getElementById('btnprevious').disabled=false;		}
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



function suppPreviousClick()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var SupplTypCode=document.getElementById('txtSupptypcode').value;
			var SupplTypName=document.getElementById('txtSuppltypname').value;
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
SupplementType.Selectfnpl(SupplTypCode,SupplTypName,Alias,compcode,userid,call_Previous);
			return false;
}


function call_Previous(response)
{
	//	var ds=response.value;
var a=supptypds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
			document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[z].supptypcode;
			document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[z].supptypename;
			document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[z].supptypealias;

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



function suppLastClick()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var SupplTypCode=document.getElementById('txtSupptypcode').value;
			var SupplTypName=document.getElementById('txtSuppltypname').value;
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
SupplementType.Selectfnpl(SupplTypCode,SupplTypName,Alias,compcode,userid,call_Last);
			return false;
}

function call_Last(response)
{
		//var ds=response.value;
		var y=supptypds.Tables[0].Rows.length;
		z=y-1;

		document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[z].supptypcode;
		document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[z].supptypename;
		document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[z].supptypealias;
		
		document.getElementById('txtSupptypcode').disabled=true;
		document.getElementById('txtSuppltypname').disabled=true;
		document.getElementById('txtAlias').disabled=true;

		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
setButtonImages();
		return false;
}


function suppdeleteClick()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SupplTypCode=document.getElementById('txtSupptypcode').value;	
		var SupplTypName=document.getElementById('txtSuppltypname').value;
		var Alias=document.getElementById('txtAlias').value;
	
		if(confirm("Are you sure you want to delete this?"))
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
SupplementType.deletecolor(SupplTypCode,compcode,userid,ip2);
			//alert("Value Deleted Sucessfully");
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
			//alert(xmlObj.childNodes(0).childNodes(2).text);
			
			SupplementType.Select(glcode,glname,glalias,compcode,userid,call_deleteclick);
			
		}
		return false;
}

function call_deleteclick(response)
{
	supptypds=response.value;
	//var ds=response.value;
	var a=supptypds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("There Is No Data");
			document.getElementById('txtSupptypcode').value="";
			document.getElementById('txtSuppltypname').value="";
			document.getElementById('txtAlias').value="";
			suppCancelClick('SupplementType');
			return false;
	}
	
	else if(z==-1 ||z>=a)
	{
			document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[0].supptypcode;
			document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[0].supptypename;
			document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[0].supptypealias;
			//return false;
	}
	else
	{
			document.getElementById('txtSupptypcode').value=supptypds.Tables[0].Rows[z].supptypcode;
			document.getElementById('txtSuppltypname').value=supptypds.Tables[0].Rows[z].supptypename;
			document.getElementById('txtAlias').value=supptypds.Tables[0].Rows[z].supptypealias;
			
			//updateStatus();		
	}
	if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                 document.getElementById('btnnext').disabled=false;
	            document.getElementById('btnlast').disabled=false;
                }
               
             if(z==supptypds.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=false;
	            document.getElementById('btnlast').disabled=false;
	            document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
              }       
	setButtonImages();
	return false;
}

function suppExitClick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}

function suppautoornot()
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
              document.getElementById('txtSuppltypname').value=trim(document.getElementById('txtSuppltypname').value.toUpperCase());
	         lstr=document.getElementById('txtSuppltypname').value;
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
	
	
		    if(document.getElementById('txtSuppltypname').value!="")
                {
                 document.getElementById('txtSuppltypname').value=document.getElementById('txtSuppltypname').value.toUpperCase();
	            document.getElementById('txtAlias').value=document.getElementById('txtSuppltypname').value;
		       // str=document.getElementById('txtSuppltypname').value;
		       str=mstr;
		        SupplementType.chksupptypcode(str,fillcall);
		        return false;
                }
		     return false;
           
           }
            else
            {
            document.getElementById('txtSuppltypname').value=document.getElementById('txtSuppltypname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		     document.getElementById('txtSuppltypname').value=trim(document.getElementById('txtSuppltypname').value);
	         lstr=document.getElementById('txtSuppltypname').value;
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
	
	
		    if(document.getElementById('txtSuppltypname').value!="")
                {
                 document.getElementById('txtSuppltypname').value=document.getElementById('txtSuppltypname').value.toUpperCase();
	            document.getElementById('txtAlias').value=document.getElementById('txtSuppltypname').value;
		       // str=document.getElementById('txtSuppltypname').value;
		       str=mstr;
		        SupplementType.chksupptypcode(str,fillcall);
		        return false;
                }
		     return false;
		
}*/

function fillcall(res)
		{
		
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Supplement Type Name has already assigned !! ");
		    document.getElementById('txtSuppltypname').value="";
		    document.getElementById('txtSupptypcode').value="";
		    document.getElementById('txtAlias').value="";
    
		    document.getElementById('txtSuppltypname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].supptypcode;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                         code++;
		                         str=str.toUpperCase();
		                        document.getElementById('txtSupptypcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                           str=str.toUpperCase();
		                          document.getElementById('txtSupptypcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtSupptypcode').disabled=false;
        document.getElementById('txtSuppltypname').value=document.getElementById('txtSuppltypname').value.toUpperCase();
        document.getElementById('txtAlias').value=document.getElementById('txtSuppltypname').value;
        auto=document.getElementById('hiddenauto').value;
        SupplementType.chksupptypcode(document.getElementById('txtSuppltypname').value,fillcall1);
         return false;
        }

return false;
}
function fillcall1(res)
{
var ds=res.value;
		
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Supplement Type has already assigned !! ");
		   
		document.getElementById('txtSuppltypname').value="";
		if(hiddentext=="new" )
		document.getElementById('txtAlias').value="";
		    
		    document.getElementById('txtSuppltypname').focus();
         
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

//This Function is used where special Character Are Not Allowed
function bla() 
{
//abbreviate the reference for future freqent use
var field = document.getElementById('txtSuppltypname').value;
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

	    document.getElementById('txtSuppltypname').value="";
        document.getElementById('txtSuppltypname').focus();
        
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



