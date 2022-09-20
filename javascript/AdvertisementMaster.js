//Get Permission is used to retrieve the current permission level of the form
var check="";
var FlagStatus;
var show="0";
var modify="";
var hiddentext;
var cityvar;
var saurabh="1";
var chknamemod;
var advds;
var flag2="0";
var gcode;
var gname;
var gadcat;
var gzone;
var popmodify="0";
var browser=navigator.appName;
var modify1="0";
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





//ToolBar 

//New Button Click

// global variable for update
var update;
//-------------

var codeexe="";

function AdvExecNew(formname)
{
var saurabh="1";
	 var msg=checkSession();
        if(msg==false)
        return false;
	 if(document.getElementById('hiddenauto').value==1)
     {
        document.getElementById('txtteamcode').disabled=true;
     }
	 else
	 {
	    document.getElementById('txtteamcode').disabled=false;
	 }

    document.getElementById("txteamname").disabled= false;
    document.getElementById("drpzone").disabled= false;
    
	document.getElementById("txtteamcode").value = "";
	document.getElementById("txteamname").value = "";
    document.getElementById("drpzone").value = "0";
    document.getElementById('hiddenchk').value="0";
    document.getElementById("LinkButton1").disabled= false;
    document.getElementById("txtsign").value = "";
    document.getElementById("hidattachment").value = "";
    
    document.getElementById("attachment1").disabled = false;
		
	show="1";
	modify="";
	hiddentext="new";
	
	document.getElementById('drpzone').focus();
	chkstatus(FlagStatus);
	document.getElementById('lbexecutive').disabled = false;	
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;
	document.getElementById('btnQuery').disabled = true;
	
	setButtonImages();
	return false;
}


function clearfields()
{

    document.getElementById("txteamname").disabled= false;
    document.getElementById("drpzone").disabled= false;
	document.getElementById("txtteamcode").value = "";
	document.getElementById("txteamname").value = "";
    document.getElementById("drpzone").value = "0";
   // document.getElementById("hidattachment").value = "";
  
    document.getElementById("LinkButton1").disabled= true;
    document.getElementById("txtsign").value = "";
    
    document.getElementById('btnNew').disabled=false;
    //document.getElementById('btnNew').focus();
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
    setButtonImages();
    return false;
    
 }
//Save Button Click
function AdvExecSave()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	var txtteamcode1 = trim(document.getElementById('txtteamcode').value);
	var txteamname1 = trim(document.getElementById('txteamname').value);
    var drpzone1= document.getElementById('drpzone').value;
    var signature= document.getElementById('txtsign').value;
    document.getElementById("TextBox1").value=document.getElementById("drpzone").value;
    document.getElementById("TextBox3").value=document.getElementById("txtteamcode").value;

   	
	var compcode = document.getElementById("hiddencompcode").value ;
	var userid=  document.getElementById("hiddenuserid").value ;
	gcode=txtteamcode1;
	gname=txteamname1;
	gzone=drpzone1;
	if(drpzone1=="0"||drpzone1==null)
	{
		alert("Please Select Branch");
		document.getElementById("drpzone").focus();
		return false;
	}
	if(document.getElementById('hiddenauto').value!=1)
	{
	 if((txtteamcode1==""||txtteamcode1==null)) //&&(document.getElementById('hiddenauto').value!=1))
	{
		alert("Please Enter Team Code");
		if(document.getElementById("txtteamcode").disabled!=true)
		document.getElementById("txtteamcode").focus();
		return false;
	}
	}
	 if(txteamname1==""||txteamname1==null)
	{
		alert("Please Enter Team Name");
		document.getElementById("txteamname").focus();
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

	if(modify=="modify")
	{
		if(	chknamemod==document.getElementById('txteamname').value)
           {
            updatestate();
           }
           else
           {
             AdvExecMaster.chkadv(compcode,txtteamcode1,userid,txteamname1,drpzone1,call_modifyclick);
             return false; 
          }

    }
   else
   {     
        var page=document.getElementById('txtteamcode').value ;
        var tname=document.getElementById("txteamname").value ;
        var bname=document.getElementById("drpzone").value;
        var signature = document.getElementById('txtsign').value;
         
        var chk="save";
        var id="";
	    if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
        }
                        
        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

        httpRequest.open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false);
        httpRequest.send('');
       
       if (httpRequest.readyState == "00") 
         {
                 alert('Session Expired Please Login Again.');
                return false;
         }
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) 
        {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) 
            {
                id=httpRequest.responseText;   
            }
            else 
            {
                 alert('Session Expired Please Login Again.');
                 return false;
            }
        }
        else
        {
                alert('Session Expired Please Login Again.');
                return false;
        }
    }
        else
        {
           		        
	        var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false );
            xml.Send();
            id=xml.responseText;
        }
            if(id=="00")
            {
                   alert('Session Expired.Please Login Again.');
                    return false;
            }
            if(id=="Y")
            {
                alert("Team Code has already been assigned");
                document.getElementById("txtteamcode").value="";
                return false;
            }
            else if(id=="Y1")
            {
                alert("Team Name has already been assigned");
                document.getElementById("txteamname").value="";
                return false;
            }
		    else
		    {	
		    var page="pop";
	        var chk="save";
	        
            var id="";		        
	        if(browser!="Microsoft Internet Explorer")
                {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false);
                        httpRequest.send('');
                       if (httpRequest.readyState == "00") 
                         {
                                 alert('Session Expired Please Login Again.');
                                return false;
                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('Session Expired Please Login Again.');
                                return false;
                            }
                        }
                        else
                        {
                              alert('Session Expired Please Login Again.');
                                return false;
                        }
                    }
                    else
                    {
            	        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		                xml.Open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false );
		                xml.Send();
		                id=xml.responseText;
		            }
		              if(id=="00")
	                {
	                       alert('Session Expired.Please Login Again.');
                            return false;
	                }
		        if(id=="Y")
		        {
		        alert("Please Enter Executive Contact Details");
		        return false;
		        }	
		        else
		        {	
		        //alert(xmlObj.childNodes(0).childNodes(0).text);
		        if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
	
			    //return false;
			    }
			    }
		   }
		   
		  // AdvExecCancel('AdvExecMaster');
		//alert('hi1');
		//return false;
}		


//=========================chk duplicacy in modify mode===============================//
function call_modifyclick(response)
{
			var compcode = document.getElementById("hiddencompcode").value ;
	        var userid=  document.getElementById("hiddenuserid").value ;
			var txteamname1=document.getElementById('txteamname').value;
			var txtteamcode1=document.getElementById('txtteamcode').value;
			var drpzone1=document.getElementById('drpzone').value;
			 
			var ds=response.value;
		  if(chknamemod!=document.getElementById('txteamname').value)
			{
                if(ds.Tables[2].Rows.length >= 1)
                {
                alert("This Team Name Already Exists.");
                document.getElementById('txteamname').value="";
                return false;
                }
                 updatestate();
			}
	}	
	
function updatestate()
{
			
			var compcode = document.getElementById("hiddencompcode").value ;
	        var userid=  document.getElementById("hiddenuserid").value ;
			var txteamname1=document.getElementById('txteamname').value;
			var txtteamcode1=document.getElementById('txtteamcode').value;
			var drpzone1=document.getElementById('drpzone').value;
			var signature = document.getElementById('txtsign').value;
			var attachment = document.getElementById('hidattachment').value;
			
			AdvExecMaster.AdvExec(compcode,txtteamcode1,txteamname1,drpzone1,2,userid,signature,attachment);	
			
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }

        advds.Tables[0].Rows[z].Team_Code=gcode ;
        advds.Tables[0].Rows[z].Team_Name=gname;	
        advds.Tables[0].Rows[z].branch_code=gzone;	
        updateStatus();
	
		document.getElementById("txtteamcode").disabled = true;
		document.getElementById("txteamname").disabled= true;
	    document.getElementById("drpzone").disabled= true;
	    
        if(document.getElementById('btnModify').disabled==false)
          document.getElementById('btnModify').focus();
        if(z==0)
        {
         document.getElementById('btnfirst').disabled=true;
         document.getElementById('btnprevious').disabled=true;
        }
			
		if(z==advds.Tables[0].Rows.length-1)
		{
		 document.getElementById('btnnext').disabled=true
		 document.getElementById('btnlast').disabled=true;
		}
		
		if(modify1=="1")
        {
          show="0";
        }	
        setButtonImages();
		document.getElementById('btnModify').focus();
		 saurabh="2";
		//modify="0";
		return false;
}

//====================================================================================//
function advsave(res)
{
 var msg=checkSession();
        if(msg==false)
        return false;
    var ds=res.value;

    var txtteamcode = trim(document.getElementById("txtteamcode").value) ;
	var txteamname = trim(document.getElementById("txteamname").value) ;
	
	
//   var drpadcat= document.getElementById("drpadcat").value ;
   var drpzone= document.getElementById("drpzone").value ;
	
	var compcode = document.getElementById("hiddencompcode").value ;
	var userid=  document.getElementById("hiddenuserid").value ;
	


if(ds.Tables[1].Rows.length > 0)
{

if(ds.Tables[0].Rows.length==0)
	{
	var txtteamcode = document.getElementById("txtteamcode").value ;
	var txteamname = document.getElementById("txteamname").value ;
	
 //  var drpadcat= document.getElementById("drpadcat").value ;
   var drpzone= document.getElementById("drpzone").value ;
	var compcode = document.getElementById("hiddencompcode").value ;
	var userid=  document.getElementById("hiddenuserid").value ;
	var signature = document.getElementById('txtsign').value;
	var attachment = document.getElementById('hidattachment').value;

	//AdvExecMaster.AdvExec(compcode,txtteamcode,txteamname,drpadcat,drpzone,1,userid);
	AdvExecMaster.AdvExec(compcode,txtteamcode,txteamname,drpzone,1,userid,signature,attachment);
	AdvExecCancel('AdvExecMaster');
	alert("Record  Saved Successfully");
	return false;
	}
	else
	{
	alert("This Code is already Exists.");
	AdvExecCancel('AdvExecMaster');
	return false;
	}
	}
	else
	{
	alert("Please Enter The Value in PopUp");
	return false;
	}
return false;
}


//Cancel Button Click
function AdvExecCancel(formname)
{
    show="0";
	chkstatus(FlagStatus);
				
	document.getElementById("txtteamcode").value = "";
	document.getElementById("txteamname").value = "";
	document.getElementById("drpzone").value = "0";

//	document.getElementById("txtpaymode").value = "0";
	
	document.getElementById("txtteamcode").disabled = true;
	document.getElementById("txteamname").disabled= true;
	document.getElementById("drpzone").disabled= true;
	document.getElementById('lbexecutive').disabled = true;
	document.getElementById('attachment1').disabled = true;
//	document.getElementById('txtpaymode').disabled = true;
	
document.getElementById('attachment1').src = "Images/index.jpeg";	
  
	 document.getElementById("LinkButton1").disabled= true;
	 document.getElementById("txtsign").value = "";
    
	//getPermission1(formname);
	givebuttonpermission(formname);
				hiddentext="clear";
				var tname=document.getElementById("txteamname").value ;
				var bname=document.getElementById("drpzone").value;
				var page="query";
		        var chk="query";
		        var id="";
		         if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false);
                        httpRequest.send('');
                        if (httpRequest.readyState == "00") 
                         {
                                 alert('Session Expired Please Login Again.');
                                return false;
                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('Session Expired Please Login Again.');
                                return false;
                            }
                        }
                        else
                        {
                          alert('Session Expired Please Login Again.');
                                return false;
                        }
                    }
		        else
		        {
            	    var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false );
		            xml.Send();
		            id=xml.responseText;
		        }
		       
		       if(id=="00")
	            {
	                   alert('Session Expired.Please Login Again.');
                        return false;
	            }
setButtonImages();
	//document.getElementById('btnSave').disabled = true;
	if(document.getElementById('btnNew').disabled==false)
       document.getElementById('btnNew').focus();
 	return false;
}

//Modify Button Click
function AdvExecModify(formname)
{ hiddentext= "modify";
	show="2";
	saurabh="0";
	document.getElementById("txtteamcode").disabled= true;
	document.getElementById("txteamname").disabled= false;
	//document.getElementById("drpadcat").disabled= false;
    document.getElementById("drpzone").disabled= false;
    document.getElementById('lbexecutive').disabled = false;
    document.getElementById('attachment1').disabled = false;
    document.getElementById('drpzone').disabled = true;

    		
	document.getElementById('hiddenchk').value="1";
    modify1="1";
	modify = "modify";
	popmodify="1";
	//show="2";
	chknamemod=document.getElementById('txteamname').value;
	chkstatus(FlagStatus);
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
   document.getElementById("LinkButton1").disabled= false;
   
	setButtonImages();
	document.getElementById('btnSave').focus();
    return false;
}

