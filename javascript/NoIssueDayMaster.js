//this for save and update
var mod="0";
var z="0";
var znk="0";
var auto="";
var hiddentext;
var modify="0";
var ds;
//this flag is for permission
var flag="";
var z=0;
var globaldaycode;
var globaldayname;
var txtnoissuedaycode;
var txtnoissuedayname;
var chknamemod;

function newclick()
{
			document.getElementById('txtnoissuedaycode').value="";
			document.getElementById('txtnoissuedayname').value="";
            if(document.getElementById('hiddenauto').value==1)
                {
                   document.getElementById('txtnoissuedaycode').disabled=true;
                   
                }
           else
              {
                document.getElementById('txtnoissuedaycode').disabled=false;
               }
              document.getElementById('txtnoissuedayname').disabled=false;
                            
             if(document.getElementById('hiddenauto').value==1)
               {
                        document.getElementById('txtnoissuedayname').focus();
               }
             else
              {
                       document.getElementById('txtnoissuedaycode').focus();
               }
	hiddentext="new";
	chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	setButtonImages();
return false;
}

//***********************************************************************************************************//
//****************************************Modify Button****************************************************//
//*********************************************************************************************************//
function modifyclick()
{
	document.getElementById('txtnoissuedaycode').disabled=true;
	document.getElementById('txtnoissuedayname').disabled=false;

	modify="1";
	chkstatus(FlagStatus);
	//updateStatus();
	document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled=true;
                    
   hiddentext="modify";	
   chknamemod=document.getElementById('txtnoissuedayname').value;
	
	flag=1;
	setButtonImages();
	return false;
}
//*************************************************************************************************************//
//**********************************************QueryButton****************************************************//
//**************************************************************************************************************//
function queryclick()
{
	document.getElementById('txtnoissuedaycode').value="";
	document.getElementById('txtnoissuedayname').value="";
	z=0;
	document.getElementById('txtnoissuedaycode').disabled=false;
	document.getElementById('txtnoissuedayname').disabled=false;

	modify="0";
	chkstatus(FlagStatus);

	document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=false;
    document.getElementById('btnSave').disabled=true;
    setButtonImages();
    document.getElementById('btnExecute').focus();
	
	hiddentext="query";
	return false;
}
//**************************************************************************************************************//
//****************************************ExecuteButton*********************************************************//
//**************************************************************************************************************//

function executeclick()
{
	z=0;
	var noisscode=document.getElementById('txtnoissuedaycode').value;
	globaldaycode=noisscode;
	var noissname=document.getElementById('txtnoissuedayname').value;
	globaldayname=noissname;
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

        NoIssueDayMaster.executenoiss(compcode, noisscode, noissname, userid,call_execute);
	    
	    updateStatus();
		document.getElementById('txtnoissuedaycode').disabled=true;
		document.getElementById('txtnoissuedayname').disabled=true;
		modify="0";
        
        document.getElementById('btnfirst').disabled=true;				
        document.getElementById('btnnext').disabled=false;					
        document.getElementById('btnprevious').disabled=true;			
        document.getElementById('btnlast').disabled=false;	
        if(document.getElementById('btnModify').disabled==false)					
           document.getElementById('btnModify').focus();
		
		hiddentext="modify";
			return false;
}

function call_execute(response)
{
    ds=response.value;
	if(ds.Tables[0].Rows.length > 0)
	{
	    var txtnoissuedaycode=document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[0].No_Iss_Day_Code
	    var txtnoissuedayname=document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[0].No_Iss_Day;

        document.getElementById('txtnoissuedaycode').disabled=true;
	    document.getElementById('txtnoissuedayname').disabled=true;
	}
	else
	{
	  alert("Your Search Doesn't Produce Any Result!!!");
      cancelclick('NoIssueDayMaster');
    }
	if(ds.Tables[0].Rows.length==1)
	{
	   document.getElementById('btnfirst').disabled=true;				
	   document.getElementById('btnnext').disabled=true;					
	   document.getElementById('btnprevious').disabled=true;			
	   document.getElementById('btnlast').disabled=true;
    }
    setButtonImages();
  	return false;
}

function cancelclick(formname)
{
    chkstatus(FlagStatus);
    givebuttonpermission(formname);
setButtonImages();
    if(document.getElementById('btnNew').disable==false)
     document.getElementById('btnNew').focus();
 
	document.getElementById('txtnoissuedaycode').value="";
	document.getElementById('txtnoissuedayname').value="";

	document.getElementById('txtnoissuedaycode').disabled=true;
	document.getElementById('txtnoissuedayname').disabled=true;

	modify="0";
	return false;
}

function exitclick()
{
	if(confirm("Do You Want To Skip This Page"))
	{
			window.close();
			return false;
	}
	return  false;
}

//************************************************************************************************************//
//************************************Save Button************************************************************//
//***********************************************************************************************************//		

