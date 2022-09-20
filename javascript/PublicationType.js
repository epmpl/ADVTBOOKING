// JScript File
var z=0;

//this flag is for permission
var flag="";
var hiddentext;
var auto="";
var hiddentext1="";
var hiddentext2="";
var dspubtypemaster;

var glapubtypecode;
var glapubtypename;
var glaAlias;

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
    CancelClick2('PublicationType');

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



function NewClick2()
{

    document.getElementById('txtpubtypecode').value="";
    document.getElementById('txtpubtypename').value="";
    document.getElementById('txtAlias').value="";


    /* document.getElementById('btnNew').disabled=true;
    document.getElementById('btnSave').disabled=false;
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnCancel').disabled=false;
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnnext').disabled=true;
    document.getElementById('btnlast').disabled=true;
    document.getElementById('btnExit').disabled=false;
    document.getElementById('btnprevious').disabled=true;*/


    chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
    
    hiddentext="new";
    
    document.getElementById('txtpubtypename').disabled=false;
    
    if(document.getElementById('hiddenauto').value==1)
    {
        document.getElementById('txtpubtypecode').disabled=true;
        document.getElementById('txtpubtypename').focus();
    }
    else
    {
        document.getElementById('txtpubtypecode').disabled=false;
        document.getElementById('txtpubtypecode').focus();
    }




    document.getElementById('txtAlias').disabled=false;

    //chkstatus(FlagStatus);
    /*document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;*/
    flag=0;
    setButtonImages();
    return false;
}

function CancelClick2(formname)
{

document.getElementById('txtpubtypecode').value="";
document.getElementById('txtpubtypename').value="";
document.getElementById('txtAlias').value="";
/*
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
document.getElementById('btnExit').disabled=false;
document.getElementById('btnprevious').disabled=true;*/

chkstatus(FlagStatus);

givebuttonpermission(formname);

document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;
if(document.getElementById('btnNew').disabled==false)
{
    document.getElementById('btnNew').focus();
}
//getPermission('PublicationType');
setButtonImages();
return false;
}


function ModifyClick2()
{
flag=1;
/*
document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=false;
document.getElementById('btnExit').disabled=true;
document.getElementById('btnQuery').disabled=true;
document.getElementById('btnNew').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
document.getElementById('btnExit').disabled=false;*/

chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				hiddentext2=document.getElementById('txtpubtypename').value;

	hiddentext="modify";
			/*document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;*/


document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=false;
document.getElementById('txtAlias').disabled=false;
setButtonImages();
return false;
}

var flag="";


function SaveClick2()
{

  document.getElementById('txtpubtypecode').value=trim(document.getElementById('txtpubtypecode').value);
 document.getElementById('txtpubtypename').value=trim(document.getElementById('txtpubtypename').value);
 document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubtypecode=document.getElementById('txtpubtypecode').value;

if(document.getElementById('hiddenauto').value!=1)
{


if (document.getElementById('txtpubtypecode').value=="")
{
alert("Please Enter Publcation Type Code");
document.getElementById('txtpubtypecode').focus();
return false;
}
//return false;
}

if (document.getElementById('txtpubtypename').value=="")
{
alert("Please Enter Publication Type Name");
document.getElementById('txtpubtypename').focus();
return false;
}
else
{
var pubtypename=document.getElementById('txtpubtypename').value;
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
var ip2=document.getElementById('ip1').value;
    PublicationType.modify(pubtypecode,pubtypename,Alias,compcode,userid,ip2);

    dspubtypemaster.Tables[0].Rows[z].pubtypecode=document.getElementById('txtpubtypecode').value;
	dspubtypemaster.Tables[0].Rows[z].pubname=document.getElementById('txtpubtypename').value;
	dspubtypemaster.Tables[0].Rows[z].pubalias=document.getElementById('txtAlias').value;
					//dsadcategorymas.Tables[0].Rows[z].Edition_Code=document.getElementById('drpednname').value;
						


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

updateStatus();

document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;

//alert("Update Successfully");
if(browser!="Microsoft Internet Explorer")
{
    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
}
else
{
    alert(xmlObj.childNodes(0).childNodes(1).text);
}
    
    if(dspubtypemaster.Tables[0].Rows.length==1)
    {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
    }   
    else if(z==0)
    {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=false;
        document.getElementById('btnlast').disabled=false;
    }
    
    else if(z==dspubtypemaster.Tables[0].Rows.length-1)
    {
        document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
    }
    else
    {
        document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        document.getElementById('btnnext').disabled=false;
        document.getElementById('btnlast').disabled=false;
    }

flag=0;
setButtonImages();
return false;
}
else
{
PublicationType.save(pubtypename,pubtypecode,compcode,userid,callsave);
//PublicationType.insert(pubtypecode,pubtypename,Alias,compcode,userid,callsave);

return false;
}
}