//Query Button Click
function AdvExecQuery(formname)
{saurabh="2";
    show="0";
	document.getElementById("txtteamcode").disabled= false;
	document.getElementById("txteamname").disabled= false;
	document.getElementById("drpzone").disabled= false;
	document.getElementById("txtsign").value = "";
		
	document.getElementById("txtteamcode").value = "";
	document.getElementById("txteamname").value = "";
	document.getElementById("drpzone").value = "0";
	document.getElementById("LinkButton1").disabled= true;
	document.Form1.txtteamcode.focus();
	chkstatus(FlagStatus);
	hiddentext="query";
	var page="query";
	var chk="query";
     var tname=document.getElementById("txteamname").value ;
     var bname=document.getElementById("drpzone").value;
    if(browser!="Microsoft Internet Explorer")
        {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
         }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false);
                        httpRequest.send('');
                        if (httpRequest.readyState == "00") 
                         {
                               alert('Session Expired Please Login Again.');
                               return false;
                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                            }
                            else 
                            {
                               alert('Session Expired Please Login Again.');
                               return false;
                            }
                        }
                        else
                        {
                           alert('Session Expired Please Login Again.');
                               return false;
                        }
                    }
		        else
		        {
            	var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        xml.Open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false );
		        xml.Send();
		        }
	            document.getElementById('btnQuery').disabled=true;
                document.getElementById('btnExecute').disabled=false;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('btnExecute').focus();
	            document.getElementById('lbexecutive').disabled = true;	
	
	      
	z=0;
	setButtonImages();
	return false;
}


//Execute Button Click
function AdvExecExecute()
{
 var msg=checkSession();
        if(msg==false)
        return false;
    show="0";
	var txtteamcode = document.getElementById("txtteamcode").value.toUpperCase(); ;
	var txteamname = document.getElementById("txteamname").value.toUpperCase() ;
	//var drpadcat= document.getElementById("drpadcat").value ;
    var drpzone= document.getElementById("drpzone").value.toUpperCase() ;
	
	
	var compcode = document.getElementById("hiddencompcode").value ;
	var userid = document.getElementById('hiddenuserid').value;
	var signature = document.getElementById('txtsign').value;
	var attachment = document.getElementById('hidattachment').value;


	
		 

	//AdvExecMaster.AdvExec(compcode,txtteamcode,txteamname,drpadcat,drpzone,0,userid,AdvExecExecute_CallBack);
	var res = AdvExecMaster.AdvExec(compcode, txtteamcode, txteamname, drpzone, 0, userid, signature, attachment)
	res = AdvExecExecute_CallBack(res)
	
	gcode=txtteamcode;
	gname=txteamname;
	//gadcat=drpadcat;
	gzone=drpzone;
	 document.getElementById("LinkButton1").disabled= false;
	
	//updateStatus();
   
//    document.getElementById('btnfirst').disabled=true;				
//    document.getElementById('btnnext').disabled=false;					
//    document.getElementById('btnprevious').disabled=true;
//    document.getElementById('btnlast').disabled = false;
//    document.getElementById('btnModify').disabled = false;
//    document.getElementById('btnDelete').disabled = false;
  //  setButtonImages();
    //alert("Bhanu");	
    if(document.getElementById('btnModify').disabled==false)					
     document.getElementById('btnModify').focus();	
    hiddentext="execute";
    
     setButtonImages();
    return false;
}
function AdvExecExecute_CallBack(response)
{
//alert("Bhanu1");
     advds=response.value;
	if(advds==null)
    {
        alert(response.error.description);
        return false;
    }   
	
if(advds!=null)
{
	if(advds.value==""||advds.value=="Undefined"||advds.Tables[0].Rows.length==0)
	{
//		document.getElementById("txtteamcode").value = "";
//		document.getElementById("txteamname").value = "";
//        document.getElementById("drpzone").value = "0";
//		document.getElementById('btnModify').disabled=true;
//		document.getElementById('btnDelete').disabled=true;		
		alert("Your Search Criteria Does not Exist");
		AdvExecCancel('AdvExecMaster');
		return false;
		
	}
	if(advds.Tables[0].Rows.length>0)
	{
		document.getElementById("txtteamcode").value=advds.Tables[0].Rows[0].Team_Code ;
		document.getElementById("txteamname").value=advds.Tables[0].Rows[0].Team_Name ;
		document.getElementById("drpzone").value=advds.Tables[0].Rows[0].branch_code ;
		document.getElementById("txtsign").value = advds.Tables[0].Rows[0].SIGN;


		if ((advds.Tables[0].Rows[0].ATTACHMENT != null) && (advds.Tables[0].Rows[0].ATTACHMENT != "")) {
		    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hidattachment").value = advds.Tables[0].Rows[0].ATTACHMENT;
		    document.getElementById('attachment1').src = "Images/indexred.jpg";
		}
		else {
		    document.getElementById('hidattachment').value = "";
		}
		
		
		
		document.getElementById("txtteamcode").disabled= true;
		document.getElementById("txteamname").disabled= true;
		document.getElementById('lbexecutive').disabled = false;	
	    document.getElementById("drpzone").disabled= true;


	    document.getElementById('btnfirst').disabled = true;
	    document.getElementById('btnnext').disabled = false;
	    document.getElementById('btnprevious').disabled = true;
	    document.getElementById('btnlast').disabled = false;
	    document.getElementById('btnModify').disabled = false;
	    document.getElementById('btnDelete').disabled = false;
		
		if(advds.Tables[0].Rows.length==1)
		{
		    document.getElementById('btnfirst').disabled=true;				
		    document.getElementById('btnnext').disabled=true;					
		    document.getElementById('btnprevious').disabled=true;			
		    document.getElementById('btnlast').disabled=true;
		}
	    
	    setButtonImages();
  	return false;
  }
}
	return false;
}

function AdvExecDelete()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	document.getElementById("txtteamcode").disabled= true;
	document.getElementById("txteamname").disabled= true;
	document.getElementById("drpzone").disabled= true;
	
	var txtteamcode = document.getElementById("txtteamcode").value ;
	var txteamname = document.getElementById("txteamname").value ;
	var drpzone = document.getElementById("drpzone").value ;
	var compcode = document.getElementById("hiddencompcode").value ;
	var userid = document.getElementById('hiddenuserid').value;
	var signature = document.getElementById('txtsign').value;
	var attachment = document.getElementById('attachment1').value;

	if (confirm("Are you sure you want to delete")) 
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
AdvExecMaster.AdvExec(compcode,txtteamcode,txteamname,drpzone,3,userid,"","");
		if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
		    alert(xmlObj.childNodes(0).childNodes(2).text);
		}

}
AdvExecCancel('AdvExecMaster');	
	document.getElementById("txtteamcode").disabled= true;
	document.getElementById("txteamname").disabled= true;
	document.getElementById("drpzone").disabled= true;
	AdvExecMaster.AdvExec(compcode,gcode,gname,gzone,0,userid,signature,attachment,AdvExecDelete_CallBack);
	
	return false;
}

function AdvExecDelete_CallBack(response)
{
	advds=response.value;
	var y = advds.Tables[0].Rows.length;
	if(advds.Tables[0].Rows.length<=0)
	{
		document.getElementById("txtteamcode").value = "";
		document.getElementById("txteamname").value = "";
		document.getElementById("drpzone").value = "0";
	    alert("No More Data is here to be deleted");
		AdvExecCancel('AdvExecMaster');
		return false;
	}
	else if(z==-1 ||z>=y)
	{    
	    document.getElementById("txtteamcode").value=advds.Tables[0].Rows[0].Team_Code ;
		document.getElementById("txteamname").value=advds.Tables[0].Rows[0].Team_Name ;
		document.getElementById("drpzone").value=advds.Tables[0].Rows[0].branch_code ;
				document.getElementById("txtsign").value=advds.Tables[0].Rows[0].SIGN ;
	}
	else
	{
	    document.getElementById("txtteamcode").value=advds.Tables[0].Rows[z].Team_Code ;
		document.getElementById("txteamname").value=advds.Tables[0].Rows[z].Team_Name ;
		document.getElementById("drpzone").value=advds.Tables[0].Rows[z].branch_code ;
				document.getElementById("txtsign").value=advds.Tables[0].Rows[z].SIGN ;
	}
	
		
	document.getElementById('btnNew').disabled=true;
	document.getElementById('btnSave').disabled=true;
	document.getElementById('btnModify').disabled=true;
	document.getElementById('btnDelete').disabled=false;
	document.getElementById('btnQuery').disabled=false;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnCancel').disabled=false;		
	document.getElementById('btnExit').disabled=false;
	setButtonImages();
	return false;
}

//Movement of Records
var z=0;