function saveclick()
{
    
    document.getElementById('txtnoissuedaycode').value=trim(document.getElementById('txtnoissuedaycode').value);
    document.getElementById('txtnoissuedayname').value=trim(document.getElementById('txtnoissuedayname').value);
  if(document.getElementById('hiddenauto').value!=1 && document.getElementById('txtnoissuedaycode').value=="")
    
        {
            alert("Please Enter The No Issue Day Code");
            document.getElementById('txtnoissuedaycode').focus();
            return false;
        }

else if(document.getElementById('txtnoissuedayname').value=="")
{
    alert("Please Enter The No Issue Day Name");
    document.getElementById('txtnoissuedayname').focus();
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
    var txtnoissuedaycode=document.getElementById('txtnoissuedaycode').value;
    var txtnoissuedayname=document.getElementById('txtnoissuedayname').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    
    

if(modify!="1" && modify!=null)
{
      
NoIssueDayMaster.checknoisscode(txtnoissuedaycode,txtnoissuedayname,compcode,userid,call_save);
        return false;
}

str=document.getElementById('txtnoissuedayname').value;
NoIssueDayMaster.dauto(str,call_modify)
return false;
}
function call_modify(response)
{
    var ds2=response.value;
    if(chknamemod!=document.getElementById('txtnoissuedayname').value)
    {
        if(ds2.Tables[0].Rows.length!=0)
        {
            alert("This No Issue Day Name has already assigned !! ");
            document.getElementById('txtnoissuedayname').focus();
            return false;
        }
    }
     var txtnoissuedaycode=document.getElementById('txtnoissuedaycode').value;
    var txtnoissuedayname=document.getElementById('txtnoissuedayname').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    

    NoIssueDayMaster.update(txtnoissuedaycode,txtnoissuedayname,compcode,userid);
    
    
    ds.Tables[0].Rows[z].txtnoissuedaycode=document.getElementById('txtnoissuedaycode').value;
    ds.Tables[0].Rows[z].txtnoissuedayname=document.getElementById('txtnoissuedayname').value;

    alert("Data Updated Successfully");

    document.getElementById('txtnoissuedaycode').disabled=true;
    document.getElementById('txtnoissuedayname').disabled=true;
    updateStatus();
    modify="0";
    flag=0;
    //var x=ds.Tables[0].Rows.length;
    //y=z;	
    if (z==0)
    {
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnprevious').disabled=true;
    }

    if(z==(ds.Tables[0].Rows.length-1))
    {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    setButtonImages();
    document.getElementById('btnModify').focus();
    
    return false;
}

  

function call_save(response)
{
     ds=response.value;
    if(ds.Tables[0].Rows.length > 0)
    {
       alert("This No Issue Day Code has Been Already Assigned");
       if(document.getElementById('txtnoissuedaycode').disabled==false)
       document.getElementById('txtnoissuedaycode').focus();
       return false;
    }
    else  if(ds.Tables[1].Rows.length > 0)
    {
       alert("This No Issue Day Name has Been Already Assigned");
       document.getElementById('txtnoissuedayname').value="";
       document.getElementById('txtnoissuedayname').focus();
       return false;
    }
    else
    {
        var txtnoissuedaycode=document.getElementById('txtnoissuedaycode').value;
        var txtnoissuedayname=document.getElementById('txtnoissuedayname').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;

       NoIssueDayMaster.insert(txtnoissuedaycode,txtnoissuedayname,compcode,userid);

       alert("Data Saved Successfully");

        document.getElementById('txtnoissuedaycode').value="";
        document.getElementById('txtnoissuedayname').value="";


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
    cancelclick('NoIssueDayMaster');
    return false;
}



//********************************************First Button****************************************************//
//************************************************************************************************************//
//*************************************************************************************************************//

function firstclick()
{
		//var ds=response.value;
		z=0;
		document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[0].No_Iss_Day_Code
		document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[0].No_Iss_Day;

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


//*************************************************************************************************************//
//******************************************LastButton*********************************************************//
//*************************************************************************************************************//
function lastclick()
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

       NoIssueDayMaster.first(call_last);
		
	   document.getElementById('txtnoissuedaycode').disabled=true;
	   document.getElementById('txtnoissuedayname').disabled=true;
		

		return false;
}

function lastclick()
{
		//ds=response.value;
		var y=ds.Tables[0].Rows.length;
		var a=y-1;
		z=a;

		document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[z].No_Iss_Day_Code
		document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[z].No_Iss_Day;
        updateStatus();
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
        document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        setButtonImages();
		return false;
}

//************************************************************************************************************//
//**********************************************Previous Button***********************************************//
//***********************************************************************************************************//


function previousclick()
{
		z--;
//		var ds=response.value;
		var a=ds.Tables[0].Rows.length;
		if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
				document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[z].No_Iss_Day_Code;
				document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[z].No_Iss_Day;

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
//***********************************************************************************************************//
//*****************************************NextButton*******************************************************//
//*********************************************************************************************************//
function nextclick()
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
NoIssueDayMaster.first(call_next);
              
//			var compcode=document.getElementById('hiddencompcode').value;
//			var userid=document.getElementById('hiddenuserid').value;
			document.getElementById('txtnoissuedaycode').disabled=true;
			document.getElementById('txtnoissuedayname').disabled=true;
			    document.getElementById('btnfirst').disabled=false;
				document.getElementById('btnprevious').disabled=false;
			return false;
}

function nextclick()
{
		
		 //ds=response.value;
		var a=ds.Tables[0].Rows.length;
		z++;
		if(z !=-1 && z >= 0)
		{
			if(z <= a-1)
			{
				var txtnoissuedaycode=document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[z].No_Iss_Day_Code
				var txtnoissuedayname=document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[z].No_Iss_Day;
				updateStatus();
			
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
//************************************************************************************************************//
//*********************************************DeleteButton**************************************************//
//**********************************************************************************************************//
function deleteclick()
{
         updateStatus();
		var noissuecode=document.getElementById('txtnoissuedaycode').value;
		var noissuename=document.getElementById('txtnoissuedayname').value;
		var compcode=document.getElementById('hiddencompcode').value;
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
			alert("Data Deleted Successfully");
			 document.getElementById('txtnoissuedaycode').value="";
               document.getElementById('txtnoissuedayname').value="";

         NoIssueDayMaster.deletenoiss(noissuecode, noissuename, compcode, userid);
			NoIssueDayMaster.executenoiss(compcode, globaldaycode, globaldayname, userid,delcall);
			//nextclick();
		}     
		else
		{
			return false;
		}
		return false;
}
	//var ds;
function delcall(res)
{
 ds= res.value;
var len=ds.Tables[0].Rows.length;
	if(ds.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtnoissuedaycode').value="";
	    document.getElementById('txtnoissuedayname').value="";
	    cancelclick('NoIssueDayMaster');
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[0].No_Iss_Day_Code;
		document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[0].No_Iss_Day;	
	}
	else
	{
		document.getElementById('txtnoissuedaycode').value=ds.Tables[0].Rows[z].No_Iss_Day_Code;
		document.getElementById('txtnoissuedayname').value=ds.Tables[0].Rows[z].No_Iss_Day;	
	}
	setButtonImages();
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


function autoornot()
{
  // if(hiddentext=="new" )
  //{
 if((document.getElementById('hiddenauto').value=="1"))
   
              {
                    changeoccured();
                    //return false;
              }
                else
                {
                    userdefine();
                   // return false;
                 }
//}
//return false;
}
function changeoccured()
{
if(hiddentext=="new")
{
//if(document.getElementById('hiddenauto').value==1)
    //{
 document.getElementById('txtnoissuedayname').value=trim(document.getElementById('txtnoissuedayname').value);
		lstr=document.getElementById('txtnoissuedayname').value;
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
		
		    if(document.getElementById('txtnoissuedayname').value!="")
                {

		document.getElementById('txtnoissuedayname').value=document.getElementById('txtnoissuedayname').value.toUpperCase();
	    str=mstr;
		NoIssueDayMaster.dauto(str,fillcall)
		//return false;
               }
              return false;
       //}
}
}
function fillcall(res)
{
        ds=res.value;
		var newstr;
		if(ds.Tables[0].Rows.length !=0)
		{
		   // alert("This Day Name has already assigned !! ");
		    document.getElementById('txtnoissuedayname').focus();		
		    return false;
		 }
		 else
		 {
		        if(hiddentext=="new" )
		        {
		            if(ds.Tables[1].Rows.length==0)
		            {
		                newstr=null;
		            }
		            else
		            {
		               newstr=ds.Tables[1].Rows[0].No_Iss_Day_Code;
		             }
		            if(newstr==0)
		              {
		              str=str.toUpperCase();
		                            document.getElementById('txtnoissuedaycode').value=str.substr(0,2)+ "1";
		                            //newstr=document.getElementById('txtadcatcode').value;
		               }
		             else if(newstr>=1)
		             {
		                    str=str.toUpperCase();
		                   var Autoincrement=parseInt(ds.Tables[1].Rows[0].No_Iss_Day_Code)+1;
		                   document.getElementById('txtnoissuedaycode').value=str.substr(0,2)+ Autoincrement;
		             }
		             else if(newstr !=null )
		             {
		                  document.getElementById('txtnoissuedayname').value=trim(document.getElementById('txtnoissuedayname').value);
		                   var code=newstr.substr(2,4);
		                   var code=newstr;
		                   code++;
		                   document.getElementById('txtnoissuedaycode').value=str.substr(0,2)+ code;
		               // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		               }
		               else
		               {
		                    str=str.toUpperCase();
		                    document.getElementById('txtnoissuedaycode').value=str.substr(0,2)+ "0";
		                            //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		                  document.getElementById('btnSave').focus();
		               }
		         }
		     }
	return false;
		}
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtnoissuedaycode').disabled=false;
        document.getElementById('txtnoissuedayname').value=document.getElementById('txtnoissuedayname').value.toUpperCase();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

//return false;
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