function callsave(res)
{
var ds= res.value;
if(ds.Tables[0].Rows.length==0)
{

		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;

		if (document.getElementById('txtpubtypecode').value=="")
		{
		alert("Please Enter Publication Type Code");
		document.getElementById('txtpubtypecode').focus();
		return false;
		}
		else
		{
		var pubtypecode=document.getElementById('txtpubtypecode').value;
		}


		if (document.getElementById('txtpubtypename').value=="")
		{
		alert("Please Enter Publication Type Name");
		document.getElementById('txtpubtypename').focus();
		return false;
		}
		else
		{
		var pubtypename=document.getElementById('txtpubtypename').value;
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

var ip2=document.getElementById('ip1').value;
		PublicationType.insert(pubtypecode,pubtypename,Alias,compcode,userid,ip2);
		

/*document.getElementById('btnNew').disabled=false;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnQuery').disabled=false;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;*/

document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;
document.getElementById('hiddencompcode').disabled=true;
document.getElementById('hiddenuserid').disabled=true;


//alert("Save Successfully");
if(browser!="Microsoft Internet Explorer")
{
    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
}
else
{
    alert(xmlObj.childNodes(0).childNodes(0).text);
}

document.getElementById('txtpubtypecode').value="";
document.getElementById('txtpubtypename').value="";
document.getElementById('txtAlias').value="";

CancelClick2('PublicationType');

return false;
}
else if(ds.Tables[0].Rows.length > 0)
{
alert("This Publication Type Code Already Exist");
document.getElementById('txtpubtypecode').value="";
//document.getElementById('txtpubtypename').value="";
return false;
}
else
{
alert("This Publication Type  Name Already Exist");
//document.getElementById('txtpubtypecode').value="";
document.getElementById('txtpubtypename').value="";
return false;
}
CancelClick2('PublicationType');
return false;
}

function QueryClick2()
{
/*
document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnModify').disabled=true;
document.getElementById('btnDelete').disabled=true;
document.getElementById('btnQuery').disabled=true;
document.getElementById('btnExecute').disabled=false;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
document.getElementById('btnExit').disabled=false;
document.getElementById('btnprevious').disabled=true;*/

chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	hiddentext="query";
z=0;
			/*document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;*/

var pubtypecode=document.getElementById('txtpubtypecode').value;
var pubtypename=document.getElementById('txtpubtypename').value;
var Alias=document.getElementById('txtAlias').value;

document.getElementById('txtpubtypecode').value="";
document.getElementById('txtpubtypename').value="";
document.getElementById('txtAlias').value="";

document.getElementById('hiddencompcode').disabled=false;
document.getElementById('hiddenuserid').disabled=false;
document.getElementById('txtpubtypecode').disabled=false;
document.getElementById('txtpubtypename').disabled=false;
document.getElementById('txtAlias').disabled=false;

setButtonImages();

return false;
}

function ExecuteClick2()
{

    //var glapubtypecode;
    //var glapubtypename;
    //var glaAlias ;

    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    var pubtypecode=document.getElementById('txtpubtypecode').value;

    glapubtypecode=pubtypecode;
    var pubtypename=document.getElementById('txtpubtypename').value;
    glapubtypename=pubtypename;
    var Alias=document.getElementById('txtAlias').value;

    glaAlias =Alias;

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
PublicationType.Execute(pubtypecode,pubtypename,Alias,compcode,userid,call_Execute);

    updateStatus();
    //			document.getElementById('btnfirst').disabled=true;
    //			document.getElementById('btnprevious').disabled=true;

    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=false;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=false;	
    if(document.getElementById('btnModify').disabled==false)
    {
        document.getElementById('btnModify').focus();
    }
    return false;
}

function call_Execute(response)

{
//var ds=response.value;

dspubtypemaster=response.value;



if (dspubtypemaster.Tables[0].Rows.length>0)
{
document.getElementById('txtpubtypecode').value=dspubtypemaster.Tables[0].Rows[0].pubtypecode;
document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[0].pubname;
document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[0].pubalias;
document.getElementById('hiddencompcode').value = dspubtypemaster.Tables[0].Rows[0].Comp_Code;
document.getElementById('hiddenuserid').value = dspubtypemaster.Tables[0].Rows[0].UserId;

/*document.getElementById('btnNew').disabled=true;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnModify').disabled=false;
document.getElementById('btnDelete').disabled=false;
document.getElementById('btnQuery').disabled=false;
document.getElementById('btnExecute').disabled=true;
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=false;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnExit').disabled=false;
document.getElementById('btnprevious').disabled=true;*/

document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;

if(dspubtypemaster.Tables[0].Rows.length==1)
{
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
//document.getElementById('btnExit').disabled=false;
document.getElementById('btnprevious').disabled=true;

}

z=0;
}
		else
		{
		document.getElementById('txtpubtypecode').disabled=true;
		document.getElementById('txtpubtypename').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		//CancelClick2('PublicationType');		
		alert("Search Not Match");
		document.getElementById('txtpubtypecode').value="";
		document.getElementById('txtpubtypename').value="";
		document.getElementById('txtAlias').value="";
		setButtonImages();
		return false;
		}
		
setButtonImages();		
		
		
}


function FirstClick2()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubtypecode=document.getElementById('txtpubtypecode').value;
var pubtypename=document.getElementById('txtpubtypename').value;

var Alias=document.getElementById('txtAlias').value;
//PublicationType.Selectfnpl(pubtypecode,compcode,userid,call_First);

            
//return false;
//}

//function call_First(response)
//{
z=0;
//var ds=response.value;
document.getElementById('txtpubtypecode').value=dspubtypemaster.Tables[0].Rows[0].pubtypecode;
document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[0].pubname;
document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[0].pubalias;
document.getElementById('hiddencompcode').value = dspubtypemaster.Tables[0].Rows[0].Comp_Code;
document.getElementById('hiddenuserid').value = dspubtypemaster.Tables[0].Rows[0].UserId;

updateStatus();

document.getElementById('btnprevious').disabled=true;	
document.getElementById('btnlast').disabled=false;	
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=false;
setButtonImages();
return false;
		
}