function AdvExecFirst(response)
{
	//var ds = response.value;
	 var msg=checkSession();
        if(msg==false)
        return false;
	document.getElementById("txtteamcode").value = advds.Tables[0].Rows[0].Team_Code;
	document.getElementById("txteamname").value = advds.Tables[0].Rows[0].Team_Name;
	document.getElementById("drpzone").value=advds.Tables[0].Rows[0].branch_code ;
	document.getElementById("txtsign").value = advds.Tables[0].Rows[0].SIGN;


	if ((advds.Tables[0].Rows[0].ATTACHMENT != null) && (advds.Tables[0].Rows[0].ATTACHMENT != "")) {
	    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


	    document.getElementById("hidattachment").value = advds.Tables[0].Rows[0].ATTACHMENT;
	    document.getElementById('attachment1').src = "Images/indexred.jpg";
	}
	else {
	    document.getElementById('hidattachment').value = "";
	   document.getElementById('attachment1').src = "Images/index.jpeg";
	}
		
	
	
		
	document.getElementById("txtteamcode").disabled= true;
	document.getElementById("txteamname").disabled= true;
    document.getElementById("drpzone").disabled= true;
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

function AdvExecNext()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var a=advds.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			document.getElementById("txtteamcode").value = advds.Tables[0].Rows[z].Team_Code;
			document.getElementById("txteamname").value = advds.Tables[0].Rows[z].Team_Name;
			document.getElementById("drpzone").value=advds.Tables[0].Rows[z].branch_code ;
			document.getElementById("txtsign").value = advds.Tables[0].Rows[z].SIGN;

			if ((advds.Tables[0].Rows[z].ATTACHMENT != null) && (advds.Tables[0].Rows[z].ATTACHMENT != "")) {
			    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


			    document.getElementById("hidattachment").value = advds.Tables[0].Rows[z].ATTACHMENT;
			    document.getElementById('attachment1').src = "Images/indexred.jpg";
			}
			else {
			    document.getElementById('hidattachment').value = "";
			    document.getElementById('attachment1').src = "Images/index.jpeg";
			}



			
		
		   		
		    updateStatus();
		    document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled = false;
			
			
			
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
	


function AdvExecPrevious()
{
 var msg=checkSession();
        if(msg==false)
        return false;
		var a=advds.Tables[0].Rows.length;
	     z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				document.getElementById("txtteamcode").value = advds.Tables[0].Rows[z].Team_Code;
			    document.getElementById("txteamname").value = advds.Tables[0].Rows[z].Team_Name;
		        document.getElementById("drpzone").value=advds.Tables[0].Rows[z].branch_code ;

		        document.getElementById("txtsign").value = advds.Tables[0].Rows[z].SIGN;


		        if ((advds.Tables[0].Rows[z].ATTACHMENT != null) && (advds.Tables[0].Rows[z].ATTACHMENT != "")) {
		            //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		            document.getElementById("hidattachment").value = advds.Tables[0].Rows[z].ATTACHMENT;
		            document.getElementById('attachment1').src = "Images/indexred.jpg";
		        }
		        else {
		            document.getElementById('hidattachment').value = "";
		            document.getElementById('attachment1').src = "Images/index.jpeg";
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
		return false;
}
	

function AdvExecLast()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	//var ds = response.value;
	var y=advds.Tables[0].Rows.length;
	
	z=y-1;
	y=y-1;
	

	document.getElementById("txtteamcode").value = advds.Tables[0].Rows[y].Team_Code;
	document.getElementById("txteamname").value = advds.Tables[0].Rows[y].Team_Name;
	document.getElementById("drpzone").value=advds.Tables[0].Rows[y].branch_code ;
	document.getElementById("txtsign").value = advds.Tables[0].Rows[y].SIGN;

	if ((advds.Tables[0].Rows[y].ATTACHMENT != null) && (advds.Tables[0].Rows[y].ATTACHMENT != "")) {
	    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


	    document.getElementById("hidattachment").value = advds.Tables[0].Rows[y].ATTACHMENT;
	    document.getElementById('attachment1').src = "Images/indexred.jpg";
	}
	else {
	    document.getElementById('hidattachment').value = "";
	    document.getElementById('attachment1').src = "Images/index.jpeg";
	}
			





	updateStatus();


	
	document.getElementById('btnnext').disabled=true;
    document.getElementById('btnlast').disabled=true;
    document.getElementById('btnfirst').disabled=false;
    document.getElementById('btnprevious').disabled=false;
    setButtonImages();
	return false;
	
}

 
  

function executivecontactdetails()
{
 var msg=checkSession();
        if(msg==false)
        return false;
if(document.getElementById('lbexecutive').disabled ==false)	
	{

 if((document.getElementById('hiddenauto').value==1)&& (document.getElementById("txteamname").value==""))
	{
        alert("Please Enter Team Name");
        document.getElementById('txteamname').focus();
        return false;
    }
   else if((document.getElementById("drpzone").value=="0"))
	{
    alert("Please Select Branch");
    document.getElementById('drpzone').focus();
    return false;
    }
    else if(document.getElementById("txtteamcode").value !="")
       {
       var branchname=document.getElementById("drpzone").value;
       var teamcode=document.getElementById("txtteamcode").value;
        for ( var index = 0; index < 200; index++ ) 
          { 

        popUpWin=window.open('Execondetail.aspx?show='+show+'&teamcode='+teamcode+'&branchname='+branchname,'Ankur','status=0,toolbar=0,resizable=1,top=0,left=0,scrollbars=yes,width='+(screen.availWidth-10)+',height='+(screen.availHeight-55)+'');
                                                 
        popUpWin.focus();
        return false;
           }
      }
    }
  


}

function exedetail()
{
 var msg=checkSession();
        if(msg==false)
        return false;
        
  var lbdesignation= document.getElementById("designation").innerHTML;
  var lbreportto= document.getElementById("reportto").innerHTML;
 

if(document.getElementById("txtexename").value=="")
{
alert("Please Enter Executive Name");
document.getElementById("txtexename").focus();
return false;
}
else if((document.getElementById("txtdesignation").value=="0") && (lbdesignation.indexOf("*") >=0) && (document.getElementById('designation').style.display!="none"))
{
alert("Please Select Designation");
document.getElementById("txtdesignation").focus();
return false;
}
else if(document.getElementById("txtcountry").value=="0")
{
alert("Please Select Country");
document.getElementById("txtcountry").focus();
return false;
}
else if(document.getElementById("drpcity").value=="0")
{
alert("Please Select City");
document.getElementById("drpcity").focus();
return false;
}

else if (document.getElementById("drpstatus").value == "0") {
    alert("Please Select Status");
    document.getElementById("drpstatus").focus();
    return false;
}
else if((document.getElementById("drprepot").value=="0")&& (lbreportto.indexOf("*") >=0) && (document.getElementById('reportto').style.display!="none"))
{
alert("Please Select Reporting To");
document.getElementById("drprepot").focus();
return false;
}

var alrt;
   if(browser!="Microsoft Internet Explorer")
     alrt = document.getElementById('lbemcode').textContent;
else
     alrt = document.getElementById('lbemcode').innerText;
 

if (alrt.indexOf('*') >= 0) {

    if (document.getElementById('txtemcode').value == "") {
        alert("Please Select The Employe");
        document.getElementById('txtemcode').focus();
        return false;
    }
}
var exename=trim(document.getElementById("txtexename").value);
var designation=document.getElementById("txtdesignation").value;
var address=trim(document.getElementById("txtaddress").value);
var street=trim(document.getElementById("txtstreet").value);
var city=document.getElementById("drpcity").value;

document.getElementById("txtcity").value=document.getElementById("drpcity").value;

//document.getElementById("txtcity").value=city
var repname=document.getElementById('txtrepname').value;
var district=document.getElementById("txtdistrict").value;
var state=document.getElementById("txtstate").value;
var country = document.getElementById("txtcountry").value;
if(document.getElementById("txtpin").value=="undefined")
{
    var pin = "";
}
else{
var pin=document.getElementById("txtpin").value;
}
var phone=document.getElementById("txtphone").value;
var status=document.getElementById("drpstatus").value;
//var s=document.Form1.drpstatus.options[status].text;
//var status=document.getElementById("drpstatus").text;
var compcode=document.getElementById("hiddencompcode").value;;
var userid=document.getElementById("hiddenuserid").value;
var teamcode=document.getElementById("hiddenteamcode").value;
var report=document.getElementById("drprepot").value;
var adtype=document.getElementById("drpadtype").value;

var brancgname1 = document.getElementById("drpbranch1").value;
if (document.getElementById("txtemail").value == "undefined") {
    var email = "";
}
else {
    var email = document.getElementById('txtemail').value;
}
if (document.getElementById('txtmobile').value == "") {
var mobile = "";
}
else {
    var mobile = document.getElementById('txtmobile').value;
}
var oldcode = document.getElementById('txtoldcode').value;

var craditlimit = document.getElementById('txtcraditlimit').value;
var attachment = document.getElementById('hidattachment').value;

var PAYMENTMODE = document.getElementById('txtpaymode').value;


var empcode = document.getElementById('hdempcode').value;

var mailto= document.getElementById('txtemailid').value;

if(document.getElementById('drptaluka').selectedIndex!='-1')
    document.getElementById('hidtaluka').value=document.getElementById('drptaluka').options[document.getElementById('drptaluka').selectedIndex].value;
else
    document.getElementById('hidtaluka').value="";
document.getElementById("txtreport").value=document.getElementById("drprepot").value;

if((popmodify!="1")&&(popmodify!=null)&&(codeexe==""))
    {
        if(opener.document.getElementById('hiddenchk').value=="1")
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
            Execondetail.chkexecname(compcode,exename,userid,teamcode,callchk);
       
       }
            
        else
        {
            var str='';
            for (var li = 1; li < document.getElementById('lbadcategory').options.length; li++)
            {
                if (document.getElementById('lbadcategory').options[li].selected == true)
                {
                    if(str == '')
                        str=document.getElementById('lbadcategory').options[li].value;
                    else
                        str=str + ',' + document.getElementById('lbadcategory').options[li].value;
                }
                
            }
            document.getElementById('hiddencat').value=str;
            return;
       }
            
        
    }
 else
     {
       //Execondetail.chkexecname(compcode,exename,userid,callchkupdate);
      //---------------- for adcategory ----------------------------//
      var flag=0;
        var length=document.getElementById('lbadcategory').options.length;
        Execondetail.deleteExecAdetail(compcode,codeexe);
                 for(var li=0;  li< length; li++)
                {
                    if(document.getElementById('lbadcategory').options[li].selected==true)
                    {
                      var badcategory=document.getElementById('lbadcategory').options[li].value;
                      Execondetail.insertExecAdetail(compcode, userid, teamcode,badcategory,flag,codeexe);
                     } 
                }
       
      //-------------------------------------------------------------//
      if(document.getElementById("hiddenexename").value == document.getElementById("txtexename").value)
      {
          Execondetail.updatedetail(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe, report, document.getElementById('hidtaluka').value, repname, adtype, brancgname1, craditlimit, email, mobile, empcode, mailto, attachment, PAYMENTMODE, oldcode);
          popmodify="0";
          window.location=window.location;
      }
      else
      {
      var teamcode=document.getElementById("hiddenteamcode").value;
           var res_chk= Execondetail.chkexecname(compcode,exename,userid,teamcode); //,callchkupdate);
           if(res_chk.value !=null && res_chk.value.Tables[0].Rows.length > 0)
           {
                  alert("Executive Name has Already been  assigned!");
                  document.getElementById("txtexename").focus();
                  return false;
           }
           else
           {
               Execondetail.updatedetail(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe, report, document.getElementById('hidtaluka').value, repname, adtype, brancgname1, craditlimit, email, mobile, empcode, mailto, attachment, PAYMENTMODE, oldcode);
              popmodify="0";
              window.location=window.location;
           }
      }

      //  Execondetail.updatedetail(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe,report,document.getElementById('hidtaluka').value,repname,adtype);
      // popmodify="0";
      //window.location=window.location;
      // }
      //alert(xmlObj.childNodes(0).childNodes(1).text);
        return false;
    }


return false;
}



function callchk(response)
{
var ds=response.value;
if(ds==null)
{
  alert(response.error.description);
  return false;
}
var flag=1;
var adtype=document.getElementById("drpadtype").value;
var repname=document.getElementById('txtrepname').value;
var exename=trim(document.getElementById("txtexename").value);
var designation=document.getElementById("txtdesignation").value;
var address=trim(document.getElementById("txtaddress").value);
var street=trim(document.getElementById("txtstreet").value);
var city=document.getElementById("drpcity").value;
var district=document.getElementById("txtdistrict").value;
var state=document.getElementById("txtstate").value;
var country=document.getElementById("txtcountry").value;
var pin=document.getElementById("txtpin").value;
var phone=document.getElementById("txtphone").value;
var status=document.getElementById("drpstatus").value;
var compcode=document.getElementById("hiddencompcode").value;;
var userid=document.getElementById("hiddenuserid").value;
var teamcode=document.getElementById("hiddenteamcode").value;
var report=document.getElementById("drprepot").value;
var taluka=document.getElementById("drptaluka").value;
var branchcode=document.getElementById('drpbranch1').value;
var craditlimit=document.getElementById('txtcraditlimit').value;
var email=document.getElementById("txtemail").value;
var mobile = document.getElementById("txtmobile").value;
var empcode = document.getElementById('hdempcode').value;
var mailto = document.getElementById('txtemailid').value;
var attachment = document.getElementById('hidattachment').value;



var PAYMENTMODE = document.getElementById('txtpaymode').value;


document.getElementById("txtreport").value=document.getElementById("drprepot").value;

var oldcode = document.getElementById('txtoldcode').value;

if(ds.Tables[0].Rows.length > 0)
{
  alert("Executive Name has Already been  assigned!");
  document.getElementById("txtexename").focus();
  return false;
}
else
{

    var res_insertdetail = Execondetail.insertintodetail(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, report, taluka, repname, adtype, branchcode, craditlimit, email, mobile, empcode, mailto, attachment, PAYMENTMODE,oldcode);
   if(res_insertdetail.value.Tables[0].Rows.length !=null)
        codeexe=res_insertdetail.value.Tables[0].Rows[0].exeno;
 //---------------- for adcategory ----------------------------//
var length=document.getElementById('lbadcategory').options.length;
Execondetail.deleteExecAdetail(compcode,codeexe);
         for(var li=0;  li< length; li++)
        {
            if(document.getElementById('lbadcategory').options[li].selected==true)
            {
             var badcategory=document.getElementById('lbadcategory').options[li].value;
              Execondetail.insertExecAdetail(compcode, userid, teamcode,badcategory,flag,codeexe);
              }
        }
       
//-------------------------------------------------------------//
 
document.getElementById("txtexename").value="";
document.getElementById("txtdesignation").value="0";
document.getElementById("txtcountry").value="0";
document.getElementById("txtstate").value="";
document.getElementById("txtdistrict").value="";
document.getElementById("drpstatus").value="0";
document.getElementById("txtaddress").value="";
document.getElementById("txtstreet").value="";
document.getElementById("drpcity").value="0";
document.getElementById("txtpin").value="";
document.getElementById("txtphone").value="";
document.getElementById("drprepot").value="0";
document.getElementById("drpadtype").value="0";
document.getElementById('drpbranch1').value="0";
document.getElementById("txtemail").value="";
document.getElementById("txtmobile").value = "";
document.getElementById("txtemcode").value = "";
document.getElementById("txtemailid").value = "";
//document.getElementById("txtpaymode").value = "";
 window.location=window.location
		return false;

}
return false;
}

