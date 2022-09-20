var z=0;

//this flag is for permission
var flag="";
var hiddentext;
var auto="";
var hiddentext1="";
var hiddentext2="";
var dspreodicitymaster;

var glaprecode;
var glaprename;
var glaprealias;

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
    btnCancelClick2('preodicitymaster');
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



function btnNewClick2()
{
document.getElementById('txtpreCode').value="";
document.getElementById('txtprename').value="";
document.getElementById('txtAlias').value="";

chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		
	hiddentext="new";

if(document.getElementById('hiddenauto').value==1)
		         {
document.getElementById('txtpreCode').disabled=true;
}
else
{
document.getElementById('txtpreCode').disabled=false;
}

document.getElementById('txtprename').disabled=false;

document.getElementById('txtAlias').disabled=false;

if(document.getElementById('hiddenauto').value==1)
		         {
document.getElementById('txtprename').focus();
}
else
{
document.getElementById('txtpreCode').focus();
}

//chkstatus(FlagStatus);
			/*document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;*/
flag=0;
setButtonImages();
return false;
}

function btnCancelClick2(formname)
{
chkstatus(FlagStatus);
givebuttonpermission(formname);
document.getElementById('txtpreCode').value="";
document.getElementById('txtprename').value="";
document.getElementById('txtAlias').value="";


document.getElementById('txtpreCode').disabled=true;
document.getElementById('txtprename').disabled=true;
document.getElementById('txtAlias').disabled=true;



if(document.getElementById('btnNew').disabled==false)
    document.getElementById('btnNew').focus();
//getPermission('AdvPositionTypMst');
setButtonImages();
return false;
}


function btnModifyClick2()
{

flag=1;
			hiddentext="modify";
			document.getElementById('txtpreCode').disabled=true;
			document.getElementById('txtprename').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			hiddentext2=document.getElementById('txtprename').value;
	
			
			chkstatus(FlagStatus);
			//document.getElementById('btnModify').disabled = true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;
setButtonImages();
			return false;


}

var flag="";


function btnSaveClick2()
{
 document.getElementById('txtprename').value=trim(document.getElementById('txtprename').value);
//if (document.getElementById('txtEditonCode').value!="1")

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
document.getElementById('txtpreCode').value=trim(document.getElementById('txtpreCode').value);
 if(document.getElementById('hiddenauto').value!=1 && document.getElementById('txtpreCode').value=="")
 {
//if (document.getElementById('txtpreCode').value=="")
        //{
        alert("Please Enter Periodicity Code");
        document.getElementById('txtpreCode').focus();
        return false;
        //}
//return false;
 }

if (document.getElementById('txtprename').value=="")
{
alert("Please Enter Periodicity Name");
document.getElementById('txtprename').focus();
return false;
}
else
{
var prename=document.getElementById('txtprename').value;
}

if (document.getElementById('txtAlias').value=="")
{
alert("Please Enter Periodicity Alias");
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

     preodicitymaster.modify(precode,prename,Alias,compcode,userid);

        dspreodicitymaster.Tables[0].Rows[z].Preodicity_Code=document.getElementById('txtpreCode').value;
	    dspreodicitymaster.Tables[0].Rows[z].Preodicity_Name=document.getElementById('txtprename').value;
	    dspreodicitymaster.Tables[0].Rows[z].preodicity_Alias=document.getElementById('txtAlias').value;
	 
     updateStatus();

document.getElementById('txtpreCode').disabled=true;
document.getElementById('txtprename').disabled=true;
document.getElementById('txtAlias').disabled=true;

/*document.getElementById('txtpreCode').value="";
document.getElementById('prename').value="";
document.getElementById('txtAlias').value="";*/

//alert("Update Successfully");
        if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dspreodicitymaster.Tables[0].Rows.length-1))
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              } 


if(browser!="Microsoft Internet Explorer")
{
    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
}
else
{
    alert(xmlObj.childNodes(0).childNodes(1).text);
}
flag=0;
setButtonImages();
return false;
}
else
{
preodicitymaster.save(precode,compcode,userid,callsave);
setButtonImages();
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

		if (document.getElementById('txtpreCode').value=="")
		{
		alert("Please Enter Position Type Code");
		document.getElementById('txtpreCode').focus();
		return false;
		}
		else
		{
		var precode=document.getElementById('txtpreCode').value;
		}

		if (document.getElementById('txtprename').value=="")
		{
		alert("Please Enter Position Type");
		document.getElementById('txtprename').focus();
		return false;
		}
		else
		{
		var prename=document.getElementById('txtprename').value;
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


		preodicitymaster.insert(precode,prename,Alias,compcode,userid);
		

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

document.getElementById('txtpreCode').disabled=true;
document.getElementById('txtprename').disabled=true;
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

document.getElementById('txtpreCode').value="";
document.getElementById('txtprename').value="";
document.getElementById('txtAlias').value="";

btnCancelClick2('preodicitymaster');

return false;
}
else
{
alert("This Code Already Exist");

return false;
}
btnCancelClick2('preodicitymaster');
return false;
}

