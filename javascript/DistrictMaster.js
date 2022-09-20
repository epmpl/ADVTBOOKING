var z=0;
var chkstatename;
var chkstate;
var statcode;
var hiddentext;
var auto="";
var hiddentext1="";
var modify="0";
var dsdistexecute;
var dsdistrictdelete;
var delstname;

////////////////////////these are the global values which are used at the time of deletion for f,p,n,l


var gladistrictcode;
var gladistrictname;
var gladistrictalias;
var gladrpcountryname;
var gladrpstatname;
////////////////////////////////
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
    CancelClickd('DistrictMaster');

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





function fillcountry()
{
		var code=document.getElementById('drpCountryName').value;
		var compcode=document.getElementById('hiddencompcode').value;
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
DistrictMaster.bindstate(code,compcode,userid,call_pac);
		document.getElementById('drpStateName').disabled=false;
		return false;
}

function call_pac(response)
{
	var ds=response.value;
	var i;

	var name=document.getElementById('drpStateName');
	  name.options.length=1;
	 name.options[0]=new Option("-----Select State-----","0");
	//name.options.length=1;

	for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
	{
			name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].State_Name,ds.Tables[0].Rows[i].State_Code);
			name.options.length;
	}
	
//	chkstatus(FlagStatus);
	return false;
	
}
//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************//
function NewClickd()
{

         var msg=checkSession();
            if(msg==false)
            return false;
		document.getElementById('txtDistrictCode').value="";
		document.getElementById('txtDistrictName').value="";
		document.getElementById('txtAlias').value="";
		//document.getElementById('drpStateName').value="0";
		 document.getElementById('drpStateName').options.length=0;
            document.getElementById('drpStateName').options[0]=new Option("----Select State----","0");
		document.getElementById('drpCountryName').value="0";
		 if(document.getElementById('hiddenauto').value==1)
		 {
		  document.getElementById('txtDistrictCode').disabled=true;
    	  }
		 else
		   {
		   document.getElementById('txtDistrictCode').disabled=false;
    	   }

		//document.getElementById('txtDistrictCode').disabled=false;
		document.getElementById('txtDistrictName').disabled=false;
		document.getElementById('txtAlias').disabled=false;
		document.getElementById('drpStateName').disabled=false;
		document.getElementById('drpCountryName').disabled=false;
		
		if(document.getElementById('hiddenauto').value==1)
		 {
		  document.getElementById('txtDistrictName').focus();
    	  }
		 else
		   {
		   document.getElementById('txtDistrictCode').focus();
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
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//

function CancelClickd(formname)
{
            chkstatus(FlagStatus);
            givebuttonpermission(formname);
            document.getElementById('txtDistrictCode').value="";
			document.getElementById('txtDistrictName').value="";
			document.getElementById('txtAlias').value="";
			 document.getElementById('drpStateName').options.length=0;
            document.getElementById('drpStateName').options[0]=new Option("----Select State----","0");
			//document.getElementById('drpStateName').value="0";
			document.getElementById('drpCountryName').value="0";


				/*document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;*/
				
			/*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnprevious').disabled=true;*/
			
			//getPermission(formname);

			document.getElementById('txtDistrictCode').disabled=true;
			document.getElementById('txtDistrictName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('drpStateName').disabled=true;
			document.getElementById('drpCountryName').disabled=true;
			setButtonImages();
			if(document.getElementById('btnNew').disable==false)
				
			document.getElementById('btnNew').focus();
			return false;
}
//*******************************************************************************//
//**************************This Function For Modify button**********************//
//*******************************************************************************//

function ModifyClickd()
{
    
						
			
                document.getElementById('txtDistrictCode').disabled=true;
			  document.getElementById('txtDistrictName').disabled=false;
			 document.getElementById('txtDistrictName').focus();
			document.getElementById('txtAlias').disabled=false;
			document.getElementById('drpStateName').disabled=false;
			document.getElementById('drpCountryName').disabled=false;
			//document.getElementById('txtDistrictName').focus();
				
			chkstatus(FlagStatus);
                 
                 chknamemod=  document.getElementById('txtDistrictName').value;
				document.getElementById('btnSave').disabled = false;
				//document.getElementById('btnSave').focus();
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
			/*document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;*/
			setButtonImages();
		   document.getElementById('btnSave').focus();
			
			flag=1;
			 hiddentext="modify";
		//fillcountry123();
			
			
			   /* document.getElementById('btnNew').disabled=true;
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
			
			//document.getElementById('btnSave').focus();
			
			return false;
}



function fillcountry123()
    {

    var code=document.getElementById('drpCountryName').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;

    DistrictMaster.bindstate(code,compcode,userid,call_pac123);
    document.getElementById('drpStateName').disabled=true;

    return false;
    }

function call_pac123(response)
{
        var ds=response.value;
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
   
            var name=document.getElementById('drpStateName');
            name.options[0]=new Option("----Select State----","0");

            name.options.length=1;

            for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
            {
            name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].State_Name,ds.Tables[0].Rows[i].State_Code);
            name.options.length;
            }
            if(statcode == undefined || statcode=="")
             {
              document.getElementById('drpStateName').value="0";
             
             }
             else
             {
              delstname=statcode;
              document.getElementById('drpStateName').value=statcode;
              statcode="";
              } 
       }
      else
        {
        alert("There is No Matching value Found");
        return false;

        }
			
			
//return false;
}



var flag="";
//*******************************************************************************//
//**************************This Function For Save button**********************//
//*******************************************************************************//

function SaveClickd()
{
//debugger;
 var msg=checkSession();
    if(msg==false)
    return false;
 document.getElementById('txtDistrictName').value=trim(document.getElementById('txtDistrictName').value);
 document.getElementById('txtDistrictCode').value=trim(document.getElementById('txtDistrictCode').value);
document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);

//if (flag==1)
	
		//{
		//var compcode=document.getElementById('hiddencompcode').value;
		//var userid=document.getElementById('hiddenuserid').value;

         
	//var DistCode=document.getElementById('txtdistrictCode').value;
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbdistrictname').textContent;
    }
    else
    {
        bc=document.getElementById('lbdistrictname').innerText;
    }
    
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('txtDistrictName').value=="")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('txtDistrictName').focus();
	        return false;
	    }
	    else
		{
				var DistName=document.getElementById('txtDistrictName').value;
		}
	}
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblDistCode').textContent;
    }
    else
    {
        bc=document.getElementById('lblDistCode').innerText;
    }
    
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('txtDistrictCode').value=="")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        if(document.getElementById('txtDistrictCode').disabled==false)
	            document.getElementById('txtDistrictCode').focus();
	        return false;
	    }
	    else
		{
				var DistCode=document.getElementById('txtDistrictCode').value;
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
	    if(document.getElementById('txtAlias').value=="")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('txtAlias').focus();
	        return false;
	    }
	    else
		{
				var Alias=document.getElementById('txtAlias').value;
		}
	}
		
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lblcountry').textContent;
    }
    else
    {
        bc=document.getElementById('lblcountry').innerText;
    }
	
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('drpCountryName').value=="0")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('drpCountryName').focus();
	        return false;
	    }
	    else
		{
				var CountryName=document.getElementById('drpCountryName').value;
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
	    if(document.getElementById('drpStateName').value=="0")
	    {   
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('drpStateName').focus();
	        return false;
	    }
	    else
		{
				var StateName=document.getElementById('drpStateName').value;
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
	    var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var DistCode=document.getElementById('txtDistrictCode').value;
		var DistName=document.getElementById('txtDistrictName').value;
		var Alias=document.getElementById('txtAlias').value;
		var StateName=document.getElementById('drpStateName').value;
		var CountryName=document.getElementById('drpCountryName').value;
		
		if(hiddentext=="new")
		{
		 
           DistrictMaster.chkcode(DistCode,DistName,compcode,userid,CountryName,call_save);
	
		}
		else
		{
		DistrictMaster.chkdistrictcodename(DistCode,DistName,compcode,CountryName,fillcallmodify);
		}
return false;
 }

//	else
//	{
//		var compcode=document.getElementById('hiddencompcode').value;
//		var userid=document.getElementById('hiddenuserid').value;
//          if(document.getElementById('hiddenauto').value!=1)
//            {
//		    if (document.getElementById('txtDistrictCode').value=="")
//		       {
//				    alert("Please Enter District Code");
//				    document.getElementById('txtDistrictCode').focus();
//				    return false;
//		       }
//		
//		    else
//		{
//				var DistCode=document.getElementById('txtDistrictCode').value;
//		}
//		
//	bc=document.getElementById('lbdistrictname').innerText; 
//    if(bc.indexOf('*')>= 0 )
//	{
//	    if(document.getElementById('txtdistrictName').value=="")
//	    {   
//	        alert('Please Enter '+(bc.replace('*', "")));
//	        document.getElementById('txtdistrictName').focus();
//	        return false;
//	    }
//	    else
//		{
//				var DistName=document.getElementById('txtdistrictName').value;
//		}
//	}
//	
//	bc=document.getElementById('lbalias').innerText; 
//    if(bc.indexOf('*')>= 0 )
//	{
//	    if(document.getElementById('txtAlias').value=="")
//	    {   
//	        alert('Please Enter '+(bc.replace('*', "")));
//	        document.getElementById('txtAlias').focus();
//	        return false;
//	    }
//	    else
//		{
//				var Alias=document.getElementById('txtAlias').value;
//		}
//	}
//		
//	bc=document.getElementById('lblcountry').innerText; 
//    if(bc.indexOf('*')>= 0 )
//	{
//	    if(document.getElementById('drpCountryName').value=="0")
//	    {   
//	        alert('Please Select '+(bc.replace('*', "")));
//	        document.getElementById('drpCountryName').focus();
//	        return false;
//	    }
//	    else
//		{
//				var CountryName=document.getElementById('drpCountryName').value;
//		}
//	}	
//	
//	bc=document.getElementById('lbstatename').innerText; 
//    if(bc.indexOf('*')>= 0 )
//	{
//	    if(document.getElementById('drpStateName').value=="0")
//	    {   
//	        alert('Please Select '+(bc.replace('*', "")));
//	        document.getElementById('drpStateName').focus();
//	        return false;
//	    }
//	    else
//		{
//				var StateName=document.getElementById('drpStateName').value;
//		}
//	}

//		if (document.getElementById('txtDistrictName').value=="")
//		{
//				alert("Please Enter District Name");
//				document.getElementById('txtDistrictName').focus();
//				return false;
//		}
//		else
//		{
//				var DistName=document.getElementById('txtDistrictName').value;
//		}

//		if (document.getElementById('txtAlias').value=="")
//		{
//				alert("Please Enter Alias");
//				document.getElementById('txtAlias').focus();
//				return false;
//		}
//		else
//		{
//				var Alias=document.getElementById('txtAlias').value;
//		}

//		
//		if (document.getElementById('drpCountryName').value==0)
//		{
//				alert("Please Select Country Name");
//				document.getElementById('drpCountryName').focus();
//				return false;	
//		}
//		else
//		{
//				var CountryName=document.getElementById('drpCountryName').value;
//		}
//		
//		if (document.getElementById('drpStateName').value==0)
//		{
//				alert("Please Select State Name");
//				document.getElementById('drpStateName').focus();
//				return false;
//		}
//		else	
//		{
//				var StateName=document.getElementById('drpStateName').value;
//		}
//}
//		DistrictMaster.chkcode(DistCode,compcode,userid,call_save);
//	
//}

    //return false;
    
//}



function fillcallmodify(response)
{
    var ds=response.value;
    if(chknamemod!=document.getElementById('txtDistrictName').value)
    {
        if(ds.Tables[0].Rows.length >=1)
        {
            alert("This District Name Already Exists.");
            document.getElementById('txtdistrictName').value="";
            return false;
        } 
    }
 
	
	    
	    var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var DistCode=document.getElementById('txtDistrictCode').value;
		var DistName=document.getElementById('txtDistrictName').value;
		var Alias=document.getElementById('txtAlias').value;
		var StateName=document.getElementById('drpStateName').value;
		var CountryName=document.getElementById('drpCountryName').value;
	
        DistrictMaster.modify(DistCode,DistName,Alias,StateName,CountryName,compcode,userid);
		
            dsdistexecute.Tables[0].Rows[z].Dist_Code=document.getElementById('txtDistrictCode').value;
		    dsdistexecute.Tables[0].Rows[z].Dist_Name=document.getElementById('txtDistrictName').value;
		    dsdistexecute.Tables[0].Rows[z].Dist_Alias=document.getElementById('txtAlias').value;
		    dsdistexecute.Tables[0].Rows[z].Country_Code=document.getElementById('drpCountryName').value;
		    dsdistexecute.Tables[0].Rows[z].State_Code=StateName;
	/*	document.getElementById('btnNew').disabled=true;
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

		document.getElementById('txtDistrictCode').disabled=true;
		document.getElementById('txtDistrictName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('drpStateName').disabled=true;
		document.getElementById('drpCountryName').disabled=true;
        
		//alert("Data Updated Successfully");
		
		updateStatus();
		
		flag=0;
		
		updateStatus();
        var x=dsdistexecute.Tables[0].Rows.length;
	y=z;	
if (z==0)
{
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
}

if(z==(dsdistexecute.Tables[0].Rows.length-1))
{
    document.getElementById('btnNext').disabled=true;
	document.getElementById('btnLast').disabled=true;
}       
        document.getElementById('btnModify').disabled=false;
        setButtonImages();
        document.getElementById('btnModify').focus();
        
        if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
        
 
 return false;
		
}
//*******************************************************************************//
//********************This Is The Responce Of The Save Button*****************//
//*******************************************************************************//
function call_save(response)
{
  
	var ds=response.value;
	if(document.getElementById('txtDistrictCode').value=="")
	{
	    alert("Please Enter District Code");
	    if(document.getElementById('txtDistrictCode').disabled==false)
		{
		    document.getElementById('txtDistrictCode').focus();
		}
	    return false;
	}
	if(ds.Tables[0].Rows.length > 0)
	{
		alert("This District Code Is Already Assigned");
		document.getElementById('txtDistrictCode').value="";
		  if(document.getElementById('txtDistrictCode').disabled==false)
		{
		    document.getElementById('txtDistrictCode').focus();
		    return false;
		}
		
		return false;
	}
	
        if(ds.Tables[1].Rows.length > 0)
        {
        alert("This District Name Is Already Assigned");
        document.getElementById('txtDistrictName').value="";
        document.getElementById('txtAlias').value="";
        document.getElementById('txtDistrictName').focus();
        return false;
        }
	
	
	else
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var DistCode=document.getElementById('txtDistrictCode').value;
		var DistName=document.getElementById('txtDistrictName').value;
		var Alias=document.getElementById('txtAlias').value;
		var StateName=document.getElementById('drpStateName').value;
		var CountryName=document.getElementById('drpCountryName').value;

		DistrictMaster.insert(DistCode,DistName,Alias,StateName,CountryName,compcode,userid);

		

		document.getElementById('txtDistrictCode').disabled=true;
		document.getElementById('txtDistrictName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('drpStateName').disabled=true;
		document.getElementById('drpCountryName').disabled=true;
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
        }
        else
        {
		    alert(xmlObj.childNodes(0).childNodes(0).text);
		}

		//alert("Data Saved Successfully");

		document.getElementById('txtDistrictCode').value="";
		document.getElementById('txtDistrictName').value="";
		document.getElementById('txtAlias').value="";
		document.getElementById('drpStateName').value="0";
		document.getElementById('drpCountryName').value="0";
		
		document.getElementById('btnNew').disabled=false;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
	}
	CancelClickd('DistrictMaster');
	return false;
}
//*******************************************************************************//
//**************************This Function For Query button**********************//
//*******************************************************************************//

function QueryClickd()
{
			z=0;
			chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
            hiddentext="query";
			/*document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;*/

			document.getElementById('txtDistrictCode').value="";
			document.getElementById('txtDistrictName').value="";
			document.getElementById('txtAlias').value="";
			//document.getElementById('drpStateName').value="0";
			 document.getElementById('drpStateName').options.length=0;
            document.getElementById('drpStateName').options[0]=new Option("----Select State----","0");
			document.getElementById('drpCountryName').value="0";

			document.getElementById('txtDistrictCode').disabled=false;
			document.getElementById('txtDistrictName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			//document.getElementById('drpStateName').disabled=true;
			document.getElementById('drpStateName').disabled=false;
			document.getElementById('drpCountryName').disabled=false;
			
			
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
				
				document.getElementById('btnExecute').focus();
				setButtonImages();
			return false;
}
//*******************************************************************************//
//**************************This Function For Execute button**********************//
//*******************************************************************************//

function ExecuteClickd()
{


//var gladistrictcode;
//var gladistrictname;
//var gladistrictalias;
//var gladrpcountryname;
//var gladrpstatname;

         var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var DistCode=document.getElementById('txtDistrictCode').value;
			gladistrictcode=DistCode;
			
			var DistName=document.getElementById('txtDistrictName').value;
			gladistrictname=DistName;
			
			var Alias=document.getElementById('txtAlias').value;
			gladistrictalias=Alias;
			
			var StateName=document.getElementById('drpStateName').value;
			gladrpstatname=StateName;
			
			var CountryName=document.getElementById('drpCountryName').value;
			gladrpcountryname=CountryName;

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
DistrictMaster.Select(DistCode,DistName,Alias,StateName,CountryName,compcode,userid,call_Execute);
			updateStatus();
						document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	
setButtonImages();
			
			
			return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//
function call_Execute(response)
{
	//var ds=response.value;
	
	dsdistexecute=response.value;
	
	if (dsdistexecute.Tables[0].Rows.length>0)
	{
			 statcode=dsdistexecute.Tables[0].Rows[0].State_Code;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			//DistrictMaster.selstat(compcode,userid,statcode,callall);
	
			document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[0].Dist_Code;
			document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[0].Dist_Name;
			document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[0].Dist_Alias;
			document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[0].Country_Code;
				fillcountry123();
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;

			document.getElementById('txtDistrictCode').disabled=true;
			document.getElementById('txtDistrictName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('drpStateName').disabled=true;
			document.getElementById('drpCountryName').disabled=true;
			z=0;
			
			if(dsdistexecute.Tables[0].Rows.length==1)
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
//			document.getElementById('txtDistrictCode').disabled=true;
//			document.getElementById('txtDistrictName').disabled=true;
//			document.getElementById('txtAlias').disabled=true;
//			document.getElementById('drpStateName').disabled=true;
//			document.getElementById('drpCountryName').disabled=true;
			CancelClickd('DistrictMaster');
			return false;
			
	}
//	if(dsdistexecute.Tables[0].Rows.length==1)
//	{
//	document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnnext').disabled=true;					
//			document.getElementById('btnprevious').disabled=true;			
//			document.getElementById('btnlast').disabled=true;
//	
//	}
	
//	return false;
}

function callall(res)
{
			var dsdistexecute=res.value;
			
			var name= document.getElementById('drpStateName');
			
			name.options[0]=new Option(dsdistexecute.Tables[0].Rows[0].State_Name,dsdistexecute.Tables[0].Rows[0].State_Code);
			
			document.getElementById('drpStateName').value=name.options[0].value;
			
			chkstatename=dsdistexecute.Tables[0].Rows[0].State_Name;
			
			chkstate=dsdistexecute.Tables[0].Rows[0].State_Code;
		
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
function FirstClickd()
{
            var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var DistCode=document.getElementById('txtDistrictCode').value;
			var DistName=document.getElementById('txtDistrictName').value;
			var Alias=document.getElementById('txtAlias').value;
			var StateName=document.getElementById('drpStateName').value;
			var CountryName=document.getElementById('drpCountryName').value;
			
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
DistrictMaster.Selectfnpl(DistCode,DistName,Alias,StateName,CountryName,compcode,userid,call_First);
			return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//		
	
function call_First(response)
{
			z=0;
			//var dsdistexecute=response.value;
			
			document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[0].Dist_Code;
			document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[0].Dist_Name;
			document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[0].Dist_Alias;
			document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[0].Country_Code;
			
			//document.getElementById('drpStateName').value=dsdistexecute.Tables[0].Rows[0].State_Code;
			 statcode=dsdistexecute.Tables[0].Rows[0].State_Code;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			//DistrictMaster.selstat(compcode,userid,statcode,callall);
			fillcountry123();
			updateStatus();
//			document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			document.getElementById('btnQuery').disabled=false;
//			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnExit').disabled=false;
			 if(document.getElementById('btnModify').disabled==false)
			   document.getElementById('btnModify').focus();
			setButtonImages();
			return false;
}
//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

function NextClickd()
{
            var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var DistCode=document.getElementById('txtDistrictCode').value;
			var DistName=document.getElementById('txtDistrictName').value;
			var Alias=document.getElementById('txtAlias').value;
			var StateName=document.getElementById('drpStateName').value;
			var CountryName=document.getElementById('drpCountryName').value;
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
DistrictMaster.Selectfnpl(DistCode,DistName,Alias,StateName,CountryName,compcode,userid,call_Next);
			return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//

function call_Next(response)
{
//var dsdistexecute=response.value;
var a=dsdistexecute.Tables[0].Rows.length;
z++;
	if(z !=-1 && z >= 0)
	{
			if(z <= a-1)
			{
				document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[z].Dist_Code;
				document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[z].Dist_Name;
				document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[z].Dist_Alias;
				document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[z].Country_Code;
				//document.getElementById('drpStateName').value=dsdistexecute.Tables[0].Rows[z].State_Code;
				
				 statcode=dsdistexecute.Tables[0].Rows[z].State_Code;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				//DistrictMaster.selstat(compcode,userid,statcode,callall);
			  	fillcountry123();
			
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
	  if(document.getElementById('btnModify').disabled==false)
		document.getElementById('btnModify').focus();
		setButtonImages();
	return false;
}
//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//

function PreviousClickd()
{
           var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var DistCode=document.getElementById('txtDistrictCode').value;
			var DistName=document.getElementById('txtDistrictName').value;
			var Alias=document.getElementById('txtAlias').value;
			var StateName=document.getElementById('drpStateName').value;
			var CountryName=document.getElementById('drpCountryName').value;
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
DistrictMaster.Selectfnpl(DistCode,DistName,Alias,StateName,CountryName,compcode,userid,call_Previous);
			return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//

function call_Previous(response)
{
//var dsdistexecute=response.value;
var a=dsdistexecute.Tables[0].Rows.length;
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
		
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
				document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[z].Dist_Code;
				document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[z].Dist_Name;
				document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[z].Dist_Alias;
				document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[z].Country_Code;
				
				//document.getElementById('drpStateName').value=dsdistexecute.Tables[0].Rows[z].State_Code;
				
				 statcode=dsdistexecute.Tables[0].Rows[z].State_Code;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				//DistrictMaster.selstat(compcode,userid,statcode,callall);
				fillcountry123();
			
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
		 if(document.getElementById('btnModify').disabled==false)
    	   document.getElementById('btnModify').focus();
setButtonImages();
return false;
}
//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

function LastClickd()
{
        var msg=checkSession();
            if(msg==false)
            return false;
		var DistCode=document.getElementById('txtDistrictCode').value;
		var DistName=document.getElementById('txtDistrictName').value;
		var Alias=document.getElementById('txtAlias').value;
		var StateName=document.getElementById('drpStateName').value;
		var CountryName=document.getElementById('drpCountryName').value;
		var compcode=document.getElementById('hiddencompcode').value;
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
DistrictMaster.Selectfnpl(DistCode,DistName,Alias,StateName,CountryName,compcode,userid,call_Last);
		return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//

function call_Last(response)
{
		//var dsdistexecute=response.value;
		var y=dsdistexecute.Tables[0].Rows.length;
		z=y-1;

		document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[z].Dist_Code;
		document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[z].Dist_Name;
		document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[z].Dist_Alias;
		document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[z].Country_Code;
		
		//document.getElementById('drpStateName').value=dsdistexecute.Tables[0].Rows[z].State_Code;
		
	    statcode=dsdistexecute.Tables[0].Rows[z].State_Code;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		//DistrictMaster.selstat(compcode,userid,statcode,callall);
				fillcountry123();
			
		document.getElementById('txtDistrictCode').disabled=true;
		document.getElementById('txtDistrictName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('drpStateName').disabled=true;
		document.getElementById('drpCountryName').disabled=true;
        updateStatus();
//		document.getElementById('btnNew').disabled=true;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnModify').disabled=false;
//		document.getElementById('btnDelete').disabled=false;
//		document.getElementById('btnQuery').disabled=false;
//		document.getElementById('btnExecute').disabled=true;
		//document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnprevious').disabled=false;
		//document.getElementById('btnExit').disabled=false;
		 if(document.getElementById('btnModify').disabled==false)
	       document.getElementById('btnModify').focus();
	       setButtonImages();
		return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//

function ExitClickd()
{
		if(confirm("Do You Want To Skip This Page"))
		{
		window.close();
		return false;
		}
		return false;
}
//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//

function deleteClick()
{


//var gladistrictcode;
//var gladistrictname;
//var gladistrictalias;
//var gladrpcountryname;
//var gladrpstatname;

         var msg=checkSession();
            if(msg==false)
            return false;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var DistCode=document.getElementById('txtDistrictCode').value;
		var DistName=document.getElementById('txtDistrictName').value;
		var Alias=document.getElementById('txtAlias').value;
		var StateName=document.getElementById('drpStateName').value;
		var CountryName=document.getElementById('drpCountryName').value;

		if(confirm("Are you sure you want to delete this"))
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
DistrictMaster.deletedist(DistCode,compcode,userid);
			if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
            }
            else
            {
		        alert(xmlObj.childNodes(0).childNodes(2).text);
		    }
			//alert("Value Deleted Sucessfully");
			DistrictMaster.Selectfnpl(DistCode,DistName,Alias,StateName,CountryName,compcode,userid);
			
			DistrictMaster.Select(gladistrictcode,gladistrictname,gladistrictalias,gladrpstatname,gladrpcountryname,compcode,userid,call_deleteclick);
			
			
			document.getElementById('txtDistrictCode').disabled=true;
			document.getElementById('txtDistrictName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('drpStateName').disabled=true;
			document.getElementById('drpCountryName').disabled=true;
		}
		return false;
}
//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function call_deleteclick(response)
{
    dsdistexecute=response.value;
	var a=dsdistexecute.Tables[0].Rows.length;
	var y=a-1;
	if( a-1 <=0 )
	{
			alert("No more data is here to be deleted");
			document.getElementById('txtDistrictCode').value="";
			document.getElementById('txtDistrictName').value="";
			document.getElementById('txtAlias').value="";
			document.getElementById('drpStateName').value="0";
			document.getElementById('drpCountryName').value="0";
			CancelClickd('DistrictMaster');
	}
	else if(z==-1 ||z>=a)
	{
	
	 statcode=dsdistexecute.Tables[0].Rows[0].State_Code;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		//DistrictMaster.selstat(compcode,userid,statcode,callall);
				fillcountry123();
			
			document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[0].Dist_Code;
			document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[0].Dist_Name;
			document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[0].Dist_Alias;
			//document.getElementById('drpStateName').value=dsdistexecute.Tables[0].Rows[0].State_Name;
			document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[0].Country_Code;
	}
	else
	{
	
	 statcode=dsdistexecute.Tables[0].Rows[z].State_Code;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		//DistrictMaster.selstat(compcode,userid,statcode,callall);
			
			
			document.getElementById('txtDistrictCode').value=dsdistexecute.Tables[0].Rows[z].Dist_Code;
			document.getElementById('txtDistrictName').value=dsdistexecute.Tables[0].Rows[z].Dist_Name;
			document.getElementById('txtAlias').value=dsdistexecute.Tables[0].Rows[z].Dist_Alias;
			//document.getElementById('drpStateName').value=delstname; //dsdistexecute.Tables[0].Rows[z].State_Name;	
			document.getElementById('drpCountryName').value=dsdistexecute.Tables[0].Rows[z].Country_Code;
				fillcountry123();
	}
	setButtonImages();
return false;
}


//*********************************************Auto Generate***********************

function autoornot()
 {
 document.getElementById('txtDistrictName').value=document.getElementById('txtDistrictName').value.toUpperCase();
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
            document.getElementById('txtDistrictName').value=document.getElementById('txtDistrictName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtDistrictName').value=trim(document.getElementById('txtDistrictName').value);
        
           lstr=document.getElementById('txtDistrictName').value;
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
	
        
        
        
		    if(document.getElementById('txtDistrictName').value!="")
               {
		document.getElementById('txtDistrictName').value=document.getElementById('txtDistrictName').value.toUpperCase();
	    document.getElementById('txtAlias').value=document.getElementById('txtDistrictName').value;
	    document.getElementById('txtAlias').focus();
		// str=document.getElementById('txtDistrictName').value;
		str=mstr;
		DistrictMaster.chkdistrictcode(str,document.getElementById('drpCountryName').value,fillcall);
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
		    alert("This District name has already assigned !! ");
		    document.getElementById('txtDistrictName').value="";
             document.getElementById('txtDistrictCode').value="";
            document.getElementById('txtAlias').value="";

		    document.getElementById('txtDistrictName').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Dist_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        //var code=newstr.substr(2,4);
		                        code++;
		                        document.getElementById('txtDistrictCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtDistrictCode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtDistrictCode').disabled=false;
        document.getElementById('txtDistrictName').value=document.getElementById('txtDistrictName').value.toUpperCase();
        document.getElementById('txtAlias').value=document.getElementById('txtDistrictName').value;
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