function callchkupdate(response)
{
var ds=response.value;

var exename=trim(document.getElementById("txtexename").value);
var designation=document.getElementById("txtdesignation").value;
var address=trim(document.getElementById("txtaddress").value);
var street=trim(document.getElementById("txtstreet").value);
var city=document.getElementById("drpcity").value;
var district=document.getElementById("txtdistrict").value;
var state=document.getElementById("txtstate").value;
var country=document.getElementById("txtcountry").value;
var pin=document.getElementById("txtpin").value;
var phone=document.getElementById("txtphone").value;
var status=document.getElementById("drpstatus").value;
var compcode=document.getElementById("hiddencompcode").value;;
var userid=document.getElementById("hiddenuserid").value;
var teamcode=document.getElementById("hiddenteamcode").value;
var report=document.getElementById("drprepot").value;
var craditlimit=document.getElementById('txtcraditlimit').value;
var email=document.getElementById("txtemail").value;
var mobile = document.getElementById("txtmobile").value;
var empcode = document.getElementById('hdempcode').value;
document.getElementById("txtreport").value=document.getElementById("drprepot").value;

 
if(ds != null)
{
    if(ds.Tables[0].Rows.length > 0)
    {
      alert("Executive Name has Already been  assigned!");
      document.getElementById("txtexename").focus();
      return false;
    }
    else
    {
        Execondetail.updatedetail(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe, report, document.getElementById('hidtaluka').value, repname, adtype, craditlimit, email, mobile, empcode);
      window.location=window.location;
      return false;
    }
}
return false;
}

// drop down

/*function addreg()
{
//alert(document.Form1.drpcity.value);
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
Execondetail.addreg(document.Form1.drpcity.value,FillDropDownList_CallBackMaindoc);
//document.getElementById('dpstate').focus();	
}


function FillDropDownList_CallBackMaindoc(response) 
		
{
	var ds=response.value;
	if(ds.Tables[1].Rows.length>0 || ds.Tables[2].Rows.length>0 || ds.Tables[0].Rows.length>0)
	{
		document.getElementById('drpcity').value=ds.Tables[3].Rows[0].City_Name;
		document.getElementById('txtdistrict').value=ds.Tables[1].Rows[0].dist_name;
		document.getElementById('txtstate').value=ds.Tables[2].Rows[0].state_name;
		document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].country_name;
		document.getElementById('txtdistrict').disabled=true;
		document.getElementById('txtstate').disabled=true;
		document.getElementById('txtcountry').disabled=true;
	}
	else
	{
		document.getElementById('txtdistrict').value="";
		document.getElementById('txtstate').value="";
		document.getElementById('txtcountry').value="";
		document.getElementById('txtdistrict').disabled=true;
		document.getElementById('txtstate').disabled=true;
		document.getElementById('txtcountry').disabled=true;
	}
	return false;
}*/


function addreg()
		{
		document.getElementById('txtstate').value="";
		document.getElementById('txtdistrict').value="";
		document.getElementById('drptaluka').value="0";
	   document.getElementById('hidencity').value=document.getElementById('drpcity').value;
		var city=document.getElementById('drpcity').value;
		Execondetail.citysel(city,addcode1);
		return false;
		}

		function addcode1(response)
		{
			var ds=response.value;
			var taluka=document.getElementById('drptaluka');
			if(ds.Tables[1].Rows.length>0 || ds.Tables[2].Rows.length>0 || ds.Tables[0].Rows.length>0)
			{
			// ad by rinki
			 if(ds.Tables[1].Rows.length != null && ds.Tables[1].Rows.length>0)
            {
                document.getElementById('txtdistrict').value=ds.Tables[1].Rows[0].dist_name;
            }
            else
            {
				document.getElementById('txtdistrict').value="";
			}	
		    if(ds.Tables[2].Rows.length != null && ds.Tables[2].Rows.length>0)
            {
                document.getElementById('txtstate').value=ds.Tables[2].Rows[0].state_name;
            }
            else
            {
                //alert("There is no matching value for state");
                document.getElementById('txtstate').value="";
                document.getElementById('txtstate').disabled=true;
            }
				
				if(ds.Tables[4].Rows.length>0)
    		        {	
    				for(var i=0;i<ds.Tables[4].Rows.length;++i) 
	    			{
    					document.getElementById("drptaluka").options[i]=new Option(ds.Tables[4].Rows[i].talu_name,ds.Tables[4].Rows[i].talu_code);
	    			}	
	    			document.getElementById('drptaluka').value=ds.Tables[4].Rows[0].talu_code;
	    			//talukacode=ds.Tables[4].Rows[0].talu_code;
	    			}
	    			else
                    {
                       if(document.getElementById('drpcity').disabled==false)
                       {
                           // alert("There is no matching value for state"); 
                           document.getElementById('drptaluka').value
                       }
                       
                       taluka.options.length=0;
                    }
				document.getElementById('txtdistrict').disabled=true;
				document.getElementById('txtstate').disabled=true;
				document.getElementById('drptaluka').disabled=true;
			}
			return false;
		}

//popup code

function selectexe()
{
 var msg=checkSession();
        if(msg==false)
        return false;
var compcode=document.getElementById("hiddencompcode").value;
var userid=document.getElementById("hiddenuserid").value;
var j;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	codeexe=document.getElementById(str).value;
	
	
	}
	}
	if(k==1)
	{
	if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=false;
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
Execondetail.upperexe(compcode,userid,codeexe,call_selectexe);
	return false;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
	return false;




}

function call_selectexe(response)
{
var ds=response.value;
if(ds.Tables[0].Rows[0].Exec_name!=null)
{
document.getElementById("txtexename").value=ds.Tables[0].Rows[0].Exec_name;
document.getElementById("hiddenexename").value=ds.Tables[0].Rows[0].Exec_name;
}
else
{
    document.getElementById("txtexename").value="";
}

if(ds.Tables[0].Rows[0].Designation!=null)
{
document.getElementById("txtdesignation").value=ds.Tables[0].Rows[0].Designation;
}
else
{
    document.getElementById("txtdesignation").value="";
}
if(ds.Tables[0].Rows[0].Add1!=null)
{
document.getElementById("txtaddress").value=ds.Tables[0].Rows[0].Add1;
}
else
{
    document.getElementById("txtaddress").value="";
}
if(ds.Tables[0].Rows[0].Street!=null)
{
document.getElementById("txtstreet").value=ds.Tables[0].Rows[0].Street;
}
else
{
    document.getElementById("txtstreet").value="";
}
//document.getElementById("drpcity").value=ds.Tables[0].Rows[z].city_code;
if(ds.Tables[0].Rows[0].dist_code!=null)
{
document.getElementById("txtdistrict").value=ds.Tables[0].Rows[0].dist_code;
}
else
{
    document.getElementById("txtdistrict").value="";
}

if(ds.Tables[0].Rows[0].State_code!=null)
{
document.getElementById("txtstate").value=ds.Tables[0].Rows[0].State_code;
}
else
{
    document.getElementById("txtstate").value="";
}
if(ds.Tables[0].Rows[0].Country_code!=null)
{
document.getElementById("txtcountry").value=ds.Tables[0].Rows[0].Country_code;
}
else
{
    document.getElementById("txtcountry").value="";
}
if(ds.Tables[0].Rows[0].pin_code!=null)
{
document.getElementById("txtpin").value=ds.Tables[0].Rows[0].pin_code;
}
else
{
    document.getElementById("txtpin").value="";
}
if(ds.Tables[0].Rows[0].phone!=null)
{
document.getElementById("txtphone").value=ds.Tables[0].Rows[0].phone;
}
else
{
    document.getElementById("txtphone").value="";
}
if(ds.Tables[0].Rows[0].exe_status!=null)
{
document.getElementById("drpstatus").value=ds.Tables[0].Rows[0].exe_status;
}
else
{
    document.getElementById("drpstatus").value=0;
}
if(ds.Tables[0].Rows[0].report_to!=null)
{
document.getElementById("drprepot").value=ds.Tables[0].Rows[0].report_to;
}
else
{
    document.getElementById("drprepot").value="";
}
if(ds.Tables[0].Rows[0].Branch_code!=null)
{
document.getElementById("drpbranch1").value=ds.Tables[0].Rows[0].Branch_code;
}
else
{
    document.getElementById("drpbranch1").value="0";
}
if(ds.Tables[0].Rows[0].CREDIT_LIMIT!=null)
{
document.getElementById("txtcraditlimit").value=ds.Tables[0].Rows[0].CREDIT_LIMIT;
}
else
{
    document.getElementById("txtcraditlimit").value="";
}
if(ds.Tables[0].Rows[0].EMAILID!=null)
{
document.getElementById("txtemail").value=ds.Tables[0].Rows[0].EMAILID;
}
else
{
    document.getElementById("txtemail").value="";
}

if(ds.Tables[0].Rows[0].EMAIL_ID!=null)
{
document.getElementById("txtemailid").value=ds.Tables[0].Rows[0].EMAIL_ID;
}
else
{
    document.getElementById("txtemailid").value="";
}


if(ds.Tables[0].Rows[0].MOBILENO!=null)
{
document.getElementById("txtmobile").value=ds.Tables[0].Rows[0].MOBILENO;
}
else
{
    document.getElementById("txtmobile").value="";
}

if (ds.Tables[0].Rows[0].HR_CODE != null) {
    document.getElementById("txtemcode").value = ds.Tables[0].Rows[0].HR_CODE;
    var empcode1 = ds.Tables[0].Rows[0].HR_CODE;;
     var empcodearr=empcode1.split("(");
     var empcodesplit = empcodearr[1];             
		     empcodesplit=empcodesplit.replace(")","");
		     document.getElementById("hdempcode").value = empcodesplit; 
}
else {
    document.getElementById("txtemcode").value = "";
}

if (ds.Tables[0].Rows[0].PAYMENTMODE != null)
 {
    document.getElementById("txtpaymode").value = ds.Tables[0].Rows[0].PAYMENTMODE;
    var empcode1 = ds.Tables[0].Rows[0].PAYMENTMODE;
    var empcodearr = empcode1.split(",");

    var arr = new Array()
    for (var i = 0; i < (empcodearr.length-1); i++) {
        arr.push(empcodearr[i])

    }



    for (var n = 1; n < document.getElementById('txtpaymode').options.length; n++) {


        for (var tt = 0; tt < arr.length; tt++) {

            if (arr[tt] == document.getElementById('txtpaymode').options[n].value)
             {
                document.getElementById('txtpaymode').options[n].selected = true;
            }
        }

    }
    
    
    
    
    
    //var empcodesplit1 = empcodearr[1];
    //empcodesplit = empcodesplit1.replace(")", "");
  //  document.getElementById("hdpaycode").value = empcodearr;
}
else 
{
    document.getElementById("txtpaymode").value = "";
}


document.getElementById("txtoldcode").value=ds.Tables[0].Rows[0].OLD_CODE;





////////////////this is the xml for the value of city

      var cit=document.getElementById("drpcity");

			 var z;
			 var page=document.getElementById("txtcountry").value;
			 var bname="";
			 var tname="";
			 var chk="find";
			 if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open("GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;   
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","exec_detail.aspx?page="+page+"&chk="+chk+"&tname="+tname+"&bname="+bname, false );
		xml.Send();
		var id=xml.responseText;
		}
		var id1=id.split("+");
		var name=id1[0];
		var name1=name.split(",");
		var code=id1[1];
		var code1=code.split(",");
		
		cit.options.length=0;
		for(z=0;z<=name1.length-1;z++)
		{
		    if(name1[z]!=",")
		    {
		        if(name1[z]!="0")
		        {
		        cit.options[cit.options.length]=new Option(name1[z],code1[z]);
                cit.options.length;
		        }
		    }
		}
		document.getElementById("drpcity").value=ds.Tables[0].Rows[0].city_code;
			document.getElementById("hidencity").value=ds.Tables[0].Rows[0].city_code;

if(ds.Tables[1].Rows.length>0)
{	
    for(var i=0;i<ds.Tables[1].Rows.length;++i) 
    {
	    document.getElementById("drptaluka").options[i]=new Option(ds.Tables[1].Rows[i].TALU_NAME,ds.Tables[1].Rows[i].TALU_CODE);
	    document.getElementById("drptaluka").options.length;
    }	
}
document.getElementById("drptaluka").value=ds.Tables[0].Rows[0].TALUKA;    
if(ds.Tables[0].Rows[0].repname!=null)
{
document.getElementById("txtrepname").value=ds.Tables[0].Rows[0].repname;
}
else
{
    document.getElementById("txtrepname").value=0;
}

if(ds.Tables[0].Rows[0].adtype!=null)
{
document.getElementById("drpadtype").value=ds.Tables[0].Rows[0].adtype;
}
else
{
    document.getElementById("drpadtype").value=0;
}
//-----------------------------------------------------------//
//var adtypecode=ds.Tables[0].Rows[0].adtype;
  var ds1=Execondetail.addadvcat(document.getElementById("drpadtype").value);
        if(ds1.value!==null)
        {
            if(ds1.value.Tables[0].Rows.length !=null && ds1.value.Tables[0].Rows.length>0)
            {
                for(var i=0;i<=ds1.value.Tables[0].Rows.length-1;++i) 
	            {
		            document.getElementById('lbadcategory').options[i]=new Option(ds1.value.Tables[0].Rows[i].Adv_Cat_Name,ds1.value.Tables[0].Rows[i].Adv_Cat_Code);
		                                                               
		          
	            }	
            }
        }

//-------------------------------------------------------------//
    var adcatlist;
    if(ds.Tables[2].Rows.length!=0)
        adcatlist = ds.Tables[2].Rows[0].adcat;	
    else
        adcatlist="";
      for(var t=0;t<document.getElementById('lbadcategory').options.length;t++)
        {
             document.getElementById('lbadcategory').options[t].selected=false;
        }
        if(adcatlist!="" && adcatlist!=null)
        {
            var data=adcatlist.split(",");
            for(var t=0;t<ds.Tables[2].Rows.length;t++)
            {
                for(var n=0;n<document.getElementById('lbadcategory').options.length;n++)
                {
                    if(ds.Tables[2].Rows[t].adcat==document.getElementById('lbadcategory').options[n].value)
                    {
                        document.getElementById('lbadcategory').options[n].selected=true;
                    }
                    
                }
            }
        }
return false;
}