function btnQueryClick2()
{


chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	hiddentext="query";
z=0;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=false;
//			document.getElementById('btnSave').disabled=true;

var precode=document.getElementById('txtpreCode').value;
var prename=document.getElementById('txtprename').value;
var Alias=document.getElementById('txtAlias').value;

document.getElementById('txtpreCode').value="";
document.getElementById('txtprename').value="";
document.getElementById('txtAlias').value="";

document.getElementById('hiddencompcode').disabled=false;
document.getElementById('hiddenuserid').disabled=false;
document.getElementById('txtpreCode').disabled=false;
document.getElementById('txtprename').disabled=false;
document.getElementById('txtAlias').disabled=false;

setButtonImages();

return false;
}

function btnExecuteClick2()
{

//var glaprecode;
//var glaprename;
//var glaprealias;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
glaprecode=precode;
var prename=document.getElementById('txtprename').value;
glaprename=prename;
var Alias=document.getElementById('txtAlias').value;
glaprealias=Alias;

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
preodicitymaster.Execute(precode,prename,Alias,compcode,userid,call_Execute);

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

function call_Execute(response)

{
//var ds=response.value;

dspreodicitymaster=response.value;

updateStatus();

if (dspreodicitymaster.Tables[0].Rows.length>0)
{
document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[0].Preodicity_Code;
document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[0].Preodicity_Name;
document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[0].preodicity_Alias;
document.getElementById('hiddencompcode').value=dspreodicitymaster.Tables[0].Rows[0].Comp_Code;
document.getElementById('hiddenuserid').value=dspreodicitymaster.Tables[0].Rows[0].UserId;


//document.getElementById('btnNew').disabled=true;
//document.getElementById('btnSave').disabled=true;
//document.getElementById('btnModify').disabled=false;
//document.getElementById('btnDelete').disabled=false;
//document.getElementById('btnQuery').disabled=false;
//document.getElementById('btnExecute').disabled=true;
//document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=false;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnExit').disabled=false;
document.getElementById('btnprevious').disabled=true;

document.getElementById('txtpreCode').disabled=true;
document.getElementById('txtprename').disabled=true;
document.getElementById('txtAlias').disabled=true;

if(dspreodicitymaster.Tables[0].Rows.length==1)
{

document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=true;
document.getElementById('btnlast').disabled=true;
//document.getElementById('btnExit').disabled=false;
document.getElementById('btnprevious').disabled=true;
}

setButtonImages();

z=0;
}
		else
		{
		document.getElementById('txtpreCode').disabled=true;
		document.getElementById('txtprename').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		
		alert("Search Not Match");
		btnCancelClick2('preodicitymaster');
		return false;
		}
}


function btnFirstClick2()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
var prename=document.getElementById('txtprename').value;
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
preodicitymaster.Selectfnpl(precode,compcode,userid,call_First);
return false;
}

function call_First(response)
{
z=0;
//var ds=response.value;
document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[0].Preodicity_Code;
document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[0].Preodicity_Name;
document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[0].preodicity_Alias;
document.getElementById('hiddencompcode').value=dspreodicitymaster.Tables[0].Rows[0].Comp_Code;
document.getElementById('hiddenuserid').value=dspreodicitymaster.Tables[0].Rows[0].UserId;
updateStatus();

		
document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=false;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnExit').disabled=false;
setButtonImages();
}


function btnNextClick2()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
var prename=document.getElementById('txtprename').value;
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
preodicitymaster.Selectfnpl(precode,compcode,userid,call_Next);
return false;
}