function NextClick2()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubtypecode=document.getElementById('txtpubtypecode').value;
var pubtypename=document.getElementById('txtpubtypename').value;
var Alias=document.getElementById('txtAlias').value;
//PublicationType.Selectfnpl(pubtypecode,compcode,userid,call_Next);
//return false;
//}

//function call_Next(response)
//{

//var ds=response.value;
var y=dspubtypemaster.Tables[0].Rows.length;
z++;
//var k=y-1;

if(z !=-1 && z >= 0)
	{
	if(z <= y-1)
		{
	    document.getElementById('txtpubtypecode').value = dspubtypemaster.Tables[0].Rows[z].pubtypecode;
	    document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[z].pubname;
	    document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[z].pubalias;
	    document.getElementById('hiddencompcode').value = dspubtypemaster.Tables[0].Rows[z].Comp_Code;
	    document.getElementById('hiddenuserid').value = dspubtypemaster.Tables[0].Rows[z].UserId;


document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;
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
		if(z==y-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
setButtonImages();
return false;
}










function PreviousClick2()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubtypecode=document.getElementById('txtpubtypecode').value;
var pubtypename=document.getElementById('txtpubtypename').value;
var Alias=document.getElementById('txtAlias').value;
//PublicationType.Selectfnpl(pubtypecode,compcode,userid,call_Previous);
//return false;
//}




//function call_Previous(response)
//{
	//var ds=response.value;
var y=dspubtypemaster.Tables[0].Rows.length;
var p=y-1;
z--;

//if(document.getElementById('btnnext').disabled=true)
//{
//document.getElementById('btnnext').disabled=false;
//}
//if(document.getElementById('btnlast').disabled=true)
//{
//document.getElementById('btnlast').disabled=false;

//}

if(z != -1  )
		{
 if(z< y-1 && z >=0)
{



     document.getElementById('txtpubtypecode').value = dspubtypemaster.Tables[0].Rows[z].pubtypecode;
     document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[z].pubname;
     document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[z].pubalias;
     document.getElementById('hiddencompcode').value = dspubtypemaster.Tables[0].Rows[z].Comp_Code;
     document.getElementById('hiddenuserid').value = dspubtypemaster.Tables[0].Rows[z].UserId;
updateStatus();
document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;


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

function LastClick2()
{

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubtypecode=document.getElementById('txtpubtypecode').value;
var pubtypename=document.getElementById('txtpubtypename').value;
var Alias=document.getElementById('txtAlias').value;
//PublicationType.Selectfnpl(pubtypecode,compcode,userid,call_Last);
//return false;
//}

//function call_Last(response)
//{
//var ds=response.value;
var y=dspubtypemaster.Tables[0].Rows.length;
a=y-1;
z=a;

document.getElementById('txtpubtypecode').value = dspubtypemaster.Tables[0].Rows[z].pubtypecode;
document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[z].pubname;
document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[z].pubalias;
document.getElementById('hiddencompcode').value = dspubtypemaster.Tables[0].Rows[z].Comp_Code;
document.getElementById('hiddenuserid').value = dspubtypemaster.Tables[0].Rows[z].UserId;


document.getElementById('txtpubtypecode').disabled=true;
document.getElementById('txtpubtypename').disabled=true;
document.getElementById('txtAlias').disabled=true;


updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
setButtonImages();
return false;


}

function ExitClick2()
{
if(confirm("Do You Want To Skip This Page"))
{
//window.location.href='Enterpage.aspx';
window.close();
return false;
}
return false;
}



function DeleteClick2()
{
boolReturn = confirm("Are you sure you wish to delete this?");
if(boolReturn==1)
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pubtypecode=document.getElementById('txtpubtypecode').value;
var pubtypename=document.getElementById('txtpubtypename').value;
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
    var ip2=document.getElementById('ip1').value;   
PublicationType.delete1(pubtypecode,compcode,userid,ip2);
//alert ("Data Deleted");	
if(browser!="Microsoft Internet Explorer")
{
    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
}
else
{
    alert(xmlObj.childNodes(0).childNodes(2).text);
}
//preodicitymaster.Selectfnpl(pubtypecode,pubtypename,Alias,compcode,userid,call_delete);

PublicationType.Execute(glapubtypecode,glapubtypename,glaAlias ,compcode,userid,call_delete);

				
				}     
				else
				
				{
				 return false;
				}
return false;
}

function call_delete(res)
{
    dspubtypemaster= res.value;
	len=dspubtypemaster.Tables[0].Rows.length;
	
	if(dspubtypemaster.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('txtpubtypecode').value="";
		document.getElementById('txtpubtypename').value="";
		document.getElementById('txtAlias').value="";

		CancelClick2('PublicationType');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
	    document.getElementById('txtpubtypecode').value = dspubtypemaster.Tables[0].Rows[0].pubtypecode;
	    document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[0].pubname;
	    document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[0].pubalias;
	}
	
	else
	{
	    document.getElementById('txtpubtypecode').value = dspubtypemaster.Tables[0].Rows[z].pubtypecode;
	    document.getElementById('txtpubtypename').value = dspubtypemaster.Tables[0].Rows[z].pubname;
	    document.getElementById('txtAlias').value = dspubtypemaster.Tables[0].Rows[z].pubalias;
	}
	//alert ("Data Deleted");	
				
//	if(browser!="Microsoft Internet Explorer")
//    {
//        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
//    }
//    else
//    {
//        alert(xmlObj.childNodes(0).childNodes(2).text);
//    }
//	    return false;
setButtonImages();
   }


// ******************************Code For Auto Generation********************

function pubtypautocode()
 {
 
 //alert("sdjcnlksdj]");
  if(document.getElementById('hiddenauto').value==1)
    {
    advautochange();
    
    return false;
    }
else
    {
    advuserdefine();

    return false;
    }
return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function advautochange()
{
document.getElementById('txtpubtypename').value=document.getElementById('txtpubtypename').value.toUpperCase();
if(hiddentext=="new" || hiddentext=="modify" )
			{
	
            UPPERCASEAdV();
           
           }
            else
            {
            
            document.getElementById('txtpubtypename').value=document.getElementById('txtpubtypename').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASEAdV()
		{
		//  document.getElementById('txtpubtypecode').value=trim(document.getElementById('txtpubtypecode').value);
		
document.getElementById('txtpubtypename').value=trim(document.getElementById('txtpubtypename').value.toUpperCase());
 document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);
         lstr=document.getElementById('txtpubtypename').value;
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
		    if(document.getElementById('txtpubtypename').value!="")
                {
                 
               
		
		if(hiddentext=="new")
	    document.getElementById('txtAlias').value=document.getElementById('txtpubtypename').value;
		// str=document.getElementById('txtpubtypename').value;
		str=mstr;
		if(hiddentext2!=document.getElementById('txtpubtypename').value)
		PublicationType.autopreodicity(str,fillcall);
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
		    alert("This Publication Type has already assigned !! ");
		  if(hiddentext=="new")
		  {  
		 document.getElementById('txtpubtypecode').value="";
		 document.getElementById('txtAlias').value="";
		 }
		 document.getElementById('txtpubtypename').value="";
		    
		    document.getElementById('txtpubtypename').focus();
    		
		    return false;
		    }
		
		        else
		        {
		         if(hiddentext=="new")
		             {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].pubtypecode;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtpubtypecode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtpubtypecode').value=str.substr(0,2)+ "0";
		                          }
		                          //if(document.getElementById('txtAlias').disable==false)
		                          document.getElementById('txtAlias').focus();
		            }
		     }
	return false;
		}
		
function advuserdefine()
    {
    document.getElementById('txtpubtypename').value=document.getElementById('txtpubtypename').value.toUpperCase();
        if(hiddentext=="new" || hiddentext=="modify" )
        {
        
        //document.getElementById('txtpubtypecode').disabled=false;
        if(hiddentext=="new" )
        {
        document.getElementById('txtpubtypecode').disabled=false;
        
        document.getElementById('txtAlias').value=document.getElementById('txtpubtypename').value;
         document.getElementById('txtAlias').focus();
        auto=document.getElementById('hiddenauto').value;
        }
         if(hiddentext2!=document.getElementById('txtpubtypename').value)
        {
            var res=PublicationType.autopreodicity(document.getElementById('txtpubtypename').value);
        	var ds=res.value;
		
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Publication Type Name has already assigned !! ");
		   
		document.getElementById('txtpubtypename').value="";
		if(hiddentext=="new" )
		document.getElementById('txtAlias').value="";
		    
		    document.getElementById('txtpubtypename').focus();
         
		    return false;
		    }
		    }
         return false;
        }
        

return false;
}

//function fillcall1(res)
//{
//  var ds=res.value;
//		
//		  if(ds.Tables[0].Rows.length!=0)
//		    {
//		    alert("This Publication Type has already assigned !! ");
//		   
//		document.getElementById('txtpubtypename').value="";
//		if(hiddentext=="new" )
//		document.getElementById('txtAlias').value="";
//		    
//		    document.getElementById('txtpubtypename').focus();
//         
//		    return false;
//		    }
//}
//	
		
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

function chkfield(event) {
   
    if (event.keyCode == "13" || event.keyCode == "9") {
       
        var key = event.keyCode;

        if (document.activeElement.id == "txtpubtypename") {
           

            document.getElementById('txtAlias').focus();
                    return false;
               
        }
    }
}