function deleteexe()
{


var compcode=document.getElementById("hiddencompcode").value;;
var userid=document.getElementById("hiddenuserid").value;
var j;
var k=0;
var codedetail;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	codedetail=document.getElementById(str).value;
	
	}
	}
	if(k==1)
	{
	if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=false;
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
Execondetail.deleteexec121(compcode,userid,codedetail);
	window.location=window.location;
	return false;
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
	return false;
}

function AdvExecexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
		
		if(typeof(popUpWin)!="undefined")
		{
		popUpWin.close();
		}
			//window.location.href='EnterPage.aspx';
			window.close();
			return false;
		}
			return false;
}

function addcount(cou)
{
       document.getElementById('txtstate').value="";
		document.getElementById('txtdistrict').value="";
		document.getElementById('drptaluka').value="0";
if(typeof(cou)=="object")
{
var country=cou.value;
}
else
{
var country=cou;
}
if(document.getElementById("txtcountry").value!="0")
{
//var country=document.getElementById('txtcountry').value;
Execondetail.addcou(country,callcount);
return false;
}
else
{
document.getElementById("txtdistrict").value="";
 document.getElementById("txtstate").value="";
  document.getElementById("drptaluka").value="0";
var pkgitem = document.getElementById("drpcity");

 pkgitem.options.length = 1; 
 pkgitem.options[0]=new Option("--Select City--","0");
 
 
 return false;
}

return false;
}
//var cityvar;
function callcount(res)
{

var ds=res.value;

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

var pkgitem = document.getElementById("drpcity");
//alert(pkgitem);
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
        
       pkgitem.options.length;
       
    }
    //alert(cityvar);
 if(cityvar == undefined || cityvar=="")
 {
  document.getElementById('drpcity').value="0";
 
 }
 else
 {
  document.getElementById('drpcity').value=cityvar;
  cityvar="";
  } 
}
else
{
alert("There is No Matching value Found");
return false;

}

return false;
}
var cl;
function selected(id)
{
var compcode=document.getElementById("hiddencompcode").value;;
var userid=document.getElementById("hiddenuserid").value;
var j;
var k=0;
 cl=id;
 //alert(cl);
if(document.getElementById(id).checked==false)
{
document.getElementById(id).checked=false;
document.getElementById("txtcraditlimit").value=""
document.getElementById("txtexename").value="";
document.getElementById("txtdesignation").value="0";
document.getElementById("txtcountry").value="0";
document.getElementById("txtstate").value="";
document.getElementById("txtdistrict").value="";
document.getElementById("drpstatus").value="0";
document.getElementById("txtaddress").value="";
document.getElementById("txtstreet").value="";
document.getElementById("txtrepname").value="0";
document.getElementById("drpbranch1").value="0";
var pkgitem = document.getElementById("drpcity");

 pkgitem.options.length = 1; 
 pkgitem.options[0]=new Option("--Select City--","0");
document.getElementById("txtpin").value="";
document.getElementById("txtphone").value="";
document.getElementById("drprepot").value="0";
document.getElementById("drpadtype").value="0";

document.getElementById("txtemail").value="";
document.getElementById("txtmobile").value = "";
document.getElementById("txtemcode").value = "";
document.getElementById("txtemailid").value = "";
//  for(var t1=0; t1<document.getElementById('lbadcategory').options.length; t1++)
// {
//    document.getElementById('lbadcategory').options[t1].selected=false;
// }
document.getElementById('lbadcategory').options.length="0";
document.getElementById('btndelete').disabled=true;

codeexe="";

return;
}


//var DataGrid1__ctl_CheckBox1= new Array();
//alert(document.getElementById("DataGrid1").rows.length);
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
//	alert(document.getElementById(str));
    document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	codeexe=document.getElementById(id).value;
	
	
	
	}
	}
	if(document.getElementById('hiddenshow').value=="2")
	{
	document.getElementById('btndelete').disabled=false;
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
Execondetail.upperexe(compcode,userid,codeexe,call_selectexe);
//	if(k==1)
//	{
//	document.getElementById('btndelete').disabled=false;
//	Execondetail.upperexe(compcode,userid,codeexe,call_selectexe);
//	return ;
//	
//	}
//	else
//	{
//	alert("You Can Select One Row At A Time");
//	return ;
//	}
	return ;


}

function closeexe()
{
//document.getElementById('cl').checked=false;

document.getElementById("txtexename").value="";
document.getElementById("txtdesignation").value="0";
document.getElementById("txtcountry").value="0";
document.getElementById("txtstate").value="";
document.getElementById("txtdistrict").value="";
document.getElementById("drpstatus").value="0";
document.getElementById("txtaddress").value="";
document.getElementById("txtstreet").value="";
var pkgitem = document.getElementById("drpcity");

 pkgitem.options.length = 1; 
 pkgitem.options[0]=new Option("--Select City--","0");
document.getElementById("txtpin").value="";
document.getElementById("txtphone").value="";
document.getElementById("drprepot").value="0";
document.getElementById("txtemail").value="";
document.getElementById("txtmobile").value = "";
document.getElementById("txtemcode").value = "";
document.getElementById("txtemailid").value = "";
codeexe="";
window.close();
return ;
}

function clearexe()
{
//document.getElementById(id).checked=false;

document.getElementById("txtexename").value="";
document.getElementById("txtdesignation").value="0";
document.getElementById("txtcountry").value="0";
document.getElementById("txtstate").value="";
document.getElementById("txtdistrict").value="";
document.getElementById("drpstatus").value="0";
document.getElementById("txtaddress").value="";
document.getElementById("txtstreet").value="";
var pkgitem = document.getElementById("drpcity");
document.getElementById("drpadtype").value = "0";
document.getElementById("lstempcode").style.display = "none";
  for(var t1=0; t1<document.getElementById('lbadcategory').options.length; t1++)
 {
    document.getElementById('lbadcategory').options[t1].selected=false;
 }
 pkgitem.options.length = 1; 
 pkgitem.options[0]=new Option("--Select City--","0");
document.getElementById("txtpin").value="";
document.getElementById("txtphone").value="";
document.getElementById("drprepot").value="0";

document.getElementById("drptaluka").value="0";
document.getElementById("txtrepname").value="0";
document.getElementById("txtemail").value="";
document.getElementById("txtmobile").value = "";
document.getElementById("txtemcode").value = "";
document.getElementById("txtemailid").value = "";
if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSubmit').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSubmit').disabled==false)))
{
    var j;
    var k=0;
    var i=document.getElementById("DataGrid1").rows.length -1;

    for(j=0;j<i;j++)
	{
	    var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
	    document.getElementById('btndelete').disabled=true;
//	     if(opener.document.getElementById('hiddensubmod').value==0)
//           {
//                document.getElementById('btnSubmit').disabled=true;
//           }
//           else
//           {
//                document.getElementById('btnSubmit').disabled=false;
//           }
	}
}

codeexe="";
return false;
}
///////////////////////////////////
function dupexecheck()
{
 
 
 
}
 






///////////////////////////////////////////
	
	
	
	
	
	
	
	
	
 function autoornot()
 {
   document.getElementById('txtteamcode').value=trim(document.getElementById('txtteamcode').value);
   document.getElementById('txteamname').value=trim(document.getElementById('txteamname').value);
 if(hiddentext=="new" )
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
            document.getElementById('txteamname').value=document.getElementById('txteamname').value.toUpperCase();
            // document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
            return;
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
//--------------------saurabh
document.getElementById('txteamname').value=trim(document.getElementById('txteamname').value);
	//	document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
		
		lstr=document.getElementById('txteamname').value;
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
		
		    if(document.getElementById('txteamname').value!="")
                {
                 
        
		  document.getElementById('txteamname').value=document.getElementById('txteamname').value.toUpperCase();
//	     if(hiddentext=="new")
//		{
//	      document.getElementById('txtalias').value=document.getElementById('txtcentername').value;
//	    }
	      str=mstr;


//-----------------------------		
		
//		    if((document.getElementById('txteamname').value!="")&&(document.getElementById('drpzone').value!="0"))
//           
//                {
                 //document.getElementById('txteamname').value=document.getElementById('txteamname').value.toUpperCase();
	            
		        str=document.getElementById('txteamname').value;
		        strreg=document.getElementById('drpzone').value;
		        AdvExecMaster.chkexeccode(str,strreg,fillcall);//strreg,
		        return false;
                }
             
		     return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		  if(ds==null)
		  {
		     alert(res.error.description);
		     return false;
		  }
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		   
		   
		    alert("This Team Name has been assigned!! ");
		    document.getElementById('txtteamcode').value="";
		    document.getElementById('txteamname').value="";
		     document.getElementById('drpzone').value="0";
		    document.getElementById('txteamname').focus();
		    
 
    		
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
		                         newstr=ds.Tables[1].Rows[0].Team_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtteamcode').value="TC"+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtteamcode').value="TC"+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
            var branchname=document.getElementById('drpzone').value;
	        var compcode = document.getElementById("hiddencompcode").value ;
	        var userid=  document.getElementById("hiddenuserid").value ;
	        var txtteamcode1 = trim(document.getElementById('txtteamcode').value);
	        var txteamname1 = trim(document.getElementById('txteamname').value);
            document.getElementById('txtteamcode').disabled=false;
            document.getElementById('txtteamcode').value=document.getElementById('txtteamcode').value.toUpperCase();
            document.getElementById('txteamname').value=document.getElementById('txteamname').value.toUpperCase();
            auto=document.getElementById('hiddenauto').value;
            AdvExecMaster.chkadv(compcode,txtteamcode1,userid,txteamname1,branchname,call_chkname);
            return false;
        }

return false;
}
	
function call_chkname(res)
		{
		    var ds=res.value;
		   
		    if(ds.Tables[0].Rows.length!=0)
		    {
		        alert("Team Code has already assigned!! ");
		        document.getElementById('txtteamcode').value="";
		        if(document.getElementById('txtteamcode').disabled==false)
		        document.getElementById('txtteamcode').focus();
    	        return false;
		    }
		    if(ds.Tables[1].Rows.length!=0)
		    {
		        alert("Team Code has already assigned!! ");
		        document.getElementById('txtteamcode').value="";
		        if(document.getElementById('txtteamcode').disabled==false)
		        document.getElementById('txtteamcode').focus();
    	        return false;
		    }
		    if(ds.Tables[2].Rows.length!=0)
		    {
		        alert("Team Name has already assigned!! ");
		        document.getElementById('txteamname').value="";
		        if(document.getElementById('txteamname').disabled==false)
		        document.getElementById('txteamname').focus();
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
//
//
function addzone(ab)
{
  autoornot();

var team=document.getElementById('txteamname').value;
//AdvExecMaster.addzone1(team,callcount);

return false;
}

/*function callcount(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drpzone");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

//var pkgitem = document.getElementById("drpcity");
//alert(pkgitem);
    pkgitem.options.length = 0; 
    //alert(pkgitem.options.length);
    document.getElementById('drpzone').value=document.getElementById('txteamname').value;
    
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Region_Name,res.value.Tables[0].Rows[i].Region_Code);
        
       pkgitem.options.length;
       
    }
    
    
    
 if(cityvar == undefined)
 {
  document.getElementById('drpzone').value=res.value.Tables[0].Rows[0].Region_Code;
 
 }
 else
 {
  document.getElementById('drpzone').value=cityvar;
  } 
}
else
{
alert("There is No Matching value Found");
pkgitem.options.length=0;
return false;

}

return false;
}*/


///////////////sorting of a drop down

function keySort(dropdownlist,caseSensitive) {
  // check the keypressBuffer attribute is defined on the dropdownlist 
  var undefined; 
  if (dropdownlist.keypressBuffer == undefined) { 
    dropdownlist.keypressBuffer = ''; 
  } 
  // get the key that was pressed 
  var key = String.fromCharCode(window.event.keyCode); 
  dropdownlist.keypressBuffer += key;
  if (!caseSensitive) {
    // convert buffer to lowercase
    dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
  }
  // find if it is the start of any of the options 
  var optionsLength = dropdownlist.options.length; 
  for (var n=0; n<optionsLength; n++) { 
    var optionText = dropdownlist.options[n].text; 
    if (!caseSensitive) {
      optionText = optionText.toLowerCase();
    }
    if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
      dropdownlist.selectedIndex = n; 
      return false; // cancel the default behavior since 
                    // we have selected our own value 
    } 
  } 
  // reset initial key to be inline with default behavior 
  dropdownlist.keypressBuffer = key; 
  return true; // give default behavior 
} 
/////////////////////////////////////////////////////////////////////////////

function messagealert_adv()
{
alert("This Executive Name has been submitted already");
return false;
}
function enter()
{
event.keycode=32;
return false;
}

function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}