function call_Next(response)
{

//var ds=response.value;
var y=dspreodicitymaster.Tables[0].Rows.length;
z++;
//var k=y-1;

if(z !=-1 && z >= 0)
	{
	if(z <= y-1)
		{
		document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Code;
document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Name;
document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[z].preodicity_Alias;
document.getElementById('hiddencompcode').value=dspreodicitymaster.Tables[0].Rows[z].Comp_Code;
document.getElementById('hiddenuserid').value=dspreodicitymaster.Tables[0].Rows[z].UserId;

document.getElementById('txtpreCode').disabled=true;
document.getElementById('txtprename').disabled=true;
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










function btnPreviousClick2()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
var prename=document.getElementById('txtprename').value;
var Alias=document.getElementById('txtAlias').value;
//preodicitymaster.Selectfnpl(precode,prename,Alias,compcode,userid,call_Previous);
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
preodicitymaster.Selectfnpl(precode,compcode,userid,call_Previous);
return false;
}




function call_Previous(response)
{
	//var ds=response.value;
var y=dspreodicitymaster.Tables[0].Rows.length;
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



    document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Code;
    document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Name;
    document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[z].preodicity_Alias;
    document.getElementById('hiddencompcode').value=dspreodicitymaster.Tables[0].Rows[z].Comp_Code;
    document.getElementById('hiddenuserid').value=dspreodicitymaster.Tables[0].Rows[z].UserId;
    updateStatus();
    document.getElementById('txtpreCode').disabled=true;
    document.getElementById('txtprename').disabled=true;
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
			return false;
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

function btnLastClick2()
{

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
var prename=document.getElementById('txtprename').value;
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
preodicitymaster.Selectfnpl(precode,compcode,userid,call_Last);
return false;
}

function call_Last(response)
{
//var ds=response.value;
var y=dspreodicitymaster.Tables[0].Rows.length;
a=y-1;
z=a;

document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Code;
document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Name;
document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[z].preodicity_Alias;
document.getElementById('hiddencompcode').value=dspreodicitymaster.Tables[0].Rows[z].Comp_Code;
document.getElementById('hiddenuserid').value=dspreodicitymaster.Tables[0].Rows[z].UserId;


document.getElementById('txtpreCode').disabled=true;
document.getElementById('txtprename').disabled=true;
document.getElementById('txtAlias').disabled=true;


updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
setButtonImages();
return false;


}

function btnExitClick2()
{
if(confirm("Do You Want To Skip This Page"))
{
//window.location.href='Enterpage.aspx';
window.close();
return false;
}
return false;
}

function btnDeleteClick2()
{
boolReturn = confirm("Are you sure you wish to delete this?");
if(boolReturn==1)
{

//var glaprecode;
//var glaprename;
//var glaprealias;
updateStatus();
		
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var precode=document.getElementById('txtpreCode').value;
var prename=document.getElementById('txtprename').value;
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
preodicitymaster.delete1(precode,compcode,userid);
//alert ("Data Deleted");	
if(browser!="Microsoft Internet Explorer")
{
    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
}
else
{
    alert(xmlObj.childNodes(0).childNodes(2).text);
}
//preodicitymaster.Selectfnpl(precode,prename,Alias,compcode,userid,call_delete);

preodicitymaster.Execute(glaprecode,glaprename,glaprealias,compcode,userid,call_delete);

				
				}     
				else
				
				{
				 return false;
				}
return false;
}

function call_delete(res)
{
    dspreodicitymaster= res.value;
	len=dspreodicitymaster.Tables[0].Rows.length;
	
	if(dspreodicitymaster.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('txtpreCode').value="";
		document.getElementById('txtprename').value="";
		document.getElementById('txtAlias').value="";
            //setButtonImages();
		btnCancelClick2('preodicitymaster');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
		document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[0].Preodicity_Code;
document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[0].Preodicity_Name;
document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[0].preodicity_Alias;
	}
	
	else
	{
		document.getElementById('txtpreCode').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Code;
document.getElementById('txtprename').value=dspreodicitymaster.Tables[0].Rows[z].Preodicity_Name;
document.getElementById('txtAlias').value=dspreodicitymaster.Tables[0].Rows[z].preodicity_Alias;
	}
	//alert ("Data Deleted");	
				
	setButtonImages();
	return false;

}


// ******************************Code For Auto Generation********************

function preoautocode()
 {
 document.getElementById('txtprename').value=document.getElementById('txtprename').value.toUpperCase();
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
if(hiddentext=="new" || hiddentext=="modify" )
			{
	
            UPPERCASEAdV();
           
           }
            else
            {
            
            document.getElementById('txtprename').value=document.getElementById('txtprename').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASEAdV()
		{
		document.getElementById('txtprename').value=trim(document.getElementById('txtprename').value);
			lstr=document.getElementById('txtprename').value;
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
		
		    if(document.getElementById('txtprename').value!="")
                {
                 
        
		document.getElementById('txtprename').value=document.getElementById('txtprename').value.toUpperCase();
		if(hiddentext=="new")
	    document.getElementById('txtAlias').value=document.getElementById('txtprename').value;
		// str=document.getElementById('txtprename').value;
		str=mstr;
		if(hiddentext2!=document.getElementById('txtprename').value)
		preodicitymaster.autopreodicity(str,fillcall);
		
		return false;
		
                }
		       
     hiddentext2="";          
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Periodicity name has already assigned !! ");
		    document.getElementById('txtprename').value="";
		    document.getElementById('txtAlias').value="";
		    document.getElementById('txtprename').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Preodicity_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtpreCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtpreCode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		}
		
function advuserdefine()
    {
       document.getElementById('txtprename').value=document.getElementById('txtprename').value.toUpperCase();
        if(hiddentext=="new" || hiddentext=="modify" )
        {
        
        //document.getElementById('txtpreCode').disabled=false;
        //document.getElementById('txtprename').value=document.getElementById('txtprename').value.toUpperCase();
        if(hiddentext=="new" )
        {
        document.getElementById('txtpreCode').disabled=false;
        document.getElementById('txtAlias').value=document.getElementById('txtprename').value;
        auto=document.getElementById('hiddenauto').value;
        }
        if(hiddentext2!=document.getElementById('txtprename').value)
        preodicitymaster.autopreodicity(document.getElementById('txtprename').value,fillcall1);
        
         return false;
        }

return false;
}

function fillcall1(res)
{
var ds=res.value;
		
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Periodicity name has already assigned !! ");
		   
		document.getElementById('txtprename').value="";
		if(hiddentext=="new" )
		document.getElementById('txtAlias').value="";
		    
		    document.getElementById('txtprename').focus();
         
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


/*----------------------*/
function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && charCode > 32 && (charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90))
        return false;

    return true;
}