//ad by rinki
function category()
{

	var adtypecode=document.getElementById('drpadtype').value;

if(document.getElementById('drpadtype').value!="0")
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
         Execondetail.addadvcat(adtypecode,call_back);

        return false;
 }
else
{
        document.getElementById('lbadcategory').value="0";
       // adtype=document.getElementById('lbadcategory');
        document.getElementById('lbadcategory').options.length = 1; 
        document.getElementById('lbadcategory').options[0]=new Option("--Select Category--","0");
 }

     return false;
}


function call_back(res)
{
    var ds=res.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
              // adtype=document.getElementById('lbadcategory');

                document.getElementById('lbadcategory').options.length = 1; 
                document.getElementById('lbadcategory').options[0]=new Option("--Select Category--","0");
                //alert(pkgitem.options.length);
        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
        {
            document.getElementById('lbadcategory').options[document.getElementById('lbadcategory').options.length] = new Option(res.value.Tables[0].Rows[i].Adv_Cat_Name,res.value.Tables[0].Rows[i].Adv_Cat_Code);
           document.getElementById('lbadcategory').options.length;
           
        }
               
    }
     

    else
    {
        document.getElementById('lbadcategory').options.length="0";
//      //  adtype=document.getElementById('lbadcategory');
//          adtype.options.length = 1; 
//        adtype.options[0]=new Option("--Select Category--","0");
        return false;
    }
     
    return false;
 
}
function setF()
{
    if(document.getElementById('txtteamcode').disabled==true)
        document.getElementById('txteamname').focus();
    else
        document.getElementById('txtteamcode').focus();    
}
function signuploadclick()
{ if(document.getElementById('LinkButton1').disabled ==false)
{	
var hdnshow="";
var filename=document.getElementById('txtsign').value;
    if(hiddentext=="query" || hiddentext=="execute")
    {
        hdnshow="0";
    }
    else
    {
        hdnshow="1";
    }
 var win=window.open('Execsignattatchment.aspx?filename='+filename+'&hiddenshow='+hdnshow,'','width=350px,height=200px,resizable=1,left=0,top=0,scrollbars=yes');
 win.focus();
 }
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

function buttonclear()

{

document.getElementById('LinkButton1').disabled=true;
loadXML('xml/errorMessage.xml');
givebuttonpermission('AdvExecMaster');
AdvExecCancel('AdvExecMaster');
}

function offset(activeid, divid, listboxid) {
    //jq('#' + listboxid).empty();

    aTag = eval(document.getElementById(activeid))
    var btag;
    var leftpos = 0;
    var toppos = 18;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById(divid).scrollLeft;
    var scrolltop = document.getElementById(divid).scrollTop;
    document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";
    document.getElementById(divid).style.display = "block";
    document.getElementById(listboxid).style.display = "block";
    document.getElementById(listboxid).focus();
}

function F2fillempcode(event) {

        if (event.keyCode == 113) {
            if (document.activeElement.id == "txtemcode") {
                var activeid = document.activeElement.id;
                //$('txtagency').value="";
                var compcode = document.getElementById('hiddencompcode').value;
                var empname = document.getElementById('txtemcode').value;
                offset(activeid, "divempcode", "lstempcode")
//                document.getElementById("divempcode").style.display = "block";
//                document.getElementById("lstempcode").style.display = "block";
//                document.getElementById('divempcode').style.top = 278 + "px";
//                document.getElementById('divempcode').style.left = 580 + "px";
              //document.getElementById('lstempcode').focus();
                var ds = Execondetail.empcodebind(compcode, empname);
                bindempcode_callbackb(ds);
            }
        }

    }


    function bindempcode_callbackb(res) {
        ds_AccName = res.value;

        if (ds_AccName != null) {
            var pkgitem = document.getElementById("lstempcode");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select Employe Name-", "0");
            pkgitem.options.length = 1;
            for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].NAME+'(' + ds_AccName.Tables[0].Rows[i].EMP_CODE + ')'+'/'+ds_AccName.Tables[0].Rows[i].FATHER_NAME+'/'+ds_AccName.Tables[0].Rows[i].BRANCH_NAME, ds_AccName.Tables[0].Rows[i].EMP_CODE);
                pkgitem.options.length;
            }
        }
        document.getElementById("lstempcode").value = "0";
        document.getElementById("divempcode").value = "";
        //document.getElementById('lstempcode').focus();

        return false;

    }



   


    function Clickrempcode_ret(event) {


       if (event.keyCode == 13 || event.type == "click") {
            if (document.activeElement.id == "lstempcode") {
                if (document.getElementById('lstempcode').value == "0") {
                    alert("Please select Employe Name");
                    return false;
                }

                var page = document.getElementById('lstempcode').value;
                agencycode = page;
                for (var k = 0; k <= document.getElementById('lstempcode').length - 1; k++) {
                    if (document.getElementById('lstempcode').options[k].value == page) {
                        if (browser != "Microsoft Internet Explorer") {
                            var abc = document.getElementById('lstempcode').options[k].textContent;
                           

                        }
                        else {
                            var abc = document.getElementById('lstempcode').options[k].innerText;
                        }
                         abc=abc.split("/");
                        abc=abc[0];
                        
                        document.getElementById('txtemcode').value = abc;

                        document.getElementById('hdempcode').value = page;
                        document.getElementById('txtexename').value=  ds_AccName.Tables[0].Rows[k-1].NAME
                       document.getElementById('txtaddress').value=  ds_AccName.Tables[0].Rows[k-1].ADDR1+ds_AccName.Tables[0].Rows[k-1].ADDR2+ds_AccName.Tables[0].Rows[k-1].ADDR3;
                        document.getElementById('txtpin').value=  ds_AccName.Tables[0].Rows[k-1].PIN
                         document.getElementById('txtemail').value=  ds_AccName.Tables[0].Rows[k-1].EMAIL
                          document.getElementById('txtmobile').value=  ds_AccName.Tables[0].Rows[k-1].MOBILE
                           document.getElementById('drpbranch1').value=  ds_AccName.Tables[0].Rows[k-1].BRAN_CODE
                        
                        
                        //                    document.getElementById('hdnretainername').value =abc;

                        document.getElementById("divempcode").style.display = "none";
                        document.getElementById("lstempcode").style.display = "none";
                        document.getElementById('txtemcode').focus();
                        return false;

                    }

                }


            }

        }
        else if (event.keyCode == 27) {

        document.getElementById("divempcode").style.display = "none";
        document.getElementById("lstempcode").style.display = "none";
            document.getElementById('txtemcode').focus();
            return false;
        }
//        return false;
    }


    function tabvalue1(event, id) {

//alert("kuldeep")

        var browser = navigator.appName;
        //alert(event.which);
        if (browser != "Microsoft Internet Explorer") {
            if (event.which == 13) {
                if (document.activeElement.id == id) {
                    if (document.getElementById('btnSave').disabled == false) {
                        document.getElementById('btnSave').focus();
                    }
                    return;

                }
                else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
                    event.which = 13;
                    return event.which;

                }
                else {
                    //alert(event.keyCode);
                    event.which = 9;
                    //alert(event.keyCode);
                    return event.which;
                }
            }
        }
        else {
            if (event.keyCode == 13) {
                if (document.activeElement.id == id) {
                    if (document.getElementById('btnSave').disabled == false) {
                        document.getElementById('btnSave').focus();
                    }
                    return;

                }
                else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
                    event.keyCode = 13;
                    return event.keyCode;

                }
                else {
                    //alert(event.keyCode);
                    event.keyCode = 9;
                    //alert(event.keyCode);
                    return event.keyCode;
                }
            }

            if (event.keyCode == 120) {
                var formname = document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/") + 1, document.URLUnencoded.lastIndexOf("."));
                window.open("Help.aspx?formname=" + formname);

            }
        }

    }


    function closeattach() {
        window.opener.document.getElementById('txtsign').value = document.getElementById('lblfilename').innerHTML;
        //        if(window.opener.document.getElementById('hidattach1').value!="")
        //        window.opener.document.getElementById('attachment1').src="Images/indexred.jpg";
        window.close();
    }
    function openfile() {
        window.open("TEMPSIGN/" + document.getElementById('lblfilename').innerHTML);
        return false;
    }




function ClientEmlChck(q) 
{
	var theurl=document.Form1.txtemailid.value;
	
            var splt= theurl.split(',');
            if(splt.length>1)
            {
            for(var i=0;i<splt.length;i++)
           {
           var eml2= splt[i];
           if(eml2!="")
           {
           if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value=="")
	{
		
	}
	else
	{
	alert("Invalid E-mail Address! Please re-enter.")
	//document.getElementById(q).value="";
	document.getElementById(q).focus();
	return (false)
	}
           }
        else
        {
//        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value=="")
//	{
//		return (true)
//	}
//	alert("Invalid E-mail Address! Please re-enter.")
//	//document.getElementById(q).value="";
//	document.getElementById(q).focus();
	return (true)
        }
            }
            }
     else       
	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value=="")
	{
		return (true)
	}
//	var splt= theurl.split(',');
	else
	{
	alert("Invalid E-mail Address! Please re-enter.")
	//document.getElementById(q).value="";
	document.getElementById(q).focus();
	return (false)
	}
}



function openattach1() {
    //if (document.getElementById('LinkButton1').disabled == false)
    window.open('ExecutiveAttachment.aspx?filename=' + document.getElementById('hidattachment').value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
    return false;
}


function  retcomslab(val)
{
    if ((trim(val)!="")&&(val!=null)&&(val!=0))
    {
        
            var RetStatusCode= val;
            //popUpWin = window.open("executivecommslab.aspx?show="+show+"&n_m="+saurabh+"&RetStatusCode="+RetStatusCode,"status","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin = window.open("executivecommsstructure.aspx?show=" +document.getElementById("hiddenshow").value + "&n_m=" + saurabh + "&RetStatusCode=" + RetStatusCode, "status", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin.focus();
            return false;
       
       
    }
    else
    {
        
            alert("Please enter the Executive Name");
           
            return false;    
        
    }
}



function retpopopn(val) {
    if ((trim(val) != "") && (val != null) && (val != 0)) {

        var RetStatusCode = val;
        //popUpWin = window.open("executivecommslab.aspx?show="+show+"&n_m="+saurabh+"&RetStatusCode="+RetStatusCode,"status","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
        popUpWin = window.open("Execopoup.aspx?show=" + document.getElementById("hiddenshow").value + "&n_m=" + saurabh + "&RetStatusCode=" + RetStatusCode, "status", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
        popUpWin.focus();
        return false;


    }
    else {

        alert("Please enter the Executive Name");

        return false;

    }
}

function tabvalue (id)
{

    if(event.keyCode==13)
    {
        if(document.activeElement.id==document.getElementById('drpcity').id && document.getElementById('txtremarks').disabled==true)
        {
            //if(document.getElementById('btnExecute').disabled==false)
            //{
                document.getElementById('btnExecute').focus();
            //}
             event.keyCode=13;
            
            return event.keyCode;
        }
        else if(document.activeElement.id==id)
        {
            if(document.getElementById('btnSave').disabled==false)
            {
                document.getElementById('btnSave').focus();
            }
            return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
            event.keyCode=13;
            return event.keyCode;

        }
        else
        {
            event.keyCode=9;
            return event.keyCode;
        }
    }
    }
    
    
    function grdSubmit()
{
if(parseFloat(document.getElementById('txtfrom').value)>parseFloat(document.getElementById('txtto').value))
//   if(parseFloat(txtfrom)>parseFloat(txtto))
	 {
	   alert("From Target cannot be greater than To Target.");
	   document.getElementById('txtfrom').value="";
	   document.getElementById('txtto').value="";
	   return false;
	 }

    var compcode=document.getElementById('hiddencompcode').value; 
    var userid=document.getElementById('hiddenuserid').value;
    var retcode = document.getElementById('hiddenretcode').value;  
    
     var PTEAM_CODE=document.getElementById('drpteam').value;
    var PADCTG_CODE=document.getElementById('drpcat').value;
    var PFROM_TGT=document.getElementById('txtfrom').value;
    
     var PTO_TGT=document.getElementById('txtto').value;
    var PCUST_TYPE=document.getElementById('drpcusttype').value;
    var PAD_TYPE=document.getElementById('drpadpub').value;
    
    
     var PPUB_TYPE=document.getElementById('drppubtype').value;
   // var PPUBL_CODE=document.getElementById('lstpublication').value;
     var PPUBL_CODE = "";
        for(var li=0;  li< document.getElementById('lstpublication').options.length; li++)
        {

            if (document.getElementById('lstpublication').options[li].selected == true)
            {
                if (document.getElementById('lstpublication').options[li].value != "")
                {
                    if(PPUBL_CODE=="")
                        PPUBL_CODE=document.getElementById('lstpublication').options[li].value;
                    else
                        PPUBL_CODE = PPUBL_CODE + "," + document.getElementById('lstpublication').options[li].value;
                }

            }
        }
    var PCOMM_TARGET_ID=document.getElementById('hiddenstructcode').value;
	 	document.getElementById('hiddenpublicationcode').value=PPUBL_CODE;
//	 	document.getElementById("hiddenflag").value="T";
//	 	document.getElementById("hiddenflag2").value="T";
	 	
if(document.getElementById("hiddenshow").value=="2")
{
//		var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		            xml.Open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays, false );
//		             xml.Send();
//		            var dl=xml.responseText;
//		            if(dl=="yes")
//		            {
//		                 alert('Session Expired.Please Login Again.');
//                        return false;
//		            }
//		            
//		              if(dl=="Y")
//		                {
//    		
//		                alert("This data is already assigned");
//	            	    return false;

//	                	}
//	        	    else
//	        	    {

//                        if  (opener.document.getElementById('hiddenchk').value=="1")
//                        {
                            if(flag2=="1")
                           {
                               executivecommsstructure.checkretstructslabupdate(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, PCOMM_TARGET_ID);
                               //(retcode,compcode,userid,common,commrate,todays,fromdays,codepass);
                               window.location=window.location;
				                return false;
				           }
				         else
				         {
                            codepass="";
                            var rescode=executivecommsstructure.getmaxcodeforslab(compcode, userid);
                            var ds = rescode.value;
		                    var commcod=ds.Tables[0].Rows[0].IDNO;
                            executivecommsstructure.insertretstructslab(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE,commcod);// PCOMM_TARGET_ID);
                            window.location=window.location;
                            return false;
				         }
//                       }
//                        else
//                        {
//	                        return ;
//                        }
//                   }

            
      }
		else
			{
     executivecommsstructure.setviewstatevalue();

			return ;
			}
//document.getElementById("hiddenflag").value="T";
}

function PopadcommstSlabClear()
{   
    flag2="0";
     document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";
        document.getElementById('lstpublication').options.length = 1; 
       document.getElementById('lstpublication').options[0]=new Option("--Select Publication--","0");

     for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
    {
         document.getElementById('lstpublication').options[t].selected=false;
    }
    if(document.getElementById("DataGrid1") ==null)
    {
        var i=document.getElementById("DataGrid2").rows.length -1;
        for(j=0;j<i;j++)
        {
            var str="DataGrid12__ctl_CheckBox1"+j;
            document.getElementById(str).checked=false;
        }
    }
    else
    {
        var i=document.getElementById("DataGrid1").rows.length -1;
        for(j=0;j<i;j++)
        {
            var str="DataGrid1__ctl_CheckBox1"+j;
            document.getElementById(str).checked=false;
        }
    }
/*
if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSave').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSave').disabled==false)))
{

 var j;
 var k=0;
 var i=document.getElementById("DataGrid2").rows.length -1;

    for(j=0;j<i;j++)
	{
	  var str="DataGrid1__ctl_CheckBox1"+j;
	  document.getElementById(str).checked=false;
	  document.getElementById('btndelete').disabled=true;
	  if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSave').disabled=true;
       }
       else
       {
            document.getElementById('btnSave').disabled=false;
       }
	}
}
*/
  return false;
}

function RetstrSlabDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
    var enlncode=document.getElementById('hiddenstructcode').value; 
 var i=document.getElementById("DataGrid1").rows.length -1;
 if(i<=1)
 {
 alert("There must be at least one record") 
 return false;
 }
	   executivecommsstructure.Ret_StructureDeleteSlab(userid,compcode,retcode,enlncode);
	   
	    document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";	
		
		
		window.location=window.location;
		return false;	
}


function openpage()
{
    show="1";
     var j;
     var inc =2;
     var flag ="false";
     var popupid="";
     if(document.getElementById("DataGrid2") == null || document.getElementById("DataGrid2") == "null")
     {
        for(j=0;j<(document.getElementById("DataGrid1").rows.length -1);j++)	
	  {  
	    var str1="DataGrid1__ctl_CheckBox1"+j; 
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			    popupid=document.getElementById(str1).value;
			}
            
        }
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
        
         var RetStatusCode = document.getElementById('hiddenretcode').value;
        
         var win = window.open("executivecommslab.aspx?show=" + document.getElementById("hiddenshow").value + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
       
        }
     }
     else
     	{		
     for(j=0;j<(document.getElementById("DataGrid2").rows.length -1);j++)	
	  {  
	    var str1="DataGrid12__ctl_CheckBox1"+j;
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			     popupid=document.getElementById(str1).value;
			}
            
        }
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
        
         var RetStatusCode = document.getElementById('hiddenretcode').value;
        
         var win = window.open("executivecommslab.aspx?show=" + document.getElementById("hiddenshow").value + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
       
        }
  }
  return false;
}



function openaddcomm()
{
   show="1";
   var j;
   var inc =2;
   var flag ="false";
   var popupid="";
    if(document.getElementById("DataGrid2") == null || document.getElementById("DataGrid2") == "null")
     {
        for(j=0;j<(document.getElementById("DataGrid1").rows.length -1);j++)	
	  {  
	    var str1="DataGrid1__ctl_CheckBox1"+j;  
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			     popupid=document.getElementById(str1).value;
			}
            
        }
         
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
         var RetStatusCode = document.getElementById('hiddenretcode').value;
         var win = window.open("executiveaddtionalcomm.aspx?show=" + document.getElementById("hiddenshow").value + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
        
        }
     }
     else
     	{	
    for(j=0;j<(document.getElementById("DataGrid2").rows.length -1);j++)	
	  {  
	    var str1="DataGrid12__ctl_CheckBox1"+j;  
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			     popupid=document.getElementById(str1).value;
			}
            
        }
         
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
         var RetStatusCode = document.getElementById('hiddenretcode').value;
         var win = window.open("executiveaddtionalcomm.aspx?show=" + document.getElementById("hiddenshow").value+ "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
        
        }
    } 
    return false;  
}

function bindpub()
{

var compcode = document.getElementById('hiddencompcode').value;

var ptype=  document.getElementById('drppubtype').value;
  var response=executivecommsstructure.bindpublicatin(compcode,ptype,"","","");
var ds=response.value;
    var pkgitem = document.getElementById("lstpublication");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Publication--","0");
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].PUBL_NAME,ds.Tables[0].Rows[i].PUBL_CODE);
        
       pkgitem.options.length;   
    }
return false;
}


function RetcomslabSubmit()
 {
    //var common=document.getElementById('drpteam').value;
    var common=document.getElementById('drpcommon').value;
	var fromdays=document.getElementById('txtfrom').value;
	var todays=document.getElementById('txtto').value;
	
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var retcode = document.getElementById('hiddenretcode').value;   
	var codepass=document.getElementById('hiddenenln').value;
	var commrate=trim(document.getElementById('txtcommrate').value);
	var targetid = document.getElementById('hdntargetid').value;  
	if(parseFloat(document.getElementById('txtfrom').value)>parseFloat(document.getElementById('txtto').value))
	 {
	   alert("From Days cannot be greater than Till Days.");
	   document.getElementById('txtfrom').value="";
	   document.getElementById('txtto').value="";
	   return false;
	 }


	
	
	/*dc=document.getElementById('lblcircular').innerText;

    if(dc.indexOf('*')>=0)
    {
	    if (trim(document.getElementById('txtcommrate').value)=="")
	    {
		    alert('Plese Enter '+(dc.replace('*',"")));
		    document.getElementById('txtcommrate').focus();
		    return false;
	    }
	}*/
	
     //----------check commmision--------------------//
  /*   if(parseFloat(document.getElementById('txtcommrate').value)>100)
	{
	    alert('Commition rate should be less than 100');
	    document.getElementById('txtcommrate').value="";
	    document.getElementById('txtcommrate').focus();
	    return false;
	}*/
	//--------------------- check double dot ------------------------//
	/* if(parseFloat(document.getElementById('txtcommrate').value)!="")
     {
			    if(commrate.match(/^\d+(\.\d{1,3})?$/i))
			    {
			      //return true;
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById('txtcommrate').value="";
			        return false;
			    }
    }*/
     
     //------------------------------------------------//
	
		// Hidden fields for final save event
		
//	opener.document.getElementById('hidden12s').value=common;
//    opener.document.getElementById('hidden32s').value=fromdays;
 //   opener.document.getElementById('hidden42s').value=todays;
		
		
		//*************************************************************************
		//                          Start from here
		//*************************************************************************
	
if(document.getElementById("hiddenshow").value=="2")
{
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays, false );
		             xml.Send();
		            var dl=xml.responseText;
		            if(dl=="yes")
		            {
		                 alert('Session Expired.Please Login Again.');
                        return false;
		            }
		            
		              if(dl=="Y")
		                {
    		
		                alert("This data is already assigned");
	            	    return false;

	                	}
	        	    else
	        	    {

//                        if  (opener.document.getElementById('hiddenchk').value=="1")
//                        {
                            if(document.getElementById('hiddenchkst').value=="1")
                           {
                               executivecommslab.checkretslabupdate(retcode,compcode,userid,common,commrate,todays,fromdays,codepass);
                               
                               window.location=window.location;
				                return false;
				           }
				         else
				         {
                            codepass="";
                            executivecommslab.insertretslab33(compcode, userid, retcode, fromdays, todays, common, commrate, targetid); //,insertret_slabcall);
                            window.location = window.location
                            return false;
				         }
//                       }
//                        else
//                        {
//	                        return ;
//                        }
                   }

            
      }
		else
			{
executivecommslab.setviewstatevalue();

				return;// false;
			}
}

function insertret_slabcall(response)
{
    var ds=response.value;
    if (ds=="fail")
    {
	    alert("This data has been already assigned");
	    return false;

    }
    else
    {
      var common=document.getElementById('drpcommon').value;
	  var fromdays=document.getElementById('txtfrom').value;
      var todays=document.getElementById('txtto').value;
	  var compcode=document.getElementById('hiddencompcode').value; 
	  var userid=document.getElementById('hiddenuserid').value;
	  var commrate=document.getElementById('txtcommrate').value;
      var retcode = document.getElementById('hiddenretcode').value;  
      var targetid = document.getElementById('hdntargetid').value;  
		
	   executivecommslab.insertretslab12(compcode,userid,retcode,fromdays, todays, common, commrate,targetid);
       window.location=window.location
     }
    
}

function PopSlabClear()
{   
    flag2="0";
    document.getElementById('txtfrom').value="";
    document.getElementById('txtto').value="";
  document.getElementById('txtcommrate').value="";
document.getElementById('drpcommon').value="0";


if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSave').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSave').disabled==false)))
{

 var j;
 var k=0;
 var i=document.getElementById("DataGrid2").rows.length -1;

    for(j=0;j<i;j++)
	{
	  var str="DataGrid1__ctl_CheckBox1"+j;
	  document.getElementById(str).checked=false;
	  document.getElementById('btndelete').disabled=true;
//	  if(opener.document.getElementById('hiddensubmod').value==0)
//       {
//            document.getElementById('btnSave').disabled=true;
//       }
//       else
//       {
//            document.getElementById('btnSave').disabled=false;
//       }
	}
}

  return false;
}


function RetSlabDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
    var enlncode=document.getElementById('hiddenenln').value; 
 	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;



	   executivecommslab.Ret_StatusDeleteSlab(userid,compcode,retcode,enlncode);
	   document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpcommon').value="0";
       document.getElementById('txtcommrate').value="";
       document.getElementById('hiddenenln').value="";	
		
		
		window.location=window.location;
		return false;	
}

function poupclose()
{
  window.close();

}


function subpopaddclear()
{
    document.getElementById('txtmainpub').value="";
    document.getElementById('txtpubper').value="";
    //document.getElementById('libox').value="0";
     for(var t=0;t<document.getElementById('libox').options.length;t++)
    {
         document.getElementById('libox').options[t].selected=false;
    }
    return false;
}



function RetaddcomslabSubmit()
 {
   
  	var lstpub = "";
        for(var li=0;  li< document.getElementById('libox').options.length; li++)
        {

            if (document.getElementById('libox').options[li].selected == true)
            {
                if (document.getElementById('libox').options[li].value != "")
                {
                    if(lstpub=="")
                        lstpub=document.getElementById('libox').options[li].value;
                    else
                        lstpub = lstpub + "," + document.getElementById('libox').options[li].value;
                }

         
            }
            
        }
   if (lstpub=="0")
	{
		alert("Plese Select Publication");
		document.getElementById('libox').focus();
		return false;
	}	
   
   
    if (document.getElementById('txtmainpub').value=="")
	{
		alert("Plese Fill Minimum Publication");
		document.getElementById('txtmainpub').focus();
		return false;
	}
   
        if (document.getElementById('txtpubper').value=="")
	{
		alert("Plese Fill Publication");
		document.getElementById('txtpubper').focus();
		return false;
	}
   
   
   
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var retcode = document.getElementById('hiddenretcode').value; 
	//var lstpub = document.getElementById('libox').value; 

	
	var minpub= document.getElementById('txtmainpub').value; 
	var publication = document.getElementById('txtpubper').value; 
	var targetid=document.getElementById('hiddensno').value;
	var commid=document.getElementById('hdncommid').value;
//	var codepass=document.getElementById('hiddenenln').value;
//	var commrate=trim(document.getElementById('txtcommrate').value);
	
//	if(parseFloat(document.getElementById('txtfrom').value)>parseFloat(document.getElementById('txtto').value))
//	 {
//	   alert("From Days cannot be greater than Till Days.");
//	   document.getElementById('txtfrom').value="";
//	   document.getElementById('txtto').value="";
//	   return false;
//	 }

if(document.getElementById("hiddenshow").value=="2")
{
//		var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		            xml.Open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays, false );
//		             xml.Send();
//		            var dl=xml.responseText;
//		            if(dl=="yes")
//		            {
//		                 alert('Session Expired.Please Login Again.');
//                        return false;
//		            }
//		            
//		              if(dl=="Y")
//		                {
//    		
//		                alert("This data is already assigned");
//	            	    return false;

//	                	}
//	        	    else
//	        	    {

//                        if  (opener.document.getElementById('hiddenchk').value=="1")
//                        {
                            if(document.getElementById('hiddenchkst').value=="1")
                           {
                               executiveaddtionalcomm.checkretaddslabupdate(compcode, userid, retcode, lstpub, minpub, publication,targetid);
                               
                               window.location=window.location;
				                return false;
				           }
				         else
				         {
                            codepass="";
                            executiveaddtionalcomm.insertretaddslab(compcode, userid, retcode, lstpub, minpub, publication,commid);
                            window.location=window.location;
                            return false;
				         }
//                       }
//                        else
//                        {
//	                        return ;
//                        }
//                   }

            
      }
		else
			{
executiveaddtionalcomm.setviewstatevalue();

				return;// false;
			}
}


function RetaddSlabDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
//	var datagrid=document.getElementById('DataGrid1');
    var targetid=document.getElementById('hiddensno').value;
// 	var j;
//	var k=0;
//	var i=document.getElementById("DataGrid1").rows.length -1;



	   executiveaddtionalcomm.Ret_AddDeleteSlab(compcode, userid, retcode,targetid);
	   document.getElementById('txtmainpub').value="";
       document.getElementById('txtpubper').value="";
       document.getElementById('libox').value="0";
  
		window.location=window.location;
		return false;	
}
function Selectgcol(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       document.getElementById('lstpublication').options.length = 1; 
       document.getElementById('lstpublication').options[0]=new Option("--Select Publication--","0");
       //document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";
    
        for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
        {
             document.getElementById('lstpublication').options[t].selected=false;

        }
       
       
//       if(opener.document.getElementById('hiddensubmod').value==0)
//       {
//            document.getElementById('btnSave').disabled=true;
//       }
//       else
//       {
//            document.getElementById('btnSave').disabled=false;
//       }

       document.getElementById('btndelete').disabled=true;
document.getElementById(ab).checked=false;
       return;// false;
        
    }
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(document.getElementById('hiddendelsau').value=="1")
	    {
          document.getElementById('btndelete').disabled= false;
        }

       if(id==str)
       {
	    if(document.getElementById(id).checked==true)
	    {
	        k=k+1;
	        code11=document.getElementById(str).value;
	        chkclick=document.getElementById(id);
	    
	        if(document.getElementById('hiddendelsau').value=="1")
	        {
	        document.getElementById('btndelete').disabled= false;
            }
	
	   }
	  }
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}

	executivecommsstructure.bindstruct(retcode,compcode,userid,code11,Selectgcol_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       //document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";
        for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
        {
             document.getElementById('lstpublication').options[t].selected=false;
        }
        return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnSave').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	//return false;
}

function Selectgcol_CallBack(response)
{

	var ds = response.value;

				
		//updatecommission = ds.Tables[0].Rows[0].stat_code;
		
		document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].from_tgt;
       document.getElementById('txtto').value=ds.Tables[0].Rows[0].to_tgt;
       document.getElementById('drpteam').value=ds.Tables[0].Rows[0].team_code;
       document.getElementById('drpadpub').value=ds.Tables[0].Rows[0].ad_type;//PUBL_CODE;
       
       document.getElementById('drpcusttype').value=ds.Tables[0].Rows[0].cust_type;
       document.getElementById('drpcat').value=ds.Tables[0].Rows[0].adctg_code;
       document.getElementById('drppubtype').value=ds.Tables[0].Rows[0].pub_type;
       document.getElementById('hiddenstructcode').value=ds.Tables[0].Rows[0].comm_target_id;
       bindpub();

       //document.getElementById('lstpublication').value=ds.Tables[0].Rows[0].PUBLICATION;
        for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
        {
             document.getElementById('lstpublication').options[t].selected=false;
        }
        if(ds.Tables[0].Rows[0].PUBL_CODE !=null && ds.Tables[0].Rows[0].publ_code !="")
        {
            var edition=ds.Tables[0].Rows[0].publ_code;            
            var  len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<document.getElementById('lstpublication').options.length; i++)
                {
                    if(document.getElementById('lstpublication').options[i].value==len[a])
                    {
                         document.getElementById('lstpublication').options[i].selected = true;
                    }
//                    else
//                    {
//                        document.getElementById('lstpublication').options[i].selected = false;
//                    }
                }
            }

        }
		
			
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSave').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnSave').disabled=false;
	}
	
	return false;
}

function AddSlabSelect(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtmainpub').value="";
       document.getElementById('txtpubper').value="";
       //document.getElementById('libox').value="0";
        document.getElementById('hiddenchkst').value="0";
        document.getElementById('hiddensno').value="";
         for(var t=0;t<document.getElementById('libox').options.length;t++)
        {
             document.getElementById('libox').options[t].selected=false;
        }
       
//       if(opener.document.getElementById('hiddensubmod').value==0)
//       {
////            document.getElementById('btnsubmit').disabled=true;
//       }

       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
     document.getElementById('hiddenchkst').value="1";
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(document.getElementById('hiddendelsau').value=="1")
	    {
          document.getElementById('btndelete').disabled= false;
        }

       if(id==str)
       {
	    if(document.getElementById(id).checked==true)
	    {
	        k=k+1;
	        code11=document.getElementById(str).value;
	        chkclick=document.getElementById(id);
	    
	        if(document.getElementById('hiddendelsau').value=="1")
	        {
	        document.getElementById('btndelete').disabled= false;
            }
	
	   }
	  }
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}

	executiveaddtionalcomm.bindAddslab(retcode,compcode,userid,code11,SelectAddSlab_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
         document.getElementById('txtmainpub').value="";
       document.getElementById('txtpubper').value="";
     // document.getElementById('libox').value="0";
       document.getElementById('hiddensno').value="";
        for(var t=0;t<document.getElementById('libox').options.length;t++)
        {
             document.getElementById('libox').options[t].selected=false;
        }
        return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnsubmit').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	
}

//function callback to fill the values to the controls
function SelectAddSlab_CallBack(response)
{
	var ds = response.value;
		
		document.getElementById('txtmainpub').value=ds.Tables[0].Rows[0].NO_OF_PUBL;
		document.getElementById('txtpubper').value=ds.Tables[0].Rows[0].ADCOMM_PER;
		//document.getElementById('libox').value = ds.Tables[0].Rows[0].PUBL_CODE;
		
		for(var t=0;t<document.getElementById('libox').options.length;t++)
        {
             document.getElementById('libox').options[t].selected=false;
        }
        if(ds.Tables[0].Rows[0].PUBL_CODE !=null && ds.Tables[0].Rows[0].PUBL_CODE !="")
        {
            var edition=ds.Tables[0].Rows[0].PUBL_CODE;            
            var  len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<document.getElementById('libox').options.length; i++)
                {
                    if(document.getElementById('libox').options[i].value==len[a])
                    {
                         document.getElementById('libox').options[i].selected = true;
                    }
//                    else
//                    {
//                        document.getElementById('lstpublication').options[i].selected = false;
//                    }
                }
            }

        }
		document.getElementById('hiddensno').value = ds.Tables[0].Rows[0].ADD_COMM_ID;
		
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSave').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnsubmit').disabled=false;
	}
	
	return false;
}



function SlabSelect(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpcommon').value="0";
       document.getElementById('txtcommrate').value="";
        document.getElementById('hiddenchkst').value="0";
       
//       if(opener.document.getElementById('hiddensubmod').value==0)
//       {
//            document.getElementById('btnSave').disabled=true;
//       }

       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
     document.getElementById('hiddenchkst').value="1";
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(document.getElementById('hiddendelsau').value=="1")
	    {
          document.getElementById('btndelete').disabled= false;
        }

       if(id==str)
       {
	    if(document.getElementById(id).checked==true)
	    {
	        k=k+1;
	        code11=document.getElementById(str).value;
	        chkclick=document.getElementById(id);
	    
	        if(document.getElementById('hiddendelsau').value=="1")
	        {
	        document.getElementById('btndelete').disabled= false;
            }
	
	   }
	  }
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}

	executivecommslab.bindslab(retcode,compcode,userid,code11,SelectSlab_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
        document.getElementById('txtfrom').value="";
        document.getElementById('txtto').value="";
        document.getElementById('drpstatus').value="0";
        document.getElementById('txtcircularno').value="";
        return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnSave').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	
}



//function callback to fill the values to the controls
function SelectSlab_CallBack(response)
{
	var ds = response.value;

				
		//updatecommission = ds.Tables[0].Rows[0].stat_code;
		
		document.getElementById('txtcommrate').value=ds.Tables[0].Rows[0].COMM_RATE;
		document.getElementById('drpcommon').value=ds.Tables[0].Rows[0].COMM_ON;
		document.getElementById('txtfrom').value = ds.Tables[0].Rows[0].FROM_DAYS;
		document.getElementById('txtto').value = ds.Tables[0].Rows[0].TILL_DAYS;
		document.getElementById('hiddenenln').value = ds.Tables[0].Rows[0].ENLN;
		
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSave').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnSave').disabled=false;
	}
	
	return false;
}


function Selectcommstruc(ab)
{
    var id=ab;
    var i=document.getElementById("DataGrid2").rows.length -1;
	if(document.getElementById(id).checked==false)
    {
       document.getElementById(ab).checked=false;
//      // return false;
    }
    else
    {
	    for(j=0;j<i;j++)
	    {
		    var str="DataGrid12__ctl_CheckBox1"+j;
	        document.getElementById(str).checked=false;
            //document.getElementById(id).checked=true;
        }
        document.getElementById(id).checked=true;
    }
   // return false;   
}